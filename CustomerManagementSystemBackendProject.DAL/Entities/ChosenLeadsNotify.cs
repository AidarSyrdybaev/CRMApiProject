using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.DAL.Entities
{
    public class ChosenLeadsNotify: Notify
    {
        public int ChosenLeadId { get; set; }

        public ChosenLead ChosenLead { get; set; }
    }
}
