using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.Models.LeadCommentModels
{
    public class LeadCommentCreateModel
    {
        public string Comment { get; set; }
        public int LeadId { get; set; }
    }
}
