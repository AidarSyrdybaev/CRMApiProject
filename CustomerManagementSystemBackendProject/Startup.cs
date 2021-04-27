using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CustomerManagementSystemBackendProject.DAL;
using CustomerManagementSystemBackendProject.DAL.Context;
using CustomerManagementSystemBackendProject.DAL.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using CustomerManagementSystemBackendProject.DAL.Factories;
using CustomerManagementSystemBackendProject.DAL.Seed;
using CustomerManagementSystemBackendProject.BL.Services.Contracts;
using CustomerManagementSystemBackendProject.BL.Services;
using CustomerManagementSystemBackendProject.BL.MProfile;
using AutoMapper;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;

namespace CustomerManagementSystemBackendProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(c => c.AddPolicy("AllowPolicy", builder => builder.AllowAnyOrigin().AllowAnyHeader().WithMethods("PUT", "DELETE", "GET", "POST")));



            var ConnectionString = Configuration.GetConnectionString("ProductionConnectionString");
            services.AddSwaggerGen(c =>
            {
                var filePath = Path.Combine(AppContext.BaseDirectory, "CustomerManagementSystemBackendProject.xml");
                c.IncludeXmlComments(filePath, includeControllerXmlComments: true);
            });

            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseNpgsql(ConnectionString);

            //adds ApplicationContext and User Identity
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(ConnectionString);
            });

            // For Identity  
            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();



            services.AddSingleton<IApplicationDbContextFactory>(
                sp => new ApplicationDbContextFactory(
                    optionsBuilder.Options
                ));

            

            // Adding Authentication  
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            // Adding Jwt Bearer  
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["JWT:ValidAudience"],
                    ValidIssuer = Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
                };
            });

          
            services.AddScoped<IAuthenticateService, AuthenticateService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ILeadService, LeadService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IStudentGroupService, StudentGroupService>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<ILeadStatusService, LeadStatusService>();
            services.AddScoped<ICityService, CityService > ();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IFilterService, FilterService>();
            services.AddScoped<ILeadCommentService, LeadCommentService>();
            services.AddScoped<IStudentCommentService, StudentCommentService>();
            services.AddScoped<IAnalystsService, AnalystsService>();
            services.AddScoped<IArchiveService, ArchiveService>();
            services.AddHostedService<LeadShcedulerService>();
            services.AddScoped<IHistoryService, HistoryService>();

            Mapper.Initialize(cfg => cfg.AddProfile(new MapperProfile()));
            services.AddHttpContextAccessor();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApplicationDbContextFactory applicationDbContextFactory, 
            UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            app.UseSwagger();

            app.UseHttpsRedirection();

            app.UseCors("AllowPolicy");

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });



            using (var context = applicationDbContextFactory.Create())
            {
                context.AddCities();
                context.AddStatuses();
                context.AddFailureStatus();
                context.AddCourses();
                context.AddTeachers();
                context.AddGroups();
                context.AddLeads();
                context.AddGroups();
                roleManager.AddRoles().ConfigureAwait(false).GetAwaiter().GetResult();
                userManager.AddUsers().ConfigureAwait(false).GetAwaiter().GetResult();
            }
        }
    }
}
