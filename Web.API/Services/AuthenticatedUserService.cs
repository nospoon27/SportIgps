using Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Web.API.Services
{
    public class AuthenticatedUserService : IAuthenticatedUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuthenticatedUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            int userId;

            if (int.TryParse(_httpContextAccessor.HttpContext?.User?.FindFirstValue("uid"), out userId))
            {
                UserId = userId;
            }
            else UserId = null;
        }

        public int? UserId { get; }
    }
}
