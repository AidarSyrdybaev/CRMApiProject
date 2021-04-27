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
        public static Group IncludeCourse(this ApplicationDbContext context, int Id)
        {
            return context.Groups
                .Include(i => i.Course.City)
                .Include(i => i.Course)
                .FirstOrDefault();
        }
    }
}
