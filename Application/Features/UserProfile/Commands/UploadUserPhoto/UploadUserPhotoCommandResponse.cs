using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserProfile.Commands.UploadUserPhoto
{
    public class UploadUserPhotoCommandResponse
    {
        public string DefaultUrl { get; set; }
        public string SmallUrl { get; set; }
    }
}
