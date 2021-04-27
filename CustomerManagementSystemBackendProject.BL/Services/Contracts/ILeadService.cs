using CustomerManagementSystemBackendProject.DAL.Entities;
using CustomerManagementSystemBackendProject.Models.CommonModels;
using CustomerManagementSystemBackendProject.Models.FilterModels;
using CustomerManagementSystemBackendProject.Models.FlexByModels;
using CustomerManagementSystemBackendProject.Models.LeadModels;
using CustomerManagementSystemBackendProject.Models.WebModels.Wrappers;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystemBackendProject.BL.Services.Contracts
{
    public interface ILeadService
    {
        Task<Response> Create(LeadCreateModel leadCreateModel, ClaimsPrincipal user);

        Task<Response> Update(LeadUpdateModel leadUpdateModel, ClaimsPrincipal user);

        Task<Response> UpdateStatus(LeadUpdateStatusModel leadUpdateStatusModel, ClaimsPrincipal user);

        Task<Response> UpdateFailureStatus(LeadFailureModel leadFailureStatusModel, ClaimsPrincipal user);

        Task<Response> Delete(int LeadId, ClaimsPrincipal user);

        Task<ResponseObject<LeadDetailsModel>> GetById(int Id);

        Task<ResponseObject<List<LeadIndexModel>>> GetAll();

        Task<PagedResponse<List<LeadIndexModel>>> IndexPagination(PaginationFilter filter);

       Task<Response> AddLeadInformation(RequestInformation requestInformation);

        Task<List<NotificationIndexModel>> Notifications();
    }
}
