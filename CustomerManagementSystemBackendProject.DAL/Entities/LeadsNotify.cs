using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.DAL.Entities
{
    public class LeadsNotify: Notify
    {
        public int LeadId { get; set; }

        public Lead Lead { get; set; }


    }
}
