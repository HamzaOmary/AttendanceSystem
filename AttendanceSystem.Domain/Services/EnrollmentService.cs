using AttendanceSystem.Domain.Entities;
using AttendanceSystem.Domain.Interfaces.Repository;
using AttendanceSystem.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Domain.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _enrollmentRepository;

        public EnrollmentService(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        public async Task<Enrollment> GetEnrollmentByIdAsync(int id)
        {
            return await _enrollmentRepository.GetEnrollmentByIdAsync(id);
        }

        public async Task<IEnumerable<Enrollment>> GetAllEnrollmentsAsync()
        {
            return await _enrollmentRepository.GetAllEnrollmentsAsync();
        }

        public async Task CreateEnrollmentAsync(Enrollment enrollment)
        {
            await _enrollmentRepository.AddEnrollmentAsync(enrollment);
        }

        //public async Task UpdateEnrollmentAsync(Enrollment enrollment)
        //{
        //    await _enrollmentRepository.UpdateEnrollmentAsync(enrollment);
        //}

        public async Task DeleteEnrollmentAsync(int id)
        {
            await _enrollmentRepository.DeleteEnrollmentAsync(id);
        }
    }
}
