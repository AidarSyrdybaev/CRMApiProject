using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.Models.AuthenticateModels
{
    public class ForgotPasswordModel
    {   
        public int Code { get; set; }
        public string Email { get; set; }
    }
}
