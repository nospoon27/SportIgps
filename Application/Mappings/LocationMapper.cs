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
            CreateMap<GetLocationByIdResponse, Location>().ReverseMap();
            CreateMap<GetAllPagedLocationsResponse, Location>().ReverseMap();
            CreateMap<CreateLocationCommand, Location>().ReverseMap();
            CreateMap<GetAllLocationsResponse, Location>().ReverseMap();
        }
    }
}
