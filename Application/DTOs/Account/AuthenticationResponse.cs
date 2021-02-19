using Domain.Entities;
using Domain.Entities.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.DTOs.Account
{
    public class AuthenticationResponse
    {
        public int UserId { get; set; }
        public string PhoneNumber { get; set; }
        public int CountryCodeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string JWT { get; set; }
        public string[] Roles { get; set; }
        public Gender Gender { get; set; }
        public UserPhotoDTO UserPhoto { get; set; }
        public string RefreshToken { get; set; }

        public AuthenticationResponse(User user, string jwtToken, string refreshToken)
        {
            UserId = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            MiddleName = user.MiddleName;
            PhoneNumber = user.PhoneNumber;
            CountryCodeId = user.CountryCodeId;
            Roles = user.UserRoles?.Select(x => x.Role?.Name).ToArray();
            Gender = user.Gender;
            JWT = jwtToken;
            RefreshToken = refreshToken;
            UserPhoto = new UserPhotoDTO()
            {
                DefaultUrl = user.UserPhoto?.DefaultUrl,
                SmallUrl = user.UserPhoto?.SmallUrl
            };
        }
    }
}
