using AttendanceSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Domain.Interfaces.Service
{
    public interface IDepartmentService
    {
        Task<Department> GetDepartmentByIdAsync(int id);
        Task<IEnumerable<Department>> GetAllDepartmentsAsync();
        Task CreateDepartmentAsync(Department department);
        Task UpdateDepartmentAsync(Department department);
        Task DeleteDepartmentAsync(int id);
    }
}
