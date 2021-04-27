using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.DAL.Entities
{
    public class StudentGroup: IEntity
    {
        public int Id { get; set; }

        public int GroupId { get; set; }

        public Group Group { get; set; }

        public int StudentId { get; set; }

        public Student Student { get; set; }
        public List<Payment> Payments { get; set; }

        public bool IsArchive { get; set; }
    }
}
