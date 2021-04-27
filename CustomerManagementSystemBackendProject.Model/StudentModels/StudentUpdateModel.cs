using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.Models.StudentModels
{
    public class StudentUpdateModel
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public int CityId { get; set; }
        public string Phone { get; set; }
        public int GroupId { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public bool HasLaptop { get; set; }

        public string Discriminator { get; set; }
    }
}
