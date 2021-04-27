using CustomerManagementSystemBackendProject.DAL.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.BL.Services
{
    public class StatisticsService
    {
        private readonly IApplicationDbContextFactory _applicationDbContextFactory;

        public StatisticsService(IApplicationDbContextFactory applicationDbContextFactory)
        {
            _applicationDbContextFactory = applicationDbContextFactory;
        }
    }
}
