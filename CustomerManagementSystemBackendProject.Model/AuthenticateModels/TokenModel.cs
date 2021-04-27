using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.Models.AuthenticateModels
{
    public class TokenModel
    {
        public string token { get; set; }

        public DateTime expiration { get; set; }
    }
}
