using AttendanceSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Domain.Interfaces.Repository
{
    public interface ICollegeRepository
    {
        Task<College> GetCollegeByIdAsync(int id);
        Task<IEnumerable<College>> GetAllCollegesAsync();
        Task AddCollegeAsync(College college);
        Task UpdateCollegeAsync(College college);
        Task DeleteCollegeAsync(int id);
    }
}
