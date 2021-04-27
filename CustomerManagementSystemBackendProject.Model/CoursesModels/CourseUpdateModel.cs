using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.Models.Course
{
    public class CourseUpdateModel
    {   
        public int Id { get; set; }

        public string Name { get; set; }

        public int CityId { get; set; }
        public string Color { get; set; }
    }
}
