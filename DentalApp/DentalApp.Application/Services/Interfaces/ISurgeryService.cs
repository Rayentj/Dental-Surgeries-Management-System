using DentalApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalApp.Application.Services.Interfaces
{
    public interface ISurgeryService
    {
        Task<IEnumerable<Surgery>> GetAllAsync();
        Task<Surgery> GetByIdAsync(int id);
        Task<Surgery> CreateAsync(Surgery surgery);
    }
}
