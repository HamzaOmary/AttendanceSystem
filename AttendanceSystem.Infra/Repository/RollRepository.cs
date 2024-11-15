using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AttendanceSystem.Domain.Entities;
using AttendanceSystem.Domain.Interfaces.Repository;
using AttendanceSystem.Domain;

namespace AttendanceSystem.Infrastructure.Repositories
{
    public class RollRepository : IRollRepository
    {
        private readonly AppDbContext _context;

        public RollRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Roll> GetRollByIdAsync(int id)
        {
            //return await _context.Rolls.FindAsync(id);
            return await _context.Rolls.Where(x => x.RollId == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Roll>> GetAllRollsAsync()
        {
            return await _context.Rolls.ToListAsync();
        }

        public async Task AddRollAsync(Roll roll)
        {
            await _context.Rolls.AddAsync(roll);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRollAsync(Roll roll)
        {
            // _context.Rolls.Update(roll);
            // await _context.SaveChangesAsync();

            var RollToUpdate = await _context.Rolls.Where(x => x.RollId == roll.RollId).FirstOrDefaultAsync();
            if (RollToUpdate != null)
            {

                RollToUpdate.RollName = roll.RollName;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteRollAsync(int id)
        {
            var rollToDelete = await _context.Rolls.FindAsync(id);
            if (rollToDelete != null)
            {
                _context.Rolls.Remove(rollToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}