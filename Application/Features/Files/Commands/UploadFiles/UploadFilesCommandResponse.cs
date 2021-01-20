using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Files.Commands.UploadFiles
{
    public class UploadFilesCommandResponse
    {
        public int Id { get; set; }
        public int Size { get; set; }
        public string FileName { get; set; }
    }
}
