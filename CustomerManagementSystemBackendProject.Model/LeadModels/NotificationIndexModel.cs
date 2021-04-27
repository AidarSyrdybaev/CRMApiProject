using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.Models.LeadModels
{
    public class NotificationIndexModel
    {
        public int LeadId { get; set; }

        public string Message { get; set; }

        public DateTime DateTime { get; set; }
    }
}
