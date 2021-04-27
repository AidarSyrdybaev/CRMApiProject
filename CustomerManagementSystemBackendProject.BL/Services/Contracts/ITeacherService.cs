using CustomerManagementSystemBackendProject.Models.CommonModels;
using CustomerManagementSystemBackendProject.Models.FilterModels;
using CustomerManagementSystemBackendProject.Models.TeacherModels;
using CustomerManagementSystemBackendProject.Models.WebModels.Wrappers;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystemBackendProject.BL.Services.Contracts
{
    public interface ITeacherService
    {
        Task<Response> Create(TeacherCreateModel TeacherCreateModel, ClaimsPrincipal User);

        Task<Response> Update(TeacherUpdateModel TeacherUpdateModel,ClaimsPrincipal User);

        Task<Response> Delete(int TeacherId, ClaimsPrincipal User);

        Task<ResponseObject<TeacherDetailsModel>> GetById(int Id);

        Task<ResponseObject<List<TeacherIndexModel>>> GetAll();

        Task<FilterResponse<List<TeacherDetailsModel>>> IndexFilter(EmployeesFilter filter);
        Task<FilterResponse<List<TeacherDetailsModel>>> IndexFilterNew(EmployeesFilter filter);
    }
}
