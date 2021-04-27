using CustomerManagementSystemBackendProject.DAL.Context;
using CustomerManagementSystemBackendProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerManagementSystemBackendProject.DAL.Extensions.Filter
{
    public static class GourseFilterExtensions
    {
        public static Group GetGroupStudentId(this ApplicationDbContext context, int StudentId, int GroupId)
        {
            var StudentGroup = context.StudentGroups.Where(i => i.StudentId == StudentId && i.GroupId == GroupId ).FirstOrDefault();
            var Group = context.Groups.Where(i => i.Id == StudentGroup.GroupId).FirstOrDefault();
            return Group;
        }
    }
}
