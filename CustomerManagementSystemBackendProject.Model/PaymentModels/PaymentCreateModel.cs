using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.Models.PaymentModels
{
    public class PaymentCreateModel
    {

        public DateTime DateTime { get; set; }

        public double Sum { get; set; }

        public int GroupId { get; set; }

        public int StudentId { get; set; }

        public string PaymentPlace { get; set; }

    }
}
