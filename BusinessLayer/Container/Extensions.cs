﻿using BusinessLayer.Abstract;
using BusinessLayer.Abstract.AbstractUnitOfWork;
using BusinessLayer.Concrete;
using BusinessLayer.Concrete.ConcreteUnitOfWork;
using BusinessLayer.ValidationRules;
using BusinessLayer.ValidationRules.ContactUsValidatorRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.UnitOfWork;
using DTOLayer.DTOs.AnnouncementDTOs;
using DTOLayer.DTOs.AppUserDTOs;
using DTOLayer.DTOs.ContactDTOs;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Container
{
    public static class Extensions
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICommentService, CommentManager>();//ders 54
            services.AddScoped<ICommentDal, EfCommentDal>();//ders 54 ef core bagımlılıgının kaldırılması.

            services.AddScoped<IDestinationService, DestinationManager>();
            services.AddScoped<IDestinationDal, EfDestinationDal>();

            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IAppUserDal, EfAppUserDal>();

            services.AddScoped<IReservationService, ReservationManager>();
            services.AddScoped<IReservationDal, EfReservationDal>();

            services.AddScoped<IGuideService,GuideManager>();
            services.AddScoped<IGuideDal, EfGuideDal>();

            services.AddScoped<IExcelService, ExcelManager>();
            services.AddScoped<IPdfService, PdfManager>();

            services.AddScoped<IContactUsService, ContactUsManager>();
            services.AddScoped<IContactUsDal, EfContactUsDal>();

            services.AddScoped<IAnnouncementService, AnnouncementManager>();
            services.AddScoped<IAnnouncementDal, EfAnnouncementDal>();

            services.AddScoped<IAccountService, AccountManager>();
            services.AddScoped<IAccountDal, EfAccountDal>();

            services.AddScoped<IUnitofWorkDal, UnitofWorkDal>();

        }


        public static void CustomerValidator(this IServiceCollection services)
        {
            services.AddTransient<IValidator<AnnouncementAddDto>, AnnouncementValidator>();
            services.AddTransient<IValidator<SendMessageDto>, SendMessageValidator>();
            //services.AddTransient<IValidator<AppUserEditDTOs>,UserEditValidator>();
            //services.AddSingleton<IValidator<AppUserEditDTOs>, UserEditValidator>();
            //services.AddScoped<IValidator<AppUserEditDTOs>, UserEditValidator>();
        }
    }
}
