using AutoMapper;
using CustomerManagementSystemBackendProject.BL.Helpers;
using CustomerManagementSystemBackendProject.BL.Services.Contracts;
using CustomerManagementSystemBackendProject.DAL.Entities;
using CustomerManagementSystemBackendProject.DAL.Extensions.Check;
using CustomerManagementSystemBackendProject.DAL.Extensions.IncludeExtensions;
using CustomerManagementSystemBackendProject.DAL.Factories;
using CustomerManagementSystemBackendProject.Models.AuthenticateModels;
using CustomerManagementSystemBackendProject.Models.CommonModels;
using CustomerManagementSystemBackendProject.Models.FilterModels;
using CustomerManagementSystemBackendProject.Models.UserModels;
using CustomerManagementSystemBackendProject.Models.WebModels.Wrappers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerManagementSystemBackendProject.BL.Services
{
    public class UserService : IUserService
    {

       
        private readonly UserManager<User> UserManager;
        private readonly RoleManager<Role> RoleManager;
        private readonly IConfiguration _configuration; 
        private readonly IApplicationDbContextFactory _applicationDbContextFactory;
        public UserService(IApplicationDbContextFactory applicationDbContextFactory, RoleManager<Role> roleManager, UserManager<User> userManager, IConfiguration configuration)
        {
            UserManager = userManager;
            RoleManager = roleManager;
            _configuration = configuration;
            _applicationDbContextFactory = applicationDbContextFactory;
            
        }


        public async Task<ResponseObject<List<UserIndexModel>>> GetAll()
        {
            using (var context = _applicationDbContextFactory.Create())
            {
                var Users = context.IncludeUsers();
                var Models = Mapper.Map<List<UserIndexModel>>(Users);
                return new ResponseObject<List<UserIndexModel>>
                {
                    Status = 100,
                    Message = "Запрос прошел успешно",
                    ResponseObj = Models
                };
            }
        }


        //работающий метод без ролей 
        public async Task<FilterResponse<List<UserIndexModel>>> IndexFilter(EmployeesFilter filter)
        {
            using (var context = _applicationDbContextFactory.Create())
            {
                var Users = context.UsersFilterInclude(CitiesId: filter.CitiesId, Name: filter.Name);
                var UsersList = Mapper.Map<List<UserIndexModel>>(Users);
                var pagedData = UsersList;
                var totalRecords = UsersList.Count();
                var pagedReponse = FilterHelper.CreatePagedReponse(pagedData, totalRecords);
                return pagedReponse;
            }
        }


        public async Task<FilterResponse<List<UserIndexModel>>> IndexFilterNew(EmployeesFilter filter)
        {
            using (var context = _applicationDbContextFactory.Create())
            {
                
                var Users = context.UsersFilterInclude(CitiesId: filter.CitiesId, Name: filter.Name);
                var Models = new List<UserIndexModel>();
                foreach (var User in Users)
                {

                    var Model = Mapper.Map<UserIndexModel>(User);
                    var rolesList = await UserManager.GetRolesAsync(User).ConfigureAwait(false);
                    Model.Roles = (List<string>)rolesList;
                    Models.Add(Model);
                }
                var pagedData = Models;
                var totalRecords = Models.Count();
                var pagedReponse = FilterHelper.CreatePagedReponse(pagedData, totalRecords);
                return pagedReponse;
            }
        }

        //работающий метод
        public async Task<UserIndexModel> GetUser(UserIndexModel model, ClaimsPrincipal User)
        {
            using (var context = _applicationDbContextFactory.Create())
            {
                User user = await UserManager.FindByNameAsync(User.Identity.Name);
                if (user != null)
                {
                    user = context.IncludeUser(User);
                    var rolesList = await UserManager.GetRolesAsync(user).ConfigureAwait(false);
                    var Model = Mapper.Map<UserIndexModel>(user);
                    Model.Roles = (List<string>)rolesList;
                    return Model;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<TokenModel> Update(UserEditModel model, ClaimsPrincipal User)
        {
            using (var context = _applicationDbContextFactory.Create())
            {
                User user = await UserManager.FindByNameAsync(User.Identity.Name);
                if (user != null)
                {
                    if (model.Email != null)
                    {
                        user.Email = model.Email;
                    }
                    if (model.Username != null)
                    {
                        user.UserName = model.Username;
                    }
                    if (model.Surname != null)
                    {
                        user.Surname = model.Surname;
                    }
                    if (model.Name != null)
                    {
                        user.Name = model.Name;
                    }
                    if (model.MiddleName != null)
                    {
                        user.MiddleName = model.MiddleName;
                    }
                    if (model.PhoneNumber != null)
                    {
                        user.PhoneNumber = model.PhoneNumber;
                    }
                    if (model.CityId != null)
                    {
                        if (!context.Check<City>(model.CityId))
                        {
                            return new TokenModel { token = "такого города нет" , expiration = DateTime.Now}; ;
                        }
                        else
                            user.CityId = model.CityId;
                    }
                        var result = await UserManager.UpdateAsync(user);
                        if (result.Succeeded)
                        {
                            return await GenerateToken(user);
                        }
                        else
                        {
                            throw new Exception("Такой логин уже существует");
                        }
                        }
                else
                {
                    return null;
                }
            }
        }


        private async Task<TokenModel> GenerateToken(User user)
        {
            var userRoles = await UserManager.GetRolesAsync(user);
            var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };
            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
            return new TokenModel
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            };

        }


    }
}
