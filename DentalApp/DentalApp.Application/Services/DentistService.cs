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
    public class DentistService : IDentistService
    {
        private readonly IDentistRepository _repository;

        public DentistService(IDentistRepository repository) => _repository = repository;

        public async Task<IEnumerable<Dentist>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<Dentist> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
        public async Task<Dentist> CreateAsync(Dentist dentist)
        {
            await _repository.AddAsync(dentist);
            await _repository.SaveChangesAsync();
            return dentist;
        }
    }
}
