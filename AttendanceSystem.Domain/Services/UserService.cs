using AttendanceSystem.Domain.DomainModel;
using AttendanceSystem.Domain.Entities;
using AttendanceSystem.Domain.Interfaces.Repository;
using AttendanceSystem.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

       // private readonly string _imageFolderpath;

     

        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;

            //_imageFolderpath = configuration["ImageSttings:ImageFolderPath"];

            //if (string.IsNullOrEmpty(_imageFolderpath))
            //{
            //    throw new Exception("Image folder path is not configured.");
            //}


        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task CreateUserAsync(User user)
        {
            await _userRepository.AddUserAsync(user);
        }

        public async Task UpdateUserAsync(User user)
        {
            await _userRepository.UpdateUserAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteUserAsync(id);
        }

        public async Task<IEnumerable<ListOfStudentModel>> GetAllStudentAsync()
        {
            return await _userRepository.GetAllStudentAsync();
        }

        public async Task<IEnumerable<ListOfTeacherModel>> GetAllTeacherAsync()
        {
            return await _userRepository.GetAllTeacherAsync();
        }


        public async Task<getUserInformationModel> GetStudentByIdAsync(int id)
        {
            var user = await _userRepository.GetStudentByIdAsync(id);

            if (user == null)
            {
                return null;
            }

            
            // Map User entity to GetUserDto
            return new getUserInformationModel
            {
                FullName = user.FullName,
                Major = user.JobTitel,
                UserEmail = user.UserEmail,
                UserPhone = user.UserPhone,
                ReferanceNumber = user.ReferanceNumber,
                Gender = user.Gender,
                Address = user.Address,
                CreateDate = user.CreateDate,
                UserImag = user.UserImag
               
                //    //FullName = $"{user.FirstName} {user.LastName}",
            };

        }


        public async Task<getUserInformationModel> GetTeacherByIdAsync(int id)
        {
            var user = await _userRepository.GetTeacherByIdAsync(id);

            if (user == null)
            {
                return null;
            }

            // Map User entity to GetUserDto
            return new getUserInformationModel
            {
                FullName = user.FullName,
                Major = user.JobTitel,
                UserEmail = user.UserEmail,
                UserPhone = user.UserPhone,
                ReferanceNumber = user.ReferanceNumber,
                Gender = user.Gender,
                Address = user.Address,
                CreateDate = user.CreateDate,
                UserImag = user.UserImag
                //    //FullName = $"{user.FirstName} {user.LastName}",
            };

        }

        public async Task<int> AddNewUserAsync(AddUserModel model)
        {
            // Generate username from FullName (first name before the first space)
            var username = model.FullName.Split(' ')[0];

            // Use ReferanceNumber as password
            var password = model.ReferanceNumber;

            var user = new User
            {
                FullName = model.FullName,
                UserEmail = model.UserEmail,
                UserPhone = model.UserPhone,
                ReferanceNumber = model.ReferanceNumber,
                Address = model.Address,
                Gender = model.Gender,
                JobTitel = model.JobTitle,
                CreateDate = DateTime.Now,
                CollegeId = model.CollegeId,
                DepartmentId = model.DepartmentId,
                RollId = model.RollId,
                UserImag = "nullss" // No image at this stage
            };

            //return await _userRepository.AddNewUserAsync(user);

            var userId = await _userRepository.AddNewUserAsync(user);

            if (userId > 0)
            {
                var login = new Login
                {
                    Username = username,
                    Password = BCrypt.Net.BCrypt.HashPassword(password), //Hashing password,
                    UserId = userId
                };

                await _userRepository.AddLoginAsync(login);
            }

            return userId;
        }

        //public async Task<List<DropDownListModel>> GetCollegesNameAsync()
        //{
        //    return await _userRepository.GetCollegesNameAsync();
        //}

        //public async Task<List<DropDownListModel>> GetDepartmentsNameAsync()
        //{
        //    return await _userRepository.GetDepartmentsNameAsync();
        //}

        //public async Task<List<DropDownListModel>> GetRolesNameAsync()
        //{
        //    return await _userRepository.GetRolesNameAsync();
        //}

        public async Task<List<UserDropdownModel>> GetUserDropDownAsync()
        {
            return await _userRepository.GetUserDropDownAsync();
        }

        public async Task<List<DropDownListModel>> GetTeacherDropDownAsync()
        {
            return await _userRepository.GetTeacherDropDownAsync();
        }


        public void UpdateUserImagePath(int userId, string imagePath)
        {
            _userRepository.UpdateUserImagePath(userId, imagePath);
        }

        public async Task<IEnumerable<TeacherPerformanceOverviewModel>> GetTeacherPerformanceOverviewAsync(int teacherId)
        {
            return await _userRepository.GetTeacherPerformanceOverviewAsync(teacherId);
        }
    }
}
