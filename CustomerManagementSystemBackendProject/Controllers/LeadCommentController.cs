using CustomerManagementSystemBackendProject.BL.Services;
using CustomerManagementSystemBackendProject.BL.Services.Contracts;
using CustomerManagementSystemBackendProject.Models.CommonModels;
using CustomerManagementSystemBackendProject.Models.LeadCommentModels;
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
    public class LeadCommentController : ControllerBase
    {
        private readonly ILeadCommentService _LeadCommentService;

        public LeadCommentController(ILeadCommentService StudentCommentService)
        {
            _LeadCommentService = StudentCommentService;
        }
        [Route("Index")]
        [HttpGet]
        public async Task<ActionResult<ResponseObject<List<LeadCommentIndexModel>>>> Index()
        {
            return await _LeadCommentService.GetAll();

        }
        [Route("Create")]
        [HttpPost]
        public async Task<ActionResult<Response>> Create(LeadCommentCreateModel model)
        {
            return await _LeadCommentService.Create(model, User);

        }
    }
}
