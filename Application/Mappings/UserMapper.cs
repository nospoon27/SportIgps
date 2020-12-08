using Application.DTOs.Account;
using Application.DTOs.Users;
using Application.Features.Users.Queries.GetAll;
using Application.Features.Users.Queries.GetAllPaged;
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
            CreateMap<User, GetAllPagedUsersResponse>();
            CreateMap<User, GetAllUsersResponse>();
            CreateMap<User, GetUserByIdResponse>();

            CreateMap<AuthenticationRequest, User>().ReverseMap();

            CreateMap<RegisterRequest, User>().ReverseMap();

            CreateMap<CountryCode, GetCountryCodesResponse>();

            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
