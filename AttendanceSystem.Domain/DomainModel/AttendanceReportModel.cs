using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Domain.DomainModel
{
    public class AttendanceReportModel
    {
        public string StudentName { get; set; }
        public string ReferenceNumber { get; set; }
        public string CourseName { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; } // Present, Absent, Late

    }
}
