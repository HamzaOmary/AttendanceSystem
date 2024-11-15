using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AttendanceSystem.Domain.Entities;
using AttendanceSystem.Domain.Interfaces.Repository;
using AttendanceSystem.Domain;

namespace AttendanceSystem.Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _context;

        public CourseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Course> GetCourseByIdAsync(int id)
        {
            // return await _context.Courses.FindAsync(id);
            return await _context.Courses.Where(x => x.CourseId == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task AddCourseAsync(Course course)
        {
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
        }

        //public async Task UpdateCourseAsync(Course course)
        //{
        //    //_context.Courses.Update(course);
        //    // await _context.SaveChangesAsync();
        //    var courseToUpdate = await _context.Courses.Where(x => x.CourseId == course.CourseId).FirstOrDefaultAsync();
        //    if (courseToUpdate != null)
        //    {

               

        //         await _context.SaveChangesAsync();
        //    }
        //}

        public async Task DeleteCourseAsync(int id)
        {
            var courseToDelete = await _context.Courses.FindAsync(id);
            if (courseToDelete != null)
            {
                _context.Courses.Remove(courseToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
