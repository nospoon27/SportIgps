using Application.Features.Sports.Commands.CreateSport;
using Application.Features.Sports.Queries.GetAll;
using Application.Features.Sports.Queries.GetAllPaged;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mappings
{
    public class SportMapper : Profile
    {
        public SportMapper()
        {
            CreateMap<Sport, GetAllSportsResponse>();
            CreateMap<Sport, GetAllPagedSportsResponse>();
            CreateMap<CreateSportCommand, Sport>();
        }
    }
}
