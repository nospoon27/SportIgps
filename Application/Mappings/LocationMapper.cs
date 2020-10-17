using Application.Features.Locations.Commands.CreateLocation;
using Application.Features.Locations.Commands.UpdateLocation;
using Application.Features.Locations.Queris.GetAll;
using Application.Features.Locations.Queris.GetAllPaged;
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
            CreateMap<GetLocationByIdQuery, Location>().ReverseMap();
            CreateMap<GetAllPagedLocationsResponse, Location>();
            CreateMap<CreateLocationCommand, Location>();
            CreateMap<GetAllLocationsResponse, Location>();
        }
    }
}
