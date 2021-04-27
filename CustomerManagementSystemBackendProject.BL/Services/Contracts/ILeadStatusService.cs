using CustomerManagementSystemBackendProject.Models.CommonModels;
using CustomerManagementSystemBackendProject.Models.LeadStatusModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystemBackendProject.BL.Services.Contracts
{
    public interface ILeadStatusService
    {

        Task<ResponseObject<List<LeadStatusIndexModel>>> GetAll();
    }
}
