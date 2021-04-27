using CustomerManagementSystemBackendProject.Models.FilterModels;
using CustomerManagementSystemBackendProject.Models.TeacherModels;
using CustomerManagementSystemBackendProject.Models.WebModels.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystemBackendProject.BL.Helpers
{

    public static class PaginationHelper
    {

        public static PagedResponse<List<T>> CreatePagedReponse<T>(List<T> pagedData, PaginationFilter validFilter, int totalRecords)
        {
            var respose = new PagedResponse<List<T>>(pagedData, validFilter.PageNumber, validFilter.PageSize);
            var totalPages = ((double)totalRecords / (double)validFilter.PageSize);
            int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));
            respose.TotalPages = roundedTotalPages;
            respose.TotalRecords = totalRecords;
            return respose;
        }

    }

    public static class FilterHelper
     {
        public static FilterResponse<List<T>> CreatePagedReponse<T>(List<T> pagedData, int totalRecords)
        {
            var respose = new FilterResponse<List<T>>(pagedData);
            respose.TotalRecords = totalRecords;
            return respose;
        }
    
    }


 }


