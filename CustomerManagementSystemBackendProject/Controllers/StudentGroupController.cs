using CustomerManagementSystemBackendProject.BL.Services.Contracts;
using CustomerManagementSystemBackendProject.DAL.Entities;
using CustomerManagementSystemBackendProject.Models.CommonModels;
using CustomerManagementSystemBackendProject.Models.StudentGroupModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagementSystemBackendProject.Controllers
{
    
        [Authorize]
        [Route("[controller]")]
        [ApiController]
        public class StudentGroupController : ControllerBase
        {
            private readonly IStudentGroupService _studentGroupService;

            public StudentGroupController(IStudentGroupService studentGroupService)
            {
            _studentGroupService = studentGroupService;
            }

            [Route("Create")]
            [HttpPost]
            public async Task<Response> Create(int StudentId, int GroupId)
            {
                return await _studentGroupService.Create(StudentId, GroupId);
            }
            [Route("Index")]
            [HttpGet]
            public async Task<ActionResult<ResponseObject<List<StudentGroupModel>>>> Index()
        {
                return await _studentGroupService.GetAll(); 
            }
        }
}
