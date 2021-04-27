using CustomerManagementSystemBackendProject.BL.Services;
using CustomerManagementSystemBackendProject.BL.Services.Contracts;
using CustomerManagementSystemBackendProject.Models.CommonModels;
using CustomerManagementSystemBackendProject.Models.PaymentModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagementSystemBackendProject.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class PaymentController : ControllerBase
    {   

        private IPaymentService paymentService { get; set; }

        public PaymentController(IPaymentService _paymentService)
        {
            paymentService = _paymentService;
        }
        
        [Route("Index")]
        [HttpGet]
        public async Task<ActionResult<ResponseObject<List<PaymentIndexModel>>>> Index()
        {   
            return await paymentService.GetAll();
        }

        [Route("Create")]
        [HttpPost]
        public async Task<ActionResult<Response>> Create(PaymentCreateModel model)
        {
            return await paymentService.Create(model, User);
        }
        [Route("Edit")]
        [HttpPut]
        public async Task<ActionResult<Response>> Edit(PaymentUpdateModel model)
        {
            return await paymentService.Update(model, User);
        }
    }
}
