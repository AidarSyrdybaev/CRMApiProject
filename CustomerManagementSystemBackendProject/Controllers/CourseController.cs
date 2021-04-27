using CustomerManagementSystemBackendProject.BL.Services.Contracts;
using CustomerManagementSystemBackendProject.Models.CommonModels;
using CustomerManagementSystemBackendProject.Models.Course;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerManagementSystemBackendProject.Controllers
{
    [Route("[controller]")]
    [Authorize]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [Route("Index")]
        [HttpGet]
        public async Task<ActionResult<ResponseObject<List<CourseIndexModel>>>> Index()
        {
            return await _courseService.GetAll();
        }

        [Route("Details")]
        [HttpGet]
        public async Task<ActionResult<ResponseObject<CourseDetailsModel>>> Details(int id)
        {
            return await _courseService.GetById(id);
        }

        [Route("Create")]
        [HttpPost]
        public async Task<ActionResult<Response>> Create(CourseCreateModel model)
        {
            return await _courseService.Create(model, User);
        }

        [Route("Update")]
        [HttpPut]
        public async Task<ActionResult<Response>> Update(CourseUpdateModel model)
        {
            return await _courseService.Update(model, User);
        }

        [Route("Delete")]
        [HttpDelete]
        public async Task<ActionResult<Response>> Delete(int id)
        {
            return await _courseService.Delete(id, User);
        }
    }
}
