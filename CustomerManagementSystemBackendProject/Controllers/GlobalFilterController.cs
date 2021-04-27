using CustomerManagementSystemBackendProject.BL.Services.Contracts;
using CustomerManagementSystemBackendProject.DAL.Factories;
using CustomerManagementSystemBackendProject.Models.CommonModels;
using CustomerManagementSystemBackendProject.Models.FilterModels;
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
    public class GlobalFilterController : ControllerBase
    {
        private IFilterService _filterService { get; set; }
        private readonly ILogger<AuthenticateController> _logger;

        public GlobalFilterController(ILogger<AuthenticateController> logger, IFilterService filterService)
        {
            _filterService = filterService;
            _logger = logger;
        }

        [HttpGet]
        [Route("GlobalFilter")]
        public async Task<ActionResult<ResponseObject<GlobalResponseFilterModel>>> GlobalFilter(GlobalFilterModel model)
        {
            return await _filterService.GlobalFilter(model);
        }
    }
}
