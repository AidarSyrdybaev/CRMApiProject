using AutoMapper;
using CustomerManagementSystemBackendProject.DAL.Entities;
using CustomerManagementSystemBackendProject.Models.Course;
using CustomerManagementSystemBackendProject.Models.GroupModels;
using CustomerManagementSystemBackendProject.Models.PaymentModels;
using CustomerManagementSystemBackendProject.Models.TeacherModels;
using CustomerManagementSystemBackendProject.Models.LeadModels;
using CustomerManagementSystemBackendProject.Models.LeadStatusModels;
using CustomerManagementSystemBackendProject.Models.StudentModels;
using CustomerManagementSystemBackendProject.Models.FlexByModels;
using System;
using System.Collections.Generic;
using System.Text;
using CustomerManagementSystemBackendProject.Models.CityModels;
using CustomerManagementSystemBackendProject.Models.StudentGroupModels;
using CustomerManagementSystemBackendProject.Models.UserModels;
using CustomerManagementSystemBackendProject.Models.AnalystsModel;
using CustomerManagementSystemBackendProject.Models.LeadCommentModels;
using CustomerManagementSystemBackendProject.Models.StudentCommentModels;

namespace CustomerManagementSystemBackendProject.BL.MProfile
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CourseMap();
            CommentMap();
            TeacherMap();
            GroupMap();
            LeadMap();
            StudentMap();
            CityMap();
            LeadStatusMap();
            PaymentMap();
            UserMap();
            StudenGroupMap();
            StatisticsMap();
        }

        private void CommentMap()
        {
            CreateMap<LeadComment, LeadCommentIndexModel>()
                .ForMember
                (
                     i => i.LeadId, src => src.MapFrom(target => target.Lead.Id)
                )
                .ForMember
              (
                    source => source.UserName,
                    src => src.MapFrom
                    (
                        target => String.Join
                        (
                            " ",
                            new string[]
                            {
                                  target.User.Surname, target.User.Name, target.User.MiddleName
                            }
                        )
                    )
              );
            CreateMap<LeadCommentCreateModel, LeadComment>();
            CreateMap<StudentComment, StudentCommentIndexModel>()
                .ForMember
                (
                     i => i.StudentId, src => src.MapFrom(target => target.Student.Id)
                )
                .ForMember
              (
                    source => source.UserName,
                    src => src.MapFrom
                    (
                        target => String.Join
                        (
                            " ",
                            new string[]
                            {
                                  target.User.Surname, target.User.Name, target.User.MiddleName
                            }
                        )
                    )
              );
            CreateMap<StudentCommentCreateModel, StudentComment>();
        }
        private void CourseMap()
        {
            CreateMap<Course, CourseIndexModel>();
            CreateMap<Course, CourseDetailsModel>();
            CreateMap<CourseUpdateModel, Course>();
            CreateMap<CourseCreateModel, Course>();

        }

        private void TeacherMap()
        {
            CreateMap<Teacher, TeacherIndexModel>()
                .ForMember
                (
                     i => i.Course, src => src.MapFrom(target => target.Course.Name)
                );
            CreateMap<Teacher, TeacherDetailsModel>()
                .ForMember
                (
                     i => i.City, src => src.MapFrom(target => target.City.Name)
                )
            .ForMember
                (
                     i => i.Course, src => src.MapFrom(target => target.Course.Name)
                );
            CreateMap<TeacherUpdateModel, Teacher>();
            CreateMap<TeacherCreateModel, Teacher>();
            CreateMap<GroupCreateModel, Course>();
        }

        private void GroupMap()
        {
            CreateMap<Group, GroupIndexModel>()
                .ForMember
                (
                     i => i.CityName, src => src.MapFrom(target => target.Teacher.Course.City.Name)
                )
                .ForMember
                (
                    i => i.Course, src => src.MapFrom(target => target.Teacher.Course.Name)
                )
                //.ForMember
                //(
                //    i => i.Months, src => src.MapFrom(target => target.Course.)
                //)
                ;
            CreateMap<Group, GroupDetailsModel>()
              .ForMember
              (
                   i => i.City, src => src.MapFrom(target => target.Teacher.Course.City.Name)
              )
              .ForMember
              (
                   i => i.Name, src => src.MapFrom(target => target.Name)
              )
              .ForMember
              (
                  i => i.Months, src => src.MapFrom(target => target.Months)
              )
              .ForMember
              (
                  i => i.Course, src => src.MapFrom(target => target.Teacher.Course.Name)
              )
               .ForMember
              (
                    source => source.Teacher,
                    src => src.MapFrom
                    (
                        target => String.Join
                        (
                            " ",
                            new string[]
                            {
                                  target.Teacher.Surname, target.Teacher.Name, target.Teacher.MiddleName
                            }
                        )
                    )
              )
              .ForMember
              (
                  i => i.StudentCount, src => src.MapFrom(target => target.StudentGroups.Count)
              )
              ;
            CreateMap<StudentGroup, GroupDetailsModel>()
                .ForMember
                (
                     i => i.City, src => src.MapFrom(target => target.Group.Teacher.Course.City.Name)
                )
                .ForMember
                (
                     i => i.Name, src => src.MapFrom(target => target.Group.Name)
                )
                .ForMember
                (
                    i => i.Months, src => src.MapFrom(target => target.Group.Months)
                )
                .ForMember
                (
                    i => i.Course, src => src.MapFrom(target => target.Group.Teacher.Course.Name)
                )
                 .ForMember
                (
                      source => source.Teacher,
                      src => src.MapFrom
                      (
                          target => String.Join
                          (
                              " ",
                              new string[]
                              {
                                  target.Group.Teacher.Surname, target.Group.Teacher.Name, target.Group.Teacher.MiddleName
                              }
                          )
                      )
                )
                .ForMember
                (
                    i => i.ContractSum, src => src.MapFrom(target => target.Payments.Count)
                )
                .ForMember
                (
                    i => i.StudentCount, src => src.MapFrom(target => target.Group.StudentGroups.Count)
                )
                ;
            CreateMap<GroupUpdateModel, Group>();
            CreateMap<GroupCreateModel, Group>();

            CreateMap<(string, int),GroupByCityModel > ()
                .ForMember(source => source.CityName, src => src.MapFrom(i => i.Item1))
                .ForMember(source => source.GroupCount, src => src.MapFrom(i => i.Item2));
        }
        private void StudentMap()
        {
            CreateMap<Student, StudentDetailsModel>()
                .ForMember(source => source.CityName, target => target.MapFrom(src => src.City.Name));
            CreateMap<Student, StudentIndexModel>()
                .ForMember(source => source.CityName, target => target.MapFrom(src => src.City.Name))
                .ForMember(source => source.Id, target => target.MapFrom(src => src.Id));
            CreateMap<StudentGroup, StudentIndexModel>()
                .ForMember(source => source.Surname, target => target.MapFrom(src => src.Student.Surname))
                .ForMember(source => source.Name, target => target.MapFrom(src => src.Student.Name))
                .ForMember(source => source.MiddleName, target => target.MapFrom(src => src.Student.MiddleName))
                .ForMember(source => source.GroupName, target => target.MapFrom(src => src.Group.Name))
                .ForMember
                (
                      source => source.TeacherName,
                      src => src.MapFrom
                      (
                          target => String.Join
                          (
                              " ",
                              new string[]
                              {
                                  target.Group.Teacher.Surname, target.Group.Teacher.Name, target.Group.Teacher.MiddleName
                              }
                          )
                      )
                )
                .ForMember(source => source.StartDate, target => target.MapFrom(src => src.Group.StartDate))
                .ForMember(source => source.EndDate, target => target.MapFrom(src => src.Group.EndDate))
                .ForMember(source => source.PaymentStatus, target => target.MapFrom(src => src.Payments))
                .ForMember(source => source.CityName, target => target.MapFrom(src => src.Student.City.Name))
                .ForMember(source => source.Id, target => target.MapFrom(src => src.Student.Id));
            CreateMap<StudentCreateModel, StudentGroup>();
           // CreateMap<StudentFullCreateModel, StudentGroup>();
            CreateMap<StudentCreateModel, Student>();
            CreateMap<StudentFullCreateModel, Student>(); 
            CreateMap<StudentGroup, Student>();
            CreateMap<Lead, Student>()
                .ForMember(source => source.Id, target => target.Ignore())
                .ForMember(source => source.Discriminator, target => target.Ignore());
            CreateMap<Group, Student>()
                .ForMember(source => source.StudentGroups, target => target.Ignore());
        }
        private void StudenGroupMap()
        {
            CreateMap<StudentGroup, StudentGroupIndexModel>()
                .ForMember(source => source.Surname, target => target.MapFrom(src => src.Student.Surname))
                .ForMember(source => source.Name, target => target.MapFrom(src => src.Student.Name))
                .ForMember(source => source.MiddleName, target => target.MapFrom(src => src.Student.MiddleName))
                .ForMember(source => source.CityName, target => target.MapFrom(src => src.Student.City.Name))
                .ForMember(source => source.GroupName, target => target.MapFrom(src => src.Group.Name))
                .ForMember
                (
                      source => source.TeacherName,
                      src => src.MapFrom
                      (
                          target => String.Join
                          (
                              " ",
                              new string[]
                              {
                                  target.Group.Teacher.Surname, target.Group.Teacher.Name, target.Group.Teacher.MiddleName
                              }
                          )
                      )
                )
                .ForMember(source => source.StartDate, target => target.MapFrom(src => src.Group.StartDate))
                .ForMember(source => source.EndDate, target => target.MapFrom(src => src.Group.EndDate))
                .ForMember(source => source.PaymentStatus, target => target.MapFrom(src => src.Group.EndDate));//исправить
            CreateMap<StudentGroup, StudentGroupModel>()
                .ForMember(source => source.Id, target => target.MapFrom(src => src.Id))
                .ForMember(source => source.GroupId, target => target.MapFrom(src => src.Group.Id))
                .ForMember(source => source.StudentId, target => target.MapFrom(src => src.Student.Id));
        }

        private void LeadMap()
        {
            CreateMap<Lead, LeadIndexModel>()
                 .ForMember(source => source.CityName, target => target.MapFrom(src => src.City.Name))
                 .ForMember(source => source.LeadStatus, target => target.MapFrom(src => src.LeadStatus.Name))
                 .ForMember(source => source.CourseName, target => target.MapFrom(src => src.Course.Name));
            CreateMap<Lead, LeadDetailsModel>()
                 .ForMember(source => source.CityName, target => target.MapFrom(src => src.City.Name))
                 .ForMember(source => source.LeadStatus, target => target.MapFrom(src => src.LeadStatus.Name))
                 .ForMember(source => source.CourseName, target => target.MapFrom(src => src.Course.Name));
            CreateMap<LeadCreateModel, Lead>();
            CreateMap<LeadUpdateModel, Lead>();
            CreateMap<LeadUpdateStatusModel, Lead>();
            CreateMap<LeadsNotify, NotificationIndexModel>()
                .ForMember(i => i.DateTime, target => target.MapFrom(src => src.Date))
                .ForMember(i => i.LeadId, target => target.MapFrom(src => src.LeadId))
                .ForMember(i => i.Message, target => target.MapFrom(src => $"Карточка #{src.Id} уже более 24 находится во ${src.Lead.LeadStatusId}"));

        }
        private void LeadStatusMap()
        {
            CreateMap<LeadStatus, LeadStatusIndexModel>();
        }
        private void CityMap()
        {

            CreateMap<(int Id, string Name, DateTime? DateTime, int Count), CityIndexModel>()
                .ForMember(source => source.Id, src => src.MapFrom(target => target.Id))
                .ForMember(source => source.Name, src => src.MapFrom(target => target.Name))
                .ForMember(source => source.CreateDate, src => src.MapFrom(target => target.DateTime))
                .ForMember(source => source.GroupsCount, src => src.MapFrom(target => target.Count));
        }
        
        private void UserMap()
        {
           
            CreateMap<User, UserIndexModel>()
                 .ForMember(source => source.CityName, target => target.MapFrom(src => src.City.Name));
           


        }

        private void PaymentMap()
        {
            CreateMap<PaymentUpdateModel, Payment>();
            CreateMap<PaymentCreateModel,Payment>();
            CreateMap<Payment, PaymentIndexModel>()
                .ForMember(source => source.StudentName,
                target => target.MapFrom(src => src.StudentGroup.Student.Surname + " " + src.StudentGroup.Student.Name + src.StudentGroup.Student.MiddleName))
                .ForMember(src => src.PaymentPercent, target => target.MapFrom(src => src.Sum / src.StudentGroup.Group.OneMounthSum))
                .ForMember(src => src.PaymentStatus,
                    target => target.MapFrom(
                        src => src.Sum == 0 ? "Неоплачен" : src.Sum == src.StudentGroup.Group.OneMounthSum ? "Оплачен" : "Частично оплачен"
                        ));
        }

        private void StatisticsMap()
        {
            CreateMap<(string, int), AnalystsModel>()
               .ForMember(source => source.Name, src => src.MapFrom(i => i.Item1))
               .ForMember(source => source.Count, src => src.MapFrom(i => i.Item2));
        }
    }
}
