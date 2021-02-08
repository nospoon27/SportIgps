using Application.Features.UserProfile.Commands.DeleteUserPhoto;
using Application.Features.UserProfile.Commands.UploadUserPhoto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.API.Controllers
{
    public class UserProfileController : BaseApiController
    {
        [HttpPost("userPhoto")]
        public async Task<ActionResult> UploadUserPhoto([FromForm] UploadUserPhotoCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("userPhoto")]
        public async Task<ActionResult> DeleteUserPhoto()
        {
            return Ok(await Mediator.Send(new DeleteUserPhotoCommand()));
        }
    }
}
