using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.Models.GroupModels
{
    public class GroupIndexModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public string CityName { get; set; }
        public int Months { get; set; }
        public string Course { get; set; }
    }
}
