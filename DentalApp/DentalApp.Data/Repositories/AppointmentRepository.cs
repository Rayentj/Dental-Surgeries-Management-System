using DentalApp.Data.Repositories.Interfaces;
using DentalApp.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalApp.Data.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly DentalAppDbContext _context;
        public AppointmentRepository(DentalAppDbContext context) => _context = context;

        public async Task<IEnumerable<Appointment>> GetAllAsync() => await _context.Appointments.Include(a => a.Patient).Include(a => a.Dentist).Include(a => a.Surgery).ToListAsync();
        public async Task<Appointment> GetByIdAsync(int id) => await _context.Appointments.Include(a => a.Patient).Include(a => a.Dentist).Include(a => a.Surgery).FirstOrDefaultAsync(a => a.AppointmentId == id);
        public async Task AddAsync(Appointment appointment) => await _context.Appointments.AddAsync(appointment);
        public void Update(Appointment appointment) => _context.Appointments.Update(appointment);
        public void Delete(Appointment appointment) => _context.Appointments.Remove(appointment);
        public async Task<bool> SaveChangesAsync() => await _context.SaveChangesAsync() > 0;
    }
}
