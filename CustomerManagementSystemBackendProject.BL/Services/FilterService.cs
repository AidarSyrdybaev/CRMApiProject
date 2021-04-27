using AutoMapper;
using CustomerManagementSystemBackendProject.BL.Services.Contracts;
using CustomerManagementSystemBackendProject.DAL.Extensions.Filter;
using CustomerManagementSystemBackendProject.DAL.Factories;
using CustomerManagementSystemBackendProject.Models.CommonModels;
using CustomerManagementSystemBackendProject.Models.FilterModels;
using CustomerManagementSystemBackendProject.Models.LeadModels;
using CustomerManagementSystemBackendProject.Models.StudentModels;
using CustomerManagementSystemBackendProject.Models.TeacherModels;
using CustomerManagementSystemBackendProject.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystemBackendProject.BL.Services
{
    public class FilterService: IFilterService
    {
        private IApplicationDbContextFactory _applicationDbContextFactory { get; }

        public FilterService(IApplicationDbContextFactory applicationDbContextFactory)
        {
            _applicationDbContextFactory = applicationDbContextFactory;
        }

        public async Task<ResponseObject<GlobalResponseFilterModel>> GlobalFilter(GlobalFilterModel globalFilterModel)
        {
            using (var context = _applicationDbContextFactory.Create())
            {
                var Model = new GlobalResponseFilterModel();
                Model.Leads = Mapper.Map<List<LeadIndexModel>>(context.LeadsFilterByFIO(globalFilterModel.Name, globalFilterModel.MiddleName, globalFilterModel.Surname));
                Model.Students = Mapper.Map<List<StudentIndexModel>>(context.StudentsFilterByFIO(globalFilterModel.Name, globalFilterModel.MiddleName, globalFilterModel.Surname));
                Model.Teachers = Mapper.Map<List<TeacherIndexModel>>(context.TeachersFilterByFIO(globalFilterModel.Name, globalFilterModel.MiddleName, globalFilterModel.Surname));
                Model.Users = Mapper.Map<List<UserIndexModel>>(context.UsersFilterByFIO(globalFilterModel.Name, globalFilterModel.MiddleName, globalFilterModel.Surname));

                return new ResponseObject<GlobalResponseFilterModel> { Status = 100, Message = "Запрос прошел успешно", ResponseObj = Model };
            }
        }
    }
}
