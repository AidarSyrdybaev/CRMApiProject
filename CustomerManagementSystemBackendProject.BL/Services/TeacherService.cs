using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CustomerManagementSystemBackendProject.DAL.Factories;
using CustomerManagementSystemBackendProject.DAL.Entities;
using CustomerManagementSystemBackendProject.Models.CommonModels;
using CustomerManagementSystemBackendProject.Models.TeacherModels;
using System.Threading.Tasks;
using System.Linq;
using CustomerManagementSystemBackendProject.DAL.Extensions.Check;
using CustomerManagementSystemBackendProject.DAL.Extensions.IncludeExtensions;
using CustomerManagementSystemBackendProject.BL.Services.Contracts;
using CustomerManagementSystemBackendProject.Models.FilterModels;
using CustomerManagementSystemBackendProject.BL.Helpers;
using CustomerManagementSystemBackendProject.Models.WebModels.Wrappers;
using CustomerManagementSystemBackendProject.Models.GroupModels;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace CustomerManagementSystemBackendProject.BL.Services
    {
        public class TeacherService: ITeacherService
        {
            private readonly IApplicationDbContextFactory _applicationDbContextFactory;
            private readonly UserManager<User> _userManager;

            public TeacherService(IApplicationDbContextFactory applicationDbContextFactory, UserManager<User> userManager)
            {
                _applicationDbContextFactory = applicationDbContextFactory;
            _userManager = userManager;
            }

            public async Task<Response> Create(TeacherCreateModel TeacherCreateModel, ClaimsPrincipal User)
            {
                using (var context = _applicationDbContextFactory.Create())
                {
                    var user = await _userManager.FindByNameAsync(User.Identity.Name);
                    var Teacher = Mapper.Map<Teacher>(TeacherCreateModel);
                    if (!context.Check<City>(Teacher.CityId))
                        return new Response { Status = 500, Message = "Такого города нет" };
                    if (!context.Check<Course>(Teacher.CourseId))
                        return new Response { Status = 500, Message = "Такого курса нет" };
                    var Result = context.Teachers.Add(Teacher);
                    context.SaveChanges();
                    context.TeacherHistories.Add(new TeacherHistory { Action = "Создание", TeacherId = Result.Entity.Id, DateTime = DateTime.Now, UserId = user.Id });
                    context.SaveChanges();
                return new Response { Status = 100, Message = "Запрос успешно прошел" };
                }

            }

            public async Task<Response> Update(TeacherUpdateModel TeacherUpdateModel, ClaimsPrincipal User)
            {
                using (var context = _applicationDbContextFactory.Create())
                {
                    var user = await _userManager.FindByNameAsync(User.Identity.Name);
                    var Teacher = Mapper.Map<Teacher>(TeacherUpdateModel);
                    if (!context.Check<City>(Teacher.CityId))
                        return new Response { Status = 500, Message = "Такого города нет" };

                    context.Teachers.Update(Teacher);
                context.TeacherHistories.Add(new TeacherHistory { Action = "Обновление", TeacherId = Teacher.Id, DateTime = DateTime.Now, UserId = user.Id });
                context.SaveChanges();
                    return new Response { Status = 100, Message = "Запрос успешно прошел" };
                }
            }

            public async Task<Response> Delete(int TeacherId, ClaimsPrincipal User)
            {
                using (var context = _applicationDbContextFactory.Create())
                {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                var Teacher = context.Teachers.Where(i => i.Id == TeacherId).FirstOrDefault();
                    if (Teacher == null)
                        return new Response { Status = 500, Message = "Объект не найден" };

                    Teacher.IsArchive = true;
                    context.Teachers.Update(Teacher);
                context.TeacherHistories.Add(new TeacherHistory { Action = "Удаление", UserId = user.Id, TeacherId = TeacherId, DateTime = DateTime.Now });

                context.SaveChanges();
                    return new Response { Status = 100, Message = "Запрос успешно прошел" };
                }
            }

            public async Task<ResponseObject<TeacherDetailsModel>> GetById(int Id)
            {
                using (var context = _applicationDbContextFactory.Create())
                {
                    var Teacher = context.IncludeTeacher(Id);
                    if (Teacher == null)
                        return new ResponseObject<TeacherDetailsModel> { Status = 500, Message = "Объект не найден" };
                    var Model = Mapper.Map<TeacherDetailsModel>(Teacher);

                    return new ResponseObject<TeacherDetailsModel> { Status = 100, Message = "Запрос прошел успешно", ResponseObj = Model };
                }
            }

            public async Task<ResponseObject<List<TeacherIndexModel>>> GetAll()
            {
                using (var context = _applicationDbContextFactory.Create())
                {
                    var Teachers = context.IncludeTeachers();
                    var Models = Mapper.Map<List<TeacherIndexModel>>(Teachers);
                    return new ResponseObject<List<TeacherIndexModel>>
                    {
                        Status = 100,
                        Message = "Запрос прошел успешно",
                        ResponseObj = Models
                    };
                }
            }
        public async Task<FilterResponse<List<TeacherDetailsModel>>> IndexFilter(EmployeesFilter filter)
        {
            using (var context = _applicationDbContextFactory.Create())
            {
                var Teachers = context.TeachersFilterInclude( CitiesId: filter.CitiesId, Name: filter.Name);
                var TeachersList = Mapper.Map<List<TeacherDetailsModel>>(Teachers);
                var pagedData = TeachersList;
                var totalRecords = TeachersList.Count();
                var pagedReponse = FilterHelper.CreatePagedReponse(pagedData, totalRecords);
                return pagedReponse;
            }
        }


        public async Task<FilterResponse<List<TeacherDetailsModel>>> IndexFilterNew(EmployeesFilter filter)
        {
            using (var context = _applicationDbContextFactory.Create())
            {

                var Teachers = context.TeachersFilterInclude(CitiesId: filter.CitiesId, Name: filter.Name); ;
                var Models = new List<TeacherDetailsModel>();
                foreach (var Teacher in Teachers)
                {

                    var Model = Mapper.Map<TeacherDetailsModel>(Teacher);
                    var GroupsList = context.IncludeTeacherGroup(Teacher.Id);
                    Model.Groups = Mapper.Map<List<GroupIndexModel>>(GroupsList);
                    Models.Add(Model);
                }
                var pagedData = Models;
                var totalRecords = Models.Count();
                var pagedReponse = FilterHelper.CreatePagedReponse(pagedData, totalRecords);
                return pagedReponse;
            }
        }

    }
    }
