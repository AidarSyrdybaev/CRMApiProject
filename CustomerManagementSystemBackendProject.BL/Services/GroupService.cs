using AutoMapper;
using CustomerManagementSystemBackendProject.DAL.Factories;
using CustomerManagementSystemBackendProject.DAL.Entities;
using CustomerManagementSystemBackendProject.Models.CommonModels;
using CustomerManagementSystemBackendProject.Models.GroupModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using CustomerManagementSystemBackendProject.DAL.Extensions.Check;
using CustomerManagementSystemBackendProject.BL.Services.Contracts;
using CustomerManagementSystemBackendProject.DAL.Extensions.IncludeExtensions;
using CustomerManagementSystemBackendProject.Models.WebModels.Wrappers;
using CustomerManagementSystemBackendProject.Models.FilterModels;
using CustomerManagementSystemBackendProject.BL.Helpers;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace CustomerManagementSystemBackendProject.BL.Services
{
    public class GroupService: IGroupService
    {
        private readonly IApplicationDbContextFactory _applicationDbContextFactory;
        private UserManager<User> _userManager;
        public GroupService(IApplicationDbContextFactory applicationDbContextFactory, UserManager<User> userManager)
        {
            _applicationDbContextFactory = applicationDbContextFactory;
        }

        public async Task<Response> Create(GroupCreateModel GroupCreateModel, ClaimsPrincipal user)
        {
            using (var context = _applicationDbContextFactory.Create())
            {
                var User = await _userManager.FindByNameAsync(user.Identity.Name);
                var Group = Mapper.Map<Group>(GroupCreateModel);
                if (context.Groups.Any(i => i.Name == Group.Name))
                    return new Response { Status = 500, Message = "Такая группа уже существует!" };
                if (!context.Check<Group>(Group.TeacherId))
                    return new Response { Status = 500, Message = "Такого учителя нет!" };

                var Result = context.Groups.Add(Group);
                context.SaveChanges();
                context.groupHistories.Add(new GroupHistory { Action="Создание", DateTime=DateTime.Now, GroupId = Result.Entity.Id, UserId = User.Id});
                context.SaveChanges();
                return new Response { Status = 100, Message = "Запрос успешно прошел" };
            }

        }

        public async Task<Response> Update(GroupUpdateModel GroupUpdateModel, ClaimsPrincipal user)
        {
            using (var context = _applicationDbContextFactory.Create())
            {
                var User = await _userManager.FindByNameAsync(user.Identity.Name);
                var Group = Mapper.Map<Group>(GroupUpdateModel);
                if (!context.Groups.Any(i => i.Id == Group.Id))
                    return new Response { Status = 500, Message = "Нет такой группы!" };
                if (!context.Check<Group>(Group.TeacherId))
                    return new Response { Status = 500, Message = "Такого курса нет!" };

                context.Groups.Update(Group);
                context.groupHistories.Add(new GroupHistory { Action = "Создание", DateTime = DateTime.Now, GroupId = GroupUpdateModel.Id, UserId = User.Id });
                context.SaveChanges();
                return new Response { Status = 100, Message = "Запрос успешно прошел" };
            }
        }

        public async Task<Response> Delete(int GroupId, ClaimsPrincipal user)
        {
            using (var context = _applicationDbContextFactory.Create())
            {
                var User = await _userManager.FindByNameAsync(user.Identity.Name);
                var Group = context.Groups.Where(i => i.Id == GroupId).FirstOrDefault();
                if (Group == null)
                    return new Response { Status = 500, Message = "Объект не найден" };

                Group.IsArchive = true;
                context.Groups.Update(Group);
                context.groupHistories.Add(new GroupHistory { Action = "Создание", DateTime = DateTime.Now, GroupId = GroupId, UserId = User.Id });
                context.SaveChanges();
                return new Response { Status = 100, Message = "Запрос успешно прошел" };
            }
        }

        public async Task<ResponseObject<GroupDetailsModel>> GetById(int Id)
        {
            using (var context = _applicationDbContextFactory.Create())
            {
                var Group = context.IncludeGroup(Id);
                if (Group == null)
                    return new ResponseObject<GroupDetailsModel> { Status = 500, Message = "Объект не найден" };
                var Model = Mapper.Map<GroupDetailsModel>(Group);
                
                return new ResponseObject<GroupDetailsModel> { Status = 100, Message = "Запрос прошел успешно", ResponseObj=Model };
            }
        }

        public async Task<ResponseObject<List<GroupIndexModel>>> GetAll()
        {
            using (var context = _applicationDbContextFactory.Create())
            {
                var Groups = context.GroupsInclude();
                var Models = Mapper.Map<List<GroupIndexModel>>(Groups);
                return new ResponseObject<List<GroupIndexModel>>
                {
                    Status = 100,
                    Message = "Запрос прошел успешно",
                    ResponseObj = Models
                };
            }
        }



        public async Task<FilterResponse<List<GroupDetailsModel>>> IndexFilter(GroupsFilter filter)
        {
            using (var context = _applicationDbContextFactory.Create())
            {
                var Groups = context.GroupsFilterInclude(CitiesId: filter.CitiesId, CoursesId: filter.CoursesId, GroupName: filter.GroupName, StartDate: filter.StartDate, EndDate: filter.EndDate);
                var GroupsList = Mapper.Map<List<GroupDetailsModel>>(Groups);
                var pagedData = GroupsList;
                var totalRecords = GroupsList.Count();
                var pagedReponse = FilterHelper.CreatePagedReponse(pagedData, totalRecords);
                return pagedReponse;
            }
        }



    
    }
}
