using Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Users.Queries.GetAllPaged
{
    public class GetAllPagedUsersResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public int CountryCodeId { get; set; }
    }
}
