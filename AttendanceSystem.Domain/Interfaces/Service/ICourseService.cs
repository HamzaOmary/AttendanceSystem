using AttendanceSystem.Domain.DomainModel;
using AttendanceSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Domain.Interfaces.Service
{
    public interface ICourseService
    {
        Task<Course> GetCourseByIdAsync(int id);
        Task<IEnumerable<Course>> GetAllCoursesAsync();
        Task CreateCourseAsync(Course course);
       // Task UpdateCourseAsync(Course course);
        Task DeleteCourseAsync(int id);

        Task<IEnumerable<ListOfCoursesModel>> GetListOfCoursesAsync();
        Task<List<DropDownListModel>> GetCourseDropDownAsync();

        Task AddCoursetwoAsync(AddCourseModel model);
    }
}
