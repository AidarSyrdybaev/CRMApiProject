using CustomerManagementSystemBackendProject.DAL.Context;
using CustomerManagementSystemBackendProject.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerManagementSystemBackendProject.DAL.Extensions.IncludeExtensions
{
    public static class CityExtensions
    {
        public static List<City> CitiesInclude(this ApplicationDbContext context)
        {
            return context.Cities
                .Include(i => i.Courses)
                .ToList();

        }

        public static List<(int Id, string Name, DateTime? DateTime, int Count)> GroupCountByCity(this ApplicationDbContext context)
        {
            var QueryResult = context.Groups.Join(context.Teachers, g => g.TeacherId, t => t.Id, (g, t) => new { Name = g.Name, t.CourseId}).
                Join(context.Courses, g => g.CourseId, c => c.Id, (g, c) => new { GroupName = g.Name, CityId = c.CityId })
                .Join(context.Cities, GT => GT.CityId, c => c.Id, (GT, c) => new { GroupName = GT.GroupName, CityId = c.Id })
                .GroupBy(i => i.CityId).Select(g => new { g.Key, Count = g.Count() }).ToList();


            //GroupBy(i => i.Teacher.City.Name).Select(g => new { g.Key, Count = g.Count() }).ToList();

            var FinalResult = QueryResult.Join(context.Cities, g => g.Key, c => c.Id, (g, c) => new { Id = c.Id, Name = c.Name, CreateDate = c.CreateDate, GroupsCount = g.Count }).ToList();
                
                
            return FinalResult.Select(i => (i.Id, i.Name, i.CreateDate, i.GroupsCount)).ToList();
        }
    }
}
