using AttendanceSystem.Domain.DomainModel;
using AttendanceSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Domain.Interfaces.Repository
{
    public interface ISectionRepository
    {
        Task<Section> GetSectionByIdAsync(int id);
        Task<IEnumerable<Section>> GetAllSectionsAsync();
        Task AddSectionAsync(Section section);
        Task UpdateSectionAsync(Section section);
        Task DeleteSectionAsync(int id);

        Task<IEnumerable<TeachingInformationModel>> GetTeachingInformationByIdAsync(int teacherId);

        //Task AddSectionAsync(Section section);

        Task<bool> FindSectionConflictAsync(Section section);
    }
}
