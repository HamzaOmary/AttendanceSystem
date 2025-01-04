using AttendanceSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Domain.DomainModel
{
    public class UpdateLoginModel
    {
        public string OldUsername { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public int UserId { get; set; }

        //public User User { get; set; } // Navigation property
    }
}
