using Application.Interfaces.Services;
using Domain.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Shared.Helpers
{
    public static class FilePathConstructor
    {
        public static string GetFolder(FilePathSettings _pathSettings, FilesFolder folder)
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

        public static string GetUrlFromAbsolutePath(string rootPath, string absolutePath) =>
            absolutePath.Replace(rootPath, "").Replace(@"\", "/");
    }
}
