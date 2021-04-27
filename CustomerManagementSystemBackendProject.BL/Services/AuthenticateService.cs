using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using CustomerManagementSystemBackendProject.BL.Services.Contracts;
using CustomerManagementSystemBackendProject.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using CustomerManagementSystemBackendProject.Models.AuthenticateModels;
using Microsoft.IdentityModel.Tokens;
using CustomerManagementSystemBackendProject.Models.CommonModels;
using CustomerManagementSystemBackendProject.DAL.Factories;
using CustomerManagementSystemBackendProject.DAL.Extensions.Check;
using CustomerManagementSystemBackendProject.Models.CommonModels;
using System.Threading;
using System.Linq;
using System.Net.Mail;
using System.Net;

namespace CustomerManagementSystemBackendProject.BL.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly IConfiguration _configuration;
        private readonly IApplicationDbContextFactory applicationDbContextFactory;
        private static int _seed = Environment.TickCount;
        private static ThreadLocal<Random> _random = new ThreadLocal<Random>(() =>
        new Random(Interlocked.Increment(ref _seed))
    );

        public AuthenticateService(UserManager<User> userManager, RoleManager<Role> roleManager, IApplicationDbContextFactory applicationDbContextFactory, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
            this.applicationDbContextFactory = applicationDbContextFactory;
        }

        public async Task<TokenModel> Login(LoginModel model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);
                
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

            return null;
        }

        public async Task<Response> Archive(int UserId)
        {
            using (var context = applicationDbContextFactory.Create())
            {
                var User = context.Users.Where(i => i.Id == UserId).FirstOrDefault();
                if(User == null)
                    return new Response { Message = "Нет такого пользователя", Status = 500 };
                User.IsArchive = true;
                context.Users.Update(User);
                return new Response { Message = "Запрос прошел успешно", Status = 100 };
            }
        }

        public async Task<Response> Register(RegisterModel model)
        {
            using (var context = applicationDbContextFactory.Create())
            {
                var userExists = await userManager.FindByNameAsync(model.Username);

                if (userExists != null)
                    return new Response { Status = 400, Message = "User already exists!" };

                var EmailExists = await userManager.FindByEmailAsync(model.Email);

                if (EmailExists != null)
                    return new Response { Status = 400, Message = "Email already exists!" };

                var Role = await roleManager.FindByIdAsync(model.RoleId.ToString());

                if (Role == null)
                    return new Response { Status = 400, Message = "There is no such role" };

                if (!context.Check<City>(model.CityId))
                    return new Response { Status = 400, Message = "There is no such CityId" };
                

                    User user = new User()
                    {
                        Email = model.Email,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        UserName = model.Username,
                        Surname = model.Surname,
                        Name = model.Name,
                        MiddleName = model.MiddleName,
                        CityId = model.CityId,
                        PhoneNumber = model.Phone

                    };
                var result = await userManager.CreateAsync(user, model.Password);
                if (!result.Succeeded)
                    new Response { Status = 400, Message = "Incorrect registration" };
                await userManager.AddToRoleAsync(user, Role.Name);
                return new Response { Status = 100, Message = "User created successfully!" };
            }

        }

        public async Task<ResponseObject<int>> GetForgotPasswordCode(string Email)
        {
            using (var context = applicationDbContextFactory.Create())
            {
                var User = await userManager.FindByEmailAsync(Email);
                if (User == null)
                    return new ResponseObject<int> { Message = "Email not found!", Status = 400};
                var ForgotPasswordKey = new ForgotPaswwordKey
                {
                    Key = _random.Value.Next(100000, 999999),
                    UserId = User.Id,
                    DateTime = DateTime.Now
                };

                var OldCode = context.ForgotPaswwordKeys.Where(i => i.UserId == User.Id).FirstOrDefault();
                if (OldCode != null)
                    context.ForgotPaswwordKeys.Remove(OldCode);

                context.ForgotPaswwordKeys.Add(ForgotPasswordKey);
                context.SaveChanges();
                SendMessage(Email, ForgotPasswordKey.Key.ToString(), "Код для восстановления паполя получен");
                return new ResponseObject<int> { Message = "Code generated", Status = 100, ResponseObj = ForgotPasswordKey.Key };
            }
        }

        public async Task<Response> GenerateNewPassword(ForgotPasswordModel forgotPasswordModel)
        {
            using (var context = applicationDbContextFactory.Create())
            {
                var User = await userManager.FindByEmailAsync(forgotPasswordModel.Email);
                var Key = context.ForgotPaswwordKeys.Where(i => i.Key == forgotPasswordModel.Code && User.Id == i.UserId).FirstOrDefault();
                if (Key == null)
                    return new Response { Status = 400, Message ="User or key not found"};
                string Password = Guid.NewGuid().ToString();
                User.PasswordHash = userManager.PasswordHasher.HashPassword(User, Password);
                context.ForgotPaswwordKeys.Remove(Key);
                await userManager.UpdateAsync(User);
                context.SaveChanges();
                SendMessage(forgotPasswordModel.Email, Password, "Новый пароль сгенерирован");
                return new Response {Status = 100, Message ="New password generated" };

            }
        }

        private void SendMessage(string Email, string Text, string Body)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("cms.neolabs@gmail.com");
                mail.To.Add($"{Email}");
                mail.Subject = $"{Body}";
                mail.Body = $"{Text}";
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("cms.neolabs@gmail.com", "Managercms21");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }

    }
}
