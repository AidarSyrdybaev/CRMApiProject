using CustomerManagementSystemBackendProject.Models.CityModels;
using CustomerManagementSystemBackendProject.Models.CommonModels;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystemBackendProject.BL.Services.Contracts
{
    public interface ICityService
    {
        Task<ResponseObject<List<CityIndexModel>>> GetAll();
        Task<Response> Delete(int CityId, ClaimsPrincipal User);

        Task<ResponseObject<List<CityIndexModel>>> GroupsCountByCity();




    }
}
