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
        //[Key]
        public int EnrollmentId { get; set; }

        //[ForeignKey("user")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        //[ForeignKey("section")]
        public int SectionId { get; set; }
        public virtual Section Section { get; set; }
        //attendance list

       public virtual ICollection<Attendance> Attendances { get; set; }
    }
}
