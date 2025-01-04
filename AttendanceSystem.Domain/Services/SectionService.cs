using AttendanceSystem.Domain.DomainModel;
using AttendanceSystem.Domain.Entities;
using AttendanceSystem.Domain.Interfaces.Repository;
using AttendanceSystem.Domain.Interfaces.Service;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

        public async Task<IEnumerable<TeachingInformationModel>> GetTeachingInformationByIdAsync(int teacherId)
        {
            return await _sectionRepository.GetTeachingInformationByIdAsync(teacherId);
        }

        
        public async Task AddSectionAsyc(AddSectionModel model)
        {
            var addSection = new Section
            {
                StartDateTime = DateTime.Parse(model.StartDateTime), // Ensure proper date parsing
                EndDateTime = DateTime.Parse(model.EndDateTime),
                SectionNumber = model.SectionNumber,
                SectionDays = model.SectionDays, // Already a concatenated string
                CourseId = model.CourseId,
                ClassRoomId = model.ClassRoomId,
                TeacherId = model.TeacherId
            };

            // Check for conflicts before adding the section
            bool hasConflict = await _sectionRepository.FindSectionConflictAsync(addSection);

            if (hasConflict)
            {
                // If there's a conflict, throw an exception or return an error response
                throw new InvalidOperationException("The section conflicts with an existing section.");
            }

            await _sectionRepository.AddSectionAsync(addSection);
        }

        public async Task<bool> FindSectionConflictAsync(Section section)
        {
            return await _sectionRepository.FindSectionConflictAsync(section);
        }
       
    }
}
