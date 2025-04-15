﻿using DentalApp.Domain.DTOs.Response;
using DentalApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalApp.Application.Services.Interfaces
{
    public interface IAddressService
    {
        Task<IEnumerable<AddressResponseDto>> GetAllAsync();
        Task<AddressResponseDto> GetByIdAsync(int id);
        Task<AddressResponseDto> CreateAsync(Address address);
    }
}
