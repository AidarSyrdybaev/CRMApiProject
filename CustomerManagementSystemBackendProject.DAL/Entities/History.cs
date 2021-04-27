using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.DAL.Entities
{
    public class History: IEntity
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public DateTime DateTime { get; set; }

        public string Action { get; set; }

        public bool IsArchive { get; set; }
    }
}
