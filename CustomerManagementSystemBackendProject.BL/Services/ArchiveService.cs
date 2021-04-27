using AutoMapper;
using CustomerManagementSystemBackendProject.BL.Services.Contracts;
using CustomerManagementSystemBackendProject.DAL.Extensions.IncludeExtensions;
using CustomerManagementSystemBackendProject.DAL.Factories;
using CustomerManagementSystemBackendProject.Models.GroupModels;
using CustomerManagementSystemBackendProject.Models.StudentModels;
using CustomerManagementSystemBackendProject.Models.TeacherModels;
using CustomerManagementSystemBackendProject.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystemBackendProject.BL.Services
{
    public class ArchiveService: IArchiveService
    {
        private IApplicationDbContextFactory _applicationDbContextFactory;

        public ArchiveService(IApplicationDbContextFactory applicationDbContextFactory)
        {
            _applicationDbContextFactory = applicationDbContextFactory;
        }

        public async Task<List<UserIndexModel>> UserArchive()
        {
            using (var context = _applicationDbContextFactory.Create())
            {
                var Users = context.IncludeArchiveUsers();
                return Mapper.Map<List<UserIndexModel>>(Users);
            }
        }

        public async Task<List<GroupIndexModel>> GroupArchive()
        {
            using (var context = _applicationDbContextFactory.Create())
            {
                var Users = context.IncludeArchiveGroups();
                return Mapper.Map<List<GroupIndexModel>>(Users);
            }
        }

        public async Task<List<StudentIndexModel>> StudentArchive()
        {
            using (var context = _applicationDbContextFactory.Create())
            {
                var Users = context.StudentsArchiveInclude();
                return Mapper.Map<List<StudentIndexModel>>(Users);
            }
        }

        public async Task<List<TeacherIndexModel>> TeacherArchive()
        {
            using (var context = _applicationDbContextFactory.Create())
            {
                var Users = context.IncludeTeachers();
                return Mapper.Map<List<TeacherIndexModel>>(Users);
            }
        }
    }
}
