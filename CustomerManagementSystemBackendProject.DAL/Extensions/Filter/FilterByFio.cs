using CustomerManagementSystemBackendProject.DAL.Context;
using CustomerManagementSystemBackendProject.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerManagementSystemBackendProject.DAL.Extensions.Filter
{
   public static class FilterByFio
    {
        public static List<Student> StudentsFilterByFIO(this ApplicationDbContext context, string Name, string MiddleName, string Surname)
        {
            return context.Students.Where(i => i.Name.Contains(Name) && i.MiddleName.Contains(MiddleName) && i.Surname.Contains(Surname)).Include(i => i.City).ToList();
        }

        public static List<Teacher> TeachersFilterByFIO(this ApplicationDbContext context, string Name, string MiddleName, string Surname)
        {
            return context.Teachers.Where(i => i.Name.Contains(Name) && i.MiddleName.Contains(MiddleName) && i.Surname.Contains(Surname)).ToList();
        }

        public static List<User> UsersFilterByFIO(this ApplicationDbContext context, string Name, string MiddleName, string Surname)
        {
            return context.Users.Where(i => i.Name.Contains(Name) && i.MiddleName.Contains(MiddleName) && i.Surname.Contains(Surname)).ToList();
        }

        public static List<Lead> LeadsFilterByFIO(this ApplicationDbContext context, string Name, string MiddleName, string Surname)
        {
            return context.Leads.Where(i => i.Name.Contains(Name) && i.MiddleName.Contains(MiddleName) && i.Surname.Contains(Surname)).ToList();
        }
    }
}
