using AutoMapper;
using DentalApp.Application.Services.Interfaces;
using DentalApp.Data.Repositories.Interfaces;
using DentalApp.Domain.DTOs.Response;
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
        private readonly IMapper _mapper;

        public AddressService(IAddressRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AddressResponseDto>> GetAllAsync()
        {
            var addresses = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<AddressResponseDto>>(addresses);
        }

        public async Task<AddressResponseDto> GetByIdAsync(int id)
        {
            var address = await _repository.GetByIdAsync(id);
            return _mapper.Map<AddressResponseDto>(address);
        }

        public async Task<AddressResponseDto> CreateAsync(Address address)
        {
            await _repository.AddAsync(address);
            await _repository.SaveChangesAsync();
            return _mapper.Map<AddressResponseDto>(address);
        }
    }
}
