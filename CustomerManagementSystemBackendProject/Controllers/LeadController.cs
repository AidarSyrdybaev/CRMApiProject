using CustomerManagementSystemBackendProject.BL.Services.Contracts;
using CustomerManagementSystemBackendProject.Models.CommonModels;
using CustomerManagementSystemBackendProject.Models.FilterModels;
using CustomerManagementSystemBackendProject.Models.LeadModels;
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
    public class LeadController : ControllerBase
    {
        private readonly ILeadService _leadService;

        public LeadController(ILeadService leadService)
        {
            _leadService = leadService;
        }
        [Route("Create")]
        [HttpPost]
        public async Task<ActionResult<Response>> Create(LeadCreateModel model)
        {
            return await _leadService.Create(model, User);
        }
        [Route("Index")]
        [HttpGet]
        public async Task<ActionResult<ResponseObject<List<LeadIndexModel>>>> Index()
        {
            return await _leadService.GetAll();
        }


        [Route("IndexPagination")]
        [HttpGet]
        public async Task<ActionResult<PagedResponse<List<LeadIndexModel>>>> Index([FromQuery] PaginationFilter filter)
        {
            return await _leadService.IndexPagination(filter);
        }

        [Route("Details")]
        [HttpGet]
        public async Task<ActionResult<ResponseObject<LeadDetailsModel>>> Details(int id)
        {
            return await _leadService.GetById(id);
        }

        [Route("Update")]
        [HttpPut]
        public async Task<ActionResult<Response>> Update(LeadUpdateModel model)
        {
            return await _leadService.Update(model, User);
        }

        [Route("LeadFailure")]
        [HttpPut]
        public async Task<ActionResult<Response>> LeadFailure(LeadFailureModel model)
        {
            return await _leadService.UpdateFailureStatus(model, User);
        }


        [Route("UpdateStatus")]
        [HttpPut]
        public async Task<ActionResult<Response>> Update(LeadUpdateStatusModel model)
        {
            try
            {
                return await _leadService.UpdateStatus(model, User);
            }
            catch (Exception e)
            {
                return new Response { Message = e.Message };
            }
        }
        [Route("Delete")]
        [HttpDelete]
        public async Task<ActionResult<Response>> Delete(int id)
        {
            return await _leadService.Delete(id, User);
        }


        [Route("Notifications")]
        [HttpGet]
        public async Task<ActionResult<List<NotificationIndexModel>>> Notifications()
        {
            return await _leadService.Notifications();
        }

    }
}
