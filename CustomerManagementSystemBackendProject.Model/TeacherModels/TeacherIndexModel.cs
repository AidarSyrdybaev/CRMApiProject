using CustomerManagementSystemBackendProject.Models.Course;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.Models.TeacherModels
{
    public class TeacherIndexModel
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string Course { get; set; }


    }
}
