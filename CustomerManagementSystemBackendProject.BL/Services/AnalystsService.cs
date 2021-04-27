using CustomerManagementSystemBackendProject.DAL.Factories;
using CustomerManagementSystemBackendProject.DAL.Extensions.Statistics;
using CustomerManagementSystemBackendProject.Models.AnalystsModel;
using CustomerManagementSystemBackendProject.Models.WebModels.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CustomerManagementSystemBackendProject.BL.Services.Contracts;

namespace CustomerManagementSystemBackendProject.BL.Services
{
    public class AnalystsService: IAnalystsService
    {
        private readonly IApplicationDbContextFactory _applicationDbContextFactory;

        public AnalystsService(IApplicationDbContextFactory applicationDbContextFactory)
        {
            _applicationDbContextFactory = applicationDbContextFactory;
        }

        public async Task<Response<List<AnalystsModel>>> StatusesAnalysts(AnalystsFilterModel model)
        {
            using (var context = _applicationDbContextFactory.Create())
            {   
                var Result = context.StatusesAnalys(model.StartDate, model.EndDate, model.CityId);
                var Models = Mapper.Map<List<AnalystsModel>>(Result);
                return new Response<List<AnalystsModel>>(Models);
            }
        }

        public async Task<Response<List<AnalystsModel>>> FailureStatusesAnalysts(AnalystsFilterModel model)
        {
            using (var context = _applicationDbContextFactory.Create())
            {
                var Result = context.FailureStatusesAnalys(model.StartDate, model.EndDate, model.CityId);
                var Models = Mapper.Map<List<AnalystsModel>>(Result);
                return new Response<List<AnalystsModel>>(Models);
            }
        }

        public async Task<Response<List<AnalystsModel>>> LeadsByCoursesAnalys(AnalystsFilterModel model)
        {
            using (var context = _applicationDbContextFactory.Create())
            {
                var Result = context.LeadsByCoursesAnalys(model.StartDate, model.EndDate, model.CityId);
                var Models = Mapper.Map<List<AnalystsModel>>(Result);
                return new Response<List<AnalystsModel>>(Models);
            }
        }

        public async Task<Response<List<AnalystsModel>>> LeadsBySourceAnalysts(AnalystsFilterModel model)
        {
            using (var context = _applicationDbContextFactory.Create())
            {
                var Result = context.LeadsByCoursesAnalys(model.StartDate, model.EndDate, model.CityId);
                var Models = Mapper.Map<List<AnalystsModel>>(Result);
                return new Response<List<AnalystsModel>>(Models);
            }
        }

        public async Task<Response<SuccessAndFailureNumbers>> LeadsByFailureAndSuccesAnalys(AnalystsFilterModel model)
        {
            using (var context = _applicationDbContextFactory.Create())
            {
                var Result = context.LeadsByFailureAndSuccesAnalys(model.StartDate, model.EndDate, model.CityId);
                var Model = new SuccessAndFailureNumbers {FailureCount = Result.Item1, SuccessCount = Result.Item2 };
                return new Response<SuccessAndFailureNumbers>(Model);
            }
        }



    }
}
