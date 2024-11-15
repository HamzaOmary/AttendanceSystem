using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Domain.Entities
{
    public class College
    {
        public int CollegeId { get; set; }
        public string CollegeName { get; set; }
        //public int CourseCount { get; set; }//DTO OR RESPONCE
        //public int StudentCount { get; set; }
        public int DeanUserId { get; set; }
        public virtual User DeanUser { get; set; } // change it to string if have a problem
        //اسم الكلاس معه virtual

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Department> Departments { get; set; }


        //public ICollection<User> Students { get; set; }
        //public ICollection<Course> Courses { get; set; }

    }
}
