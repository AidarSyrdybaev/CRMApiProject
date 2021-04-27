using CustomerManagementSystemBackendProject.Models.CommonModels;
using CustomerManagementSystemBackendProject.Models.LeadCommentModels;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystemBackendProject.BL.Services.Contracts
{
    public interface ILeadCommentService
    {
        Task<ResponseObject<List<LeadCommentIndexModel>>> GetAll();

        Task<Response> Create(LeadCommentCreateModel leadCommentCreateModel, ClaimsPrincipal claimsPrincipal);
    }
}
