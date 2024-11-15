using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AttendanceSystem.Domain.Entities;
using AttendanceSystem.Domain.Interfaces.Repository;
using AttendanceSystem.Domain;

namespace AttendanceSystem.Infrastructure.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly AppDbContext _context;

        public LoginRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Login> GetLoginByIdAsync(int id)
        {
            // return await _context.Logins.FindAsync(id);
            return await _context.Logins.Where(x => x.LoginId == id).FirstOrDefaultAsync();
        }

        //public async Task<IEnumerable<Login>> GetAllLoginsAsync()
        //{
        //    return await _context.Logins.ToListAsync();
        //}

        public async Task AddLoginAsync(Login login)
        {
            await _context.Logins.AddAsync(login);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateLoginAsync(Login login)
        {
            //_context.Logins.Update(login);
            //await _context.SaveChangesAsync();

             var loginToUpdate = await _context.Logins.Where(x => x.LoginId == login.LoginId).FirstOrDefaultAsync();
            if (loginToUpdate != null)
            {
                loginToUpdate.Username = login.Username;
                loginToUpdate.Password = login.Password;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteLoginAsync(int id)
        {
            var loginToDelete = await _context.Logins.FindAsync(id);
            if (loginToDelete != null)
            {
                _context.Logins.Remove(loginToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}