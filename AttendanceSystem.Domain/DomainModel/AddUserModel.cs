using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Domain.DomainModel
{
    public class AddUserModel
    {
        public string FullName { get; set; }
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }
        public string ReferanceNumber { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string JobTitle { get; set; }
        public int CollegeId { get; set; }
        public int DepartmentId { get; set; }
        public int RollId { get; set; }
    }
}
