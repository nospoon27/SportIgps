using Application.DTOs.Account;
using Application.Features.Users.Queries.GetAll;
using Application.Features.Users.Queries.GetById;
using Application.Features.Users.Queries.GetCountryCodes;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mappings
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<User, GetAllUsersResponse>()
                .ForMember(x => x.CounrtyCode, o => o.MapFrom(x => x.CountryCode.Code));

            CreateMap<User, GetUserByIdResponse>()
                .ForMember(x => x.CounrtyCode, o => o.MapFrom(x => x.CountryCode.Code));

            CreateMap<AuthenticationRequest, User>().ReverseMap();

            CreateMap<RegisterRequest, User>().ReverseMap();

            CreateMap<CountryCode, GetCountryCodesResponse>();
        }
    }
}
