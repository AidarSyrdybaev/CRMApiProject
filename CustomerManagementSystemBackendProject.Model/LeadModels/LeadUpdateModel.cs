using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.Models.LeadModels
{
    public class LeadUpdateModel
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public int CityId { get; set; }
        public string Phone { get; set; }
        public int CourseId { get; set; }
        public int LeadStatusId { get; set; }
        public string FlexById { get; set; }
        public int? LeadFailureStatusId { get; set; }
    }
}
