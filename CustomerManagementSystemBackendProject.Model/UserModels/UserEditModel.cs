using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.Models.UserModels
{
    public class UserEditModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public int CityId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
