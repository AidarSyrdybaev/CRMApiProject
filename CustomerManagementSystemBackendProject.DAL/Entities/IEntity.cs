using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.DAL.Entities
{
    public interface IEntity
    {
        public int Id { get; set; }

        public bool IsArchive { get; set; }


    }
}
