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
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<Department> GetDepartmentByIdAsync(int id)
        {
            return await _departmentRepository.GetDepartmentByIdAsync(id);
        }

        public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
        {
            return await _departmentRepository.GetAllDepartmentsAsync();
        }

        public async Task CreateDepartmentAsync(Department department)
        {
            await _departmentRepository.AddDepartmentAsync(department);
        }

        public async Task UpdateDepartmentAsync(Department department)
        {
            await _departmentRepository.UpdateDepartmentAsync(department);
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            await _departmentRepository.DeleteDepartmentAsync(id);
        }
    }
}
