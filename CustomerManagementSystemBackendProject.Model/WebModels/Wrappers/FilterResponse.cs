using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.Models.WebModels.Wrappers
{
    public class FilterResponse<T> : Response<T>
    {
       
        public int TotalRecords { get; set; }


        public FilterResponse(T data) : base(data)
        {
            
        }
    }
}
