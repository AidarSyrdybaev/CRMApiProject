using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.DAL.Entities
{
    public class ForgotPaswwordKey: IEntity
    {
        public int Id { get; set; }

        public int Key { get; set; }

        public int UserId { get; set; }

        public DateTime DateTime { get; set; }

        public User User { get; set; }

        public bool IsArchive { get; set; }
    }
}
