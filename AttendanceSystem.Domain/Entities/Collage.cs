using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Domain.Entities
{
    public class Collage
    {
        public int CollageId { get; set; }
        public string CollageName { get; set; }
        //public int CourseCount { get; set; }//DTO OR RESPONCE
        //public int StudentCount { get; set; }
        public int DeanUserId { get; set; }
        public virtual User DeanUser { get; set; }

        //public ICollection<User> Students { get; set; }
        //public ICollection<Department> Departments { get; set; }
        //public ICollection<Course> Courses { get; set; }

    }
}
