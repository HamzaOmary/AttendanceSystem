using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AttendanceSystem.Domain.Entities;
using AttendanceSystem.Domain.Interfaces.Repository;
using AttendanceSystem.Domain;
using AttendanceSystem.Domain.DomainModel;

namespace AttendanceSystem.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            // return await _context.Users.FindAsync(id);
            // return await _context.Users.FirstOrDefaultAsync(x=>x.UserId==id);
            return await _context.Users.Where(x => x.UserId == id).FirstOrDefaultAsync();
            //return await _context.Users.FindAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.Include(x => x.College).ToListAsync();
        }

        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            //_context.Users.Update(user);
            //await _context.SaveChangesAsync();

            var userToUpdate = await _context.Users.Where(x => x.UserId == user.UserId).FirstOrDefaultAsync();
            if (userToUpdate != null)
            {

                userToUpdate.FullName = user.FullName;
                userToUpdate.UserEmail = user.UserEmail;
                userToUpdate.UserPhone = user.UserPhone;
                userToUpdate.UserImag = user.UserImag;
                userToUpdate.Address = user.Address;
                userToUpdate.JobTitel = user.JobTitel;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteUserAsync(int id)
        {
            var userToDelete = await _context.Users.Where(x => x.UserId == id).FirstOrDefaultAsync();
            if (userToDelete != null)
            {
                _context.Users.Remove(userToDelete);
                await _context.SaveChangesAsync();
            }
        }

        //public async Task<User> GetUserByLoginIdAsync(int id)
        //{
        //    // return await _context.Users.FindAsync(id);
        //    // return await _context.Users.FirstOrDefaultAsync(x=>x.UserId==id);
        //    return await _context.Users.Where(x => x. == id).FirstOrDefaultAsync();
        //}

        //public async Task<DashboardStatisticsModel> GetDashboardStatistics()
        //{
        //    var result = new DashboardStatisticsModel();
        //    var query =  _context.Users.GroupBy(x=>x.RollId)
        //        .Select(x=>new DashboardStatisticsModel
        //    {
        //        TotalStudent =x.Where(k=>k.RollId == 2).Count(),
        //        TotalTeacher =x.Where(k=>k.RollId == 3).Count(),
        //        TotalCourses = 0
        //    });

        //    result = await query.FirstOrDefaultAsync();/////////////////////////////
        //    return result;
        //}

        public async Task<IEnumerable<ListOfStudentModel>> GetAllStudentAsync()
        {
            {
                var students = await _context.Users.Include(x => x.Department).Where(x => x.RollId == 2)
                    .Select(x => new ListOfStudentModel
                    {
                        StudentName = x.FullName,
                        ReferenceNumber = x.ReferanceNumber,
                        StudentEmail = x.UserEmail,
                        PhoneNumber = x.UserPhone,
                        Department = x.Department.DepartmentName


                    }
                    )
                    .ToListAsync(); // Assuming RollId 2 represents students

                return students;
                //// return await _context.Users.FindAsync(id);
                //// return await _context.Users.FirstOrDefaultAsync(x=>x.UserId==id);
                //return await _context.Users.Where(x => x.RollId == 2)
                //.Select(x => new { }
                //);
            }
        }

        public async Task<IEnumerable<ListOfTeacherModel>> GetAllTeacherAsync()
        {
            {
                var teachers = await _context.Users.Include(x => x.Department).Where(x => x.RollId == 3)
                    .Select(x => new ListOfTeacherModel
                    {
                        TeacherName = x.FullName,
                        ReferenceNumber = x.ReferanceNumber,
                        TeacherEmail = x.UserEmail,
                        PhoneNumber = x.UserPhone,
                        Department = x.Department.DepartmentName


                    }
                    )
                    .ToListAsync(); // Assuming RollId 2 represents students

                return teachers;
                //// return await _context.Users.FindAsync(id);
                //// return await _context.Users.FirstOrDefaultAsync(x=>x.UserId==id);
                //return await _context.Users.Where(x => x.RollId == 2)
                //.Select(x => new { }
                //);
            }
        }

        public async Task<User> GetStudentByIdAsync(int id)
        {
            return await _context.Users.Include(x => x.Department).Where(x => x.UserId == id && x.RollId == 2).FirstOrDefaultAsync();

        }
        
         public async Task<User> GetTeacherByIdAsync(int id)
        {
            return await _context.Users.Include(x => x.Department).Where(x => x.UserId == id && x.RollId == 3).FirstOrDefaultAsync();

        }

        public async Task<int> AddNewUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user.UserId;
        }

        public async Task AddLoginAsync(Login login)
        {
            _context.Logins.Add(login);
            await _context.SaveChangesAsync();
        }

        //public async Task<List<DropDownListModel>> GetCollegesNameAsync()
        //{
        //    return await _context.Colleges
        //        .Select(c => new DropDownListModel { Id = c.CollegeId, Name = c.CollegeName })
        //        .ToListAsync();
        //}

        //public async Task<List<DropDownListModel>> GetDepartmentsNameAsync()
        //{
        //    return await _context.Departments
        //        .Select(d => new DropDownListModel { Id = d.DepartmentId, Name = d.DepartmentName })
        //        .ToListAsync();
        //}

        //public async Task<List<DropDownListModel>> GetRolesNameAsync()
        //{
        //    return await _context.Rolls
        //        .Select(r => new DropDownListModel { Id = r.RollId, Name = r.RollName })
        //        .ToListAsync();
        //}

        public async Task<List<UserDropdownModel>> GetUserDropDownAsync()
        {
            return await _context.Users
                .Select(u => new UserDropdownModel
                {
                    UserId = u.UserId,
                    FullName = u.FullName,
                    ReferenceNumber = u.ReferanceNumber
                })
                .ToListAsync();
        }

        public async Task<List<DropDownListModel>> GetTeacherDropDownAsync()
        {
            return await _context.Users
                .Where(x => x.RollId == 3)
                .Select(x => new DropDownListModel { Id = x.UserId , Name = x.FullName })
                .ToListAsync();
        }

        public void UpdateUserImagePath(int userId, string imagePath)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == userId);
            if (user != null)
            {
                user.UserImag = imagePath;
                _context.SaveChanges();
            }
        }


        public async Task<IEnumerable<TeacherPerformanceOverviewModel>> GetTeacherPerformanceOverviewAsync(int teacherId)
        {
            var performanceData = await (
                from section in _context.Sections
                join course in _context.Courses on section.CourseId equals course.CourseId
                join enrollment in _context.Enrollments on section.SectionId equals enrollment.SectionId into enrollments
                from enrollment in enrollments.DefaultIfEmpty()
                where section.TeacherId == teacherId
                group enrollment by new
                {
                    section.SectionNumber,
                    course.CourseName,
                    course.CourseNumber
                } into grouped
                select new TeacherPerformanceOverviewModel
                {
                    CourseName = grouped.Key.CourseName,
                    CourseNumber = grouped.Key.CourseNumber,
                    SectionNumber = grouped.Key.SectionNumber,
                    TotalStudent = grouped.Count(e => e != null),
                    AverageAttendance = grouped.Count(e => e != null) > 0
                        ? (double)_context.Attendances
                            .Where(a => grouped.Select(g => g.EnrollmentId).Contains(a.EnrollmentId))
                            .Count(a => a.Status == "Present")
                          / (grouped.Count(e => e != null) * grouped.Key.SectionNumber.Length) * 100 // Example calculation
                        : 0
                }
            ).ToListAsync();

            return performanceData;
        }

    }
}

