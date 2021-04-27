using CustomerManagementSystemBackendProject.DAL.Factories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagementSystemBackendProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {   
        private IApplicationDbContextFactory DbContextFactory { get; set; }
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IApplicationDbContextFactory dbContextFactory)
        {
            DbContextFactory = dbContextFactory;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            try
            {
                using (var Context = DbContextFactory.Create())
                {

                }
                var rng = new Random();
                return new string[] { "Hello world! Test-commit-2" };
            }
            catch(Exception e)
            {
                return new string[] { e.StackTrace };
            }
        }
    }
}
