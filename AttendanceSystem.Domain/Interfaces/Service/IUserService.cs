using AttendanceSystem.Domain.DomainModel;
using AttendanceSystem.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Domain.Interfaces.Service
{
    public interface IUserService
    {
        Task<User> GetUserByIdAsync(int id);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);

        Task<IEnumerable<ListOfStudentModel>> GetAllStudentAsync();
        Task<IEnumerable<ListOfTeacherModel>> GetAllTeacherAsync();

        Task<getUserInformationModel> GetStudentByIdAsync(int id);
        Task<getUserInformationModel> GetTeacherByIdAsync(int id);

        Task<int> AddNewUserAsync(AddUserModel model);
        //Task AddLoginAsync(Login login);
        //Task<List<DropDownListModel>> GetCollegesNameAsync();
        // Task<List<DropDownListModel>> GetDepartmentsNameAsync();
        // Task<List<DropDownListModel>> GetRolesNameAsync();
        Task<List<UserDropdownModel>> GetUserDropDownAsync();

        Task<List<DropDownListModel>> GetTeacherDropDownAsync();

        void UpdateUserImagePath(int userId, string imagePath);

        Task<IEnumerable<TeacherPerformanceOverviewModel>> GetTeacherPerformanceOverviewAsync(int teacherId);

    }
}
 