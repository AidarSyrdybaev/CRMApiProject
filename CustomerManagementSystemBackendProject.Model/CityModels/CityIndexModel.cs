using CustomerManagementSystemBackendProject.Models.Course;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.Models.CityModels
{
    public class CityIndexModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public int GroupsCount { get; set; }
    }
}
