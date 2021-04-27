using CustomerManagementSystemBackendProject.Models.AuthenticateModels;
using CustomerManagementSystemBackendProject.Models.CommonModels;
using CustomerManagementSystemBackendProject.Models.FilterModels;
using CustomerManagementSystemBackendProject.Models.UserModels;
using CustomerManagementSystemBackendProject.Models.WebModels.Wrappers;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystemBackendProject.BL.Services.Contracts
{
    public interface IUserService
    {
        Task<ResponseObject<List<UserIndexModel>>> GetAll();
        Task<FilterResponse<List<UserIndexModel>>> IndexFilter(EmployeesFilter filter);
        Task<FilterResponse<List<UserIndexModel>>> IndexFilterNew(EmployeesFilter filter);
        Task<UserIndexModel> GetUser(UserIndexModel model, ClaimsPrincipal User);
        Task<TokenModel> Update(UserEditModel model, ClaimsPrincipal User);
    }
}
