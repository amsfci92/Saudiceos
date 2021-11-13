
using Cigarette.Enterprise.BLL.ContactUsServ;
using Cigarette.Enterprise.DAL.Repository;
using System.Web.Mvc;
using Saudiceos.Enterprise.Web.Areas.AdminPanel.AuthServices.UserRoleService;
using Saudiceos.Enterprise.Web.Controllers;
using Unity;
using Unity.Injection;
using Unity.Mvc5;
using Cigarette.Enterprise.BLL.SettingsServ;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Saudiceos.Enterprise.Web.Areas.AdminPanel.Controllers;
using Cigarette.Enterprise.BLL.NewsServ;
using Cigarette.Enterprise.BLL.CEOServ;
using Cigarette.Enterprise.BLL.CEOAddEditRequestServ;
using Cigarette.Enterprise.BLL.IndividualOpportunityDiscoveryServ;
using Cigarette.Enterprise.BLL.UserServ;
using Cigarette.Enterprise.BLL.CompanyAttractRequestServ;
using Cigarette.Enterprise.BLL.KnowledgeCenterServ;
using Cigarette.Enterprise.BLL.BannerServ;
using Cigarette.Enterprise.BLL.ReportServ;
using Cigarette.Enterprise.BLL.ServiceServ;

namespace Saudiceos.Enterprise.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            
            container.RegisterType<AccountController>(new InjectionConstructor());
            //container.RegisterType<RolesAdminController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor()); 

            container.RegisterType<IUnitOfWork, UnitOfWork>();

            container.RegisterType<IUserService , UserService>();
            container.RegisterType<INewsService, NewsService>();
            container.RegisterType<ICEOService, CEOService>();
            container.RegisterType<ICEOAddEditRequestService, CEOAddEditRequestService>();
            container.RegisterType<IIndividualOpportunityDiscoveryService, IndividualOpportunityDiscoveryService>();
            container.RegisterType<ICompanyAttractRequestService, CompanyAttractRequestService>();
            container.RegisterType<IContactUsService, ContactUsService>();
            container.RegisterType<IKnowledgeCenterService, KnowledgeCenterService>();
            container.RegisterType<IBannerService, BannerService>(); 
            container.RegisterType<ISettingsService, SettingsService>();
            container.RegisterType<IReportService, ReportService>();
            container.RegisterType<IServiceService, ServiceService>();
            

            // Auth DI
            container.RegisterType<IUserRoleService, UserRoleService>();  

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}