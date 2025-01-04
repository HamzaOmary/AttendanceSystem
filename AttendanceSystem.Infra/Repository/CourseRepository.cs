using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AttendanceSystem.Domain.Entities;
using AttendanceSystem.Domain.Interfaces.Repository;
using AttendanceSystem.Domain;
using AttendanceSystem.Domain.DomainModel;

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
            //var newCourse = new Course
            //{
            //    CourseName = course.CourseName,
            //    CourseNumber = course.CourseNumber,
            //    CreditHour = course.CreditHour,
            //    DepartmentId = course.DepartmentId
            //};

            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();

            // Retrieve the created course with only the required fields
            //var createdCourse = await _context.Courses
            //    .Where(c => c.CourseId == course.CourseId)
            //    .Select(c => new
            //    {
            //        c.CourseId,           // Include CourseId
            //        c.CourseName,         // Include CourseName
            //        c.CourseNumber,       // Include CourseNumber
            //        c.CreditHour,         // Include CreditHour
            //        c.DepartmentId // Flatten the Department's name
            //    })
            //    .FirstOrDefaultAsync();

            // Return the result
            //return CreatedAtAction(nameof(CreateCourseAsync), new { id = createdCourse.CourseId }, createdCourse);
            //object value = c => new { c.CourseName, c.CourseNumber, c.CreditHour, c.DepartmentId };
            //object selector = value;
            //course = await Queryable.Select(_context.Courses, selector);

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

       
        public async Task<IEnumerable<ListOfCoursesModel>> GetListOfCoursesAsync()
        {
            {
                var courses = await _context.Courses.Include(c => c.Department)
                    .Select(c => new ListOfCoursesModel
                    {
                        CourseName = c.CourseName,
                        CourseNumber = c.CourseNumber,
                        Credits =  c.CreditHour,
                        Department = c.Department.DepartmentName
                    }
                    )
                    .ToListAsync(); // Assuming RollId 2 represents students

                return courses;
                //// return await _context.Users.FindAsync(id);
                //// return await _context.Users.FirstOrDefaultAsync(x=>x.UserId==id);
                //return await _context.Users.Where(x => x.RollId == 2)
                //.Select(x => new { }
                //);
            }
        }




        //public async Task AddCoursetwoAsync(AddCourseModel courseModel)
        //{
        //    await _context.Courses.AddAsync(course);
        //    await _context.SaveChangesAsync();

        //    // Retrieve the created course with only the required fields
        //    //var createdCourse = await _context.Courses
        //    //    .Where(c => c.CourseId == course.CourseId)
        //    //    .Select(c => new
        //    //    {
        //    //        c.CourseId,           // Include CourseId
        //    //        c.CourseName,         // Include CourseName
        //    //        c.CourseNumber,       // Include CourseNumber
        //    //        c.CreditHour,         // Include CreditHour
        //    //        c.DepartmentId // Flatten the Department's name
        //    //    })
        //    //    .FirstOrDefaultAsync();

        //    // Return the result
        //    //return CreatedAtAction(nameof(CreateCourseAsync), new { id = createdCourse.CourseId }, createdCourse);
        //    //object value = c => new { c.CourseName, c.CourseNumber, c.CreditHour, c.DepartmentId };
        //    //object selector = value;
        //    //course = await Queryable.Select(_context.Courses, selector);

        //}

        public async Task AddCoursetwoAsync(Course course)
        {

            _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
        }

        public async Task<List<DropDownListModel>> GetCourseDropDownAsync()
        {
            return await _context.Courses
                .Select(c => new DropDownListModel { Id = c.CourseId , Name = c.CourseName })
                .ToListAsync();
        }



    }
}
