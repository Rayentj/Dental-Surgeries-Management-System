using DentalApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalApp.Application.Services.Interfaces
{
    public interface IDentistService
    {
        Task<IEnumerable<Dentist>> GetAllAsync();
        Task<Dentist> GetByIdAsync(int id);
        Task<Dentist> CreateAsync(Dentist dentist);
    }
}
