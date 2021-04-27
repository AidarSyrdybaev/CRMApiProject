using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.DAL.Entities
{
    public class Role: IdentityRole<int>, IEntity
    {
        public bool IsArchive { get; set; }
    }
}
