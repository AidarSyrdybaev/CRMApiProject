using CustomerManagementSystemBackendProject.DAL.Context;
using CustomerManagementSystemBackendProject.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystemBackendProject.DAL.Seed
{
    public static class ContextSeed
    {
        public static void AddCities(this ApplicationDbContext applicationDbContext)
        {   
            if(applicationDbContext.Cities.All(i => i.Name != "Бишкек"))
                applicationDbContext.Cities.Add(new City { Name="Бишкек"});
            if (applicationDbContext.Cities.All(i => i.Name != "Ош"))
                applicationDbContext.Cities.Add(new City { Name ="Ош" });
            applicationDbContext.SaveChanges();
        }

        public static void AddStatuses(this ApplicationDbContext applicationDbContext)
        {
            if(applicationDbContext.LeadStatuses.All(i => i.Name != "Первый контакт"))
                applicationDbContext.LeadStatuses.Add(new LeadStatus { Name = "Первый контакт" });
            if (applicationDbContext.LeadStatuses.All(i => i.Name != "Звонок совершен"))
                applicationDbContext.LeadStatuses.Add(new LeadStatus { Name = "Звонок совершен" });
            if (applicationDbContext.LeadStatuses.All(i => i.Name != "Записан на пробный урок"))
                applicationDbContext.LeadStatuses.Add(new LeadStatus { Name = "Записан на пробный урок" });
            if (applicationDbContext.LeadStatuses.All(i => i.Name != "Посетил пробный урок"))
                applicationDbContext.LeadStatuses.Add(new LeadStatus { Name = "Посетил пробный урок" });
            if (applicationDbContext.LeadStatuses.All(i => i.Name != "Успешная сделка"))
                applicationDbContext.LeadStatuses.Add(new LeadStatus { Name = "Успешная сделка" });
            if (applicationDbContext.LeadStatuses.All(i => i.Name != "Провальная сделка"))
                applicationDbContext.LeadStatuses.Add(new LeadStatus { Name = "Провальная сделка" });
            applicationDbContext.SaveChanges();

        }

        public static void AddFailureStatus(this ApplicationDbContext applicationDbContext)
        {
            if (applicationDbContext.leadFailureStatuses.All(i => i.Name == "Личные проблемы"))
                applicationDbContext.leadFailureStatuses.Add(new LeadFailureStatus { Name = "Личные проблемы" });
            if (applicationDbContext.leadFailureStatuses.All(i => i.Name == "Личные проблемы"))
                applicationDbContext.leadFailureStatuses.Add(new LeadFailureStatus { Name = "Финансовые проблемы" });
            if (applicationDbContext.leadFailureStatuses.All(i => i.Name == "Личные проблемы"))
                applicationDbContext.leadFailureStatuses.Add(new LeadFailureStatus { Name = "Не объяснил" });
            if (applicationDbContext.leadFailureStatuses.All(i => i.Name == "Личные проблемы"))
                applicationDbContext.leadFailureStatuses.Add(new LeadFailureStatus { Name = "Игнорирует" });

            applicationDbContext.SaveChanges();

        }
        public static void AddTeachers(this ApplicationDbContext applicationDbContext)
        {
            var CitiesId = applicationDbContext.Cities.Select(i => i.Id).ToArray();

            if (applicationDbContext.Teachers.All(i => i.Name != "Бакыт"))
                applicationDbContext.Teachers.Add(new Teacher { Surname = "Кудайбергенов", Name = "Бакыт", MiddleName = "Джолдошевич", Phone = "996707998811", CityId =  CitiesId[0], CourseId = 1, Patent = "#123456", PatentStartDate = DateTime.Now, PatentEndDate = DateTime.Now});
            if (applicationDbContext.Teachers.All(i => i.Name != "Виктория"))
                applicationDbContext.Teachers.Add(new Teacher { Surname = "Сергеева", Name = "Виктория", MiddleName = "Владимировна", Phone = "996557557557", CityId = CitiesId[0], CourseId = 2, Patent = "#123456", PatentStartDate = DateTime.Now, PatentEndDate = DateTime.Now });
            if (applicationDbContext.Teachers.All(i => i.Name != "Айдар"))
                applicationDbContext.Teachers.Add(new Teacher { Surname = "Сырдыбаев", Name = "Айдар", MiddleName = "Джайнакович", Phone = "996700700111", CityId = CitiesId[0],CourseId = 3, Patent = "#123456", PatentStartDate = DateTime.Now, PatentEndDate = DateTime.Now });

            applicationDbContext.SaveChanges();
        }

        public static void AddCourses(this ApplicationDbContext applicationDbContext)
        {
            var Teachers = applicationDbContext.Teachers.Select(i => i.Id).ToArray();
            var Cities = applicationDbContext.Cities.Select(i => i.Id).ToArray();

            if (applicationDbContext.Courses.All(i => i.Name != "C#"))
                applicationDbContext.Courses.Add(new Course { Name = "C#", CityId = Cities[0], Color = "#FF0000" });
            if (applicationDbContext.Courses.All(i => i.Name != "Java"))
                applicationDbContext.Courses.Add(new Course { Name = "Java", CityId = Cities[1], Color = "#FF1493"});
            if (applicationDbContext.Courses.All(i => i.Name != "Python"))
                applicationDbContext.Courses.Add(new Course { Name = "Python", CityId = Cities[0], Color = "#FF8C00"});
            applicationDbContext.SaveChanges();
        }



        public static void AddGroups(this ApplicationDbContext applicationDbContext)
        {
            var CoursesId = applicationDbContext.Teachers.Select(i => i.Id).ToArray();

            if (applicationDbContext.Groups.All(i => i.Name != "C# 1ая группа"))
                applicationDbContext.Groups.Add(new Group { Name = "C# 1ая группа", TeacherId = CoursesId[0], StartDate = new DateTime(2021, 01, 01), EndDate = new DateTime(2021, 05, 01) , OneMounthSum = 8000});
            if (applicationDbContext.Groups.All(i => i.Name != "C# 2ая группа"))
                applicationDbContext.Groups.Add(new Group { Name = "C# 2ая группа", TeacherId = CoursesId[1], StartDate = new DateTime(2021, 04, 01), EndDate = new DateTime(2021, 07, 01) , OneMounthSum = 8000 });
            if (applicationDbContext.Groups.All(i => i.Name != "Java 1ая группа"))
                applicationDbContext.Groups.Add(new Group { Name = "Java 1ая группа", TeacherId = CoursesId[2], StartDate = new DateTime(2021, 08, 01), EndDate = new DateTime(2021, 10, 01) , OneMounthSum = 8000 }) ;
            if (applicationDbContext.Groups.All(i => i.Name != "Python 1ая группа"))
                applicationDbContext.Groups.Add(new Group { Name = "Python 1ая группа", TeacherId = CoursesId[0], StartDate = new DateTime(2021, 07, 01), EndDate = new DateTime(2021, 09, 01) , OneMounthSum = 8000 });
            if (applicationDbContext.Groups.All(i => i.Name != "Java 2ая группа"))
                applicationDbContext.Groups.Add(new Group { Name = "Java 2ая группа", TeacherId = CoursesId[1] , StartDate = new DateTime(2021, 10, 01), EndDate = new DateTime(2021, 12, 01) , OneMounthSum = 8000 });
            applicationDbContext.SaveChanges();
        }

        public static void AddLeads(this ApplicationDbContext applicationDbContext)
        {
            if (applicationDbContext.Leads.All(i => i.Name != "Иван"))
                applicationDbContext.Leads.Add(new Lead { Surname= "Иванов", Name = "Сергей", MiddleName = "Иванович", Phone = "123456789", CityId = 1, CourseId = 2, LeadStatusId = 1, CreateDate = DateTime.Now});
            if (applicationDbContext.Leads.All(i => i.Name != "Асан"))
                applicationDbContext.Leads.Add(new Lead { Surname = "Асанов", Name = "Yсон", MiddleName = "Асанович", Phone = "123456789", CityId = 2, CourseId = 3, LeadStatusId = 2, CreateDate = DateTime.Now });
            if (applicationDbContext.Leads.All(i => i.Name != "Айдана"))
                applicationDbContext.Leads.Add(new Lead { Surname = "Жусупбекова", Name = "Айдана", MiddleName = "Турусбаевна", Phone = "123456789", CityId = 1, CourseId = 2, LeadStatusId = 3 , CreateDate = DateTime.Now });
            if (applicationDbContext.Leads.All(i => i.Name != "Айдар"))
                applicationDbContext.Leads.Add(new Lead { Surname = "Таалаев", Name = "Токтогул", MiddleName = "Айдарович", Phone = "123456789", CityId = 2, CourseId = 3, LeadStatusId = 4 , CreateDate = DateTime.Now });
            if (applicationDbContext.Leads.All(i => i.Name != "Айдана"))
                applicationDbContext.Leads.Add(new Lead { Surname = "Айбекова", Name = "Айдана", MiddleName = "Айдаровна", Phone = "123456789", CityId = 2, CourseId = 3, LeadStatusId = 5 , CreateDate = DateTime.Now });
            applicationDbContext.SaveChanges();
        }

        public async static Task AddRoles(this RoleManager<Role> roleManager)
        {   
            if (await roleManager.FindByNameAsync("Superadmin") == null)
                await roleManager.CreateAsync(new Role { Name="Superadmin"});

            if (await roleManager.FindByNameAsync("Admin") == null)
                await roleManager.CreateAsync(new Role { Name = "Admin" });

            if (await roleManager.FindByNameAsync("SMM") == null)
                await roleManager.CreateAsync(new Role { Name = "SMM" });

        }

        public async static Task AddUsers(this UserManager<User> userManager)
        {
            if (await userManager.FindByNameAsync("Superadmin") == null)
            {
                var User = new User
                {   
                    UserName = "UserSuperAdmin",
                    Name = "Айдар",
                    MiddleName = "Джайнакович",
                    Email = "SuperAdmin@gmail.ru",
                    CityId = 1
                };
                var Result = await userManager.CreateAsync(User, "!Admin11");
                await userManager.AddToRoleAsync(User, "Superadmin");
            }
            if (await userManager.FindByNameAsync("Admin") == null)
            { 
                var User = new User
                {
                    UserName = "UserAdmin",
                    Name = "Токтогул",
                    MiddleName = "Медерович",
                    Email = "Admin@gmail.ru",
                    CityId = 1
                };
                await userManager.CreateAsync(User, "!Admin11");
                await userManager.AddToRoleAsync(User, "Admin");

               
            }


            if (await userManager.FindByNameAsync("SMM") == null)
            {
                var User = new User
                {
                    UserName = "UserCMM",
                    Name = "Куттубек",
                    MiddleName = "Жоронович",
                    Email = "CMM@gmail.ru",
                    CityId = 1
                };
                await userManager.CreateAsync(User, "!Admin11");
                await userManager.AddToRoleAsync(User, "SMM");
            }
        }
    }
}
