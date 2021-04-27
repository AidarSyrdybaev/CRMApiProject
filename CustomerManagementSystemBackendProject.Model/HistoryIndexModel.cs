using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.Models
{
    public class HistoryIndexModel
    {
        public string Information { get; set; }

        public string Action { get; set; }

        public DateTime DateTime { get; set; }

        public string Type { get; set; }
    }
}
