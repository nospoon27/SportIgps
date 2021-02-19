using Application.Interfaces.Services;
using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class SportDbContext : DbContext
    {
        private readonly IAuthenticatedUserService _authenticatedUser;
        public SportDbContext(DbContextOptions<SportDbContext> options, IAuthenticatedUserService authenticatedUser) : base(options)
        {
            _authenticatedUser = authenticatedUser;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserPhoto> UserPhotos { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<WorkoutGroup> WorkoutGroups { get; set; }
        public DbSet<WorkoutGroupClient> WorkoutGroupClients { get; set; }
        public DbSet<WorkoutGroupTrainer> WorkoutGroupTrainers { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<TrainerSpecialization> TrainerSpecializations { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<RoleClaim> RoleClaims { get; set; }
        public DbSet<CountryCode> CountryCodes { get; set; }
        public DbSet<Abonement> Abonements { get; set; }
        public DbSet<AbonementLimit> AbonementLimits { get; set; }
        public DbSet<FileEntity> FileEntities { get; set; }
        public DbSet<ScheduleEvent> ScheduleEvents { get; set; }
        public DbSet<ScheduleEventTrainer> ScheduleEventTrainers { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.Now;
                        entry.Entity.CreatedBy = _authenticatedUser.UserId;
                        entry.Entity.CreatedIp = _authenticatedUser.RemoteIp;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = DateTime.Now;
                        entry.Entity.LastModifiedBy = _authenticatedUser.UserId;
                        entry.Entity.LastModifiedIp = _authenticatedUser.RemoteIp;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
