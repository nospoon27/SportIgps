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
        private IWebHostEnvironment _env;
        private PathSettings _pathSettings;
        public FileService(
            IUnitOfWork unitOfWork,
            IWebHostEnvironment env,
            IOptions<PathSettings> options)
        {
            _unitOfWork = unitOfWork;
            _env = env;
            _pathSettings = options.Value;
        }

        public async Task<IList<FileEntity>> GetAllFiles(Expression<Func<FileEntity, bool>> predicate = null)
        {
            return await _unitOfWork.GetRepository<FileEntity>()
                .GetAllAsync(predicate);
        }

        public async Task<FileEntity> GetFile(int id)
        {
            return await _unitOfWork.GetRepository<FileEntity>()
                .FindAsync(id);
        }

        public async Task<FileEntity> GetFile(string path)
        {
            return await _unitOfWork.GetRepository<FileEntity>()
                .GetSingleOrDefaultAsync(predicate: x => x.Path == path);
        }

        public async Task<FileEntity> SaveFileAndReturn(IFormFile file)
        {
            return await SaveFile(file);
        }

        public async Task<IList<FileEntity>> SaveFilesAndReturn(IList<IFormFile> files)
        {
            var savedFiles = new List<FileEntity>();
            foreach (var file in files)
            {
                if (file != null)
                {
                    savedFiles.Add(await SaveFile(file));
                }
            }

            return savedFiles;
        }

        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                + "__"
                + Guid.NewGuid().ToString().Substring(0, 6)
                + Path.GetExtension(fileName);
        }

        private async Task<FileEntity> SaveFile(IFormFile file)
        {
            var savedInDirFile = await SaveFileToDirectory(file);
            return await SaveFileToDataBase(savedInDirFile);
        }

        private async Task<FileEntity> SaveFileToDataBase(FileEntity file)
        {
            //var fileSavePath = Path.Combine(_env.WebRootPath, _pathSettings.FilesPath, GetUniqueFileName(file.FileName));
            //await file.CopyToAsync(new FileStream(fileSavePath, FileMode.Create));
            var savedFile = await _unitOfWork.GetRepository<FileEntity>()
                .InsertAsync(file);
            await _unitOfWork.SaveChangesAsync();
            return savedFile.Entity;
        }

        private async Task<FileEntity> SaveFileToDirectory(IFormFile file)
        {
            var fileSavePath = Path.Combine(_env.WebRootPath, _pathSettings.FilesPath, GetUniqueFileName(file.FileName));
            await file.CopyToAsync(new FileStream(fileSavePath, FileMode.Create));
            return new FileEntity(file.Length, Path.GetExtension(file.FileName), fileSavePath);
        }

        public async Task<int> DeleteFile(int id)
        {
            var file = await _unitOfWork.GetRepository<FileEntity>().FindAsync(id);
            if (file == null) throw new NotFoundException("Файл не найден");
            _unitOfWork.GetRepository<FileEntity>().Delete(file);
            await _unitOfWork.SaveChangesAsync();

            return id;
        }
    }
}
