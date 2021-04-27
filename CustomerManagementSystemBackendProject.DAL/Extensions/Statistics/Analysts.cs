using CustomerManagementSystemBackendProject.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerManagementSystemBackendProject.DAL.Extensions.Statistics
{
    public static class Analysts
    {
        public static List<(string, int)> StatusesAnalys(this ApplicationDbContext context, DateTime? StartDate, DateTime? EndDate, int? CityId)
        {
            var QueryResult = context.Leads
                 .Where(i => (!StartDate.HasValue || i.CreateDate > StartDate) && (!EndDate.HasValue || i.CreateDate < EndDate))
                 .Where(i => !CityId.HasValue || i.CityId == CityId)
                 .Join(context.LeadStatuses, L => L.LeadStatusId, LSt => LSt.Id, (L, LSt) => new { StatusName = LSt.Name })
                 .GroupBy(i => i.StatusName)
                 .Select(g => new { g.Key, Count = g.Count() }).ToList();

            return QueryResult.Select(i => (i.Key, i.Count)).ToList();

        }

        public static List<(string, int)> FailureStatusesAnalys(this ApplicationDbContext context, DateTime? StartDate, DateTime? EndDate, int? CityId)
        {
            var QueryResult = context.Leads
                 .Where(i => (!StartDate.HasValue || i.CreateDate > StartDate) && (!EndDate.HasValue || i.CreateDate < EndDate))
                 .Where(i => !CityId.HasValue || i.CityId == CityId)
                 .Where(i => i.LeadFailureStatusId.HasValue)
                 .Join(context.leadFailureStatuses, L => L.LeadFailureStatusId, LSt => LSt.Id, (L, LSt) => new { StatusName = LSt.Name })
                 .GroupBy(i => i.StatusName)
                 .Select(g => new { g.Key, Count = g.Count() }).ToList();

            return QueryResult.Select(i => (i.Key, i.Count)).ToList();
        }

        public static List<(string, int)> LeadsByCoursesAnalys(this ApplicationDbContext context, DateTime? StartDate, DateTime? EndDate, int? CityId)
        { 
            var QueryResult = context.Courses.
                Join(context.Leads, C => C.Id, Leads => Leads.CourseId, (C, Leads) => new { Leads.Id, Leads.CreateDate, Leads.CityId, C.Name})
               . Where(i => (!StartDate.HasValue || i.CreateDate > StartDate) && (!EndDate.HasValue || i.CreateDate < EndDate))
                 .Where(i => !CityId.HasValue || i.CityId == CityId)
                 .GroupBy(i => i.Name)
                 .Select(g => new { g.Key, Count = g.Count() }).ToList();

            return QueryResult.Select(i => (i.Key, i.Count)).ToList();

        }

        public static List<(string, int)> LeadsBySourceAnalys(this ApplicationDbContext context, DateTime? StartDate, DateTime? EndDate, int? CityId)
        {
            var QueryResult = context.Leads
               .Where(i => (!StartDate.HasValue || i.CreateDate > StartDate) && (!EndDate.HasValue || i.CreateDate < EndDate))
                 .Where(i => !CityId.HasValue || i.CityId == CityId)
                 .GroupBy(i => i.Source)
                 .Select(g => new { g.Key, Count = g.Count() }).ToList();

            return QueryResult.Select(i => (i.Key, i.Count)).ToList();

        }

        public static (int, int) LeadsByFailureAndSuccesAnalys(this ApplicationDbContext context, DateTime? StartDate, DateTime? EndDate, int? CityId)
        {
            var Count = context.Leads
               .Where(i => i.LeadFailureStatusId.HasValue)
               .Count();

            var CountS = context.Leads
                .Include(i => i.LeadStatus)
                .Where(i => i.LeadStatus.Name == "Успешная сделка").Count();

            return (Count, CountS);

        }


    }
}
