using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Domain.DomainModel
{
    public class StudentAttendanceOverviewModel
    {
        public string CourseName { get; set; }
        public int TotalClasses { get; set; }
        public int ClassesAttended { get; set; }
        public double AttendancePercentage { get; set; }

    }
}
