using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.DAL.Entities
{
    public class Lead: Client
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int LeadStatusId { get; set; }
        public LeadStatus LeadStatus { get; set; }
        public string FlexById { get; set; }
        public int? LeadFailureStatusId { get; set; }
        public LeadFailureStatus LeadFailureStatus { get; set; }
        public DateTime CreateDate { get; set; }

        public DateTime UpdateStatusDate { get; set; }
        public string Source { get; set; }

        public bool IsArchive { get; set; }
    }
}
