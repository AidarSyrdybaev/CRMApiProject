using CustomerManagementSystemBackendProject.Models.GroupModels;
using CustomerManagementSystemBackendProject.Models.StudentModels;
using CustomerManagementSystemBackendProject.Models.TeacherModels;
using CustomerManagementSystemBackendProject.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystemBackendProject.BL.Services.Contracts
{
    public interface IArchiveService
    {
         Task<List<UserIndexModel>> UserArchive();

         Task<List<GroupIndexModel>> GroupArchive();

         Task<List<StudentIndexModel>> StudentArchive();

         Task<List<TeacherIndexModel>> TeacherArchive();
    }
}
