using CustomerManagementSystemBackendProject.DAL.Context;
using CustomerManagementSystemBackendProject.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerManagementSystemBackendProject.DAL.Extensions.IncludeExtensions
{
    public static class GroupExtensions
    {
        public static Group IncludeGroup(this ApplicationDbContext context, int Id)
        {
            return context.Groups
                .Where(i => i.Id == Id)
                .Include(i => i.Teacher.Course.City)
                .Include(i => i.Teacher.Course)
                .FirstOrDefault();
        }

        public static List<Group> IncludeArchiveGroups(this ApplicationDbContext context)
        {
            return context.Groups
                .Where(i => i.IsArchive)
                .Include(i => i.Teacher.Course.City)
                .Include(i => i.Teacher.Course)
                .ToList();
        }
        public static List<Group> IncludeTeacherGroup(this ApplicationDbContext context, int Id)
        {
            return context.Groups
                .Where(i => i.TeacherId == Id)
                .Include(i => i.Teacher.Course)
                .Include(i => i.Teacher)
                .Include(i => i.Teacher.Course.City)
                .ToList();
        }
        public static List<Group> GroupsInclude(this ApplicationDbContext context)
        {
            return context.Groups
                .Where(i => !i.IsArchive)
                .Include(i => i.Teacher.Course)
                .Include(i => i.Teacher)
                .Include(i => i.Teacher.Course.City)
                .ToList();

        }

        public static Group IncludeCourse(this ApplicationDbContext context, int Id)
        {
            return context.Groups
                .Include(i => i.Teacher.Course.City)
                .Include(i => i.Teacher.Course)
                .FirstOrDefault();
        }
        public static List<Group> GroupsFilterInclude(this ApplicationDbContext context, int[] CitiesId, int [] CoursesId, string GroupName, DateTime? StartDate, DateTime? EndDate)
        {
            return context.Groups
               .Where(i => CitiesId == null || CitiesId.Any(a => a == i.Teacher.Course.CityId))
               .Where(i => CoursesId == null || CoursesId.Any(a => a == i.Teacher.Course.Id))
               .Where(i => GroupName == null || i.Name == GroupName)
               .Where(i => (StartDate == null || StartDate < i.StartDate) || (EndDate == null || EndDate > i.EndDate))
               .Where(i => !i.IsArchive)
                       .Include(i => i.Teacher.Course.City)
                       .Include(i => i.Teacher.Course)
                       .Include(i => i.StudentGroups)
                       .Include(i => i.Teacher.Course)
                       .OrderBy(i => i.Name)
                       .ToList();
        }

        public static List<StudentGroup> StudentGroupsFilterInclude(this ApplicationDbContext context, int[] CitiesId, int[] CoursesId, string GroupName, DateTime? StartDate, DateTime? EndDate)
        {
            return context.StudentGroups
               .Where(i => CitiesId == null || CitiesId.Any(a => a == i.Group.Teacher.City.Id))
               .Where(i => CoursesId == null || CoursesId.Any(a => a == i.Group.Teacher.Course.Id))
               .Where(i => GroupName == null || i.Group.Name == GroupName)
               .Where(i => (StartDate == null || StartDate < i.Group.StartDate) || (EndDate == null || EndDate > i.Group.EndDate))
               .Where(i => !i.IsArchive)
                       .Include(i => i.Group.Teacher.Course.City)
                       .Include(i => i.Group.Teacher.Course)
                       .Include(i => i.Group.StudentGroups)
                       .Include(i => i.Payments)
                       .Include(i => i.Group)
                       .Include(i => i.Group.Teacher.Course)
                       .OrderBy(i => i.Group.Name)
                       .ToList();
        }
    }
}
