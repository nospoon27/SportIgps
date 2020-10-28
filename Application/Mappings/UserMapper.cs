using Application.DTOs.Account;
using Application.Features.Users.Queries.GetAll;
using Application.Features.Users.Queries.GetById;
using Application.Features.Users.Queries.GetCountryCodes;
using Application.Features.Users.Queries.GetGenders;
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
                .ForMember(x => x.Gender, o => o.MapFrom(x => x.Gender.Name))
                .ForMember(x => x.CounrtyCode, o => o.MapFrom(x => x.CountryCode.Code));

            CreateMap<User, GetUserByIdResponse>()
                .ForMember(x => x.Gender, o => o.MapFrom(x => x.Gender.Name))
                .ForMember(x => x.CounrtyCode, o => o.MapFrom(x => x.CountryCode.Code));

            CreateMap<AuthenticationRequest, User>().ReverseMap();

            CreateMap<RegisterRequest, User>().ReverseMap();

            CreateMap<Gender, GetGendersResponse>();

            CreateMap<CountryCode, GetCountryCodesResponse>();
        }
    }
}
