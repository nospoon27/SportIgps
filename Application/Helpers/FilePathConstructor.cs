using Application.Interfaces.Services;
using Domain.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers
{
    public static class FilePathConstructor
    {
        public static string GetFolder(FilePathSettings _pathSettings, FilesFolder folder)
        {
            switch (folder)
            {
                case FilesFolder.ANY:
                    return Path.Combine(_pathSettings.RootPath, _pathSettings.Any);
                case FilesFolder.IMAGES:
                    return Path.Combine(_pathSettings.RootPath, _pathSettings.Images);
                case FilesFolder.DOCUMENTS:
                    return Path.Combine(_pathSettings.RootPath, _pathSettings.Documents);
                default:
                    throw new Exception("Папка не найдена.");
            }
        }

        public static string GetUrlFromRelativePath(string rootPath, string absolutePath) =>
            absolutePath.Replace(rootPath, "").Replace(@"\", "/");

        public static string GetUniqueFileName() =>
            Guid.NewGuid().ToString();
    }
}
