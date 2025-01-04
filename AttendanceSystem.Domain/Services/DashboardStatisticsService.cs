using AttendanceSystem.Domain.DomainModel;
using AttendanceSystem.Domain.Interfaces.Repository;
using AttendanceSystem.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Domain.Services
{
    public class DashboardStatisticsService : IDashboardStatisticsService
    {
        private readonly IDashboardStatisticsRepository _repository;

        public DashboardStatisticsService(IDashboardStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<DashboardStatisticsModel> GetDashboardStatisticsAsync()
        {
            return await _repository.GetDashboardStatisticsAsync();
        }
    }
}
