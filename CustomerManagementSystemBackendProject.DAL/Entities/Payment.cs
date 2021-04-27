using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.DAL.Entities
{
    public class Payment: IEntity
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public DateTime DateTime { get; set; }

        public double Sum { get; set; }

        public int StudentGroupId { get; set; }

        public string PaymentPlace { get; set; }

        public StudentGroup StudentGroup { get; set; }

        public bool IsArchive { get; set; }

    }
}
