using CustomerManagementSystemBackendProject.DAL.Context;
using CustomerManagementSystemBackendProject.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace CustomerManagementSystemBackendProject.DAL.Extensions.IncludeExtensions
{
    public static class UserExtension
    {

        public static User IncludeUserId(this ApplicationDbContext context, int Id)
        {
            return context.Users
               .Where(i => i.Id == Id)
               .Include(i => i.City)
               .FirstOrDefault();
        }

        public static User IncludeUser(this ApplicationDbContext context, ClaimsPrincipal User)
        {
            return context.Users
               .Where(i => i.UserName == User.Identity.Name)
               .Include(i => i.City)
               .FirstOrDefault();
        }

        public static List<User> IncludeArchiveUsers(this ApplicationDbContext context)
        {
            return context.Users
               .Where(i => i.IsArchive)
               .Include(i => i.City)
               .ToList();
        }


        public static List<User> IncludeUsers(this ApplicationDbContext context)
        {
            return context.Users
                .Include(i => i.City)
                .ToList();

        }

        //работающий метод без ролей
        //public static List<User> UsersFilterInclude(this ApplicationDbContext context, int[] CitiesId, string Name)
        //{
        //    return context.Users
        //       .Where(i => CitiesId == null || CitiesId.Any(a => a == i.CityId))
        //       .Where(i => Name == null || i.Name == Name)
        //               .Include(i => i.City)
        //               .ToList();
        //}




        public static List<User> UsersFilterInclude(this ApplicationDbContext context, int[] CitiesId, string Name)
        {
            return context.Users
               .Where(i => CitiesId == null || CitiesId.Any(a => a == i.CityId))
               .Where(i => Name == null || i.Name == Name)
               .Where(i => !i.IsArchive)
                       .Include(i => i.City)
                       .ToList();
        }
    }
}
