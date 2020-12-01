using Domain.Entities;
using Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.DTOs.Account
{
    public class MeResponse
    {
        public int UserId { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string JWT { get; set; }
        public string[] Roles { get; set; }
        public Gender Gender { get; set; }
        public MeResponse(User user)
        {
            UserId = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            MiddleName = user.MiddleName;
            PhoneNumber = user.PhoneNumber;
            Roles = user.UserRoles?.Select(x => x.Role?.Name).ToArray();
            Gender = user.Gender;
        }
    }
}
