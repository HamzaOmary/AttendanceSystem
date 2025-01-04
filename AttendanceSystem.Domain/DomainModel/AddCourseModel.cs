using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Domain.DomainModel
{
    public class AddCourseModel
    {
        public string CourseName { get; set; }
        public string CourseNumber { get; set; }
        public int CreditHour { get; set; }
        public int DepartmentId { get; set; }
        
    }
}
