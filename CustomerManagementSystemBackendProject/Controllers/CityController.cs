using CustomerManagementSystemBackendProject.BL.Services.Contracts;
using CustomerManagementSystemBackendProject.Models.CityModels;
using CustomerManagementSystemBackendProject.Models.CommonModels;
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
    public class CityController : ControllerBase
    {
        private readonly ICityService _CityService;

        public CityController(ICityService CityService)
        {
            _CityService = CityService;
        }
        [Route("Index")]
        [HttpGet]
        public async Task<ActionResult<ResponseObject<List<CityIndexModel>>>> Index()
        {
            return await _CityService.GroupsCountByCity();

        }

        [Route("Delete")]
        [HttpDelete]
        public async Task<ActionResult<Response>> Delete(int id)
        {
            return await _CityService.Delete(id, User);
        }
    }
}
