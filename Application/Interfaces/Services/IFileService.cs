using Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IFileService
    {
        Task<FileEntity> GetFileEntity(int id);
        Task<FileEntity> GetFileEntity(string path);
        Task<IList<FileEntity>> GetAllFiles(Expression<Func<FileEntity, bool>> predicate = null);
        Task<IList<FileEntity>> SaveFilesAndReturn(IList<IFormFile> files, FilesFolder folder, string[] additionalPath = null);
        Task<FileEntity> SaveFileAndReturn(IFormFile file, FilesFolder folder, string[] additionalPath = null);
        Task<int> DeleteFile(int id);

        Task<FileInfo> SaveFile(Stream stream, string fileName);
        Task<byte[]> GetFile(string fileName);
        string ConstructURL(string partOfFilePath);
    }

    public enum FilesFolder
    {
        ANY = 0,
        IMAGES,
        DOCUMENTS
    }
}
