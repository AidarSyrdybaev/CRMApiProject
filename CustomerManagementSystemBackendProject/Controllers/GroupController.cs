using CustomerManagementSystemBackendProject.BL.Services.Contracts;
using CustomerManagementSystemBackendProject.Models.CommonModels;
using CustomerManagementSystemBackendProject.Models.FilterModels;
using CustomerManagementSystemBackendProject.Models.GroupModels;
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
    [Route("[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _GroupService;

        public GroupController(IGroupService GroupService)
        {
            _GroupService = GroupService;
        }
        /// <summary>
        /// Authorize a user.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST / Authorize a user
        ///     {
        ///    
        ///        "Username": "Employee",
        ///        "Password": "Password!1"
        ///     }
        ///
        /// </remarks>
        /// <param name="model"></param>
        /// <returns>A token</returns>
        /// <response code="200">Returns the token</response>
        /// <response code="401">Wrong username or password</response>
        /// <response code="400">Model is null</response>
        [Route("Index")]
        [HttpGet]
        public async Task<ActionResult<ResponseObject<List<GroupIndexModel>>>> Index()
        {
            return await _GroupService.GetAll();
        }
        /// <summary>
        /// Authorize a user.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST / Authorize a user
        ///     {
        ///    
        ///        "Username": "Employee",
        ///        "Password": "Password!1"
        ///     }
        ///
        /// </remarks>
        /// <param name="model"></param>
        /// <returns>A token</returns>
        /// <response code="200">Returns the token</response>
        /// <response code="401">Wrong username or password</response>
        /// <response code="400">Model is null</response>
        [Route("Details")]
        [HttpGet]
        public async Task<ActionResult<ResponseObject<GroupDetailsModel>>> Details(int id)
        {
            return await _GroupService.GetById(id);
        }
        /// <summary>
        /// Authorize a user.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST / Authorize a user
        ///     {
        ///    
        ///        "Username": "Employee",
        ///        "Password": "Password!1"
        ///     }
        ///
        /// </remarks>
        /// <param name="model"></param>
        /// <returns>A token</returns>
        /// <response code="200">Returns the token</response>
        /// <response code="401">Wrong username or password</response>
        /// <response code="400">Model is null</response>
        [Route("Create")]
        [HttpPost]
        public async Task<ActionResult<Response>> Create(GroupCreateModel model)
        {
            return await _GroupService.Create(model, User);
        }
        /// <summary>
        /// Authorize a user.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST / Authorize a user
        ///     {
        ///    
        ///        "Username": "Employee",
        ///        "Password": "Password!1"
        ///     }
        ///
        /// </remarks>
        /// <param name="model"></param>
        /// <returns>A token</returns>
        /// <response code="200">Returns the token</response>
        /// <response code="401">Wrong username or password</response>
        /// <response code="400">Model is null</response>
        [Route("Update")]
        [HttpPut]
        public async Task<ActionResult<Response>> Update(GroupUpdateModel model)
        {
            return await _GroupService.Update(model, User);
        }
        /// <summary>
        /// Authorize a user.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST / Authorize a user
        ///     {
        ///    
        ///        "Username": "Employee",
        ///        "Password": "Password!1"
        ///     }
        ///
        /// </remarks>
        /// <param name="model"></param>
        /// <returns>A token</returns>
        /// <response code="200">Returns the token</response>
        /// <response code="401">Wrong username or password</response>
        /// <response code="400">Model is null</response>
        [Route("Delete")]
        [HttpDelete]
        public async Task<ActionResult<Response>> Delete(int id)
        {
            return await _GroupService.Delete(id, User);
        }


        [Route("IndexFilter")]
        [HttpGet]
        public async Task<ActionResult<FilterResponse<List<GroupDetailsModel>>>> Index([FromQuery] GroupsFilter filter)
        {
            return await _GroupService.IndexFilter(filter);
        }




    }
}
