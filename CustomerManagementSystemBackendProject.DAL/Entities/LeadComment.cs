using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.DAL.Entities
{
      public class LeadComment
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int LeadId { get; set; }
        public Lead Lead { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime CommentDateTime { get; set; }

        public bool IsArchive { get; set; }

    }
}
