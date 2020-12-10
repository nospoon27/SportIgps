using Application.Sieve.Models;
using Application.Sieve.Services;
using Domain.Common;
using Domain.Entities;
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

            return mapper;
        }
    }
}
