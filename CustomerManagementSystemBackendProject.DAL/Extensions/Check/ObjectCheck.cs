using CustomerManagementSystemBackendProject.DAL.Context;
using CustomerManagementSystemBackendProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerManagementSystemBackendProject.DAL.Extensions.Check
{
    public static class ObjectCheck
    {
        public static bool Check<T>(this ApplicationDbContext context, int Id) where T: class, IEntity
        {   
            var DbSet = context.Set<T>();
            return DbSet.Any(i => i.Id == Id);
        }

        public static bool LeadsNotificationsCheck(this ApplicationDbContext context, int LeadId)
        {
            return context.LeadsNotifies.Any(i => i.LeadId == LeadId);
        }
    }
}
