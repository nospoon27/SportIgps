using Application.Interfaces.Services;
using Application.Interfaces.UnitOfWork;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Identity.Services
{
    public class CountryCodeService : ICountryCodeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CountryCodeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<CountryCode> GetById(int id)
        {
            var countryCode = await _unitOfWork.GetRepository<CountryCode>().GetSingleOrDefaultAsync(predicate: x => x.Id == id);
            if (countryCode == null) throw new KeyNotFoundException("Код страны с таким ключом не найден");
            return countryCode;
        }
    }
}
