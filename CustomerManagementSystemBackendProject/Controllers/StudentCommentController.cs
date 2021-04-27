using CustomerManagementSystemBackendProject.BL.Services.Contracts;
using CustomerManagementSystemBackendProject.Models.CommonModels;
using CustomerManagementSystemBackendProject.Models.StudentCommentModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagementSystemBackendProject.Controllers
{
    [Route("[controller]")]
    [Authorize]
    [ApiController]
    public class StudentCommentController : ControllerBase
    {
        private readonly IStudentCommentService _StudentCommentService;

        public StudentCommentController(IStudentCommentService StudentCommentService)
        {
            _StudentCommentService = StudentCommentService;
        }
        [Route("Index")]
        [HttpGet]
        public async Task<ActionResult<ResponseObject<List<StudentCommentIndexModel>>>> Index()
        {
            return await _StudentCommentService.GetAll();

        }
        [Route("Create")]
        [HttpPost]
        public async Task<ActionResult<Response>> Create(StudentCommentCreateModel model)
        {
            return await _StudentCommentService.Create(model, User);
            
        }
    }
}
