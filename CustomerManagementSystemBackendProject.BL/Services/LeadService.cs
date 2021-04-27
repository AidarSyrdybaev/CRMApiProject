using AutoMapper;
using CustomerManagementSystemBackendProject.BL.Helpers;
using CustomerManagementSystemBackendProject.BL.Services.Contracts;
using CustomerManagementSystemBackendProject.DAL.Entities;
using CustomerManagementSystemBackendProject.DAL.Extensions.Check;
using CustomerManagementSystemBackendProject.DAL.Extensions.IncludeExtensions;
using CustomerManagementSystemBackendProject.DAL.Factories;
using CustomerManagementSystemBackendProject.Models.CommonModels;
using CustomerManagementSystemBackendProject.Models.FilterModels;
using CustomerManagementSystemBackendProject.Models.FlexByModels;
using CustomerManagementSystemBackendProject.Models.LeadCommentModels;
using CustomerManagementSystemBackendProject.Models.LeadModels;
using CustomerManagementSystemBackendProject.Models.WebModels.Wrappers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystemBackendProject.BL.Services
{
    public class LeadService: ILeadService
    {
        private readonly IApplicationDbContextFactory _applicationDbContextFactory;
        private UserManager<User> _userManager;

        public LeadService(IApplicationDbContextFactory applicationDbContextFactory, UserManager<User> userManager)
        {
            _applicationDbContextFactory = applicationDbContextFactory;
            _userManager = userManager;
        }


        public async Task<ResponseObject<List<LeadIndexModel>>> GetAll()
        {
            using (var context = _applicationDbContextFactory.Create())
            {
                var Leads = context.LeadsInclude();
                var Models = Mapper.Map<List<LeadIndexModel>>(Leads);
                return new ResponseObject<List<LeadIndexModel>>
                {
                    Status = 100,
                    Message = "Запрос прошел успешно",
                    ResponseObj = Models
                };
            }
        }

        public async Task<PagedResponse<List<LeadIndexModel>>> IndexPagination(PaginationFilter filter)
        {
            using (var context = _applicationDbContextFactory.Create())
            {   

               var Leads = context.LeadsFilterInclude(PageNumber: filter.PageNumber, PageSize: filter.PageSize, CitiesId: filter.CitiesId, CoursesId: filter.CoursesId, LeadStatusesId: filter.LeadStatusesId);
               var LeadsList = Mapper.Map<List<LeadIndexModel>>(Leads);
               var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
               var pagedData = LeadsList;
               var totalRecords = LeadsList.Count();
               var pagedReponse = PaginationHelper.CreatePagedReponse(pagedData, validFilter, totalRecords);
               return pagedReponse;
            }
        }

        private PagedResponse<List<LeadIndexModel>> Ok(PagedResponse<List<Lead>> pagedReponse)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> Create(LeadCreateModel leadCreateModel, ClaimsPrincipal user)
        {
            using (var context = _applicationDbContextFactory.Create())
            {
                var User = await _userManager.FindByNameAsync(user.Identity.Name);
                var Lead = Mapper.Map<Lead>(leadCreateModel);
                if (!context.Check<Course>(leadCreateModel.CourseId))
                    return new Response { Status = 500, Message = "Такого курса нет!" };
                if (!context.Check<LeadStatus>(leadCreateModel.LeadStatusId))
                    return new Response { Status = 500, Message = "Такого статуса нет!" };
           
                if (!context.Check<City>(leadCreateModel.CityId))
                    return new Response { Status = 500, Message = "Такого города нет!" };
                if (context.Leads.Any(i => i.Id == Lead.Id))
                    return new Response { Status = 500, Message = "Такой лид уже существует!" };
                Lead.CreateDate = DateTime.Now;
                var Result = context.Leads.Add(Lead);
                context.SaveChanges();
                context.LeadHistories.Add(new LeadHistory { Action="Создание", LeadId = Result.Entity.Id, DateTime = DateTime.Now, UserId = User.Id});
                context.SaveChanges();
                return new Response { Status = 100, Message = "Запрос успешно прошел." };
            }

        }

        public async Task<Response> Delete(int LeadId, ClaimsPrincipal user)
        {
            using (var context = _applicationDbContextFactory.Create())
            {
                var User = await _userManager.FindByNameAsync(user.Identity.Name);
                var Lead = context.Leads.Where(i => i.Id == LeadId).FirstOrDefault();
                if (Lead == null)
                    return new Response { Status = 500, Message = "Объект не найден" };
                Lead.IsArchive = true;
                context.Leads.Add(Lead);
                context.LeadHistories.Add(new LeadHistory { Action = "Удаление", LeadId = LeadId, DateTime = DateTime.Now, UserId = User.Id });
                context.SaveChanges();
                return new Response { Status = 100, Message = "Запрос успешно прошел" };
            }
        }

        public async Task<ResponseObject<LeadDetailsModel>> GetById(int Id)
        {
            using (var context = _applicationDbContextFactory.Create())
            {
                var Lead = context.LeadInclude(Id);
                if (Lead == null)
                    return new ResponseObject<LeadDetailsModel> { Status = 500, Message = "Объект не найден" };
                var Model = Mapper.Map<LeadDetailsModel>(Lead);
                var CommentsList = context.OneLeadCommentsInclude(Lead.Id);
                Model.LeadComments = Mapper.Map<List<LeadCommentIndexModel>>(CommentsList);
                return new ResponseObject<LeadDetailsModel> { Status = 100, Message = "Запрос прошел успешно", ResponseObj = Model };
            }
        }

        public async Task<Response> Update(LeadUpdateModel leadUpdateModel, ClaimsPrincipal user)
        {
            using (var context = _applicationDbContextFactory.Create())
            {
                var User = await _userManager.FindByNameAsync(user.Identity.Name);
                var Lead = Mapper.Map<Lead>(leadUpdateModel);
                if (!context.Leads.Any(i => i.Id == Lead.Id))
                    return new Response { Status = 500, Message = "Нет такого лида!" };
                if (!context.Check<Course>(leadUpdateModel.CourseId))
                    return new Response { Status = 500, Message = "Такого курса нет!" };
                if (!context.Check<LeadStatus>(leadUpdateModel.LeadStatusId))
                    return new Response { Status = 500, Message = "Такого статуса нет!" };
                if (!context.Check<City>(leadUpdateModel.CityId))
                    return new Response { Status = 500, Message = "Такого города нет!" };
                Lead.CreateDate = context.Leads.Where(i => i.Id == leadUpdateModel.Id).Select(i => i.CreateDate).FirstOrDefault();

                context.LeadHistories.Add(new LeadHistory { Action = "Обновление", LeadId = leadUpdateModel.Id, DateTime = DateTime.Now, UserId = User.Id });
                context.Leads.Update(Lead);
                context.SaveChanges();
                return new Response { Status = 100, Message = "Запрос успешно прошел" };
            }
        }

        public async Task<Response> UpdateStatus(LeadUpdateStatusModel leadUpdateStatusModel, ClaimsPrincipal user)
        {
            using (var context = _applicationDbContextFactory.Create())
            {
                var User = await _userManager.FindByNameAsync(user.Identity.Name);
                var Lead = context.Leads.Where(i => i.Id == leadUpdateStatusModel.Id).FirstOrDefault();
                Lead.LeadStatusId = leadUpdateStatusModel.LeadStatusId;
                if (!context.Leads.Any(i => i.Id == Lead.Id))
                    return new Response { Status = 500, Message = "Нет такого лида!" };
                if (!context.Check<LeadStatus>(leadUpdateStatusModel.LeadStatusId))
                    return new Response { Status = 500, Message = "Такого статуса нет!" };
                context.LeadHistories.Add(new LeadHistory { Action = "Обновление", LeadId = leadUpdateStatusModel.Id, DateTime = DateTime.Now, UserId = User.Id });
                context.Leads.Update(Lead);
                context.SaveChanges();
                return new Response { Status = 100, Message = "Запрос успешно прошел" };
            }
        }

        public async Task<Response> UpdateFailureStatus(LeadFailureModel leadFailureStatusModel, ClaimsPrincipal user)
        {
            using (var context = _applicationDbContextFactory.Create())
            {
                var User = await _userManager.FindByNameAsync(user.Identity.Name);
                var Lead = context.Leads.Where(i => i.Id == leadFailureStatusModel.Id).FirstOrDefault();
                Lead.LeadStatusId = context.LeadStatuses.Where(i => i.Name.ToLower() == "провальная сделка" ).Select(i => i.Id).FirstOrDefault();
                Lead.LeadFailureStatusId = leadFailureStatusModel.LeadFailureReasonId;
                if (!context.Leads.Any(i => i.Id == Lead.Id))
                    return new Response { Status = 500, Message = "Нет такого лида!" };
                if (!context.Check<LeadFailureStatus>(leadFailureStatusModel.LeadFailureReasonId))
                    return new Response { Status = 500, Message = "Такого статуса нет!" };
                context.LeadHistories.Add(new LeadHistory { Action = "Обновление", LeadId = leadFailureStatusModel.Id, DateTime = DateTime.Now, UserId = User.Id });
                context.Leads.Update(Lead);
                context.SaveChanges();
                return new Response { Status = 100, Message = "Запрос успешно прошел" };
            }
        }
        public async Task<Response> AddLeadInformation(RequestInformation requestInformation)
        {
            using (var context = _applicationDbContextFactory.Create())
            {
                foreach (var lead in requestInformation.data.Leads)
                {
                    if (!context.Leads.Any(i => i.FlexById == lead.Key))
                    {
                        var Lead = new Lead
                        {
                            FlexById = lead.Key,
                            Name = "Test",
                            CourseId = 2,
                            CityId = 1,
                            LeadStatusId = 1,
                            Phone = lead.Value.Client.Phone
                        };
                        context.Leads.Add(Lead);
                    }
                }
                context.SaveChanges();
                return new Response { Status = 100, Message = "Запрос успешно прошел" };
            }
        }

        public async Task<List<NotificationIndexModel>> Notifications()
        {
            using (var context = _applicationDbContextFactory.Create())
            {
                var Entites = context.LeadsNotifies.ToList().OrderByDescending(i => i.Date);
                return Mapper.Map<List<NotificationIndexModel>>(Entites);
            }
        }
    }
}
