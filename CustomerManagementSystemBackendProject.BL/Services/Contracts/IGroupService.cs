using CustomerManagementSystemBackendProject.Models.CityModels;
using CustomerManagementSystemBackendProject.Models.CommonModels;
using CustomerManagementSystemBackendProject.Models.FilterModels;
using CustomerManagementSystemBackendProject.Models.GroupModels;
using CustomerManagementSystemBackendProject.Models.WebModels.Wrappers;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystemBackendProject.BL.Services.Contracts
{
    public interface IGroupService
    {
        Task<Response> Create(GroupCreateModel GroupCreateModel, ClaimsPrincipal user);

        Task<Response> Update(GroupUpdateModel GroupUpdateModel, ClaimsPrincipal user);

        Task<Response> Delete(int GroupId, ClaimsPrincipal user);

        Task<ResponseObject<GroupDetailsModel>> GetById(int Id);

        Task<ResponseObject<List<GroupIndexModel>>> GetAll();
        Task<FilterResponse<List<GroupDetailsModel>>> IndexFilter(GroupsFilter filter);


    }
}
