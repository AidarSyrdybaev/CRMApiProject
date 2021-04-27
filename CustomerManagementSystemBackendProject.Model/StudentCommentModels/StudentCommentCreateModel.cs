using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.Models.StudentCommentModels
{
    public class StudentCommentCreateModel
    {
        public string Comment { get; set; }
        public int StudentId { get; set; }
    }
}
