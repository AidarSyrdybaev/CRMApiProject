using CustomerManagementSystemBackendProject.DAL.Context;
using CustomerManagementSystemBackendProject.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerManagementSystemBackendProject.DAL.Extensions.IncludeExtensions
{
    public static class PaymentExtensions
    {
        public static List<Payment> GetFullPayments(this ApplicationDbContext context)
        {
            return context.Payments
                .Include(i => i.StudentGroup.Student)
                .Include(i => i.User)
                .Include(i => i.StudentGroup.Group)
                .ToList();
        }
    }
}
