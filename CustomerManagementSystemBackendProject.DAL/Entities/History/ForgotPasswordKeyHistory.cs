using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.DAL.Entities
{
    public class ForgotPasswordKeyHistory: History
    {
        public int ForgotPasswordKeyId { get; set; }

        public ForgotPaswwordKey ForgotPaswwordKey { get; set; }

    }
}
