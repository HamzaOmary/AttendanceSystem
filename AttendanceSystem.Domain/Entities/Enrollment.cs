using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Domain.Entities
{
    public class Enrollment
    {
        [Key]
        public int EnrollmentId { get; set; }

        [ForeignKey("user")]
        public int userId { get; set; }
        public User user { get; set; }

        [ForeignKey("section")]
        public int sectionId { get; set; }
        public Section section { get; set; }
        //attendance list
    }
}
