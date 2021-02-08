using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Application.Exceptions;
using Application.Interfaces.Services;
using Application.Interfaces.UnitOfWork;
using Domain.Entities;
using Domain.Settings;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Infrastructure.Shared.Services
{
    public class FileService : IFileService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _env;
        private readonly FilePathSettings _pathSettings;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public FileService(
            IUnitOfWork unitOfWork,
            IWebHostEnvironment env,
            IOptions<FilePathSettings> options,
            IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _env = env;
            _pathSettings = options.Value;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IList<FileEntity>> GetAllFiles(Expression<Func<FileEntity, bool>> predicate = null)
        {
            return await _unitOfWork.GetRepository<FileEntity>()
                .GetAllAsync(predicate);
        }

        public async Task<FileEntity> GetFileEntity(int id)
        {
            return await _unitOfWork.GetRepository<FileEntity>()
                .FindAsync(id);
        }

        public async Task<FileEntity> GetFileEntity(string path)
        {
            return await _unitOfWork.GetRepository<FileEntity>()
                .GetSingleOrDefaultAsync(predicate: x => x.Path == path);
        }

        public async Task<FileEntity> SaveFileAndReturn(IFormFile file, FilesFolder folder, string[] additionalPath = null)
        {
            return await SaveFile(file, folder, additionalPath);
        }

        public async Task<IList<FileEntity>> SaveFilesAndReturn(IList<IFormFile> files, FilesFolder folder, string[] additionalPath = null)
        {
            var savedFiles = new List<FileEntity>();
            foreach (var file in files)
            {
                if (file != null)
                {
                    savedFiles.Add(await SaveFile(file, folder, additionalPath));
                }
            }

            return savedFiles;
        }

        public async Task<int> DeleteFile(int id)
        {
            var file = await _unitOfWork.GetRepository<FileEntity>().FindAsync(id);
            if (file == null) throw new NotFoundException("Файл не найден");
            _unitOfWork.GetRepository<FileEntity>().Delete(file);
            await _unitOfWork.SaveChangesAsync();

            return id;
        }

        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Guid.NewGuid().ToString()
                + Path.GetExtension(fileName);
        }

        private async Task<FileEntity> SaveFile(IFormFile file, FilesFolder folder, string[] additionalPath = null)
        {
            var savedInDirFile = await SaveFileToDirectory(file, folder, additionalPath);
            return await SaveFileToDataBase(savedInDirFile);
        }

        private async Task<FileEntity> SaveFileToDataBase(FileEntity file)
        {
            var savedFile = await _unitOfWork.GetRepository<FileEntity>()
                .InsertAsync(file);
            await _unitOfWork.SaveChangesAsync();
            return savedFile.Entity;
        }

        private async Task<FileEntity> SaveFileToDirectory(IFormFile file, FilesFolder folder, string[] additionalPath = null)
        {
            var pathParts = new List<string>
            {
                _env.WebRootPath, _pathSettings.RootPath, GetFileFolder(folder),
            };
            if (additionalPath != null) pathParts.AddRange(additionalPath);
            pathParts.Add(GetUniqueFileName(file.FileName));

            var fileSavePath = Path.Combine(pathParts.ToArray());

            await file.CopyToAsync(new FileStream(fileSavePath, FileMode.Create));
            return new FileEntity(file.Length, Path.GetExtension(file.FileName), fileSavePath);
        }

        private string GetFileFolder(FilesFolder folder)
        {
            switch (folder)
            {
                case FilesFolder.ANY:
                    return _pathSettings.Any;
                case FilesFolder.IMAGES:
                    return _pathSettings.Images;
                case FilesFolder.DOCUMENTS:
                    return _pathSettings.Documents;
                default:
                    throw new Exception("Папка не найдена.");
            }
        }

        public async Task<FileInfo> SaveFile(Stream stream, string fileName)
        {
            await stream.CopyToAsync(new FileStream(fileName, FileMode.Create));
            
            return new FileInfo(fileName);
        }

        public async Task<byte[]> GetFile(string fileName)
        {
            return await File.ReadAllBytesAsync(fileName);
        }

        public string ConstructURL(string partOfFilePath)
        {
            var currentContext = _httpContextAccessor.HttpContext;
            var result = $"{currentContext.Request.Scheme}://{currentContext.Request.Host}{currentContext.Request.PathBase}{partOfFilePath}".TrimEnd('/');
            return result;
        }
    }
}
