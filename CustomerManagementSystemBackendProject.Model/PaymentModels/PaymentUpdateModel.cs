using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.Models.PaymentModels
{
    public class PaymentUpdateModel
    {   
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public double Sum { get; set; }

        public int GroupId{ get; set; }

        public int StudentId { get; set; }

        public string PaymentPlace { get; set; }
    }
}
