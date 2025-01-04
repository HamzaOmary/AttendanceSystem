using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Domain.DomainModel
{
    public class DashboardStatisticsModel
    {
        public int TotalStudent {  get; set; }
        public int TotalTeacher {  get; set; }
        public int TotalCourses {  get; set; }
        public double AttendanceRate { get; set; }
        public List<WeeklyAttendance> WeeklyAttendance { get; set; }
    }

    public class WeeklyAttendance
    {
        public string Day { get; set; }
        public double AttendanceRate { get; set; }
    }

}
