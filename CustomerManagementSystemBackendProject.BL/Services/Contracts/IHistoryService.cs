using CustomerManagementSystemBackendProject.Models.CommonModels;
using CustomerManagementSystemBackendProject.Models;
using CustomerManagementSystemBackendProject.Models.LeadModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystemBackendProject.BL.Services.Contracts
{
    public interface IHistoryService
    {

        Task<List<HistoryIndexModel>> GetAll();

    }
}
