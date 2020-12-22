using Application.Sieve.Models;
using Application.Sieve.Services;
using Domain.Common;
using Domain.Entities;
using Humanizer;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.SieveProcessors
{
    public class ApplicationSieveProcessor : SieveProcessor
    {
        public ApplicationSieveProcessor(
            IOptions<SieveOptions> options) : base(options)
        {
        }

        protected override SievePropertyMapper MapProperties(SievePropertyMapper mapper)
        {
            // BaseEntity
            mapper.Property<BaseEntity>(e => e.Id).CanFilter().CanSort();
            mapper.Property<BaseEntity>(e => e.Created).CanFilter().CanSort();
            mapper.Property<BaseEntity>(e => e.CreatedBy).CanFilter();
            mapper.Property<BaseEntity>(e => e.CreatedIp).CanFilter();
            mapper.Property<BaseEntity>(e => e.LastModified).CanFilter().CanSort();
            mapper.Property<BaseEntity>(e => e.LastModifiedBy).CanFilter();
            mapper.Property<BaseEntity>(e => e.LastModifiedIp).CanFilter();

            // Location
            mapper.Property<Location>(x => x.Name).CanFilter().CanSort();
            mapper.Property<Location>(x => x.Description).CanFilter().CanSort();
            mapper.Property<Location>(x => x.PeopleAmount).CanFilter().CanSort();

            // Sport
            mapper.Property<Sport>(x => x.Name).CanFilter().CanSort();
            mapper.Property<Sport>(x => x.Description).CanFilter().CanSort();

            // Trainer
            mapper.Property<Trainer>(t => t.User.LastName)
                .HasName($"{nameof(User)}.{nameof(User.LastName)}".Camelize())
                .CanFilter();
            mapper.Property<Trainer>(t => t.User.FirstName)
                .HasName($"{nameof(User)}.{nameof(User.FirstName)}".Camelize())
                .CanFilter();
            mapper.Property<Trainer>(t => t.User.MiddleName)
                .HasName($"{nameof(User)}.{nameof(User.MiddleName)}".Camelize())
                .CanFilter();

            // Workout
            mapper.Property<Workout>(w => w.Name).CanFilter().CanSort();

            // WorkoutGroup
            mapper.Property<WorkoutGroup>(wg => wg.Name).CanSort().CanFilter();

            // User
            mapper.Property<User>(u => u.LastName).CanFilter().CanSort();
            mapper.Property<User>(u => u.FirstName).CanFilter().CanSort();
            mapper.Property<User>(u => u.MiddleName).CanFilter().CanSort();

            // Role
            mapper.Property<Role>(r => r.Name).CanFilter().CanSort();

            // RoleClaim
            mapper.Property<RoleClaim>(rc => rc.Role.Name).CanFilter().CanSort();
            mapper.Property<RoleClaim>(rc => rc.ClaimValue).CanFilter().CanSort();
            mapper.Property<RoleClaim>(rc => rc.ClaimType).CanFilter().CanSort();

            // UserRole
            mapper.Property<UserRole>(ur => ur.Role.Name).CanFilter();
            mapper.Property<UserRole>(ur => ur.User.LastName).CanFilter();
            mapper.Property<UserRole>(ur => ur.User.FirstName).CanFilter();
            mapper.Property<UserRole>(ur => ur.User.MiddleName).CanFilter();

            // CountryCode
            mapper.Property<CountryCode>(c => c.ISOName).CanFilter().CanSort();
            mapper.Property<CountryCode>(c => c.Code).CanFilter().CanSort();

            return mapper;
        }
    }
}
