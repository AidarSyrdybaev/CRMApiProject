using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.DAL.Entities
{
    public class LeadHistory: History
    {
        public int LeadId { get; set; }
        public Lead Lead { get; set; }
    }
}
