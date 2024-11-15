using AttendanceSystem.Domain.Entities;
using AttendanceSystem.Domain.Interfaces.Repository;
using AttendanceSystem.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Domain.Services
{
    public class ClassRoomService :IClassRoomService
    {
        private readonly IClassRoomRepository _classRoomRepository;

        public ClassRoomService(IClassRoomRepository classRoomRepository)
        {
            _classRoomRepository = classRoomRepository;
        }

        public async Task<ClassRoom> GetClassRoomByIdAsync(int id)
        {
            return await _classRoomRepository.GetClassRoomByIdAsync(id);
        }

        public async Task<IEnumerable<ClassRoom>> GetAllClassRoomsAsync()
        {
            return await _classRoomRepository.GetAllClassRoomsAsync();
        }

        public async Task CreateClassRoomAsync(ClassRoom classRoom)
        {
            await _classRoomRepository.AddClassRoomAsync(classRoom);
        }

        //public async Task UpdateClassRoomAsync(ClassRoom classRoom)
        //{
        //    await _classRoomRepository.UpdateClassRoomAsync(classRoom);
        //}

        public async Task DeleteClassRoomAsync(int id)
        {
            await _classRoomRepository.DeleteClassRoomAsync(id);
        }
    }
}
