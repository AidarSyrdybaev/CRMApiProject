using CustomerManagementSystemBackendProject.Models.CommonModels;
using CustomerManagementSystemBackendProject.Models.StudentCommentModels;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystemBackendProject.BL.Services.Contracts
{
    public interface IStudentCommentService
    {
        Task<ResponseObject<List<StudentCommentIndexModel>>> GetAll();

        Task<Response> Create(StudentCommentCreateModel studentCommentCreateModel, ClaimsPrincipal claimsPrincipal);
    }
}
