using System;
using System.Collections.Generic;
using System.Text;
using CustomerManagementSystemBackendProject.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagementSystemBackendProject.DAL.Context
{
    public class ApplicationDbContext: IdentityDbContext<User, Role, int>
    {   

        public DbSet<ChosenLead> ChosenLeads { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Lead> Leads { get; set; }

        public DbSet<LeadStatus> LeadStatuses { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<StudentGroup> StudentGroups { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<LeadFailureStatus> leadFailureStatuses { get; set; }

        public DbSet<ForgotPaswwordKey> ForgotPaswwordKeys { get; set; }

        public DbSet<Notify> Notifies { get; set; }

        public DbSet<LeadsNotify> LeadsNotifies { get; set; }

        public DbSet<ChosenLeadsNotify> ChosenLeadsNotifies { get; set; }

        public DbSet<LeadComment> LeadComments { get; set; }

        public DbSet<StudentComment> StudentComments { get; set; }

        public DbSet<History> Histories { get; set; }

        public DbSet<CityHistory> CityHistories { get; set; }

        public DbSet<CourseHistory> courseHistories { get; set; }

        public DbSet<ForgotPasswordKeyHistory> forgotPasswordKeyHistories { get; set; }

        public DbSet<GroupHistory> groupHistories { get; set; }

        public DbSet<LeadHistory> LeadHistories { get; set; }

        public DbSet<PaymentHistory> PaymentHistories { get; set; }

        public DbSet<StudentGroupHistory> studentGroupHistories { get; set; }
        public DbSet<StudentHistory> StudentHistories { get; set; }

        public DbSet<TeacherHistory> TeacherHistories { get; set; }

        public DbSet<UserHistory> UserHistories { get; set; }

        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        { 
        
        }


    }
}
