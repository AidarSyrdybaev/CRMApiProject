using CustomerManagementSystemBackendProject.DAL.Entities;
using CustomerManagementSystemBackendProject.DAL.Extensions.Check;
using CustomerManagementSystemBackendProject.DAL.Factories;
using Microsoft.Extensions.Hosting;
using NCrontab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerManagementSystemBackendProject.BL.Services
{
    public class LeadShcedulerService : BackgroundService
    {
        private CrontabSchedule _schedule;
        private DateTime _nextRun;
        private IApplicationDbContextFactory ApplicationDbContextFactory { get; set; }

        private string Schedule => "*/10 * * * * *"; //Runs every 10 seconds

        public LeadShcedulerService(IApplicationDbContextFactory applicationDbContextFactory)
        {
            ApplicationDbContextFactory = applicationDbContextFactory;
            _schedule = CrontabSchedule.Parse(Schedule, new CrontabSchedule.ParseOptions { IncludingSeconds = true });
            _nextRun = _schedule.GetNextOccurrence(DateTime.Now);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            do
            {
                var now = DateTime.Now;
                var nextrun = _schedule.GetNextOccurrence(now);
                if (now > _nextRun)
                {
                    LeadsProcess();
                    _nextRun = _schedule.GetNextOccurrence(DateTime.Now);
                }
                await Task.Delay(5000, stoppingToken); //5 seconds delay
            }
            while (!stoppingToken.IsCancellationRequested);
        }

        private void LeadsProcess()
        {
            using (var context = ApplicationDbContextFactory.Create())
            {
                var Leads = context.Leads.ToList();
                foreach (var Lead in Leads)
                    if (DateTime.Now < Lead.UpdateStatusDate && !context.LeadsNotificationsCheck(Lead.Id) && Lead.LeadStatusId != 5 && Lead.LeadStatusId != 6)
                    {
                        context.LeadsNotifies.Add(new LeadsNotify { LeadId = Lead.Id , Date = DateTime.Now});
                        context.SaveChanges();
                    }
            }
        }
    }
}
