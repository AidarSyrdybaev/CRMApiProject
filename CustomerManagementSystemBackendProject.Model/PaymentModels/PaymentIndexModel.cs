using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.Models.PaymentModels
{
    public class PaymentIndexModel
    {
        public int Id { get; set; }

        public string StudentName { get; set; }

        public double PaymentSum { get; set; }

        public double PaymentPercent { get; set; }

        public string PaymentStatus { get; set; }

        public int Sum { get; set; }

    }
}
