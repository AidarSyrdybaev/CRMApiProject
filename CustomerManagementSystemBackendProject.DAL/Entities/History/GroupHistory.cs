using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.DAL.Entities
{
    public class GroupHistory: History
    {
        public int GroupId { get; set; }

        public Group Group { get; set; }
    }
}
