using CustomerManagementSystemBackendProject.DAL.Context;
using CustomerManagementSystemBackendProject.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerManagementSystemBackendProject.DAL.Extensions.Check
{
    public static class CourseExtensions
    {
        public static Course IncludeCourse(this ApplicationDbContext context, int Id)
        {
            return context.Courses.Where(i => i.Id == Id)
                .Where(i => !i.IsArchive)
                .Include(i => i.City)
                .FirstOrDefault();
        }
    }
}
