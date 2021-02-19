using Application.DTOs.Account;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class AccountMapper : GeneralProfile
    {
        public AccountMapper()
        {
            CreateMap<UserPhoto, UserPhotoDTO>();
            CreateMap<User, MeResponse>();
        }
    }
}
