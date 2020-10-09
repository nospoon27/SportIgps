using Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Account
{
    public class AuthenticationResponse
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public List<string> Roles { get; set; }
        public string JWT { get; set; }

        [JsonIgnore]
        public string RefreshToken { get; set; }

        public AuthenticationResponse(User user, string jwtToken, string refreshToken)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            MiddleName = user.MiddleName;
            PhoneNumber = user.PhoneNumber;
            JWT = jwtToken;
            RefreshToken = refreshToken;
        }
    }
}
