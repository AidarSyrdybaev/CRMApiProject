using CustomerManagementSystemBackendProject.BL.Services.Contracts;
using CustomerManagementSystemBackendProject.Models;
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
    public class HistoryController : ControllerBase
    {
        private readonly ILogger<HistoryController> _logger;
        private readonly IHistoryService _historyService;

        public HistoryController(ILogger<HistoryController> logger, IHistoryService historyService)
        {
            _logger = logger;
            _historyService = historyService;
        }

        [HttpGet]
        [Route("Index")]
        public async Task<List<HistoryIndexModel>> Index()
        {
            return await _historyService.GetAll();
        }
    }
}
