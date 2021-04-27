using CustomerManagementSystemBackendProject.DAL.Context;
using CustomerManagementSystemBackendProject.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerManagementSystemBackendProject.DAL.Extensions.IncludeExtensions
{
    public static class TeacherExtensions
    {
        public static Teacher IncludeTeacher(this ApplicationDbContext context, int Id)
        {
            return context.Teachers
               .Where(i => i.Id == Id)
               .Include(i => i.City)
               .Include(i => i.Course)
               .FirstOrDefault();
        }

        public static List<Teacher> IncludeTeachers(this ApplicationDbContext context)
        {
            return context.Teachers
               .Include(i => i.City)
               .Include(i => i.Course)
               .ToList();
        }
        public static List<Teacher> TeachersFilterInclude(this ApplicationDbContext context, int[] CitiesId,  string Name)
        {
            return context.Teachers
               .Where(i => CitiesId == null || CitiesId.Any(a => a == i.CityId))
               .Where(i => Name == null || i.Name == Name)
               .Where(i => !i.IsArchive)
                       .Include(i => i.City)
                       .Include(i => i.Course)
                       .Include(i => i.Groups)
                       .OrderBy(i => i.Course)
                       .ToList();
        }
    }
}
