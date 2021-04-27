using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.DAL.Entities
{
    public class TeacherHistory: History
    {
        public int TeacherId { get; set; }

        public Teacher Teacher { get; set; }
    }
}
