using Cigarette.Enterprise.BLL.ContactUsServ;
using Cigarette.Enterprise.ViewModels.ViewModels.ContactUs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Saudiceos.Enterprise.Web.Controllers
{
    [Route("{ctrl:regex(^Admin$)}")]
    public class HomeController : BaseController
    {
        private IContactUsService _contactUsRepository;
 
        public HomeController(IContactUsService contactUsRepository)
        {
            _contactUsRepository = contactUsRepository;
        }
        [Route("{a?}/{i?}")]
        public ActionResult Index()
        {
            return View("Privacy");
        }
    }
}