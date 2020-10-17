using Application.Interfaces.Services;
using Application.Interfaces.UnitOfWork;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations.Seeds
{
    public static class DbInitializer
    {
        public static async Task InitializeData(this IServiceScope scope)
        {
            var unitOfWork = scope.ServiceProvider.GetService<IUnitOfWork>();
            var passwordHashService = scope.ServiceProvider.GetService<IPasswordHashService>();
            await AddAbonementAgeCategory(unitOfWork);
            await AddAbonementLimitType(unitOfWork);
            await AddAccessCardType(unitOfWork);
            await AddCountryCode(unitOfWork);
            await AddGender(unitOfWork);
            await AddRole(unitOfWork);
            await AddUser(unitOfWork, passwordHashService);
            await AddUserRole(unitOfWork);
        }

        private static async Task AddAbonementAgeCategory(IUnitOfWork unitOfWork)
        {
            var count = await unitOfWork.GetRepository<AbonementAgeCategory>().CountAsync();
            if (count == 0)
            {
                await unitOfWork.GetRepository<AbonementAgeCategory>()
                .InsertAsync(new List<AbonementAgeCategory>()
                {
                    new AbonementAgeCategory { Name = "Взрослый" },
                    new AbonementAgeCategory { Name = "Детский" }
                });
            }
            await unitOfWork.SaveChangesAsync();
        }

        private static async Task AddAbonementLimitType(IUnitOfWork unitOfWork)
        {
            var count = await unitOfWork.GetRepository<AbonementLimitType>().CountAsync();
            if (count == 0)
            {
                await unitOfWork.GetRepository<AbonementLimitType>()
                    .InsertAsync(new List<AbonementLimitType>()
                    {
                        new AbonementLimitType { Name = "Ограниченный" },
                        new AbonementLimitType { Name = "Безлимитный" }
                    });
            }
            await unitOfWork.SaveChangesAsync();
        }

        private static async Task AddAccessCardType(IUnitOfWork unitOfWork)
        {
            var count = await unitOfWork.GetRepository<AccessCardType>().CountAsync();
            if (count == 0)
            {
                await unitOfWork.GetRepository<AccessCardType>()
                    .InsertAsync(new List<AccessCardType>()
                    {
                        new AccessCardType { Name = "Ограниченный" },
                        new AccessCardType { Name = "Свободный" }
                    });
            }
            await unitOfWork.SaveChangesAsync();
        }

        private static async Task AddCountryCode(IUnitOfWork unitOfWork)
        {
            var count = await unitOfWork.GetRepository<CountryCode>().CountAsync();
            if(count == 0)
            {
                await unitOfWork.GetRepository<CountryCode>()
                    .InsertAsync(new List<CountryCode>()
                    {
                        new CountryCode { Code = "+7", ISOName = "RUS" },
                        new CountryCode { Code = "+380", ISOName = "UKR" },
                        new CountryCode { Code = "+374", ISOName = "ARM" },
                        new CountryCode { Code = "+994", ISOName = "AZE" },
                        new CountryCode { Code = "+375", ISOName = "BLR" },
                        new CountryCode { Code = "+359", ISOName = "BGR" },
                        new CountryCode { Code = "+7", ISOName = "KAZ" },
                        new CountryCode { Code = "+996", ISOName = "KGZ" },
                        new CountryCode { Code = "+381", ISOName = "SRB" },
                        new CountryCode { Code = "+82", ISOName = "KOR" },
                    });
            }
            await unitOfWork.SaveChangesAsync();
        }

        private static async Task AddGender (IUnitOfWork unitOfWork)
        {
            var count = await unitOfWork.GetRepository<Gender>().CountAsync();
            if(count == 0)
            {
                await unitOfWork.GetRepository<Gender>()
                    .InsertAsync(new Gender[]
                    {
                        new Gender { Name = "Мужской" },
                        new Gender { Name = "Женский" }
                    });
            }
            await unitOfWork.SaveChangesAsync();
        }

        private static async Task AddRole (IUnitOfWork unitOfWork)
        {
            var count = await unitOfWork.GetRepository<Role>().CountAsync();
            if(count == 0)
            {
                await unitOfWork.GetRepository<Role>()
                    .InsertAsync(new Role[]
                    {
                        new Role { Name = "admin" },
                        new Role { Name = "manager" },
                        new Role { Name = "trainer" },
                        new Role { Name = "client" }
                    });
            }
            await unitOfWork.SaveChangesAsync();
        }

        private static async Task AddUser (IUnitOfWork unitOfWork, IPasswordHashService passwordHashService)
        {
            var count = await unitOfWork.GetRepository<User>().CountAsync();
            if(count == 0)
            {
                var genders = await unitOfWork.GetRepository<Gender>().GetAllAsync();
                var gender = await unitOfWork.GetRepository<Gender>().GetSingleOrDefaultAsync(predicate: x => x.Name.ToLower() == "мужской");
                var countyCode = await unitOfWork.GetRepository<CountryCode>().GetSingleOrDefaultAsync(predicate: x => x.ISOName == "RUS");
                await unitOfWork.GetRepository<User>()
                    .InsertAsync(new User[]
                    {
                        new User
                        {
                            Id = 1,
                            FirstName = "Дим",
                            LastName = "Зиннатов",
                            MiddleName = "Вилданович",
                            PhoneNumber = "9500280027",
                            DateOfBirth = new DateTime(1998, 1, 29),
                            GenderId = gender.Id,
                            CountryCodeId = countyCode.Id,
                            Password = passwordHashService.HashPassword("secret")
                        }
                    });
            }
            await unitOfWork.SaveChangesAsync();
        }

        private static async Task AddUserRole (IUnitOfWork unitOfWork)
        {
            var count = await unitOfWork.GetRepository<UserRole>().CountAsync();
            if(count == 0)
            {
                var adminRole = await unitOfWork.GetRepository<Role>().GetSingleOrDefaultAsync(predicate: x => x.Name == "admin");
                var adminUser = await unitOfWork.GetRepository<User>().GetSingleOrDefaultAsync(predicate: x => x.PhoneNumber == "9500280027");
                await unitOfWork.GetRepository<UserRole>()
                    .InsertAsync(new UserRole[]
                    {
                        new UserRole { RoleId = adminRole.Id, UserId = adminUser.Id }
                    });
            }
            await unitOfWork.SaveChangesAsync();
        }
    }
}
