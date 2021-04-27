using CustomerManagementSystemBackendProject.DAL.Factories;
using CustomerManagementSystemBackendProject.Models.CommonModels;
using CustomerManagementSystemBackendProject.Models.PaymentModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CustomerManagementSystemBackendProject.DAL.Extensions.Filter;
using CustomerManagementSystemBackendProject.DAL.Entities;
using AutoMapper;
using CustomerManagementSystemBackendProject.DAL.Extensions.Check;
using System.Linq;
using CustomerManagementSystemBackendProject.DAL.Extensions.IncludeExtensions;
using CustomerManagementSystemBackendProject.BL.Services.Contracts;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace CustomerManagementSystemBackendProject.BL.Services
{
    public class PaymentService: IPaymentService
    {

        private readonly UserManager<User> _userManager;
        private readonly IApplicationDbContextFactory _applicationDbContextFactory;

        public PaymentService(IApplicationDbContextFactory applicationDbContextFactory, UserManager<User> userManager)
        {
            _applicationDbContextFactory = applicationDbContextFactory;
            _userManager = userManager;
        }

        public async Task<Response> Create(PaymentCreateModel model, ClaimsPrincipal claimsPrincipal)
        {
            using (var context = _applicationDbContextFactory.Create())
            {
                var Entity = Mapper.Map<Payment>(model);
                var Group = context.GetGroupStudentId(model.StudentId, model.GroupId);
                var User = await _userManager.FindByNameAsync(claimsPrincipal.Identity.Name);
                Entity.UserId = User.Id;
                if (Entity.Sum > Group.OneMounthSum)
                {
                    return new Response { Status = 500, Message = "Сумма взноса больше суммы контракта" };
                }
                if (context.StudentGroups.Any(i => i.GroupId == model.GroupId && i.StudentId == model.GroupId))
                    return new Response { Status = 500, Message = "Студент не зарегистрирован в данной группе" };
                var result = context.Add(Entity);
                context.SaveChanges();
                context.PaymentHistories.Add(new PaymentHistory { Action = "Создание", PaymentId = result.Entity.Id, DateTime = DateTime.Now, UserId = User.Id });
                context.SaveChanges();
                return new Response { Status = 100, Message = "Запрос прошел успешно" };
            }
        }

        public async Task<Response> Update(PaymentUpdateModel model, ClaimsPrincipal claimsPrincipal)
        {
            using (var context = _applicationDbContextFactory.Create())
            {
                var Entity = context.Payments.Where( i => i.Id == model.Id).FirstOrDefault();
                if(Entity == null)
                    return new Response { Status = 500, Message = "Студент еще внес оплату за этот месяц" };
                Entity.Sum += model.Sum;
                Entity.DateTime = model.DateTime;
                var User = await _userManager.FindByNameAsync(claimsPrincipal.Identity.Name);
                Entity.UserId = User.Id;
                var Group = context.GetGroupStudentId(model.StudentId, model.GroupId);
                if (Entity.Sum> Group.OneMounthSum)
                {
                    return new Response { Status = 500, Message = "Сумма взноса больше суммы контракта" };
                }
                if (context.StudentGroups.Any(i => i.GroupId == model.GroupId && i.StudentId == model.GroupId))
                    return new Response { Status = 500, Message = "Студент не зарегистрирован в данной группе" };
                context.Update(Entity);
                context.SaveChanges();
                return new Response { Status = 100, Message = "Запрос прошел успешно" };
            }
        }

        public async Task<ResponseObject<List<PaymentIndexModel>>> GetAll()
        {
            using (var context = _applicationDbContextFactory.Create())
            {
                var Entites = context.GetFullPayments();
                var Models = Mapper.Map<List<PaymentIndexModel>>(Entites);
                return new ResponseObject<List<PaymentIndexModel>> {Message="Запрос прошел успешно", Status=100, ResponseObj = Models};
            }
        }
    }
}
