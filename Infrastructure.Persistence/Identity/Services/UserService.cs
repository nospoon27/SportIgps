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
            return await _unitOfWork
                .GetRepository<User>()
                .FindAsync(id);
        }

        public async Task<User> FindByIdWithRoleClaims(int id)
        {
            return await _unitOfWork
                .GetRepository<User>()
                .GetSingleOrDefaultAsync(
                predicate: x => x.Id == id,
                include: source => source.Include(u => u.Roles)
                .ThenInclude(r => r.RoleClaims));
        }
    }
}
