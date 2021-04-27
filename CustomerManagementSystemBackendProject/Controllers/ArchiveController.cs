using CustomerManagementSystemBackendProject.BL.Services.Contracts;
using CustomerManagementSystemBackendProject.Models.GroupModels;
using CustomerManagementSystemBackendProject.Models.StudentModels;
using CustomerManagementSystemBackendProject.Models.TeacherModels;
using CustomerManagementSystemBackendProject.Models.UserModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagementSystemBackendProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArchiveController : ControllerBase
    {
        private readonly ILogger<ArchiveController> _logger;
        private readonly IArchiveService _archiveService;

        public ArchiveController(ILogger<ArchiveController> logger, IArchiveService archiveService)
        {
            _logger = logger;
            _archiveService = archiveService;
        }
        [Route(" ArchiveStudents")]
        [HttpGet]
        public async Task<List<StudentIndexModel>> ArchiveStudents()
        {
            return await _archiveService.StudentArchive();
        }
        [Route("ArchiveTeachers")]
        [HttpGet]
        public async Task<List<TeacherIndexModel>> ArchiveTeachers()
        {
            return await _archiveService.TeacherArchive();
        }
        [Route("ArchiveGroups")]
        [HttpGet]
        public async Task<List<GroupIndexModel>> ArchiveGroups()
        {
            return await _archiveService.GroupArchive();
        }
        [Route("ArchiveUsers")]
        [HttpGet]
        public async Task<List<UserIndexModel>> ArchiveUsers()
        {
            return await _archiveService.UserArchive();
        }
    }
}
