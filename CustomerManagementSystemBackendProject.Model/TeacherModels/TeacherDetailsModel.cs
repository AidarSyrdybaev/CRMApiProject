using CustomerManagementSystemBackendProject.Models.GroupModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.Models.TeacherModels
{ 
    public class TeacherDetailsModel
    {   
        public int Id { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string MiddleName { get; set; }

        public string City { get; set; }
        public string Course { get; set; }

        public string Phone { get; set; }

        public string Patent { get; set; }
        public List<GroupIndexModel> Groups { get; set; }
        public DateTime PatentStartDate { get; set; }
        public DateTime PatentEndDate { get; set; }
    }
}
