using CustomerManagementSystemBackendProject.BL.Services.Contracts;
using CustomerManagementSystemBackendProject.Models.CommonModels;
using CustomerManagementSystemBackendProject.Models.FilterModels;
using CustomerManagementSystemBackendProject.Models.TeacherModels;
using CustomerManagementSystemBackendProject.Models.WebModels.Wrappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _TeacherService;

        public TeacherController(ITeacherService TeacherService)
        {
            _TeacherService = TeacherService;
        }

        [Route("Index")]
        [HttpGet]
        public async Task<ActionResult<ResponseObject<List<TeacherIndexModel>>>> Index()
        {
            return await _TeacherService.GetAll();
        }

        [Route("Details")]
        [HttpGet]
        public async Task<ActionResult<ResponseObject<TeacherDetailsModel>>> Details(int id)
        {
            return await _TeacherService.GetById(id);
        }

        [Route("Create")]
        [HttpPost]
        public async Task<ActionResult<Response>> Create(TeacherCreateModel model)
        {
            return await _TeacherService.Create(model, User);
        }

        [Route("Update")]
        [HttpPut]
        public async Task<ActionResult<Response>> Update(TeacherUpdateModel model)
        {
            return await _TeacherService.Update(model, User);
        }

        [Route("Delete")]
        [HttpDelete]
        public async Task<ActionResult<Response>> Delete(int id)
        {
            return await _TeacherService.Delete(id, User);
        }

        //[Route("IndexFilter")]
        //[HttpGet]
        //public async Task<ActionResult<FilterResponse<List<TeacherDetailsModel>>>> Index([FromQuery] EmployeesFilter filter)
        //{
        //    return await _TeacherService.IndexFilter(filter);
        //}

        [Route("IndexFilter")]
        [HttpGet]
        public async Task<ActionResult<FilterResponse<List<TeacherDetailsModel>>>> Index([FromQuery] EmployeesFilter filter)
        {
            return await _TeacherService.IndexFilterNew(filter);
        }
    }
}
