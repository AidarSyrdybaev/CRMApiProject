using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.Models.LeadCommentModels
{
    public class LeadCommentIndexModel
    {
        public int id { get; set; }
        public string UserName { get; set; }
        public DateTime CommentDateTime { get; set; }
        public string Comment { get; set; }
        public int LeadId { get; set; }
    }
}
