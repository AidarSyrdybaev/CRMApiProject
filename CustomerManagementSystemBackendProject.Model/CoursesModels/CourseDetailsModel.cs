using CustomerManagementSystemBackendProject.Models.TeacherModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.Models.Course
{
    public class CourseDetailsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TeacherIndexModel> Teachers { get; set; }
        public string Color { get; set; }
    }
}
