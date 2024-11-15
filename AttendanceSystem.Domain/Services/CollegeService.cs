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
    public class CollegeService : ICollegeService
    {
        private readonly ICollegeRepository _collegeRepository;

        public CollegeService(ICollegeRepository collegeRepository)
        {
            _collegeRepository = collegeRepository;
        }

        public async Task<College> GetCollegeByIdAsync(int id)
        {
            return await _collegeRepository.GetCollegeByIdAsync(id);
        }

        public async Task<IEnumerable<College>> GetAllCollegesAsync()
        {
            return await _collegeRepository.GetAllCollegesAsync();
        }

        public async Task CreateCollegeAsync(College college)
        {
            await _collegeRepository.AddCollegeAsync(college);
        }

        public async Task UpdateCollegeAsync(College college)
        {
            await _collegeRepository.UpdateCollegeAsync(college);
        }

        public async Task DeleteCollegeAsync(int id)
        {
            await _collegeRepository.DeleteCollegeAsync(id);
        }
    }
}
