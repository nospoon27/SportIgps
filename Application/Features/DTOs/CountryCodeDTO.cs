using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.DTOs
{
    public class CountryCodeDTO
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string ISOName { get; set; }
    }
}
