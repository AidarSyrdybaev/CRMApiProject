using CustomerManagementSystemBackendProject.BL.Services.Contracts;
using CustomerManagementSystemBackendProject.Models.FlexByModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CustomerManagementSystemBackendProject.Controllers
{

    [Route("[controller]")]
    public class FlexByController : Controller
    {
        private  ILeadService LeadService { get; }

        public FlexByController(ILeadService leadService)
        {
            LeadService = leadService;
        }

        [Route("Index")]
        [HttpGet]
        public ActionResult Index()
        {
            WebRequest request = WebRequest.Create("https://neolabs.dev/mod/api/?api_key=e539509b630b27e47ac594d0dbba4e69&method=getLeads");
            WebResponse response = request.GetResponse(); // для отправки используется метод Post

            string Text = string.Empty;
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string line = "";
                    while ((line = reader.ReadLine()) != null)
                    {
                        Text += line;
                    }
                }
            }


            var models = JsonConvert.DeserializeObject<RequestInformation>(Text);
            var response2 = LeadService.AddLeadInformation(models);

            response.Close();
            return Ok(response2);
        }
    }
}
