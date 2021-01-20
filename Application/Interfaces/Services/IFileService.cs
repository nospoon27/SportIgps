using Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IFileService
    {
        Task<FileEntity> GetFile(int id);
        Task<FileEntity> GetFile(string path);
        Task<IList<FileEntity>> GetAllFiles(Expression<Func<FileEntity, bool>> predicate = null);
        Task<IList<FileEntity>> SaveFilesAndReturn(IList<IFormFile> files);
        Task<FileEntity> SaveFileAndReturn(IFormFile file);
        Task<int> DeleteFile(int id);
    }
}
