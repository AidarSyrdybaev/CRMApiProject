using CustomerManagementSystemBackendProject.Models.CommonModels;
using CustomerManagementSystemBackendProject.Models.PaymentModels;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystemBackendProject.BL.Services.Contracts
{
    public interface IPaymentService
    {
        Task<Response> Create(PaymentCreateModel model, ClaimsPrincipal claimsPrincipal);

        Task<Response> Update(PaymentUpdateModel model, ClaimsPrincipal claimsPrincipal);

        Task<ResponseObject<List<PaymentIndexModel>>> GetAll();
    }
}
