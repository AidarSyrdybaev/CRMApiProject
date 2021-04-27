using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.DAL.Entities
{
    public class Course: IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public List<Teacher> Teachers { get; set; }
        public string Color { get; set; }

        public List<CourseHistory> courseHistories { get; set; }

        public bool IsArchive { get; set; }

    }
}
