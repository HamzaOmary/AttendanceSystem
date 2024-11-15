using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AttendanceSystem.Domain.Entities;
using AttendanceSystem.Domain.Interfaces.Repository;
using AttendanceSystem.Domain;

namespace AttendanceSystem.Infrastructure.Repositories
{
    public class ClassRoomRepository : IClassRoomRepository
    {
        private readonly AppDbContext _context;

        public ClassRoomRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ClassRoom> GetClassRoomByIdAsync(int id)
        {
            // return await _context.ClassRooms.FindAsync(id);
            return await _context.ClassRooms.Where(x => x.ClassRoomId == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ClassRoom>> GetAllClassRoomsAsync()
        {
            return await _context.ClassRooms.ToListAsync();
        }

        public async Task AddClassRoomAsync(ClassRoom classRoom)
        {
            await _context.ClassRooms.AddAsync(classRoom);
            await _context.SaveChangesAsync();
        }

        //public async Task UpdateClassRoomAsync(ClassRoom classRoom)
        //{
        //    _context.ClassRooms.Update(classRoom);
        //    await _context.SaveChangesAsync();
        //}

        public async Task DeleteClassRoomAsync(int id)
        {
            var classRoomToDelete = await _context.ClassRooms.FindAsync(id);
            if (classRoomToDelete != null)
            {
                _context.ClassRooms.Remove(classRoomToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}