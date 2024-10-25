using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Domain.Entities
{
    public class Roll
    {
        //[PrimaryKey]
        //[Key]
        public int RollId { get; set; }
        public string RollName { get; set; }
    }
}
