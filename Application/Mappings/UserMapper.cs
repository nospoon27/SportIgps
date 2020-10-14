using Application.Features.Users.Queries.GetAll;
using Application.Features.Users.Queries.GetById;
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
            CreateMap<User, GetAllUsersResponse>().ReverseMap();
            CreateMap<User, GetUserByIdResponse>().ReverseMap();
        }
    }
}
