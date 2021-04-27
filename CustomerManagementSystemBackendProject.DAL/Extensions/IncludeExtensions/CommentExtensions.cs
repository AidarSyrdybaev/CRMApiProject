using CustomerManagementSystemBackendProject.DAL.Context;
using CustomerManagementSystemBackendProject.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerManagementSystemBackendProject.DAL.Extensions.IncludeExtensions
{
    public static class CommentExtension
    {
        public static List<LeadComment> LeadCommentsInclude(this ApplicationDbContext context)
        {
            return context.LeadComments
                .Include(i => i.Lead)
                .Include(i => i.User)
                .ToList();

        }

        public static List<LeadComment> OneLeadCommentsInclude(this ApplicationDbContext context, int LeadId)
        {
            return context.LeadComments
                .Where(i => i.LeadId == LeadId)
                .Include(i => i.Lead)
                .Include(i => i.User)
                .ToList();

        }


        public static List<StudentComment> OneStudentCommentsInclude(this ApplicationDbContext context, int StudentId)
        {
            return context.StudentComments
                .Where(i => i.StudentId == StudentId)
                .Include(i => i.Student)
                .Include(i => i.User)
                .ToList();

        }
        public static List<StudentComment> StudentCommentsInclude(this ApplicationDbContext context)
        {
            return context.StudentComments
                .Include(i => i.Student)
                .Include(i => i.User)
                .ToList();

        }

    }
}
