using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AttendanceSystem.Domain.Entities;
using AttendanceSystem.Domain.Interfaces.Repository;
using AttendanceSystem.Domain;

namespace AttendanceSystem.Infrastructure.Repositories
{
    public class SectionRepository : ISectionRepository
    {
        private readonly AppDbContext _context;

        public SectionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Section> GetSectionByIdAsync(int id)
        {
            // return await _context.Sections.FindAsync(id);
            return await _context.Sections.Where(x => x.SectionId == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Section>> GetAllSectionsAsync()
        {
            return await _context.Sections.ToListAsync();
        }

        public async Task AddSectionAsync(Section section)
        {
            await _context.Sections.AddAsync(section);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSectionAsync(Section section)
        {
            // _context.Sections.Update(section);
            //await _context.SaveChangesAsync();

            var sectionToUpdate = await _context.Sections.Where(x => x.SectionId == section.SectionId).FirstOrDefaultAsync();
            if (sectionToUpdate != null)
            {
                sectionToUpdate.StartDateTime=section.StartDateTime;
                sectionToUpdate.EndDateTime=section.EndDateTime;
                sectionToUpdate.SectionDays=section.SectionDays;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteSectionAsync(int id)
        {
            var sectionToDelete = await _context.Sections.FindAsync(id);
            if (sectionToDelete != null)
            {
                _context.Sections.Remove(sectionToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
