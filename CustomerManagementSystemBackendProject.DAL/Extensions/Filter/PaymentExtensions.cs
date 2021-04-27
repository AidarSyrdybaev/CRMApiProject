using CustomerManagementSystemBackendProject.DAL.Context;
using CustomerManagementSystemBackendProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CustomerManagementSystemBackendProject.DAL.Extensions.Filter
{
    public static class PaymentExtensions
    {
        public static Payment GetPayment(this ApplicationDbContext context, int StudentGroupId, DateTime dateTime)
        {
            return context.Payments
                .Where(i => i.StudentGroupId == StudentGroupId)
                .Where(i => i.DateTime.Year == dateTime.Year)
                .Where(i => i.DateTime.Month == dateTime.Month)
                .FirstOrDefault();
        }
    }
}
