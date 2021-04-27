using AutoMapper;
using CustomerManagementSystemBackendProject.BL.Services.Contracts;
using CustomerManagementSystemBackendProject.DAL.Entities;
using CustomerManagementSystemBackendProject.DAL.Extensions.Check;
using CustomerManagementSystemBackendProject.DAL.Extensions.IncludeExtensions;
using CustomerManagementSystemBackendProject.DAL.Factories;
using CustomerManagementSystemBackendProject.Models.CommonModels;
using CustomerManagementSystemBackendProject.Models.StudentGroupModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystemBackendProject.BL.Services
{
    public class StudentGroupService:IStudentGroupService
    {
        private readonly IApplicationDbContextFactory _applicationDbContextFactory;

        public StudentGroupService(IApplicationDbContextFactory applicationDbContextFactory)
        {
            _applicationDbContextFactory = applicationDbContextFactory;
        }
        public async Task<Response> Create(int StudentId, int GroupId)
        {
            using (var context = _applicationDbContextFactory.Create())
            {
                var StudentGroup = context.StudentGroups.Where(i => i.StudentId == StudentId && i.GroupId == GroupId).FirstOrDefault();
                if (StudentGroup != null)
                    return new ResponseObject<StudentGroup> { Status = 500, Message = "Студент в этой группе уже есть!" };
                if (!context.Check<Student>(StudentId))
                    return new Response { Status = 500, Message = "Такого студента нет!" };
                if (!context.Check<Group>(GroupId))
                    return new Response { Status = 500, Message = "Такой группы нет!" };
                context.StudentGroups.Add(new StudentGroup { StudentId = StudentId, GroupId = GroupId});
                context.SaveChanges();
                return new Response { Status = 100, Message = "Запрос успешно прошел." };
            }

        }
        public async Task<ResponseObject<List<StudentGroupModel>>> GetAll()
        {
            using (var context = _applicationDbContextFactory.Create())
            {
                var StudentGroups = context.StudentGroupsInclude();
                var Models = Mapper.Map<List<StudentGroupModel>>(StudentGroups);
                return new ResponseObject<List<StudentGroupModel>>
                {
                    Status = 100,
                    Message = "Запрос прошел успешно",
                    ResponseObj = Models
                };
            }
        }
    }
}
