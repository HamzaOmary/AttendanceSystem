using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Domain.DomainModel
{
    public class TeachingInformationModel
    {
        public string CourseName { get; set; }
        public string CourseNumber { get; set; }
        public string SectionNumber { get; set; }
        public int TotalStudent { get; set; }
        public string Schedule { get; set; }

       // public List<TeachingInformationModel> Sections { get; set; }
    }
}
