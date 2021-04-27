using CustomerManagementSystemBackendProject.BL.Services.Contracts;
using CustomerManagementSystemBackendProject.Models.AnalystsModel;
using CustomerManagementSystemBackendProject.Models.WebModels.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagementSystemBackendProject.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AnalystsController : ControllerBase
    {
        private readonly ILogger<AnalystsController> _logger;
        private readonly IAnalystsService _analystsService;

        public AnalystsController(ILogger<AnalystsController> logger, IAnalystsService analystsService)
        {
            _logger = logger;
            _analystsService = analystsService;
        }

        [Route("LeadsByCoursesAnalys")]
        [HttpGet]
        public async Task<ActionResult<Response<List<AnalystsModel>>>> LeadsByCoursesAnalys([FromQuery]AnalystsFilterModel filter )
        {
            return await _analystsService.LeadsByCoursesAnalys(filter);

        }
        [Route("FailureStatusesAnalysts")]
        [HttpGet]
        public async Task<ActionResult<Response<List<AnalystsModel>>>> FailureStatusesAnalysts([FromQuery] AnalystsFilterModel filter)
        {
            return await _analystsService.FailureStatusesAnalysts(filter);

        }

        [Route("LeadsBySourceAnalysts")]
        [HttpGet]
        public async Task<ActionResult<Response<List<AnalystsModel>>>> LeadsBySourceAnalysts([FromQuery] AnalystsFilterModel filter)
        {
            return await _analystsService.LeadsBySourceAnalysts(filter);

        }

        [Route("LeadsByFailureAndSuccesAnalys")]
        [HttpGet]
        public async Task<ActionResult<Response<SuccessAndFailureNumbers>>> LeadsByFailureAndSuccesAnalys([FromQuery] AnalystsFilterModel filter)
        {
            return await _analystsService.LeadsByFailureAndSuccesAnalys(filter);

        }
        [Route("StatusesAnalysts")]
        [HttpGet]
        public async Task<ActionResult<Response<List<AnalystsModel>>>> Index([FromQuery] AnalystsFilterModel filter)
        {
            return await _analystsService.StatusesAnalysts(filter);

        }
    }
}
