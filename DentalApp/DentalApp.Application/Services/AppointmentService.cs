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
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _repository;

        public AppointmentService(IAppointmentRepository repository) => _repository = repository;

        public async Task<IEnumerable<Appointment>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<Appointment> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
        public async Task<Appointment> CreateAsync(Appointment appointment)
        {
            await _repository.AddAsync(appointment);
            await _repository.SaveChangesAsync();
            return appointment;
        }
    }
}
