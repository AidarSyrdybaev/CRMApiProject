using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.DAL.Entities
{
    public class CityHistory: History
    {   
        public City City { get; set; }
        public int CityId { get; set; }
    }
}
