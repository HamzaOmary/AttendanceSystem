using AttendanceSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Domain.Interfaces.Repository
{
    public interface ICourseRepository
    {
        Task<Course> GetCourseByIdAsync(int id);
        Task<IEnumerable<Course>> GetAllCoursesAsync();
        Task AddCourseAsync(Course course);
       
        //Task UpdateCourseAsync(Course course);
        Task DeleteCourseAsync(int id);
    }
}
