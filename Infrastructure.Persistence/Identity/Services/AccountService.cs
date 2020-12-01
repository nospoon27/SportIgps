using Application.CustomTypes;
using Application.DTOs.Account;
using Application.Exceptions;
using Application.Interfaces.Services;
using Application.Interfaces.UnitOfWork;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using Domain.Settings;
using Infrastructure.Persistence.Identity.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Identity.Services
{
    public class AccountService : IAccountService
    {
        private readonly JWTSettings _jwtSettings;
        private readonly IUserService _userService;
        private readonly ILogger<AccountService> _logger;
        private readonly IPasswordHashService _passwordHashService;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly ICountryCodeService _countryCodeService;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IUnitOfWork _unitOfWork;
        public AccountService(
            IOptions<JWTSettings> jwtSetting,
            IUserService userService,
            ILogger<AccountService> logger,
            IPasswordHashService passwordHashService,
            ITokenService tokenService,
            IMapper mapper,
            ICountryCodeService countryCodeService,
            IAuthenticatedUserService authenticatedUserService,
            IUnitOfWork unitOfWork)
        {
            _jwtSettings = jwtSetting.Value;
            _userService = userService;
            _logger = logger;
            _passwordHashService = passwordHashService;
            _tokenService = tokenService;
            _mapper = mapper;
            _countryCodeService = countryCodeService;
            _authenticatedUserService = authenticatedUserService;
            _unitOfWork = unitOfWork;
        }
        public async Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request, string ipAddress)
        {
            var countryCode = await _countryCodeService.GetById(request.CountryCodeId);

            var user = await _userService.FindByPhoneNumber(countryCode, request.PhoneNumber);
            if (user == null || !_passwordHashService.VerifyHashedPassword(user.Password, request.Password))
            {
                _logger.LogInformation($"{nameof(AuthenticateAsync)}, не найден пользователь с номером {request.PhoneNumber}");
                throw new ApiException($"Вы ввели неправильный пароль или логин");
            }

            var jwt = _tokenService.GenerateJWToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken(ipAddress);

            await _tokenService.AddRefreshTokenToUser(user, refreshToken);

            AuthenticationResponse response = new AuthenticationResponse(
                user,
                jwt,
                refreshToken.Token);
            return new Response<AuthenticationResponse>(response, $"Authenticated {user.PhoneNumber} ({user.LastName} {user.FirstName} {user.MiddleName})");
        }

        public async Task<Response<string>> RegisterAsync(RegisterRequest request, string origin)
        {
            var countryCode = await _countryCodeService.GetById(request.CountryCodeId);
            //var userWithSameUserName = await _userService.FindByPhoneNumber(countryCode, request.PhoneNumber);
            //if (userWithSameUserName != null)
            //{
            //    _logger.LogInformation($"{nameof(RegisterAsync)}, пользователь {request.PhoneNumber} уже существует");
            //    throw new ApiException($"Пользователь с таким номером телефона уже существует");
            //}

            var user = _mapper.Map<User>(request);
            //var user = new User()
            //{
            //    FirstName = request.FirstName,
            //    LastName = request.LastName,
            //    PhoneNumber = request.PhoneNumber,
            //    Password = request.Password
            //};
            user.CountryCodeId = countryCode.Id;
            user.Gender = user.Gender;

            // Добавляем пользователя
            await _userService.AddNewUser(user, true);
            await _unitOfWork.SaveChangesAsync();

            // Добавляем роль пользователю
            var clientRole = await _userService.FindRoleByName("client");
            await _userService.AddRoleToUser(user, clientRole.Name);
            await _unitOfWork.SaveChangesAsync();

            return new Response<string>(user.Id.ToString(), $"Пользователь зарегистрирован");
        }

        public async Task<Response<AuthenticationResponse>> RefreshToken(string cookieRefreshToken, string ipAddress)
        {
            var userId = _authenticatedUserService.UserId;

            var token = cookieRefreshToken ?? await _tokenService.GetRefreshTokenAsync(userId.Value);
            var user = await _unitOfWork.GetRepository<User>()
                .GetSingleOrDefaultAsync(
                predicate: x => x.RefreshTokens.Any(x => x.Token == token),
                include: source => source.Include(t => t.RefreshTokens).Include(r => r.UserRoles).ThenInclude(x => x.Role),
                disableTracking: false);

            var actualToken = user.RefreshTokens.SingleOrDefault(x => x.Token == token);
            if (actualToken == null || !actualToken.IsActive) return null;

            var newToken = _tokenService.GenerateRefreshToken(ipAddress);
            actualToken.Revoked = DateTime.Now;
            actualToken.RevokedByIp = ipAddress;
            actualToken.ReplacedByToken = newToken.Token;

            user.RefreshTokens.Add(newToken);
            await _unitOfWork.SaveChangesAsync();

            var jwt = _tokenService.GenerateJWToken(user);

            return new Response<AuthenticationResponse>(
                new AuthenticationResponse(
                    user, 
                    jwt, 
                    newToken.Token));
        }

        public async Task<Response<bool>> RevokeToken(string token, string ipAddress)
        {
            var refreshToken = await _unitOfWork.GetRepository<Domain.Entities.RefreshToken>()
                .GetSingleOrDefaultAsync(
                predicate: x => x.Token == token, 
                disableTracking: false);

            if (refreshToken == null || !refreshToken.IsActive)
            {
                new Response<bool>(false);
            }

            refreshToken.Revoked = DateTime.Now;
            refreshToken.RevokedByIp = ipAddress;
            await _unitOfWork.SaveChangesAsync();

            return new Response<bool>(true);
        }

        public async Task<Response<MeResponse>> AccountData(int userId)
        {
            var user = await _userService.FindById(userId);

            if (user == null) throw new NotFoundException("Пользователь не найден");

            var response = new MeResponse(user);

            return new Response<MeResponse>(response);            
        }

        public async Task<Response<IList<string>>> GetPermissions(int userId)
        {
            var user = await _unitOfWork.GetRepository<User>()
                .GetFirstOrDefaultAsync(
                predicate: x => x.Id == userId,
                include: source => source
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .ThenInclude(r => r.RoleClaims));

            var permissions = user.UserRoles
                .SelectMany(ur => ur.Role.RoleClaims?.Where(rc => rc.ClaimType == CustomClaimTypes.Permission)
                .Select(rc => rc.ClaimValue));

            return new Response<IList<string>>(permissions.ToList());
        }
    }
}
