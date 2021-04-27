using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.Models.FilterModels
{
    public class GroupsFilter
    {
        public int[] CitiesId { get; set; }
        public int[] CoursesId { get; set; }
        public string GroupName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
