using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Domain.Entities
{
    public  class User
    {
        //[Key]
       // [PrimaryKey("User_Id")]
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }
        public string ReferanceNumber { get; set; }//string 
        public string UserImag { get; set; }//???????
        public DateTime CreateDate { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string JobTitel { get; set; }//allow null

        //[ForeignKey("collage")]
        public int CollageId { get; set; }
        public virtual Collage Collage { get; set; }

        //[ForeignKey("department")]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        //[ForeignKey("roll")]
        public int RollId { get; set; }
        public virtual Roll Roll { get; set; }

        public int LoginId { get; set; }
        public virtual Login Login { get; set; }
        //public ICollection<Course> courses { get; set; }
        //public ICollection<Enrollment> enrollments { get; set; }
    }
}
