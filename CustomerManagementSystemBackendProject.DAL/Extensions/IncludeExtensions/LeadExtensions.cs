using CustomerManagementSystemBackendProject.DAL.Context;
using CustomerManagementSystemBackendProject.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerManagementSystemBackendProject.DAL.Extensions.IncludeExtensions
{
    public static class LeadExtensions
    {
        public static Lead LeadInclude(this ApplicationDbContext context, int Id)
        {
            return context.Leads
                .Where(i=> i.Id == Id)
                .Include(i => i.City)
                .Include(i => i.LeadStatus)
                .Include(i => i.Course)
                .FirstOrDefault();
            
        }
        public static List<Lead> LeadsInclude(this ApplicationDbContext context)
        {
            return context.Leads
                .Include(i => i.City)
                .Include(i => i.LeadStatus)
                .Include(i => i.Course)
                .ToList();

        }

        public static List<LeadsNotify> LeadsNotifyInclude(this ApplicationDbContext context)
        {
            return context.LeadsNotifies
                .Include(i => i.Lead)
                .Include(i => i.Lead.LeadStatus)
                .ToList();
        }

        //public static List<Lead> LeadsFilterInclude(this ApplicationDbContext context, int PageNumber, int PageSize, int? CityId, int? CourseId, int? LeadStatusId)
        //{
        //    return context.Leads
        //        .Where(i => CityId == null || CityId.Value == i.CityId)
        //        .Where(i => CourseId == null || CourseId.Value == i.CourseId)
        //        .Where(i => LeadStatusId == null || LeadStatusId.Value == i.LeadStatusId)
        //        .Skip((PageNumber - 1) * PageSize)
        //               .Take(PageSize)
        //                .Include(i => i.City)
        //                .Include(i => i.Course)
        //                .Include(i => i.LeadStatus)
        //                .OrderBy(i => i.LeadStatus)
        //                .ToList();
        //}

        public static List<Lead> LeadsFilterInclude(this ApplicationDbContext context, int PageNumber, int PageSize, int[] CitiesId, int[] CoursesId, int[] LeadStatusesId)
        {
            return context.Leads
                .Where(i => CitiesId == null || CitiesId.Any(a => a == i.CityId))
                .Where(i => CoursesId == null || CoursesId.Any(a => a == i.CourseId))
                .Where(i => LeadStatusesId == null || LeadStatusesId.Any(a => a == i.LeadStatusId))
                .Where(i => !i.IsArchive)
                .Skip((PageNumber - 1) * PageSize)
                       .Take(PageSize)
                        .Include(i => i.City)
                        .Include(i => i.Course)
                        .Include(i => i.LeadStatus)
                        .OrderBy(i => i.LeadStatus)
                        .ToList();
        }
    }
}
