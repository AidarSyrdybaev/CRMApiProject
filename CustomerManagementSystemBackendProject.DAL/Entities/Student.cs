using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.DAL.Entities
{
    public class Student: Client
    {
        public List<StudentGroup> StudentGroups { get; set; }

        public List<StudentComment> StudentComments { get; set; }
        public int? LeadId { get; set; }

        public Lead Lead { get; set; }

        public bool IsArchive { get; set; }
    }
}
