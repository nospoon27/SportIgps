using Application.CustomTypes;
using Application.Exceptions;
using Application.Interfaces.Services;
using Application.Interfaces.UnitOfWork;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Persistence.Identity.Services;
using Infrastructure.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Tests
{
    public class UserServiceTests
    {
        private readonly InMemoryContext db;
        protected UserService userService { get; }
        protected List<User> users { get; } = TestEntities.TestUsers();
        protected IUnitOfWork<InMemoryContext> unitOfWork { get; }
        protected Mock<IRepository<User>> userRepositoryMock { get; }
        public UserServiceTests()
        {
            db = new InMemoryContext();
            if (!db.Roles.Any())
            {
                db.AddRange(TestEntities.TestRoles());
                db.SaveChanges();
            }
            if (!db.Users.Any())
            {
                db.AddRange(users);
                db.Add(new User
                {
                    Id = 5,
                    Roles = db.Roles.ToList()
                });
                db.Add(new User
                {
                    Id = 6,
                    Roles = db.Roles.Where(x => x.Id == (int)RoleId.client).ToList()
                });
                db.SaveChanges();
            }
            if (!db.RoleClaims.Any())
            {
                db.RoleClaims.Add(new RoleClaim
                {
                    Id = 1,
                    ClaimType = CustomClaimTypes.Permission,
                    ClaimValue = "read",
                    Role = db.Roles.Single(x => x.Id == 1)
                });
                db.RoleClaims.Add(new RoleClaim
                {
                    Id = 2,
                    ClaimType = CustomClaimTypes.Permission,
                    ClaimValue = "create",
                    Role = db.Roles.Single(x => x.Id == 1)
                });
                db.SaveChanges();
            }
            
            unitOfWork = new UnitOfWork<InMemoryContext>(db);
            userRepositoryMock = new Mock<IRepository<User>>();
            userService = new UserService(unitOfWork);
        }
        public class FindByPhoneNumber : UserServiceTests
        {
            [TestCase("9119407574")]
            [TestCase("9998887766")]
            [Test(Description = "Find user by phone number. Expected result - user")]
            public async Task Should_return_user(string input)
            {
                var result = await userService.FindByPhoneNumber(input);

                var actual = users.SingleOrDefault(x => x.PhoneNumber == input);

                Assert.True(result.PhoneNumber == input);
                Assert.True(result.PhoneNumber == actual.PhoneNumber);
            }

            [Test(Description = "Find user by phone number. Should throw an ArgumentNullException")]
            public void Should_throw_ArgumentNullException_when_put_null_phoneNumber()
            {
                var ex = Assert.ThrowsAsync<ArgumentNullException>(() => userService.FindByPhoneNumber(null));
            }
        }

        public class AddNewUser : UserServiceTests
        {
            [Test(Description = "Add user. Should succes find added user")]
            public async Task Should_success_adding_user()
            {
                var addingUser = new User() { PhoneNumber = "1112223344", Id = 100 };
                await userService.AddNewUser(addingUser, false);

                var addedUser = db.Users.Find(100);
                Assert.IsNotNull(addedUser);
            }

            [TestCase(101)]
            [Test(Description = "Add user with not unique PhoneNumber. Should throw an ApiException")]
            public void Should_throw_apiException_when_adding_user(int id)
            {
                var sameUser = db.Users.First();
                var addingUser = new User() { PhoneNumber = sameUser.PhoneNumber, Id = id };
                var ex = Assert.ThrowsAsync<ApiException>(() => userService.AddNewUser(addingUser, true));
                
                var user = db.Users.Find(id);
                Assert.IsNull(user);
            }

            [Test(Description = "Add user with null argument. Should throw an ArgumentNullException")]
            public void Should_throw_argumentNullException_when_put_null_argument()
            {
                var ex = Assert.ThrowsAsync <ArgumentNullException>(() => userService.AddNewUser(null, false));
            }
        }

        public class FindById : UserServiceTests
        {
            [TestCase(1)]
            [TestCase(2)]
            [Test(Description = "Find user by id. Should return user")]
            public async Task Should_return_user(int id)
            {
                var result = await userService.FindById(id);

                var actual = users.Single(x => x.Id == id);

                Assert.True(result.Id == id);
                Assert.True(result.Id == actual.Id);
            }

            [Test(Description = "Find user by id. Should throw an ArgumentException")]
            public void Should_throw_ArgumentException_when_put_id_equals_zero ()
            {
                var ex = Assert.ThrowsAsync<ArgumentException>(() => userService.FindById(0));
            }
        }

        public class FindByIdWithRoleClaims : UserServiceTests
        {
            [Test]
            [TestCase(5)]
            public async Task Should_return_user_with_roleClaims(int id)
            {
                var result = await userService.FindByIdWithRoleClaims(id);

                var actual = db.Users.Include(x => x.Roles)
                    .ThenInclude(x => x.RoleClaims).Single(x => x.Id == id);

                Assert.True(result.Id == actual.Id);
                Assert.True(result.Roles.Count == actual.Roles.Count);
                Assert.IsNotNull(result.Roles.SingleOrDefault(x => x.Name == RoleId.admin.ToString()));
                int resultRoleClaimsCount = result.Roles.SingleOrDefault(x => x.Name == RoleId.admin.ToString()).RoleClaims.Count;
                int actualRoleClaimsCount = actual.Roles.SingleOrDefault(x => x.Name == RoleId.admin.ToString()).RoleClaims.Count;
                Assert.True(resultRoleClaimsCount == actualRoleClaimsCount);
            }

            [Test]
            public void Should_return_ArgumentException_when_put_id_equal_zero()
            {
                var ex = Assert.ThrowsAsync<ArgumentException>(() => userService.FindByIdWithRoleClaims(0));
            }
        }

        public class AddRoleToUser : UserServiceTests
        {
            [Test]
            public async Task Should_add_role_to_user()
            {
                var user = db.Users.Find(1);
                var roleName = RoleId.admin.ToString();
                await userService.AddRoleToUser(user, roleName);

                var rr = db.UserRoles.ToList();
                var actual = db.Users.Include(x => x.Roles).FirstOrDefault(x => x.Id == 1);

                Assert.AreEqual(actual.Roles.Count, 1);
                Assert.IsNotNull(actual.Roles.SingleOrDefault(x => x.Name == roleName));
            }
        }

        public class FindRoleByName : UserServiceTests
        {
            [Test]
            [TestCase("admin")]
            [TestCase("client")]
            public async Task Should_find_role_by_name(string name)
            {
                var result = await userService.FindRoleByName(name);

                var actual = db.Roles.FirstOrDefault(x => x.Name == name);

                Assert.True(result.Name == actual.Name);
                Assert.True(name == result.Name);
            }
        }
    }
}