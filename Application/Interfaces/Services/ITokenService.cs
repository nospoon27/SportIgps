using Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface ITokenService
    {
        /// <summary>
        /// Сгенерировать JWT
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        JwtSecurityToken GenerateJWToken(User user);

        /// <summary>
        /// Сгенерировать токен обновления
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <returns>Токен обновления</returns>
        RefreshToken GenerateRefreshToken(string ipAddress);

        /// <summary>
        /// Получить последний сгенерированный токен обновления
        /// </summary>
        /// <param name="userId">id пользователя</param>
        /// <returns>Строка токена</returns>
        Task<string> GetRefreshTokenAsync(int userId);

        /// <summary>
        /// Отозвать токен обновления
        /// </summary>
        /// <param name="token"></param>
        /// <param name="ipAddress"></param>
        /// <returns>Успешность выполнения</returns>
        Task<bool> RevokeRefreshToken(string token, string ipAddress);

        Task AddRefreshTokenToUser(User user, RefreshToken refreshToken);
    }
}
