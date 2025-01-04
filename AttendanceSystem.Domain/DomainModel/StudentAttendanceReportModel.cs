using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Domain.DomainModel
{
    public class StudentAttendanceReportModel
    {
      
        public List<SubjectAttendanceModel> SubjectAttendance { get; set; }
        public List<DateWiseAttendanceModel> DateWiseAttendance { get; set; }
        

    }
    public class SubjectAttendanceModel
    {
        public string CourseName { get; set; }
        public int TotalClasses { get; set; }
        public int ClassesAttended { get; set; }
        public double AttendancePercentage { get; set; }
    }

    public class DateWiseAttendanceModel
    {
        public string CourseName { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }

}
