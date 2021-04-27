using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.DAL.Entities
{
    public class UserHistory: History
    {
        public int UserId { get; set; }

        public User User { get; set; }
    }
}
