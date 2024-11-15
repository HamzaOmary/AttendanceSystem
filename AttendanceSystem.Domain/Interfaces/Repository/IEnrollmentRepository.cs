using AttendanceSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Domain.Interfaces.Repository
{
    public interface IEnrollmentRepository
    {
        Task<Enrollment> GetEnrollmentByIdAsync(int id);
        Task<IEnumerable<Enrollment>> GetAllEnrollmentsAsync();
        Task AddEnrollmentAsync(Enrollment enrollment);
        
        //Task UpdateEnrollmentAsync(Enrollment enrollment);
        Task DeleteEnrollmentAsync(int id);
    }
}
