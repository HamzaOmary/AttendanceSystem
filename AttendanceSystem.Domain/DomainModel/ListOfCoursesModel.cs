using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Domain.DomainModel
{
    public class ListOfCoursesModel
    {
        public string CourseName { get; set; }
        public string CourseNumber { get; set; }
        public string Department { get; set; }
        public int Credits { get; set; }
    }
}
