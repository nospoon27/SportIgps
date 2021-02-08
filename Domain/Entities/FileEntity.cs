using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class FileEntity : BaseEntity
    {
        public FileEntity()
        {
        }

        public FileEntity(long size, string fileType, string path)
        {
            Size = size;
            FileType = fileType;
            Path = path;
        }

        public string Url { get; set; }
        public string Path { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public long Size { get; set; }
        public string FileType { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
