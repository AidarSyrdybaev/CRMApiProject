using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.DAL.Entities
{
    public class StudentGroupHistory: History
    {
        public int StudentGroupId { get; set; }

        public StudentGroup StudentGroup { get; set; }
    }
}
