using CustomerManagementSystemBackendProject.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.DAL.Factories
{
    public class ApplicationDbContextFactory: IApplicationDbContextFactory
    {
        private DbContextOptions DbContextOptions { get; set; }
        public ApplicationDbContextFactory(DbContextOptions dbContextOptions)
        {
            DbContextOptions = dbContextOptions;
        }
        public ApplicationDbContext Create()
        {
            return new ApplicationDbContext(DbContextOptions);
        }
    }
}
