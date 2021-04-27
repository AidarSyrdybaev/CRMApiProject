using CustomerManagementSystemBackendProject.BL.Services.Contracts;
using CustomerManagementSystemBackendProject.Models.CommonModels;
using CustomerManagementSystemBackendProject.Models.FilterModels;
using CustomerManagementSystemBackendProject.Models.StudentModels;
using CustomerManagementSystemBackendProject.Models.WebModels.Wrappers;
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
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [Route("Create")]
        [HttpPost]
        public async Task<ActionResult<Response>> Create(StudentCreateModel model)
        {
            return await _studentService.Create(model);
        }

        [Route("FullCreate")]
        [HttpPost]
        public async Task<ActionResult<Response>> Create(StudentFullCreateModel model)
        {
            return await _studentService.FullCreate(model);
        }


        [Route("Index")]
        [HttpGet]
        public async Task<ActionResult<ResponseObject<List<StudentIndexModel>>>> Index()
        {
            return await _studentService.GetAll();
        }

        [Route("Details")]
        [HttpGet]
        public async Task<ActionResult<ResponseObject<StudentDetailsModel>>> Details(int id)
        {
            return await _studentService.GetById(id);
        }
        [Route("Update")]
        [HttpPut]
        public async Task<ActionResult<Response>> Update(StudentUpdateModel model)
        {
            return await _studentService.Update(model);
        }

        [Route("Delete")]
        [HttpDelete]
        public async Task<ActionResult<Response>> Delete(int id)
        {
            return await _studentService.Delete(id);
        }

        [Route("IndexPagination")]
        [HttpGet]
        public async Task<ActionResult<PagedResponse<List<StudentIndexModel>>>> Index([FromQuery] PaginationFilter filter)
        {
            return await _studentService.IndexPagination(filter);
        }

    }
}
