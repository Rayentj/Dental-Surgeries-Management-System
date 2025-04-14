using DentalApp.Application.Services.Interfaces;
using DentalApp.Data.Repositories.Interfaces;
using DentalApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalApp.Application.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _repository;

        public AddressService(IAddressRepository repository) => _repository = repository;

        public async Task<IEnumerable<Address>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<Address> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
        public async Task<Address> CreateAsync(Address address)
        {
            await _repository.AddAsync(address);
            await _repository.SaveChangesAsync();
            return address;
        }
    }
}
