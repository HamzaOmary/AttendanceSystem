using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AttendanceSystem.Domain.Entities;
using AttendanceSystem.Domain.Interfaces.Repository;
using AttendanceSystem.Domain;
using AttendanceSystem.Domain.DomainModel;
using System.Text.RegularExpressions;

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
                
        public async Task<IEnumerable<TeachingInformationModel>> GetTeachingInformationByIdAsync(int teacherId)
        { 
            // return await _context.Sections.FindAsync(id);
            //var teacherSection = await _context.Sections.Include(c => c.Course).Where(x => x.TeacherId == teacherId).ToListAsync();
            //var sectionStudents = await _context.Enrollments.Where(x => x.UserId == teacherId ).CountAsync();

                var sectionsInfo = await (
            from enrollment in _context.Enrollments
            join section in _context.Sections on enrollment.SectionId equals section.SectionId
            join course in _context.Courses on section.CourseId equals course.CourseId
            where section.TeacherId == teacherId
            group enrollment by new
            {
                //section.SectionId,
                section.SectionNumber,
                section.StartDateTime,
                section.EndDateTime,
                section.SectionDays,
                course.CourseName,
                course.CourseNumber
            } into grouped
            select new TeachingInformationModel
            {
                CourseName = grouped.Key.CourseName,
                CourseNumber = grouped.Key.CourseNumber,
                SectionNumber = grouped.Key.SectionNumber,
                TotalStudent = grouped.Count(), /// كيف اخليه يعبي قيمه صفر اذا ما في يوزر
                Schedule = FormatSchedule(grouped.Key.StartDateTime, grouped.Key.EndDateTime, grouped.Key.SectionDays)
            }
            ).ToListAsync();

                return sectionsInfo;




        }

        

        private static string FormatSchedule(DateTime startDateTime, DateTime endDateTime, string sectionDays)
        {
            // Map day abbreviations if needed (e.g., Sun/Wed → Mon, Wed)
            var dayMapping = new Dictionary<string, string>
            {
                { "Sun", "Sun" },
                { "Mon", "Mon" },
                { "Tue", "Tue" },
                { "Wed", "Wed" },
                { "Thu", "Thu" },
                { "Fri", "Fri" },
                { "Sat", "Sat" }
            };

            // Split sectionDays by '/' and replace with mapped days
            var days = string.Join(", ", sectionDays.Split('/').Select(day => dayMapping.ContainsKey(day) ? dayMapping[day] : day));

            // Format the time (e.g., 10:00 AM - 12:00 PM)
            string time = $"{startDateTime.ToString("hh:mm tt")} to {endDateTime.ToString("hh:mm tt")}";

            // Combine days and time
            return $"{days} - {time}";
        }

        //section.StartDateTime.ToString("HH:mm:ss") >= x.StartDateTime.ToString("HH:mm:ss")
        //x.SectionDays.Split(',').Any(day => section.SectionDays.Split(',').Contains(day)
        public async Task<bool> FindSectionConflictAsync(Section section)
        {

            return await _context.Sections.AnyAsync(x =>
                    // Check for classroom conflicts
                    (
                     x.ClassRoomId == section.ClassRoomId &&
                     x.SectionDays == section.SectionDays && // Same days
                     (
                         // Time overlaps
                         (section.StartDateTime.TimeOfDay >= x.StartDateTime.TimeOfDay && section.StartDateTime.TimeOfDay < x.EndDateTime.TimeOfDay) ||
                         (section.EndDateTime.TimeOfDay > x.StartDateTime.TimeOfDay && section.EndDateTime.TimeOfDay <= x.EndDateTime.TimeOfDay) ||
                         (section.StartDateTime.TimeOfDay <= x.StartDateTime.TimeOfDay && section.EndDateTime.TimeOfDay >= x.EndDateTime.TimeOfDay)
                     )
                    ) 
                    ||
                    // Check for instructor conflicts
                    (x.TeacherId == section.TeacherId &&
                     x.SectionDays == section.SectionDays && // Same days
                     (
                         // Time overlaps
                         (section.StartDateTime.TimeOfDay >= x.StartDateTime.TimeOfDay && section.StartDateTime.TimeOfDay < x.EndDateTime.TimeOfDay) ||
                         (section.EndDateTime.TimeOfDay > x.StartDateTime.TimeOfDay && section.EndDateTime.TimeOfDay <= x.EndDateTime.TimeOfDay) ||
                         (section.StartDateTime.TimeOfDay <= x.StartDateTime.TimeOfDay && section.EndDateTime.TimeOfDay >= x.EndDateTime.TimeOfDay)
                     )
                    )
               
            );

            //return await _context.Sections.Where(x => x.ClassRoomId == section.ClassRoomId 
            //                                     && x.SectionDays.Split(',').Any(day => section.SectionDays.Split(',').Contains(day)) 
            //                                     && (
            //                                            (section.StartDateTime.TimeOfDay > x.StartDateTime.TimeOfDay
            //                                         || (x.StartDateTime.ToString("HH:mm:ss") >= section.)


            //                                        )
        }
    }
}
