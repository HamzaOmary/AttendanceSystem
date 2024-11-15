using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AttendanceSystem.Domain.Entities;
using AttendanceSystem.Domain.Interfaces.Repository;
using AttendanceSystem.Domain;

namespace AttendanceSystem.Infrastructure.Repositories
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly AppDbContext _context;

        public EnrollmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Enrollment> GetEnrollmentByIdAsync(int id)
        {
            // return await _context.Enrollments.FindAsync(id);
            return await _context.Enrollments.Where(x => x.EnrollmentId == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Enrollment>> GetAllEnrollmentsAsync()
        {
            return await _context.Enrollments.ToListAsync();
        }

        public async Task AddEnrollmentAsync(Enrollment enrollment)
        {
            await _context.Enrollments.AddAsync(enrollment);
            await _context.SaveChangesAsync();
        }

        //public async Task UpdateEnrollmentAsync(Enrollment enrollment)
        //{
        //    _context.Enrollments.Update(enrollment);
        //    await _context.SaveChangesAsync();
        //}

        public async Task DeleteEnrollmentAsync(int id)
        {
            var enrollmentToDelete = await _context.Enrollments.FindAsync(id);
            if (enrollmentToDelete != null)
            {
                _context.Enrollments.Remove(enrollmentToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}