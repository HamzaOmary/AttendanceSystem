using AttendanceSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Domain.Interfaces.Service
{
    public interface IClassRoomService
    {
        Task<ClassRoom> GetClassRoomByIdAsync(int id);
        Task<IEnumerable<ClassRoom>> GetAllClassRoomsAsync();
        Task CreateClassRoomAsync(ClassRoom classRoom);
        
        //Task UpdateClassRoomAsync(ClassRoom classRoom);
        Task DeleteClassRoomAsync(int id);
    }
}
