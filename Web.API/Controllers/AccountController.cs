using Application.DTOs.Account;
using Application.Exceptions;
using Application.Interfaces.Services;
using Application.Wrappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.API.Filters;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : WithVersionBaseApiController
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        /// <summary>
        /// Аутентификация
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("authenticate")]
        public async Task<ActionResult<Response<AuthenticationResponse>>> Authenticate(AuthenticationRequest request)
        {
            var result = await _accountService.AuthenticateAsync(request, GenerateIPAddress());
            setTokenCookie(result.Data.RefreshToken);
            return Ok(result);
        }

        /// <summary>
        /// Регистрация
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<ActionResult<Response<string>>> RegisterAsync(RegisterRequest request)
        {
            var origin = Request.Headers["origin"];
            return Ok(await _accountService.RegisterAsync(request, origin));
        }

        /// <summary>
        /// Обновление токена
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpPost("refreshToken")]
        public async Task<ActionResult<Response<AuthenticationResponse>>> RefreshToken()
        {
            var cookieRefreshToken = Request.Cookies["refreshToken"];
            var ipAddress = GenerateIPAddress();
            var result = await _accountService.RefreshToken(cookieRefreshToken, ipAddress);
            if (result == null) return Unauthorized("Невалидный токен");
            setTokenCookie(result.Data.RefreshToken);
            return Ok(result);
        }

        /// <summary>
        /// Отозвать токен
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("revokeToken")]
        public async Task<ActionResult> RevokeToken([FromBody] RevokeTokenRequest request)
        {
            var refreshToken = request.Token ?? Request.Cookies["refreshToken"];
            if (string.IsNullOrEmpty(refreshToken)) return BadRequest();

            var result = await _accountService.RevokeToken(refreshToken, GenerateIPAddress());

            return result ? (ActionResult) Ok() : NotFound();
        }

        private void setTokenCookie(string token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7)
            };
            Response.Cookies.Append("refreshToken", token, cookieOptions);
        }

        private string GenerateIPAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
    }
}
