using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Domain.Entities
{
    public class ClassRoom
    {
        public int ClassRoomId {  get; set; }
        public int ClassNumber { get; set; }

        public virtual ICollection<Section> Sections { get; set; }
    }
}
