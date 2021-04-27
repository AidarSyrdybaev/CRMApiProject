using CustomerManagementSystemBackendProject.Models.GroupModels;
using CustomerManagementSystemBackendProject.Models.StudentCommentModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.Models.StudentModels
{
    public class StudentDetailsModel
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string CityName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool HasLaptop { get; set; }
        public string Discriminator { get; set; }
        public List<GroupIndexModel> Groups { get; set; }
        public List<StudentCommentIndexModel> StudentComments { get; set; }
    }
}
