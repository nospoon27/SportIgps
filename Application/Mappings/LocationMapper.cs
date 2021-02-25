using Application.Features.DTOs;
using Application.Features.Locations.Commands.CreateLocation;
using Application.Features.Locations.Commands.UpdateLocation;
using Application.Features.Locations.Queries.GetAll;
using Application.Features.Locations.Queries.GetAllPaged;
using Application.Features.Locations.Queris.GetById;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mappings
{
    public class LocationMapper : Profile
    {
        public LocationMapper()
        {
            CreateMap<Location, LocationDTO>();
            CreateMap<CreateLocationCommand, Location>().ReverseMap();
        }
    }
}
