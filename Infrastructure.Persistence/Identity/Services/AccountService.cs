using Application.DTOs.Account;
using Application.Exceptions;
using Application.Interfaces.Services;
using Application.Interfaces.UnitOfWork;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using Domain.Settings;
using Infrastructure.Persistence.Identity.Helpers;
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
        public AccountService(
            IOptions<JWTSettings> jwtSetting,
            IUserService userService,
            ILogger<AccountService> logger,
            IPasswordHashService passwordHashService,
            ITokenService tokenService,
            IMapper mapper,
            ICountryCodeService countryCodeService)
        {
            _jwtSettings = jwtSetting.Value;
            _userService = userService;
            _logger = logger;
            _passwordHashService = passwordHashService;
            _tokenService = tokenService;
            _mapper = mapper;
            _countryCodeService = countryCodeService;
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
                new JwtSecurityTokenHandler().WriteToken(jwt),
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

            await _userService.AddNewUser(user, true);

            var clientRole = await _userService.FindRoleByName("client");

            await _userService.AddRoleToUser(user, clientRole.Name);

            return new Response<string>(user.Id.ToString(), $"Пользователь зарегистрирован");
        }

    }
}
