using AttendanceSystem.Domain.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static System.Collections.Specialized.BitVector32;

namespace AttendanceSystem.Domain.Interfaces.Service
{
    public interface ISectionService
    {
        Task<Entities.Section> GetSectionByIdAsync(int id);
        Task<IEnumerable<Entities.Section>> GetAllSectionsAsync();
        Task CreateSectionAsync(Entities.Section section);
        Task UpdateSectionAsync(Entities.Section section);
        Task DeleteSectionAsync(int id);

        Task<IEnumerable<TeachingInformationModel>> GetTeachingInformationByIdAsync(int teacherId);

        Task AddSectionAsyc(AddSectionModel model);

        Task <bool> FindSectionConflictAsync(Entities.Section section);
    }
}
