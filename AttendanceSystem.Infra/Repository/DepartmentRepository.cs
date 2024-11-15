using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AttendanceSystem.Domain.Entities;
using AttendanceSystem.Domain.Interfaces.Repository;
using AttendanceSystem.Domain;

namespace AttendanceSystem.Infrastructure.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _context;

        public DepartmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Department> GetDepartmentByIdAsync(int id)
        {
            //return await _context.Departments.FindAsync(id);
            return await _context.Departments.Where(x => x.DepartmentId == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task AddDepartmentAsync(Department department)
        {
            await _context.Departments.AddAsync(department);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDepartmentAsync(Department department)
        {
            // _context.Departments.Update(department);
            //await _context.SaveChangesAsync();

            var departmentToUpdate = await _context.Departments.Where(x => x.DepartmentId == department.DepartmentId).FirstOrDefaultAsync();
            if (departmentToUpdate != null)
            {

                departmentToUpdate.HeadUserId = department.HeadUserId;

                 await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            var departmentToDelete = await _context.Departments.FindAsync(id);
            if (departmentToDelete != null)
            {
                _context.Departments.Remove(departmentToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}