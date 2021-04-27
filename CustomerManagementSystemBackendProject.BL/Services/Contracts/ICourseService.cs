using CustomerManagementSystemBackendProject.Models.CommonModels;
using CustomerManagementSystemBackendProject.Models.Course;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystemBackendProject.BL.Services.Contracts
{
    public interface ICourseService
    {
        Task<Response> Create(CourseCreateModel courseCreateModel, ClaimsPrincipal claimsPrincipal);

        Task<Response> Update(CourseUpdateModel courseUpdateModel, ClaimsPrincipal claimsPrincipal);

        Task<Response> Delete(int CourseId, ClaimsPrincipal claimsPrincipal);

        Task<ResponseObject<CourseDetailsModel>> GetById(int Id);

        Task<ResponseObject<List<CourseIndexModel>>> GetAll();
    }
}
