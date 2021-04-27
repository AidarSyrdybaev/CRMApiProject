using CustomerManagementSystemBackendProject.Models.AnalystsModel;
using CustomerManagementSystemBackendProject.Models.WebModels.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystemBackendProject.BL.Services.Contracts
{
    public interface IAnalystsService
    {
        Task<Response<List<AnalystsModel>>> StatusesAnalysts(AnalystsFilterModel model);

        Task<Response<List<AnalystsModel>>> FailureStatusesAnalysts(AnalystsFilterModel model);

        Task<Response<List<AnalystsModel>>> LeadsByCoursesAnalys(AnalystsFilterModel model);

        Task<Response<List<AnalystsModel>>> LeadsBySourceAnalysts(AnalystsFilterModel model);
        Task<Response<SuccessAndFailureNumbers>> LeadsByFailureAndSuccesAnalys(AnalystsFilterModel model);
    }
}
