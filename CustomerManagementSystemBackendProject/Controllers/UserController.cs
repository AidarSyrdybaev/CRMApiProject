using CustomerManagementSystemBackendProject.BL.Services;
using CustomerManagementSystemBackendProject.BL.Services.Contracts;
using CustomerManagementSystemBackendProject.Models.CommonModels;
using CustomerManagementSystemBackendProject.Models.FilterModels;
using CustomerManagementSystemBackendProject.Models.UserModels;
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
    public class UserController : ControllerBase
    {
        private readonly IUserService _UserService;

        public UserController(IUserService UserService)
        {
            _UserService = UserService;
        }

        [Route("Index")]
        [HttpGet]
        public async Task<ActionResult<ResponseObject<List<UserIndexModel>>>> Index()
        {
            return await _UserService.GetAll();
        }

        [Route("IndexFilter")]
        [HttpGet]
        public async Task<ActionResult<FilterResponse<List<UserIndexModel>>>> Index([FromQuery] EmployeesFilter filter)
        {
            return await _UserService.IndexFilterNew(filter);
        }

        //[Route("GetUser")]
        //[HttpGet]
        //public async Task<ActionResult<UserIndexModel>> GetUser([FromQuery] UserIndexModel model)
        //{
        //    var Result = await _UserService.GetUser(model, User);
        //    if (Result == null)
        //    {
        //        return StatusCode(StatusCodes.Status401Unauthorized, Result);
        //    }
        //    return StatusCode(StatusCodes.Status200OK, Result);
        //}
        [Authorize]
        [HttpGet]
        [Route("GetUser")]
        public async Task<ActionResult<UserIndexModel>> GetUser([FromQuery] UserIndexModel model)
        {
            var Result = await _UserService.GetUser(model, User);
            if (Result == null)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, Result);
            }
            return Result;
        }

        [HttpPut]
        [Authorize]
        [Route("Update")]
        public async Task<IActionResult> Update(UserEditModel model)
        {
           
              var Result = await _UserService.Update(model, User);
              if (Result == null)
             {
              return StatusCode(StatusCodes.Status401Unauthorized, Result);
             }

            return StatusCode(StatusCodes.Status200OK, Result);


        }
    }
}
