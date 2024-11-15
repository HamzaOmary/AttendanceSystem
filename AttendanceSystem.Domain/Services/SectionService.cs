using AttendanceSystem.Domain.Interfaces.Repository;
using AttendanceSystem.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static System.Collections.Specialized.BitVector32;

namespace AttendanceSystem.Domain.Services
{
    public class SectionService : ISectionService
    {
        private readonly ISectionRepository _sectionRepository;

        public SectionService(ISectionRepository sectionRepository)
        {
            _sectionRepository = sectionRepository;
        }

        public async Task<Entities.Section> GetSectionByIdAsync(int id)
        {
            return await _sectionRepository.GetSectionByIdAsync(id);
        }

        public async Task<IEnumerable<Entities.Section>> GetAllSectionsAsync()
        {
            return await _sectionRepository.GetAllSectionsAsync();
        }

        public async Task CreateSectionAsync(Entities.Section section)
        {
            await _sectionRepository.AddSectionAsync(section);
        }

        public async Task UpdateSectionAsync(Entities.Section section)
        {
            await _sectionRepository.UpdateSectionAsync(section);
        }

        public async Task DeleteSectionAsync(int id)
        {
            await _sectionRepository.DeleteSectionAsync(id);
        }
    }
}
