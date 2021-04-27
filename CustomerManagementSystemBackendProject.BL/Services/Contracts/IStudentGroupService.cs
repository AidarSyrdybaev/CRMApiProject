using CustomerManagementSystemBackendProject.DAL.Entities;
using CustomerManagementSystemBackendProject.Models.CommonModels;
using CustomerManagementSystemBackendProject.Models.StudentGroupModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystemBackendProject.BL.Services.Contracts
{
    public interface IStudentGroupService
    {
        Task<Response> Create(int StudentId, int GroupId);

        Task<ResponseObject<List<StudentGroupModel>>> GetAll();
    }
}
