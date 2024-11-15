using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Domain.Entities
{
    public class Section
    {
        //[Key]
        public int SectionId {  get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string SectionNumber { get; set; }
        public string SectionDays { get; set; }

        //[ForeignKey("course")]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }

        //[ForeignKey("class_room")]
        public int ClassRoomId { get; set; }
        public virtual ClassRoom ClassRoom { get; set; }




        public virtual ICollection<Enrollment> Enrollments { get; set; }    
    }
}
