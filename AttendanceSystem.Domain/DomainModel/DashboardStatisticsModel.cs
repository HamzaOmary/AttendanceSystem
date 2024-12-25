using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Domain.DomainModel
{
    public class DashboardStatisticsModel
    {
        public int TotalStudent {  get; set; }
        public int TotalTeacher {  get; set; }
        public int TotalCourses {  get; set; }
    }
}
