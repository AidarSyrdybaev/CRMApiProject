using CustomerManagementSystemBackendProject.DAL.Context;
using CustomerManagementSystemBackendProject.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerManagementSystemBackendProject.DAL.Extensions.IncludeExtensions
{
    public static class StudentExtensions
    {
        public static Student StudentInclude(this ApplicationDbContext context, int Id)
        {
            return context.Students
                .Where(i => i.Id == Id)
                .Include(i => i.City)
                .FirstOrDefault();

        }
        public static List<Student> StudentsInclude(this ApplicationDbContext context)
        {
            return context.Students
                .Include(i => !i.IsArchive)
                .Include(i => i.City)
                .ToList();

        }

        public static List<Student> StudentsArchiveInclude(this ApplicationDbContext context)
        {
            return context.Students
                .Where(i => i.IsArchive)
                .Include(i => i.City)
                .ToList();

        }
        public static List<StudentGroup> StudentsGroupsInclude(this ApplicationDbContext context)
        {
            return context.StudentGroups
                .Include(i => i.Group)
                .Include(i => i.Student)
                .Include(i => i.Student.City)
                .Include(i => i.Group.Teacher.Course)
                .ToList();

        }


        public static List<StudentGroup> StudentsFilterInclude(this ApplicationDbContext context, int PageNumber, int PageSize, int[] CitiesId, int[] CoursesId, string StudentName, DateTime? StartDate, DateTime? EndDate)
        {
            return context.StudentGroups
                .Where(i => CitiesId == null || CitiesId.Any(a => a == i.Student.City.Id))
                .Where(i => CoursesId == null || CoursesId.Any(a => a == i.Group.Teacher.Course.Id))
                .Where(i => StudentName == null || i.Student.Name == StudentName)
                .Where(i => (StartDate == null || StartDate < i.Group.StartDate) || (EndDate == null || EndDate > i.Group.EndDate))
                . Where(i => !i.IsArchive)
                .Skip((PageNumber - 1) * PageSize)
                       .Take(PageSize)
                       .Include(i => i.Group)
                       .Include(i => i.Student)
                       .Include(i => i.Student.City)
                       .Include(i => i.Group.Teacher.Course)
                        .OrderBy(i => i.Group.Name)
                        .ToList();
        }
        public static List<Group> GroupsInclude(this ApplicationDbContext context, int StudentId)
        {
            return context.StudentGroups.Where(i => i.StudentId == StudentId)
                .Include(i => i.Group).Select(i => i.Group).ToList();
        }
    }
}
