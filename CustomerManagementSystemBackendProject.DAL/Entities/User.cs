using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.DAL.Entities
{
    public class User: IdentityUser<int>, IEntity
    {
        public string Surname { get; set; }

        public string Name { get; set; }

        public string? MiddleName { get; set; }

        public int CityId { get; set; }

        public City City { get; set; }

        public bool IsArchive { get; set; }
    }
}
