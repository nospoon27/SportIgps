using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Users.Queries.GetCountryCodes
{
    public class GetCountryCodesResponse
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string ISOName { get; set; }
    }
}
