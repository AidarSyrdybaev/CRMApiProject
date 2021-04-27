using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.DAL.Entities
{
    public class Notify : IEntity
    {
        public int Id { get ; set ; }
        public bool IsArchive { get ; set ; }

        public DateTime Date { get; set; }
    }
}
