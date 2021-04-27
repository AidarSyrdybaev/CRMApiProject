using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.Models.GroupModels
{
    public class GroupUpdateModel
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
