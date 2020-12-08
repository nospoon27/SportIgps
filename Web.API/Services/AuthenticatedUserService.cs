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

            if (int.TryParse(_httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier), out userId))
            {
                UserId = userId;
            }
            else UserId = null;

            if (_httpContextAccessor.HttpContext != null)
            {
                RemoteIp = _httpContextAccessor.HttpContext.Request.Headers.ContainsKey("X-Forwarded-For")
                        ? _httpContextAccessor.HttpContext.Request.Headers["X-Forwarded-For"].ToString()
                        : _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString(); 
            }
        }

        public int? UserId { get; }
        public string RemoteIp { get; }
    }
}
