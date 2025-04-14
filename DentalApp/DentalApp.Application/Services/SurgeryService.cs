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
    public class SurgeryService : ISurgeryService
    {
        private readonly ISurgeryRepository _repository;

        public SurgeryService(ISurgeryRepository repository) => _repository = repository;

        public async Task<IEnumerable<Surgery>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<Surgery> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
        public async Task<Surgery> CreateAsync(Surgery surgery)
        {
            await _repository.AddAsync(surgery);
            await _repository.SaveChangesAsync();
            return surgery;
        }
    }
}
