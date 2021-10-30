
using Cigarette.Enterprise.BLL.BannerServ;
using Cigarette.Enterprise.BLL.CEOAddEditRequestServ;
using Cigarette.Enterprise.BLL.CEOServ;
using Cigarette.Enterprise.BLL.ContactUsServ;
using Cigarette.Enterprise.BLL.NewsServ;
using Cigarette.Enterprise.BLL.ReportServ;
using Cigarette.Enterprise.BLL.ServiceServ;
using Cigarette.Enterprise.BLL.SettingsServ; 
using Cigarette.Enterprise.DAL.Repository; 
using Microsoft.Owin.Security;
using System; 
using Unity;
using Unity.Injection;

namespace Taswiq4U.Enterprise.WebApi
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();

            //container.RegisterType<AccountController>(new InjectionConstructor());
            //container.RegisterType<AccountController>(new InjectionConstructor(
            //    typeof(ApplicationUserManager),
            //    typeof(ISecureDataFormat<AuthenticationTicket>)
            // ));
            
            //container.RegisterType<PaymentController>(new InjectionConstructor());
            //container.RegisterType<RolesAdminController>(new InjectionConstructor());
            //container.RegisterType<ManageController>(new InjectionConstructor());
            //container.RegisterType<UsersAdminController>(new InjectionConstructor());

            // Repository
            //container.RegisterType<ICategoryRepository, CategoryRepository>();

            // Services
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IReportService, ReportService>();
            container.RegisterType<ICEOService, CEOService>();
            container.RegisterType<INewsService, NewsService>();
            container.RegisterType<IBannerService, BannerService>();
            container.RegisterType<IContactUsService, ContactUsService>();

            container.RegisterType<IReportService, ReportService>();
            container.RegisterType<IServiceService, ServiceService>();
            container.RegisterType<ISettingsService, SettingsService>();
            container.RegisterType<ICEOAddEditRequestService, CEOAddEditRequestService>();
            

            //container.RegisterType<IAdvertisementServices, AdvertisementServices>();
            //container.RegisterType<ICategoryServices, CategoryServices>();
            //container.RegisterType<ICountryService, CountryService>();
            //container.RegisterType<IFavoriteService, FavoriteService>();
            //container.RegisterType<ICityServices, CityServices>();
            //container.RegisterType<ISpecificationService, SpecificationService>();
            //container.RegisterType<ICategory_SpecificationServices, Category_SpecificationServices>();
            //container.RegisterType<ISettingsService, SettingsService>();

            //container.RegisterType<IAdvertisementImageServices, AdvertisementImageServices>();
            //container.RegisterType<ICommercialAdService, CommercialAdService>();
            //container.RegisterType<IAdBundleService, AdBundleService>();
            //container.RegisterType<IPaymentGatewayService, PaymentGatewayService>();
            //container.RegisterType<IFeaturedAdvertisementService, FeaturedAdvertisementServices>();
            //container.RegisterType<ISmsGatewayService, SmsGatewayService>();
            //container.RegisterType<ISystemDataFileService, SystemDataFileService>();
            //container.RegisterType<ICommercialAdsUserService, CommercialAdsUserService>();

        }
    }
}