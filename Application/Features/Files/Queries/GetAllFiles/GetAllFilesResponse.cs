using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Files.Queries.GetAllFiles
{
    public class GetAllFilesResponse
    {
        public string Path { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public long Size { get; set; }
        public string FileType { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
