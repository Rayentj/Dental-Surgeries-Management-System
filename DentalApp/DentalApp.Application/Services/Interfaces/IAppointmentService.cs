﻿using DentalApp.Domain.DTOs.Request;
using DentalApp.Domain.DTOs.Response;
using DentalApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalApp.Application.Services.Interfaces
{
    public interface IAppointmentService
    {
        Task<IEnumerable<AppointmentResponseDto>> GetAllAsync();
        Task<AppointmentResponseDto> GetByIdAsync(int id);
        Task<AppointmentResponseDto> CreateAsync(AppointmentRequestDto dto);
        Task<bool> UpdateAsync(int id, AppointmentRequestDto dto);
        Task<bool> DeleteAsync(int id);
        public Task<IEnumerable<AppointmentResponseDto>> GetByDentistIdAsync(int dentistId);
        public Task<IEnumerable<AppointmentResponseDto>> GetByPatientIdAsync(int patientId);

        public Task<bool> CancelAsync(int id);

        Task<PaginatedResponse<AppointmentResponseDto>> GetPagedAsync(PagingRequest request);
    }
}
