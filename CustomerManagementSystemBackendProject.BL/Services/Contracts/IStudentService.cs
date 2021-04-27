using CustomerManagementSystemBackendProject.Models.CommonModels;
using CustomerManagementSystemBackendProject.Models.FilterModels;
using CustomerManagementSystemBackendProject.Models.StudentModels;
using CustomerManagementSystemBackendProject.Models.WebModels.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystemBackendProject.BL.Services.Contracts
{
    public interface IStudentService
    {
        Task<Response> Create(StudentCreateModel studentCreateModel);
        Task<Response> FullCreate(StudentFullCreateModel studentFullCreateModel);

        Task<Response> Update(StudentUpdateModel studentUpdateModel);

        Task<Response> Delete(int StudentId);

        Task<ResponseObject<StudentDetailsModel>> GetById(int Id);

        Task<ResponseObject<List<StudentIndexModel>>> GetAll();
        Task<PagedResponse<List<StudentIndexModel>>> IndexPagination(PaginationFilter filter);
    }
}
