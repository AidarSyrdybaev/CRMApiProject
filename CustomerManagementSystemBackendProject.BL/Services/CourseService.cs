using AutoMapper;
using CustomerManagementSystemBackendProject.DAL.Entities;
using CustomerManagementSystemBackendProject.DAL.Factories;
using CustomerManagementSystemBackendProject.Models.CommonModels;
using CustomerManagementSystemBackendProject.Models.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerManagementSystemBackendProject.DAL.Extensions.Check;
using CustomerManagementSystemBackendProject.BL.Services.Contracts;
using CustomerManagementSystemBackendProject.Models.TeacherModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace CustomerManagementSystemBackendProject.BL.Services
{
    public class CourseService: ICourseService
    {
        private UserManager<User> _userManager;
        private readonly IApplicationDbContextFactory _applicationDbContextFactory;

        public CourseService(IApplicationDbContextFactory applicationDbContextFactory, UserManager<User> userManager)
        {
            _applicationDbContextFactory = applicationDbContextFactory;
            _userManager = userManager;
        }

        public async Task<Response> Create(CourseCreateModel courseCreateModel, ClaimsPrincipal claimsPrincipal)
        {
            using (var context = _applicationDbContextFactory.Create())
            {
                var User = await _userManager.FindByNameAsync(claimsPrincipal.Identity.Name);
                var Course = Mapper.Map<Course>(courseCreateModel);
                if(!context.Check<City>(courseCreateModel.CityId))
                    return new Response { Status = 500, Message = "Такого города нет!" };
                if (context.Courses.Any(i => i.Name == Course.Name && i.CityId == courseCreateModel.CityId))
                    return new Response { Status = 500, Message = "Такой курс уже есть в этом городе!" };
                var Result = context.Courses.Add(Course);
                context.SaveChanges();
                context.courseHistories.Add(new CourseHistory { Action = "Создание", CourseId = Result.Entity.Id, DateTime = DateTime.Now, UserId = User.Id });
                context.SaveChanges();
                return new Response { Status = 100, Message = "Запрос успешно прошел." };
            }

        }

        public async Task<Response> Update(CourseUpdateModel courseUpdateModel, ClaimsPrincipal claimsPrincipal)
        {
            using (var context = _applicationDbContextFactory.Create())
            {
                var User = await _userManager.FindByNameAsync(claimsPrincipal.Identity.Name);
                var Course = Mapper.Map<Course>(courseUpdateModel);
                if (!context.Check<City>(courseUpdateModel.CityId))
                    return new Response { Status = 500, Message = "Такого города нет!" };
                if (context.Courses.Any(i => i.Name == Course.Name && i.CityId == courseUpdateModel.CityId))
                    return new Response { Status = 500, Message = "Такой курс уже есть в этом городе!" };

                context.Courses.Update(Course);
                context.courseHistories.Add(new CourseHistory { Action = "Обновление", CourseId =courseUpdateModel.Id, DateTime = DateTime.Now, UserId = User.Id });
                context.SaveChanges();
                return new Response { Status = 100, Message = "Запрос успешно прошел" };
            }
        }

        public async Task<Response> Delete(int CourseId,  ClaimsPrincipal claimsPrincipal)
        {
            using (var context = _applicationDbContextFactory.Create())
            {
                var User = await _userManager.FindByNameAsync(claimsPrincipal.Identity.Name);
                var course = context.Courses.Where(i => i.Id == CourseId).FirstOrDefault();
                if (course == null || course.IsArchive == true)
                    return new Response { Status = 500, Message = "Объект не найден" };

                course.IsArchive = true;
                context.courseHistories.Add(new CourseHistory { Action = "Удаление", CourseId = CourseId, DateTime = DateTime.Now, UserId = User.Id });
                context.Courses.Update(course);
                context.SaveChanges();
                return new Response { Status = 100, Message = "Запрос успешно прошел" };
            }
        }

        public async Task<ResponseObject<CourseDetailsModel>> GetById(int Id)
        {
            using (var context = _applicationDbContextFactory.Create())
            {
                var Course = context.IncludeCourse(Id);
                var Model = Mapper.Map<CourseDetailsModel>(Course);
                var CourseTeachers = context.Teachers.Where(t => t.CourseId == Id).ToList();
                Model.Teachers = Mapper.Map<List<TeacherIndexModel>>(CourseTeachers);
                if(Course == null)
                    return new ResponseObject<CourseDetailsModel> { Status = 500, Message = "Объект не найден" };
                return new ResponseObject<CourseDetailsModel> { Status=100, Message="Запрос прошел успешно", ResponseObj=Model};
            }
        }

        public async Task<ResponseObject<List<CourseIndexModel>>> GetAll()
        {
            using (var context = _applicationDbContextFactory.Create())
            {
                var Courses = context.Courses.ToList();
                var Models = Mapper.Map<List<CourseIndexModel>>(Courses);
                return new ResponseObject<List<CourseIndexModel>>
                {
                    Status=100,
                    Message="Запрос прошел успешно",
                    ResponseObj=Models
                };
            }
        }
    }
}
