using Application.Wrappers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.API.Controllers
{
    public class UsersController : BaseApiController
    {
        [HttpGet]
        public ActionResult Get()
        {
            return Ok();
        }
    }
}
