using CustomerManagementSystemBackendProject.Models.AuthenticateModels;
using CustomerManagementSystemBackendProject.Models.CommonModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystemBackendProject.BL.Services.Contracts
{
    public interface IAuthenticateService
    {
        Task<TokenModel> Login(LoginModel model);

        Task<Response> Register(RegisterModel model);
        Task<ResponseObject<int>> GetForgotPasswordCode(string Email);

        Task<Response> GenerateNewPassword(ForgotPasswordModel forgotPasswordModel);

        Task<Response> Archive(int UserId);
    }
}
