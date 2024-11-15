using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Domain.Entities
{
    public class Department
    {
        //[Key]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int HeadUserId { get; set; }

        //[ForeignKey("collage")]
        public int CollegeId { get; set; }
        public virtual College College { get; set; } 

        public virtual User HeadUser { get; set; } // change it to string if have a problem

        public virtual ICollection<Course> Courses { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
