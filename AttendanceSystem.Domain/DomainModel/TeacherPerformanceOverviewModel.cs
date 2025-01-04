using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Domain.DomainModel
{
    public class TeacherPerformanceOverviewModel
    {
        public string CourseName { get; set; }
        public string CourseNumber { get; set; }
        public string SectionNumber { get; set; }
        public int TotalStudent { get; set; }
        public double AverageAttendance { get; set; } // Average Attendance (%)
    }
}
