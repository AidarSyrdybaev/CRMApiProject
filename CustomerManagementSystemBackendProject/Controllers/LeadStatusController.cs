using CustomerManagementSystemBackendProject.BL.Services.Contracts;
using CustomerManagementSystemBackendProject.Models.CommonModels;
using CustomerManagementSystemBackendProject.Models.LeadStatusModels;
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
    public class LeadStatusController : ControllerBase
    {
        private readonly ILeadStatusService _LeadStatusService;

        public LeadStatusController(ILeadStatusService LeadStatusService)
        {
            _LeadStatusService = LeadStatusService;
        }
        [Route("Index")]
        [HttpGet]
        public async Task<ActionResult<ResponseObject<List<LeadStatusIndexModel>>>> Index()
        {
            return await _LeadStatusService.GetAll();

        }
    }
}
