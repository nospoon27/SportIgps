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
        private readonly IAuthenticatedUserService _authenticatedUserService;
        public AccountController(
            IAccountService accountService,
            IAuthenticatedUserService authenticatedUserService)
        {
            _accountService = accountService;
            _authenticatedUserService = authenticatedUserService;
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
        [AllowAnonymous]
        [HttpPost("refreshToken")]
        public async Task<ActionResult<Response<AuthenticationResponse>>> RefreshToken()
        {
            var cookieRefreshToken = Request.Cookies["refreshToken"];
            var ipAddress = GenerateIPAddress();
            
            var result = await _accountService.RefreshToken(cookieRefreshToken, ipAddress);
            if (result == null) throw new UnauthorizedException("Невалидный токен");
            setTokenCookie(result.Data.RefreshToken);
            return Ok(result);
        }

        /// <summary>
        /// Отозвать токен
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("revokeToken")]
        public async Task<ActionResult<Response<bool>>> RevokeToken([FromBody] RevokeTokenRequest request)
        {
            var refreshToken = request.Token ?? Request.Cookies["refreshToken"];
            
            if (string.IsNullOrEmpty(refreshToken)) throw new ApiException("Ошибка обновления доступа");
            var result = await _accountService.RevokeToken(refreshToken, GenerateIPAddress());
            Response.Cookies.Delete("refreshToken");

            return result.Data ? result : throw new NotFoundException("Токен не найден");
        }

        /// <summary>
        /// Получить данные пользователя
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("me")]
        public async Task<ActionResult> Me()
        {
            var userId = _authenticatedUserService.GetRequiredUserId();
            var response = await _accountService.AccountData(userId);
            return Ok(response);
        }

        [Authorize]
        [HttpGet("permissions")]
        public async Task<ActionResult<Response<IList<string>>>> GetPermissions()
        {
            var userId = _authenticatedUserService.UserId;
            var response = await _accountService.GetPermissions(userId.Value);
            return Ok(response);
        }

        [Authorize]
        [HttpPost("changePassword")]
        public async Task<ActionResult<Response<bool>>> ChangePassword([FromBody] ChangePasswordRequest request)
        {
            var userId = _authenticatedUserService.GetRequiredUserId();
            var response = await _accountService.ChangePassword(userId, request.CurrentPassword, request.NewPassword);

            return Ok(response);
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
