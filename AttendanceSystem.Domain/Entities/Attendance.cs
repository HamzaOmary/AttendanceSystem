using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Domain.Entities
{
    public class Attendance
    {
        public int AttendanceId { get; set; }
        public string Status { get; set; }
        public DateTime Date {  get; set; }

        public int UserId {  get; set; }
        public virtual User User { get; set; }

        public int EnrollmentId {  get; set; }
        public virtual Enrollment Enrollment { get; set; }
    }
}
