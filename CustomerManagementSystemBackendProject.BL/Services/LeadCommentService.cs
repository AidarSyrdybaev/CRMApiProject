using AutoMapper;
using AutoMapper.Configuration;
using CustomerManagementSystemBackendProject.BL.Services.Contracts;
using CustomerManagementSystemBackendProject.DAL.Entities;
using CustomerManagementSystemBackendProject.DAL.Extensions.Check;
using CustomerManagementSystemBackendProject.DAL.Extensions.IncludeExtensions;
using CustomerManagementSystemBackendProject.DAL.Factories;
using CustomerManagementSystemBackendProject.Models.CommonModels;
using CustomerManagementSystemBackendProject.Models.LeadCommentModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystemBackendProject.BL.Services
{
    public class LeadCommentService : ILeadCommentService
    {
        private readonly IApplicationDbContextFactory _applicationDbContextFactory;
        private readonly UserManager<User> UserManager;
       
        public LeadCommentService(IApplicationDbContextFactory applicationDbContextFactory, UserManager<User> userManager)
        {
            UserManager = userManager;
            _applicationDbContextFactory = applicationDbContextFactory;
        }
        public async Task<ResponseObject<List<LeadCommentIndexModel>>> GetAll()
        {
            using (var context = _applicationDbContextFactory.Create())
            {
                var LeadComments = context.LeadCommentsInclude();
                var Models = Mapper.Map<List<LeadCommentIndexModel>>(LeadComments);
                return new ResponseObject<List<LeadCommentIndexModel>>
                {
                    Status = 100,
                    Message = "Запрос прошел успешно",
                    ResponseObj = Models
                };
            }
        }


        public async Task<Response> Create(LeadCommentCreateModel leadCommentCreateModel, ClaimsPrincipal User)
        {
            using (var context = _applicationDbContextFactory.Create())
            {
                User user = await UserManager.FindByNameAsync(User.Identity.Name);
                if (user != null)
                {
                    var LeadComment = Mapper.Map<LeadComment>(leadCommentCreateModel);
                    if (!context.Check<Lead>(leadCommentCreateModel.LeadId))
                        return new Response { Status = 500, Message = "Такого лида нет!" };
                    LeadComment.UserId = user.Id;
                    LeadComment.CommentDateTime = DateTime.Now;
                    context.LeadComments.Add(LeadComment);
                    context.SaveChanges();
                    return new Response { Status = 100, Message = "Запрос успешно прошел." };
                }
                else
                {
                    return null;
                }
            }
        }
    }
}

