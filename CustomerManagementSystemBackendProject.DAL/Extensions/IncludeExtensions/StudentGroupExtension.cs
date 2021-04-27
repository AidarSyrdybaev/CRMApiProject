using CustomerManagementSystemBackendProject.DAL.Context;
using CustomerManagementSystemBackendProject.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerManagementSystemBackendProject.DAL.Extensions.IncludeExtensions
{
    public static class StudentGroupExtensions
    {
       
        public static List<StudentGroup> StudentGroupsInclude(this ApplicationDbContext context)
        {
            return context.StudentGroups
                .Include(i => i.Student)
                .Include(i => i.Group)
                .ToList();

        }

        public static StudentGroup StudentGroupInclude(this ApplicationDbContext context, int Id)
        {
            return context.StudentGroups
                .Where(i => i.Id == Id)
                .Include(i => i.Student)
                .Include(i => i.Group)
                .FirstOrDefault();

        }
    }
}
