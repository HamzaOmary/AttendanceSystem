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
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.Include(x=>x.College).ToListAsync();
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
               
                userToUpdate.FullName=user.FullName;
                userToUpdate.UserEmail=user.UserEmail;
                userToUpdate.UserPhone=user.UserPhone;
                userToUpdate.UserImag=user.UserImag;
                userToUpdate.Address=user.Address;
                userToUpdate.JobTitel=user.JobTitel;

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

        public async Task<DashboardStatisticsModel> GetDashboardStatistics()
        {
            var result = new DashboardStatisticsModel();
            var query =  _context.Users.GroupBy(x=>x.RollId)
                .Select(x=>new DashboardStatisticsModel
            {
                TotalStudent =x.Where(k=>k.RollId == 2).Count(),
                TotalTeacher =x.Where(k=>k.RollId == 3).Count(),
                TotalCourses =0
            });

            result = await query.FirstOrDefaultAsync();/////////////////////////////
            return result;
        }
    }
}

