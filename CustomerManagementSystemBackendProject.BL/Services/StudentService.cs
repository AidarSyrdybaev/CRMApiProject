using AutoMapper;
using CustomerManagementSystemBackendProject.BL.Helpers;
using CustomerManagementSystemBackendProject.BL.Services.Contracts;
using CustomerManagementSystemBackendProject.DAL.Entities;
using CustomerManagementSystemBackendProject.DAL.Extensions.Check;
using CustomerManagementSystemBackendProject.DAL.Extensions.IncludeExtensions;
using CustomerManagementSystemBackendProject.DAL.Factories;
using CustomerManagementSystemBackendProject.Models.CommonModels;
using CustomerManagementSystemBackendProject.Models.FilterModels;
using CustomerManagementSystemBackendProject.Models.GroupModels;
using CustomerManagementSystemBackendProject.Models.LeadModels;
using CustomerManagementSystemBackendProject.Models.StudentCommentModels;
using CustomerManagementSystemBackendProject.Models.StudentModels;
using CustomerManagementSystemBackendProject.Models.WebModels.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystemBackendProject.BL.Services
{
    public class StudentService:IStudentService
    {
        private readonly IApplicationDbContextFactory _applicationDbContextFactory;

        private readonly IStudentGroupService _studentGroupService;

        public StudentService(IApplicationDbContextFactory applicationDbContextFactory, IStudentGroupService studentGroupService)
        {
            _applicationDbContextFactory = applicationDbContextFactory;
            _studentGroupService = studentGroupService;
        }
        public async Task<Response> Create(StudentCreateModel studentCreateModel)
        {
            using (var context = _applicationDbContextFactory.Create())
            {
                var Lead = context.LeadInclude(studentCreateModel.LeadId);

                var StatusID = context.LeadStatuses.Where(i => i.Name == "Успешная сделка").Select(i => i.Id).FirstOrDefault();
              
                Lead.LeadStatusId = StatusID;
                if (Lead == null)
                    return new ResponseObject<LeadDetailsModel> { Status = 500, Message = "Объект не найден" };
                if (!context.Check<Lead>(studentCreateModel.LeadId))
                    return new Response { Status = 500, Message = "Такого лида нет!" };
                if (!context.Check<Group>(studentCreateModel.GroupId))
                    return new Response { Status = 500, Message = "Такой группы нет!" };
                var Student = Mapper.Map<Student>(Lead);
                var Entry = context.Students.Add(Student);
                context.Leads.Remove(Lead);
                context.SaveChanges();
                _studentGroupService.Create(Entry.Entity.Id, studentCreateModel.GroupId);
                return new Response { Status = 100, Message = "Запрос успешно прошел." };
            }

        }

        public async Task<Response> FullCreate(StudentFullCreateModel studentFullCreateModel)
        {
            using (var context = _applicationDbContextFactory.Create())
            {
                var Student = Mapper.Map<Student>(studentFullCreateModel);
                if (!context.Check<City>(studentFullCreateModel.CityId))
                    return new Response { Status = 500, Message = "Такого города нет!" };
                if (context.Students.Any(i => i.Id == Student.Id))
                    return new Response { Status = 500, Message = "Такой студент уже существует!" };
                if (!context.Check<Group>(studentFullCreateModel.GroupId))
                    return new Response { Status = 500, Message = "Такой группы нет!" };
                Student.Surname = studentFullCreateModel.Surname;
                Student.Name = studentFullCreateModel.Name;
                Student.MiddleName = studentFullCreateModel.MiddleName;
                Student.CityId = studentFullCreateModel.CityId;
                Student.Phone = studentFullCreateModel.Phone;
                Student.Email = studentFullCreateModel.Email;
                Student.Address = studentFullCreateModel.Address;
                Student.HasLaptop = studentFullCreateModel.HasLaptop;
                var Entry = context.Students.Add(Student);
                context.SaveChanges();
                _studentGroupService.Create(Entry.Entity.Id, studentFullCreateModel.GroupId);
                
                
                return new Response { Status = 100, Message = "Запрос успешно прошел." };
            }

        }
        //public async Task<ResponseObject<List<StudentIndexModel>>> GetAll()
        //{
        //    using (var context = _applicationDbContextFactory.Create())
        //    {
        //        var Students = context.StudentsInclude();
        //        var Models = Mapper.Map<List<StudentIndexModel>>(Students);
        //        return new ResponseObject<List<StudentIndexModel>>
        //        {
        //            Status = 100,
        //            Message = "Запрос прошел успешно",
        //            ResponseObj = Models
        //        };
        //    }
        //}

        public async Task<ResponseObject<List<StudentIndexModel>>> GetAll()
        {
            using (var context = _applicationDbContextFactory.Create())
            {
                var Students = context.StudentsGroupsInclude();
                var Models = Mapper.Map<List<StudentIndexModel>>(Students);
                return new ResponseObject<List<StudentIndexModel>>
                {
                    Status = 100,
                    Message = "Запрос прошел успешно",
                    ResponseObj = Models
                };
            }
        }
        public async Task<ResponseObject<StudentDetailsModel>> GetById(int Id)
        {
            using (var context = _applicationDbContextFactory.Create())
            {
                var Student = context.StudentInclude(Id); 
                if (Student == null)
                    return new ResponseObject<StudentDetailsModel> { Status = 500, Message = "Объект не найден" };
                var Model = Mapper.Map<StudentDetailsModel>(Student);
                Model.Groups = Mapper.Map<List<GroupIndexModel>>(context.GroupsInclude(Id));
                var CommentsList = context.OneStudentCommentsInclude(Student.Id);
                Model.StudentComments = Mapper.Map<List<StudentCommentIndexModel>>(CommentsList);
                return new ResponseObject<StudentDetailsModel> { Status = 100, Message = "Запрос прошел успешно", ResponseObj = Model };
            }
        }

        public async Task<Response> Delete(int StudentId)
        {
            using (var context = _applicationDbContextFactory.Create())
            {
                var Student = context.Students.Where(i => i.Id == StudentId).FirstOrDefault();
                if (Student == null)
                    return new Response { Status = 500, Message = "Объект не найден" };

                Student.IsArchive = true;
                context.Students.Update(Student);
                context.SaveChanges();
                return new Response { Status = 100, Message = "Запрос успешно прошел" };
            }
        }
        public async Task<Response> Update(StudentUpdateModel studentUpdateModel)
        {
            using (var context = _applicationDbContextFactory.Create())
            {
                var Student = Mapper.Map<Student>(studentUpdateModel);
                if (!context.Students.Any(i => i.Id == Student.Id))
                    return new Response { Status = 500, Message = "Нет такого студента!" };
                if (!context.Check<City>(studentUpdateModel.CityId))
                    return new Response { Status = 500, Message = "Такого города нет!" };

                context.Students.Update(Student);
                context.SaveChanges();
                return new Response { Status = 100, Message = "Запрос успешно прошел" };
            }
        }

        public async Task<PagedResponse<List<StudentIndexModel>>> IndexPagination(PaginationFilter filter)
        {
            using (var context = _applicationDbContextFactory.Create())
            {
                var Students = context.StudentsFilterInclude(PageNumber: filter.PageNumber, PageSize: filter.PageSize, CitiesId: filter.CitiesId, CoursesId: filter.CoursesId, StudentName: filter.StudentName, StartDate: filter.StartDate, EndDate: filter.EndDate);
                var StudentsList = Mapper.Map<List<StudentIndexModel>>(Students);
                var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
                var pagedData = StudentsList;
                var totalRecords = StudentsList.Count();
                var pagedReponse = PaginationHelper.CreatePagedReponse(pagedData, validFilter, totalRecords);
                return pagedReponse;
            }
        }
    }
}
