using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.DAL.Entities
{
    public class PaymentHistory: History
    {
        public int PaymentId { get; set; }

        public Payment Payment { get; set; }
    }
}
