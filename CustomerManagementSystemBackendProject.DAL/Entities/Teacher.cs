using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.DAL.Entities
{
    public class Teacher : IEntity
    {
        public int Id { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string? MiddleName { get; set; }

        public int CityId { get; set; }
        
        public City City { get; set; }

        public string Phone { get; set; }
        public string Patent { get; set; }
        public DateTime PatentStartDate { get; set; }
        public DateTime PatentEndDate { get; set; }
        public List<Group> Groups { get; set; }
        public Course Course { get; set; }

        public int CourseId { get; set; }

       public bool IsArchive { get; set; }
        // public IEnumerable<Course> Course { get; set; }
    }
}
