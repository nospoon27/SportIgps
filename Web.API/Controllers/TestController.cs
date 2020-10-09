using Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.API.Controllers
{
    public class TestController : BaseApiController
    {
        [HttpGet("/test")]
        public ActionResult<object> Test()
        {
            return Ok();
        }
    }
}
