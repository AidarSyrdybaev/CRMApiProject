using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CustomerManagementSystemBackendProject.Models.GroupModels
{ 
    public class GroupDetailsModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Course { get; set; }

        public string City { get; set; }

        public string Teacher { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int Months { get; set; }
        public int ContractSum { get; set; }
        public int StudentCount { get; set; }
       
    }
}
