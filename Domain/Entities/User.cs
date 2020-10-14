using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int GenderId { get; set; }
        public Gender Gender { get; set; }
        public int CountryCodeId { get; set; }
        public CountryCode CountryCode { get; set; }
        public string Password { get; set; }

        [JsonIgnore]
        public ICollection<UserRole> UserRoles { get; set; }

        [JsonIgnore]
        public IList<Role> Roles { get; set; }

        [JsonIgnore]
        public List<RefreshToken> RefreshTokens { get; set; }
    }
}
