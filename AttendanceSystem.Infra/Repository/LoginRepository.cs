using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AttendanceSystem.Domain.Entities;
using AttendanceSystem.Domain.Interfaces.Repository;
using AttendanceSystem.Domain;
using System.Runtime.InteropServices;
using AttendanceSystem.Domain.DomainModel;
using static System.Collections.Specialized.BitVector32;

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

        public async Task<Login> GetLoginByUserIdAsync(int id)
        {
            // return await _context.Logins.FindAsync(id);
            return await _context.Logins.Where(x => x.UserId == id).FirstOrDefaultAsync();
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

            var loginToUpdate = await _context.Logins.Where(x => x.UserId == login.UserId).FirstOrDefaultAsync();
            if (loginToUpdate != null)
            {
                loginToUpdate.Username = login.Username;
                loginToUpdate.Password = login.Password;

                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdatePasswordAsync(UpdateLoginModel model)
        {
            // Retrieve the user by UserId
            var userLogin = await _context.Logins
                .Where(x => x.UserId == model.UserId)
                .FirstOrDefaultAsync();

            if (userLogin == null)
            {
                throw new Exception("User not found.");
            }

            // Validate old username and password
            if (userLogin.Username != model.OldUsername || userLogin.Password != model.OldPassword)
            {
                throw new Exception("Invalid old username or password.");
            }

            // Update password
            userLogin.Password = BCrypt.Net.BCrypt.HashPassword(model.NewPassword); //model.NewPassword;

            // Save changes
            await _context.SaveChangesAsync();
        }

        //public async Task UpdatePasswordAsync(UpdateLoginModel model)
        //{
        //    var passToUpdate = await _context.Logins.Where(x => x.UserId == model.UserId).FirstOrDefaultAsync();

        //    // _context.Logins.Update(login);
        //    //await _context.SaveChangesAsync();
        //   // Console.WriteLine(passToUpdate);


        //    //var NewPass = new Login
        //    //{
        //    //    Password = model.NewPassword
        //    //};

        //    if (passToUpdate != null && passToUpdate.Username == model.OldUsername && passToUpdate.Password == model.OldPassword)
        //    {
        //        //passToUpdate.Equals(model.NewPassword);
        //       // _context.Remove(passToUpdate.Password);
        //        var NewPsaaword = new Login
        //        {
        //            Username = model.OldUsername,
        //            Password = model.NewPassword//BCrypt.Net.BCrypt.HashPassword(model.NewPassword) //model.NewPassword
        //        };

        //        await _context.SaveChangesAsync();
        //    }
        //}





        public async Task DeleteLoginAsync(int id)
        {
            var loginToDelete = await _context.Logins.FindAsync(id);
            if (loginToDelete != null)
            {
                _context.Logins.Remove(loginToDelete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Login> GetByUsernameAsync(string username)
        {

             return await _context.Logins.Where(login => login.Username == username).FirstOrDefaultAsync();
            //_context.Logins.Update(login);
            //await _context.SaveChangesAsync();

            //var loginToUpdate = await _context.Logins.Where(x => x.LoginId == login.LoginId).FirstOrDefaultAsync();
            //if (loginToUpdate != null)
            //{
            //    loginToUpdate.Username = login.Username;
            //    loginToUpdate.Password = login.Password;

            //    await _context.SaveChangesAsync();
            //}
        }
    }
}