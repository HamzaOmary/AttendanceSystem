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
        [Key]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int HeadUserId { get; set; }

        [ForeignKey("collage")]
        public int CollageId { get; set; }
        public Collage Collage { get; set; }
        public User HeadUser { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
