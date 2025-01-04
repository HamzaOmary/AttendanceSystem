using AttendanceSystem.Domain.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Domain.Interfaces.Service
{
    public interface IDashboardStatisticsService
    {
        Task<DashboardStatisticsModel> GetDashboardStatisticsAsync();
    }
}
