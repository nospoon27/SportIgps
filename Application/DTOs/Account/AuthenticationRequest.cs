using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Account
{
    public class AuthenticationRequest
    {
        public int CountryCodeId { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}
