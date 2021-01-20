using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Files.Commands.UploadFile
{
    public class UploadFileCommandResponse
    {
        public int Id { get; set; }
        public int Size { get; set; }
        public string FileName { get; set; }
    }
}
