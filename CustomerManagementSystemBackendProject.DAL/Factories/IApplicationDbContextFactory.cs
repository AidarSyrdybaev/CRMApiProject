using CustomerManagementSystemBackendProject.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.DAL.Factories
{
    public interface IApplicationDbContextFactory
    {
        ApplicationDbContext Create();
    }
}
