using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.Models.GroupModels
{
    public class GroupCreateModel
    {
        public string Name { get; set; }
        public int CityId { get; set; }
        public int TeacherId { get; set; }
        public int ContractSum { get; set; }
        public int Month { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
