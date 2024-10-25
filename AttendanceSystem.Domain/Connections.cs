using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Domain
{
    internal class Connections
    {
        public const string sqlConnStr = """
            Server = HAMZAOMARY;
            Database = Attendance_Sys_DB;
            User Id = sa;
            Password = hamza@12345678;
            TrustServerCertificate = True;

            """;
    }
}

// ADD to sql connection string (sqlConnStr)
//Usert Id = ???;    User Id = sa;
//Password = ??????; Password = hamza@12345678;
//ممكن تحتاج ==> Presist Security Info = True;
