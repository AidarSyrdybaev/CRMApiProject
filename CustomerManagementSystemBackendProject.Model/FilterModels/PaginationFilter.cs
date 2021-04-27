using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.Models.FilterModels
{
    public class PaginationFilter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        //public int? CityId { get; set; }
        //public int? LeadStatusId { get; set; }
        //public int? CourseId { get; set; }
        public int[] CitiesId { get; set; }
        public int[] LeadStatusesId { get; set; }
        public int[] CoursesId { get; set; }
        public string StudentName { get; set; }
        public PaginationFilter()
        {
            this.PageNumber = 1;
            this.PageSize = 50;
        }
        public PaginationFilter(int pageNumber, int pageSize )
        {
            this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
            this.PageSize = pageSize < 50 ? 50 : pageSize;
        }
    }
}
