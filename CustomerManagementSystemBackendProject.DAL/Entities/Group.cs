using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CustomerManagementSystemBackendProject.DAL.Entities
{
    public class Group: IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

      //  [NotMapped]
        public int Months 
        {
            get { return (int)((EndDate.Date - StartDate.Date).TotalDays/30); } set {; } 
        
        }
        public int OneMounthSum { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public List<StudentGroup> StudentGroups { get; set; }

        public bool IsArchive { get; set; }

        [NotMapped]
        public int StudentCount
        {
            get { return (int)(StudentGroups.Count); }
            set {; }
        }
    }
}
