using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.DAL.Entities
{
    public class StudentHistory: History
    {
        public int StudentId { get; set; }

        public Student Student { get; set; }
    }
}
