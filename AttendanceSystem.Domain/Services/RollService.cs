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
    public class RollService : IRollService
    {
        private readonly IRollRepository _rollRepository;

        public RollService(IRollRepository rollRepository)
        {
            _rollRepository = rollRepository;
        }

        public async Task<Roll> GetRollByIdAsync(int id)
        {
            return await _rollRepository.GetRollByIdAsync(id);
        }

        public async Task<IEnumerable<Roll>> GetAllRollsAsync()
        {
            return await _rollRepository.GetAllRollsAsync();
        }

        public async Task CreateRollAsync(Roll roll)
        {
            await _rollRepository.AddRollAsync(roll);
        }

        public async Task UpdateRollAsync(Roll roll)
        {
            await _rollRepository.UpdateRollAsync(roll);
        }

        public async Task DeleteRollAsync(int id)
        {
            await _rollRepository.DeleteRollAsync(id);
        }
    }
}
