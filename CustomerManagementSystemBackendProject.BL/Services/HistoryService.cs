using CustomerManagementSystemBackendProject.BL.Services.Contracts;
using CustomerManagementSystemBackendProject.DAL.Entities;
using CustomerManagementSystemBackendProject.DAL.Factories;
using CustomerManagementSystemBackendProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystemBackendProject.BL.Services
{
    public class HistoryService: IHistoryService

    {
        private IApplicationDbContextFactory _applicationDbContextFactory;

        public HistoryService (IApplicationDbContextFactory applicationDbContextFactory)
        {
            _applicationDbContextFactory = applicationDbContextFactory;
        }
        //Task<List<HistoryIndexModel>
        public async Task<List<HistoryIndexModel>> GetAll()
        {
            using (var context = _applicationDbContextFactory.Create())
            {
                var Models = new List<HistoryIndexModel>();
                var Histories = context.Histories.ToList();
                foreach (var History in Histories)
                {
                    if (History is StudentHistory)
                    {
                        var Student = context.Students.Where(i => i.Id == ((StudentHistory)History).StudentId).FirstOrDefault();
                        var Model = new HistoryIndexModel { Action=History.Action, DateTime = History.DateTime, Information = Student.Surname + " " + Student.Name + " " + Student.MiddleName, Type="Студент"};
                        Models.Add(Model);
                    }
                    if (History is LeadHistory)
                    {
                        var Student = context.Leads.Where(i => i.Id == ((LeadHistory)History).LeadId).FirstOrDefault();
                        var Model = new HistoryIndexModel { Action = History.Action, DateTime = History.DateTime, Information = Student.Surname + " " + Student.Name + " " + Student.MiddleName, Type = "Лид" };
                        Models.Add(Model);
                    }

                    if (History is CourseHistory)
                    {
                        var Student = context.Courses.Where(i => i.Id == ((CourseHistory)History).CourseId).FirstOrDefault();
                        var Model = new HistoryIndexModel { Action = History.Action, DateTime = History.DateTime, Information = Student.Name, Type = "Курсы" };
                        Models.Add(Model);
                    }
                    if (History is TeacherHistory)
                    {
                        var Student = context.Teachers.Where(i => i.Id == ((TeacherHistory)History).TeacherId).FirstOrDefault();
                        var Model = new HistoryIndexModel { Action = History.Action, DateTime = History.DateTime, Information = Student.Surname + " " + Student.Name + " " + Student.MiddleName, Type = "Учитель" };
                        Models.Add(Model);
                    }
                    if (History is GroupHistory)
                    {
                        var Student = context.Groups.Where(i => i.Id == ((GroupHistory)History).GroupId).FirstOrDefault();
                        var Model = new HistoryIndexModel { Action = History.Action, DateTime = History.DateTime, Information = Student.Name, Type = "Группа" };
                        Models.Add(Model);
                    }
                }

                return Models;
            }
        }
    }
}
