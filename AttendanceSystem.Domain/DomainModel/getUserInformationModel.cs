using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Domain.DomainModel
{
    public class getUserInformationModel
    {
        //public int UserId { get; set; }
        public string FullName { get; set; }
        public string Major { get; set; }
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }
        public string ReferanceNumber { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public DateTime CreateDate { get; set; }

        public string UserImag { get; set; }

    }
}
