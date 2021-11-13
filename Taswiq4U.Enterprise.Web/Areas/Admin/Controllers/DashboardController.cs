
using Cigarette.Enterprise.BLL.BannerServ;
using Cigarette.Enterprise.BLL.CEOServ;
using Cigarette.Enterprise.BLL.NewsServ;
using Cigarette.Enterprise.BLL.ReportServ;
using Cigarette.Enterprise.BLL.ServiceServ;
using Cigarette.Enterprise.ViewModels.ViewModels.About;
using Cigarette.Enterprise.ViewModels.VM;
using Microsoft.AspNet.Identity;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Saudiceos.Enterprise.Web.Areas.AdminPanel.Controllers
{
    [Authorize()]
    [RouteArea("Admin")]
    [RoutePrefix("dashboard")] 
    public class DashboardController : Controller
    {
        private ICEOService _cEOSerivce;
        private IBannerService _bannerService;
        private INewsService _newsService;
        private IReportService _reportService;
        private IServiceService _serviceService;
        private ILogger _logger = Log.Logger;

        public DashboardController(ICEOService cEOService,
            IBannerService bannerService, 
            INewsService newsService,
            IReportService reportService,
            IServiceService serviceService)
        {
            _cEOSerivce = cEOService;
            _bannerService = bannerService;
            _newsService = newsService;
            _reportService = reportService;
            _serviceService = serviceService;
        }
        [Route("details")]
        public ActionResult Index()
        {
            _logger.Debug("Dashboard Called..");
            var dashboardStats = new DashboardStat
            {
                CEOCount = _cEOSerivce.GetAllCeosCount(),
                BannerCount = _bannerService.GetAllCount(),
                NewsCount = _newsService.GetAllCount(),
                ReportsCount = _reportService.GetAllCount(),
                ServiceCount = _serviceService.GetAllCount()
            };

            return View("Dashboard", dashboardStats); 
        }
          
    }
}