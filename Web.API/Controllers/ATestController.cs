using Application.Exceptions;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.API.Controllers
{
    public class ATestController : BaseApiController
    {
        private readonly ILogger<ATestController> logger;
        private readonly IAuthenticatedUserService auth;

        public ATestController(
            ILogger<ATestController> logger,
            IAuthenticatedUserService auth)
        {
            this.logger = logger;
            this.auth = auth;
        }

        [HttpGet("/test")]
        public ActionResult<object> Test()
        {
            logger.LogInformation(Guid.NewGuid().ToString());
            logger.LogWarning(Guid.NewGuid().ToString());
            logger.LogDebug(Guid.NewGuid().ToString());
            logger.LogError(Guid.NewGuid().ToString());

            return Ok(auth.UserId);
        }
    }
}
