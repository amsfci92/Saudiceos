 
using Cigarette.Enterprise.DAL.Repository.SettingsRep;
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
using Cigarette.Enterprise.DAL.Repository.ContactUsRep;
using Cigarette.Enterprise.DAL.Repository.CEORep;
using Cigarette.Enterprise.DAL.Repository.CEOAddEditRequestRep;
using Cigarette.Enterprise.DAL.Repository.IndividualOpportunityDiscoveryRep;
using Cigarette.Enterprise.DAL.Repository.KnowledgeCenterRep;
using Cigarette.Enterprise.DAL.Repository.BannerRepo;
using Cigarette.Enterprise.DAL.Repository.NewsRep;
using Cigarette.Enterprise.DAL.Repository.AspNetUserRep;
using Cigarette.Enterprise.DAL.Repository.CompanyAttractRequestRep;
using Cigarette.Enterprise.DAL.Repository.ReportRep;
using Cigarette.Enterprise.DAL.Repository.ServiceRep;
using Cigarette.Enterprise.DAL.Repository.CategoryRep;

namespace Cigarette.Enterprise.DAL.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        ICEORepository CEOs { get; }
        IBannerRepository Banners { get; } 
        ICEOAddEditRequestRepository CEOAddEditRequests { get; }
        IIndividualOpportunityDiscoveryRepository IndividualOpportunityDiscoveries { get; }
        IKnowledgeCenterRepository KnowldegeCenters{ get; }
        ISettingsRepository Settings { get; } 
        IContactRepository ContactUs { get; set; } 
        INewsRepository News { get; }
        IAspNetUserRepository Users { get; }
        ICompanyAttractRequestRepository CompanyAttractRequests { get; }
        IReportRepository Report { get; }
        IServiceRepository Service { get; }
        ICategoryRepository Category { get; }
        SaudiceosEntities SaudiceosEntities { get;  }
        void SaveChanges();
    }
}
