using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.DAL.Entities
{
    public class ChosenLead: IEntity
    {
        public int Id { get; set; }

        public int LeadId { get; set; }

        public Lead Lead { get; set; }

        public DateTime ChoseDateTime { get; set; }

        public DateTime CallDateTime { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public bool IsArchive { get; set; }
    }
}
