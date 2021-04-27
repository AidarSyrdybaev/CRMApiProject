using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.DAL.Entities
{
    public class StudentComment
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime CommentDateTime { get; set; }

        public bool IsArchive { get; set; }

    }
}
