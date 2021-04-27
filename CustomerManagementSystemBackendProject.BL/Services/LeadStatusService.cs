using AutoMapper;
using CustomerManagementSystemBackendProject.BL.Services.Contracts;
using CustomerManagementSystemBackendProject.DAL.Factories;
using CustomerManagementSystemBackendProject.Models.CommonModels;
using CustomerManagementSystemBackendProject.Models.LeadStatusModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystemBackendProject.BL.Services
{
    public class LeadStatusService:ILeadStatusService
    {
        private readonly IApplicationDbContextFactory _applicationDbContextFactory;

        public LeadStatusService(IApplicationDbContextFactory applicationDbContextFactory)
        {
            _applicationDbContextFactory = applicationDbContextFactory;
        }
        public async Task<ResponseObject<List<LeadStatusIndexModel>>> GetAll()
        {
            using (var context = _applicationDbContextFactory.Create())
            {
                var LeadStatuses = context.LeadStatuses.ToList();
                var Models = Mapper.Map<List<LeadStatusIndexModel>>(LeadStatuses);
                return new ResponseObject<List<LeadStatusIndexModel>>
                {
                    Status = 100,
                    Message = "Запрос прошел успешно",
                    ResponseObj = Models
                };
            }
        }
    }
}
