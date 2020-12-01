using Application.Exceptions;
using Application.Interfaces.Services;
using Application.Interfaces.UnitOfWork;
using Domain.Entities;
using Domain.Settings;
using Infrastructure.Persistence.Identity.Helpers;
using Microsoft.EntityFrameworkCore;
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
    public class TokenService : ITokenService
    {
        private readonly JWTSettings _jwtSettings;
        private readonly IUnitOfWork _unitOfWork;
        public TokenService(
            IOptions<JWTSettings> options,
            IUnitOfWork unitOfWork)
        {
            _jwtSettings = options.Value;
            _unitOfWork = unitOfWork;
        }

        public string GenerateJWToken(User user)
        {
            using RSA rsa = RSA.Create();
            rsa.ImportRSAPrivateKey(
                source: Convert.FromBase64String(_jwtSettings.PrivateKey),
                bytesRead: out int _);

            var signingCredentials = new SigningCredentials(
                key: new RsaSecurityKey(rsa),
                algorithm: SecurityAlgorithms.RsaSha256)
            {
                CryptoProviderFactory = new CryptoProviderFactory() { CacheSignatureProviders = false }
            };

            var roleClaims = user.UserRoles.Select(ur => new Claim(ClaimTypes.Role, ur.Role.Name)).ToArray();

            DateTime jwtDate = DateTime.Now;
            string ipAddress = IpHelper.GetIpAddress();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.MobilePhone, user.PhoneNumber),
                new Claim("code", user.CountryCodeId.ToString())
            }.Union(roleClaims);

            var jwt = new JwtSecurityTokenHandler()
                .WriteToken(new JwtSecurityToken(
                audience: "jwt",
                issuer: "jwt",
                claims: claims,
                notBefore: jwtDate,
                expires: jwtDate.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials
            ));
            return jwt;
        }

        public RefreshToken GenerateRefreshToken(string ipAddress)
        {
            using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            var randomBytes = new byte[64];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            return new RefreshToken
            {
                Token = Convert.ToBase64String(randomBytes),
                Expires = DateTime.Now.AddDays(7),
                Created = DateTime.Now,
                CreatedByIp = ipAddress,
            };
        }

        public async Task<string> GetRefreshTokenAsync(int userId)
        {
            var user = await _unitOfWork
                .GetRepository<User>()
                .GetAll()
                .Include(x => x.RefreshTokens)
                .SingleOrDefaultAsync(x => x.Id == userId);
            if (user == null) throw new ApiException("Пользователь не найден");

            var token = user.RefreshTokens
                .OrderByDescending(x => x.Created)
                .FirstOrDefault().Token;
            return token;
        }

        public async Task<bool> RevokeRefreshToken(string token, string ipAddress)
        {
            var refreshToken = await _unitOfWork
                .GetRepository<RefreshToken>()
                .GetSingleOrDefaultAsync(
                    predicate: x => x.Token == token,
                    disableTracking: false);

            if(refreshToken == null || !refreshToken.IsActive)
            {
                return false;
            }
            refreshToken.Revoked = DateTime.Now;
            refreshToken.RevokedByIp = ipAddress;

            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task AddRefreshTokenToUser(User user, RefreshToken refreshToken)
        {
            user.RefreshTokens.Add(refreshToken);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
