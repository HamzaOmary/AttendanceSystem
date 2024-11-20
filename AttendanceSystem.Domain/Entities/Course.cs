using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Domain.Entities
{
    public class Course
    {

        public int CourseId { get; set; }
        public string CourseName { get; set; }
        //public string Cour_Days { get; set; }
        public string CourseNumber { get; set; }

        // رقم الشعبة 
        public int CreditHour { get; set; }

       // [ForeignKey("user")]
        //public int TeacherId { get; set; }
        //public virtual User Teacher { get; set; }
        
   
         
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }


        public virtual ICollection<Section> Sections { get; set; }
    }
}
