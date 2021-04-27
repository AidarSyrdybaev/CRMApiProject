using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.Models.CommonModels
{
    public class ResponseObject<T>: Response
    {
        public T ResponseObj { get; set; }
    }
}
