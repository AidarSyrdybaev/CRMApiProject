using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.DAL.Entities
{
    public class Entity: IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsArchive { get; set; }
    }
}
