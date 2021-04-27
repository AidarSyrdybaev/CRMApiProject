using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.Models.AuthenticateModels
{
    public class RegisterModel
    {   
        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string MiddleName { get; set; }

        public string Phone { get; set; }

        public int RoleId { get; set; }

        public int CityId { get; set; }
    }
}
