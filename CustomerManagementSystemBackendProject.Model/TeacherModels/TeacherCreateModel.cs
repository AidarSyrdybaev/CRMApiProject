using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.Models.TeacherModels
{
    public class TeacherCreateModel
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public int CityId { get; set; }
        public int CourseId { get; set; }
        public string Phone { get; set; }
        public string Patent { get; set; }
        public DateTime PatentStartDate { get; set; }
        public DateTime PatentEndDate { get; set; }
    }
}
