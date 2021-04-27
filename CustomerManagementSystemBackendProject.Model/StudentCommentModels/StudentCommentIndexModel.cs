using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.Models.StudentCommentModels
{
    public class StudentCommentIndexModel
    {
        public int id { get; set; }
        public string UserName { get; set; }
        public DateTime CommentDateTime { get; set; }
        public string Comment { get; set; }
        public int StudentId { get; set; }
    }
}
