using CustomerManagementSystemBackendProject.Models.LeadCommentModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.Models.LeadModels
{
      public class LeadDetailsModel
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string CityName { get; set; }
        public string Phone { get; set; }
        public string CourseName{ get; set; }
        public string LeadStatus { get; set; }
        public string FlexById { get; set; }
        public int? LeadFailureStatusId { get; set; }
        public List<LeadCommentIndexModel> LeadComments { get; set; }
    }
}
