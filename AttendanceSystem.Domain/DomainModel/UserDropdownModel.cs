using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Domain.DomainModel
{
    public class UserDropdownModel
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string ReferenceNumber { get; set; }
    }
}
