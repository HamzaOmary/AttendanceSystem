using AttendanceSystem.Domain.DomainModel;
using AttendanceSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Domain.Interfaces.Repository
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(int id);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
        
        Task <IEnumerable<ListOfStudentModel>> GetAllStudentAsync();
        Task <IEnumerable<ListOfTeacherModel>> GetAllTeacherAsync();
        Task<User> GetStudentByIdAsync(int id);
        Task<User> GetTeacherByIdAsync(int id);

        Task<int> AddNewUserAsync(User user);
        Task AddLoginAsync(Login login); 
        // To add login credentials
        // Task<List<DropDownListModel>> GetCollegesNameAsync();
        // Task<List<DropDownListModel>> GetDepartmentsNameAsync();
        // Task<List<DropDownListModel>> GetRolesNameAsync();
        Task<List<UserDropdownModel>> GetUserDropDownAsync();
        Task<List<DropDownListModel>> GetTeacherDropDownAsync();
        void UpdateUserImagePath(int userId, string imagePath);


        Task<IEnumerable<TeacherPerformanceOverviewModel>> GetTeacherPerformanceOverviewAsync(int teacherId);

    }

}




