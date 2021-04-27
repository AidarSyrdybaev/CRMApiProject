using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.Models.FlexByModels
{
    public class Status
    {
        public string code { get; set; }
        public string name { get; set; }
    }

    public class Client
    { 
        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
    }

    public class form_data
    { 
        public Dictionary<string, formInformation> info { get; set; }
    }

    public class formInformation
    { 
        public string Id { get; set; }

        public string name { get; set; }

        public string value { get; set; }

        public string type { get; set; }

        public string oryg_name { get; set; }
    }

    public class Page
    { 
        public string url { get; set; }

        public string name { get; set; }
    
    }

    public class Cookies
    { 
        public string roistat_visit { get; set; }
    }

    public class Utm
    { 
        public string url { get; set; }

        public string ip { get; set; }

        public Cookies cookies { get; set; }


    }

    public class Info
    {
        public string Id { get; set; }

        public string Num { get; set; }

        public string Time { get; set; }

        public string note { get; set; }

        public Dictionary<string, formInformation> form_data { get; set; }

        public Status Status { get; set; }

        public Client Client { get; set; }

        public List<object> Product { get; set; }

        public Page page {get;set;}

        public Utm utm { get; set; }
    }

    public class Data
    { 
        public Dictionary<string, Info> Leads { get; set; }   
    }

    public class RequestInformation
    { 
        public Data data { get; set; }
    }
}
