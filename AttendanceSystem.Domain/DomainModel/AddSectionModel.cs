using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Domain.DomainModel
{
    public class AddSectionModel
    {
        public string StartDateTime { get; set; } // Concatenated StartDate and StartTime
        public string EndDateTime { get; set; }   // Concatenated EndDate and EndTime
        public string SectionNumber { get; set; }
        public string SectionDays { get; set; } // Days as a single concatenated string
        public int CourseId { get; set; }
        public int ClassRoomId { get; set; }
        public int TeacherId { get; set; }

    }
}
