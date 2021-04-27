using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.DAL.Entities
{
    public class City: IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } 
        public DateTime? CreateDate { get { return (DateTime)(DateTime.Now); } set {; } }
        public List<Course> Courses { get; set; }
        public List<User> Users { get; set; }

        public bool IsArchive { get; set; }

        //public IEnumerable<Course> Courses { get; set; }
    }
}
