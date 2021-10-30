
using Cigarette.Enterprise.DAL.Repository.SettingsRep; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using Cigarette.Enterprise.DAL.Repository.ContactUsRep;
using Cigarette.Enterprise.DAL.Repository.CEORep;
using Cigarette.Enterprise.DAL.Repository.BannerRepo;
using Cigarette.Enterprise.DAL.Repository.CEOAddEditRequestRep;
using Cigarette.Enterprise.DAL.Repository.IndividualOpportunityDiscoveryRep;
using Cigarette.Enterprise.DAL.Repository.KnowledgeCenterRep;
using Cigarette.Enterprise.DAL.Repository.NewsRep;
using Cigarette.Enterprise.DAL.Repository.AspNetUserRep;
using Cigarette.Enterprise.DAL.Repository.CompanyAttractRequestRep;
using Cigarette.Enterprise.DAL.Repository.ReportRep;
using Cigarette.Enterprise.DAL.Repository.ServiceRep;
using Cigarette.Enterprise.DAL.Repository.CategoryRep;

namespace Cigarette.Enterprise.DAL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SaudiceosEntities _context;
 
        public ISettingsRepository Settings { get; private set; }  

        public ICEORepository CEOs { get; set; }

        public IBannerRepository Banners { get; set; }

        public ICEOAddEditRequestRepository CEOAddEditRequests { get; set; }

        public IIndividualOpportunityDiscoveryRepository IndividualOpportunityDiscoveries { get; set; }

        public IKnowledgeCenterRepository KnowldegeCenters{ get; set; }

        public IContactRepository ContactUs { get; set; }

        public INewsRepository News { get; set; }

        public IAspNetUserRepository Users { get; set; }
        public ICompanyAttractRequestRepository CompanyAttractRequests { get; set; }

        public IReportRepository Report { get; set; }

        public IServiceRepository Service { get; set; }

        public SaudiceosEntities SaudiceosEntities { get; set; }

        public ICategoryRepository Category { get; set; }

        public UnitOfWork()
        {
            _context = new SaudiceosEntities();
            SaudiceosEntities = _context;
            CEOs = new CEORepository(_context);
            CEOAddEditRequests = new CEOAddEditRequestRepository(_context);
            CompanyAttractRequests = new CompanyAttractRequestRepository(_context);
            News = new NewsRepository(_context);
            Settings = new SettingsRepository(_context);
            Users = new AspNetUserRepository(_context);
            ContactUs = new ContactRepository(_context);
            KnowldegeCenters = new KnowledgeCenterRepository(_context);
            IndividualOpportunityDiscoveries = new IndividualOpportunityDiscoveryRepository(_context);
            Report = new ReportRepository(_context);
            Banners = new BannerRepository(_context);
            Service = new ServiceRepository(_context);
            Category = new CategoryRepository(_context);
        }
         
        public void Dispose()
        {
            _context.Dispose();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
