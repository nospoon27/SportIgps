using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface ICountryCodeService
    {
        Task<CountryCode> GetById(int id);
    }
}
