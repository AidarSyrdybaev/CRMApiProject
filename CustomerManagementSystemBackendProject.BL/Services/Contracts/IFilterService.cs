using CustomerManagementSystemBackendProject.Models.CommonModels;
using CustomerManagementSystemBackendProject.Models.FilterModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystemBackendProject.BL.Services.Contracts
{
    public interface IFilterService
    {
        Task<ResponseObject<GlobalResponseFilterModel>> GlobalFilter(GlobalFilterModel globalFilterModel);
    }
}
