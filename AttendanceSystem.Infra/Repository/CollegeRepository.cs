using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AttendanceSystem.Domain.Entities;
using AttendanceSystem.Domain.Interfaces.Repository;
using AttendanceSystem.Domain;

namespace AttendanceSystem.Infrastructure.Repositories
{
    public class CollegeRepository : ICollegeRepository
    {
        private readonly AppDbContext _context;

        public CollegeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<College> GetCollegeByIdAsync(int id)
        {
            //return await _context.Colleges.FindAsync(id);
            return await _context.Colleges.Where(X => X.CollegeId == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<College>> GetAllCollegesAsync()
        {
            return await _context.Colleges.ToListAsync();
        }

        public async Task AddCollegeAsync(College college)
        {
            await _context.Colleges.AddAsync(college);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCollegeAsync(College college)
        {
            //_context.Colleges.Update(college);
            //await _context.SaveChangesAsync();

            var collegeToUpdate = await _context.Colleges.Where(x => x.CollegeId == college.CollegeId).FirstOrDefaultAsync();
            if (collegeToUpdate != null)
            {

                collegeToUpdate.DeanUserId = college.DeanUserId;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteCollegeAsync(int id)
        {
            var collegeToDelete = await _context.Colleges.FindAsync(id);
            if (collegeToDelete != null)
            {
                _context.Colleges.Remove(collegeToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}