using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Files.Commands
{
    public class UploadedFile
    {
        public int Id { get; set; }
        public int Size { get; set; }
        public string FileName { get; set; }
    }
}