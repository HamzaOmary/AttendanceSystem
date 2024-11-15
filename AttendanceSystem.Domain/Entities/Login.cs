using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Domain.Entities
{
    public class Login
    {
        //[Key]
        public int LoginId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }


        public virtual ICollection<User> Users { get; set; }
    }
}
