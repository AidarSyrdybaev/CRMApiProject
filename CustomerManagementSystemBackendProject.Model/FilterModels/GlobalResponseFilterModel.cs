using CustomerManagementSystemBackendProject.Models.LeadModels;
using CustomerManagementSystemBackendProject.Models.StudentModels;
using CustomerManagementSystemBackendProject.Models.TeacherModels;
using CustomerManagementSystemBackendProject.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.Models.FilterModels
{
    public class GlobalResponseFilterModel
    {
        public List<UserIndexModel> Users { get; set; }

        public List<LeadIndexModel> Leads { get; set; }

        public List<StudentIndexModel> Students { get; set; }

        public List<TeacherIndexModel> Teachers { get; set; }
    }
}
