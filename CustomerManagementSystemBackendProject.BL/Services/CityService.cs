using AutoMapper;
using CustomerManagementSystemBackendProject.BL.Services.Contracts;
using CustomerManagementSystemBackendProject.DAL.Entities;
using CustomerManagementSystemBackendProject.DAL.Extensions.IncludeExtensions;
using CustomerManagementSystemBackendProject.DAL.Factories;
using CustomerManagementSystemBackendProject.Models.CityModels;
using CustomerManagementSystemBackendProject.Models.CommonModels;
using CustomerManagementSystemBackendProject.Models.Course;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystemBackendProject.BL.Services
{
    public class CityService:ICityService
    {
        private readonly IApplicationDbContextFactory _applicationDbContextFactory;
        private UserManager<User> _userManager;

        public CityService(IApplicationDbContextFactory applicationDbContextFactory, UserManager<User> userManager)
        {
            _applicationDbContextFactory = applicationDbContextFactory;
            _userManager = userManager;

        }

        public async Task<ResponseObject<List<CityIndexModel>>> GetAll()
        {
            using (var context = _applicationDbContextFactory.Create())
            {
                var Cities = context.Cities.ToList();
                var Models = Mapper.Map<List<CityIndexModel>>(Cities);
                
                return new ResponseObject<List<CityIndexModel>>
                {
                    Status = 100,
                    Message = "Запрос прошел успешно",
                    ResponseObj = Models
                };
            }
        }

        public async Task<Response> Delete(int CityId, ClaimsPrincipal user)
        {
            using (var context = _applicationDbContextFactory.Create())
            {
                var User = await _userManager.FindByNameAsync(user.Identity.Name);
                var City = context.Cities.Where(i => i.Id == CityId).FirstOrDefault();
                if (City == null)
                    return new Response { Status = 500, Message = "Объект не найден" };

                context.Cities.Remove(City);
                context.CityHistories.Add(new CityHistory{CityId = CityId,Action="Удаление",  UserId = User.Id, DateTime  =DateTime.Now});
                context.SaveChanges();
                return new Response { Status = 100, Message = "Запрос успешно прошел" };
            }
        }

        public async Task<ResponseObject<List<CityIndexModel>>> GroupsCountByCity()
        {
            using (var context = _applicationDbContextFactory.Create())
            {
                var Models = Mapper.Map<List<CityIndexModel>>(context.GroupCountByCity());
                return new ResponseObject<List<CityIndexModel>> { Status = 100, Message = "Запрос прошел успешно", ResponseObj = Models };
            }
        }
    }
}
