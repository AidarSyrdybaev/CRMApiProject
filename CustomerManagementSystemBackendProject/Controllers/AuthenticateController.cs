using CustomerManagementSystemBackendProject.BL.Services.Contracts;
using CustomerManagementSystemBackendProject.DAL.Factories;
using CustomerManagementSystemBackendProject.Models.AuthenticateModels;
using Microsoft.AspNetCore.Authorization;
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
    //[Authorize(Roles ="SuperAdmin")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private IApplicationDbContextFactory _dbContextFactory { get; set; }
        private readonly ILogger<AuthenticateController> _logger;
        private readonly IAuthenticateService _authenticateService;

        public AuthenticateController(ILogger<AuthenticateController> logger, IApplicationDbContextFactory dbContextFactory, IAuthenticateService authenticateService)
        {
            _dbContextFactory = dbContextFactory;
            _logger = logger;
            _authenticateService = authenticateService;
        }
        
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var Result = await _authenticateService.Login(model);
            if (Result != null)
            {
                return Ok(new
                {
                    token = Result.token,
                    expiration = Result.expiration
                });
            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var Result = await _authenticateService.Register(model);
            return Ok(Result);
        }

        [HttpPost]
        [Route("GeerateForgotPasswordCode")]
        public async Task<IActionResult> Generate(ForgotPasswordRequestModel model)
        {
            var Result = await _authenticateService.GetForgotPasswordCode(model.Email);
            return Ok(Result);
        }

        [HttpPost]
        [Route("GenerateNewPassword")]
        public async Task<IActionResult> GeneratePassword(ForgotPasswordModel model)
        {
            var Result = await _authenticateService.GenerateNewPassword(model);
            return Ok(Result);
        }


        [HttpPut]
        [Route("Archive")]
        public async Task<IActionResult> Archive(int UserId)
        {
            var Result = await _authenticateService.Archive(UserId);
            return Ok(Result);
        }

    }
}
