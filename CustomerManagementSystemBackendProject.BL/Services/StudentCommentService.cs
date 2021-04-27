using AutoMapper;
using AutoMapper.Configuration;
using CustomerManagementSystemBackendProject.BL.Services.Contracts;
using CustomerManagementSystemBackendProject.DAL.Entities;
using CustomerManagementSystemBackendProject.DAL.Extensions.Check;
using CustomerManagementSystemBackendProject.DAL.Extensions.IncludeExtensions;
using CustomerManagementSystemBackendProject.DAL.Factories;
using CustomerManagementSystemBackendProject.Models.CommonModels;
using CustomerManagementSystemBackendProject.Models.StudentCommentModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystemBackendProject.BL.Services
{
    public class StudentCommentService: IStudentCommentService
    {
        private readonly IApplicationDbContextFactory _applicationDbContextFactory;
        private readonly UserManager<User> UserManager;
        public StudentCommentService(IApplicationDbContextFactory applicationDbContextFactory, UserManager<User> userManager)
        {
            UserManager = userManager;
            _applicationDbContextFactory = applicationDbContextFactory;
        }
        public async Task<ResponseObject<List<StudentCommentIndexModel>>> GetAll()
        {
            using (var context = _applicationDbContextFactory.Create())
            {
                var StudentComments = context.StudentCommentsInclude();
                var Models = Mapper.Map<List<StudentCommentIndexModel>>(StudentComments);
                return new ResponseObject<List<StudentCommentIndexModel>>
                {
                    Status = 100,
                    Message = "Запрос прошел успешно",
                    ResponseObj = Models
                };
            }
        }


        public async Task<Response> Create(StudentCommentCreateModel studentCommentCreateModel, ClaimsPrincipal User)
        {
            using (var context = _applicationDbContextFactory.Create())
            {
                User user = await UserManager.FindByNameAsync(User.Identity.Name);
                if (user != null)
                {
                    var StudentComment = Mapper.Map<StudentComment>(studentCommentCreateModel);
                    if (!context.Check<Student>(studentCommentCreateModel.StudentId))
                        return new Response { Status = 500, Message = "Такого студента нет!" };
                    StudentComment.UserId = user.Id;
                    StudentComment.CommentDateTime = DateTime.Now;
                    context.StudentComments.Add(StudentComment);
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
