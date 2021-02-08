using Application.Helpers;
using Application.Interfaces.Services;
using Application.Interfaces.UnitOfWork;
using Application.Wrappers;
using Domain.Entities;
using Domain.Settings;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp.Formats.Jpeg;

namespace Application.Features.UserProfile.Commands.UploadUserPhoto
{
    public class UploadUserPhotoCommandHandler : IRequestHandler<UploadUserPhotoCommand, Response<UploadUserPhotoCommandResponse>>
    {
        private readonly IFileService _fileService;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _env;
        private readonly FilePathSettings _pathSettings;
        public UploadUserPhotoCommandHandler(
            IFileService fileService,
            IAuthenticatedUserService authenticatedUserService,
            IUnitOfWork unitOfWork,
            IWebHostEnvironment env,
            IOptions<FilePathSettings> options)
        {
            _fileService = fileService;
            _authenticatedUserService = authenticatedUserService;
            _unitOfWork = unitOfWork;
            _env = env;
            _pathSettings = options.Value;
        }

        public async Task<Response<UploadUserPhotoCommandResponse>> Handle(UploadUserPhotoCommand request, CancellationToken cancellationToken)
        {
            int currentUserId = _authenticatedUserService.GetRequiredUserId();
            UserPhoto currentUserPhoto = await _unitOfWork.GetRepository<UserPhoto>()
                .GetSingleOrDefaultAsync(
                predicate: x => x.UserId == currentUserId);

            string folderPath = FilePathConstructor.GetFolder(_pathSettings, FilesFolder.IMAGES);
            string defaultPhotoPath = Path.Combine(_env.WebRootPath, folderPath, $"{FilePathConstructor.GetUniqueFileName()}.jpg");
            string smallPhotoPath = Path.Combine(_env.WebRootPath, folderPath, $"{FilePathConstructor.GetUniqueFileName()}.jpg");

            //await SaveSmallPhoto(request.File, smallPhotoPath);
            //await SaveDefaultPhoto(request.File, defaultPhotoPath);

            string defaultPhotoUrl = FilePathConstructor.GetUrlFromRelativePath(_env.WebRootPath, defaultPhotoPath);
            string smallPhotoUrl = FilePathConstructor.GetUrlFromRelativePath(_env.WebRootPath, smallPhotoPath);

            string defaultPhotoAbsoluteUrl = _fileService.ConstructURL(defaultPhotoUrl);
            string smallPhotoAbsoluteUrl = _fileService.ConstructURL(smallPhotoUrl);

            using(var stream = request.File.OpenReadStream())
            {
                using var image = await Image.LoadAsync(stream);
                var encoder = new JpegEncoder { Quality = 75 };
                if(image.Width > 250)
                {
                    var cloneForResize = image.Clone(x => x.Resize(250, 250));
                    await cloneForResize.SaveAsJpegAsync(smallPhotoPath, encoder);
                } else
                {
                    await image.SaveAsJpegAsync(smallPhotoPath, encoder);
                }
                await image.SaveAsJpegAsync(defaultPhotoPath, encoder);
            }

            if (currentUserPhoto == null)
            {
                await _unitOfWork.GetRepository<UserPhoto>().InsertAsync(
                    new UserPhoto(currentUserId, defaultPhotoAbsoluteUrl, smallPhotoAbsoluteUrl, defaultPhotoPath, smallPhotoPath));
            }
            else
            {
                DeleteFile(currentUserPhoto.DefaultPath);
                DeleteFile(currentUserPhoto.SmallPath);
                currentUserPhoto.ChangeUrls(defaultPhotoAbsoluteUrl, smallPhotoAbsoluteUrl, defaultPhotoPath, smallPhotoPath);
                _unitOfWork.GetRepository<UserPhoto>().Update(currentUserPhoto);
            }

            await _unitOfWork.SaveChangesAsync();

            UploadUserPhotoCommandResponse response = new UploadUserPhotoCommandResponse
            {
                DefaultUrl = defaultPhotoAbsoluteUrl,
                SmallUrl = defaultPhotoAbsoluteUrl
            };

            return new Response<UploadUserPhotoCommandResponse>(response);
        }

        private void DeleteFile(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
