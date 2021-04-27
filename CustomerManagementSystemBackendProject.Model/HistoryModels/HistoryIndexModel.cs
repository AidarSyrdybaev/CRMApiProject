using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.Models.HistoryModels
{
    public class HistoryIndexModel
    {
        public string Object { get; set; }
        public string ObjectType { get; set; }
        public string User { get; set; }
        public string Action { get; set; }
        public DateTime DateTime { get; set; }
    }
}
