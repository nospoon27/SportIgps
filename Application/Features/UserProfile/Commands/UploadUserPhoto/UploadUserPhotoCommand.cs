using Application.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserProfile.Commands.UploadUserPhoto
{
    public class UploadUserPhotoCommand : IRequest<Response<UploadUserPhotoCommandResponse>>
    {
        public IFormFile File { get; set; }
    }
}
