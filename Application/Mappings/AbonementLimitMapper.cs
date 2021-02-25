using Application.Features.AbonementLimits.Commands.Create;
using Application.Features.AbonementLimits.Queries.GetAll;
using Application.Features.AbonementLimits.Queries.GetAllPaged;
using Application.Features.AbonementLimits.Queries.GetById;
using Application.Features.DTOs;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class AbonementLimitMapper : Profile
    {
        public AbonementLimitMapper()
        {
            CreateMap<CreateAbonementLimitCommand, AbonementLimit>().ReverseMap();

            CreateMap<AbonementLimit, AbonementLimitDTO>();
        }
    }
}
