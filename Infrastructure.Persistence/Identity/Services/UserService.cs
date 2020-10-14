using Application.Exceptions;
using Application.Interfaces.Services;
using Application.Interfaces.UnitOfWork;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> FindByPhoneNumber(string phoneNumber)
        {
            if (phoneNumber == null) throw new ArgumentNullException("Номер не может быть null");

            var user = await _unitOfWork
                .GetRepository<User>()
                .GetSingleOrDefaultAsync(
                predicate: x => x.PhoneNumber == phoneNumber,
                include: source => source.Include(u => u.Roles),
                disableTracking: false);

            return user;
        }

        public async Task AddNewUser(User user, bool checkForSamePhoneNumber = false)
        {
            if (user == null) throw new ArgumentNullException("User не может быть null");
            if (checkForSamePhoneNumber)
            {
                var sameUser = await _unitOfWork
                    .GetRepository<User>()
                    .GetFirstOrDefaultAsync(predicate: x => x.PhoneNumber == user.PhoneNumber);
                if (sameUser != null) throw new ApiException($"Пользователь с номером {user.PhoneNumber} уже существует");
            }

            await _unitOfWork
                .GetRepository<User>()
                .InsertAsync(user);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<User> FindById(int id)
        {
            if (id == 0) throw new ArgumentException("id не может быть равен 0");
            return await _unitOfWork
                .GetRepository<User>()
                .FindAsync(id);
        }

        public async Task<User> FindByIdWithRoleClaims(int id)
        {
            if (id == 0) throw new ArgumentException("id не может быть равен 0");
            return await _unitOfWork
                .GetRepository<User>()
                .GetSingleOrDefaultAsync(
                predicate: x => x.Id == id,
                include: source => source.Include(u => u.Roles)
                .ThenInclude(r => r.RoleClaims));
        }

        public async Task AddRoleToUser(User user, string roleName)
        {
            if (user == null || roleName == null) throw new ArgumentNullException();

            var role = await FindRoleByName(roleName);
            if (role == null) throw new ApiException($"Не удалось присвоить роль. Роль {roleName} не найдена");

            var actualUser = await _unitOfWork.GetRepository<User>()
                .GetSingleOrDefaultAsync(
                predicate: x => x.Id == user.Id,
                include: source => source.Include(u => u.Roles));

            actualUser.Roles.Add(role);

            //await _unitOfWork.GetRepository<UserRole>()
            //    .InsertAsync(new UserRole(user.Id, role.Id));
        }

        public async Task<Role> FindRoleByName(string roleName)
        {
            if (roleName == null) throw new ArgumentNullException("roleName не может быть null");
            return await _unitOfWork.GetRepository<Role>()
                .GetSingleOrDefaultAsync(predicate: x => x.Name == roleName);
        }
    }
}
