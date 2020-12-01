using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IUserService
    {
        /// <summary>
        /// Найти пользователя по номеру телефона и коду страны
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        Task<User> FindByPhoneNumber(CountryCode countryCode, string phoneNumber);

        /// <summary>
        /// Добавить пользователя
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <param name="checkForSamePhoneNumber">Проверить на наличие похожего телефона?</param>
        /// <returns></returns>
        Task AddNewUser(User user, bool checkForSamePhoneNumber = false);

        /// <summary>
        /// Поиск пользователя по id, возвращает пользователя с UserRoles=>Role, CountryCode
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<User> FindById(int id);

        Task<User> FindByIdWithRoleClaims(int id);

        Task AddRoleToUser(User user, string roleName);

        Task<Role> FindRoleByName(string roleName);
    }
}
