//using AutoMapper; 
//using Cigarette.Enterprise.DAL.Repository;
//using Cigarette.Enterprise.Notifications;
//using Cigarette.Enterprise.ResourceManager.LanguagesResourceFiles;
//using Cigarette.Enterprise.ViewModels.BindingModels.UserInfo;
//using Cigarette.Enterprise.ViewModels.Pagination;
//using Cigarette.Enterprise.ViewModels.ViewModels.AdminViewModels.Country;
//using Cigarette.Enterprise.ViewModels.ViewModels.Advertisement;
//using Cigarette.Enterprise.ViewModels.ViewModels.Login;
//using Cigarette.Enterprise.ViewModels.ViewModels.Register;
//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.Owin;
//using Microsoft.Owin.Security;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text.RegularExpressions;
//using System.Threading.Tasks;
//using System.Web;
//using System.Web.Mvc;
//using Saudiceos.Enterprise.Web.helper;
//using Saudiceos.Enterprise.Web.Models;

//namespace Saudiceos.Enterprise.Web.Controllers
//{
//    public class ClientController : BaseController
//    {
//        private ApplicationSignInManager _signInManager;
//        private ApplicationUserManager _userManager; 

//        public ApplicationSignInManager SignInManager
//        {
//            get
//            {
//                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
//            }
//            private set
//            {
//                _signInManager = value;
//            }
//        }

//        public ApplicationUserManager UserManager
//        {
//            get
//            {
//                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
//            }
//            private set
//            {
//                _userManager = value;
//            }
//        }

//        #region Helper
//        private CountryListItemViewModel CurrentCountryId()
//        {
//            string countery = "EG";
//            var cookieCountry = HttpContext.Request.Cookies["Country"];

//            if (cookieCountry != null && !string.IsNullOrWhiteSpace(cookieCountry.Value))
//            {
//                countery = cookieCountry.Value;
//            }

//            var countrFound = _countryService.GetCountryByAbbr(countery.ToLower());


//            if (countrFound == null)
//            {
//                countrFound = _countryService.GetCountryByAbbr(countery.ToLower());

//                if (countrFound == null)
//                    return null;
//            }
//            return countrFound;
//        }
//        #endregion
//        public ClientController()
//        { 
//        }
//        public ClientController(ApplicationUserManager userManager,
//            ApplicationSignInManager signInManager)
//        {
//            UserManager = userManager;
//            SignInManager = signInManager; 
//        }

         

//        //ViewBag.LoginFailure = "معلومات الدخول غير صحيحة";
//        [HttpGet]
//        public ActionResult Register(string returnUrl, bool? LoginFailure)
//        { 
//            if (string.IsNullOrWhiteSpace(country))
//            {
//                return RedirectToRoute("Register", new { LoginFailure = LoginFailure});
//            }

//            ViewBag.ReturnUrl = returnUrl;
//            ViewBag.Country = country;
//            ViewBag.Countries = _countryService.GetCountries(false);
//            if (LoginFailure.HasValue && LoginFailure.Value == true)
//                ViewBag.LoginFailure =  language == "ar" ? "معلومات الدخول غير صحيحة" : "Login info not correct";
//            return View();
//        }

//        [HttpGet]
//        public async Task<ActionResult> VerifyPassword(string returnUrl, string phone)
//        { 
//            var countryDetails = _countryService.GetCountryByAbbr(country);

//            if (countryDetails == null)
//                return HttpNotFound();

//            if (!string.IsNullOrWhiteSpace(phone))
//            {
//                var user = await UserManager.FindByNameAsync(string.Format("{0}-{1}", countryDetails.CountryId, phone));

//                if (user == null || string.IsNullOrWhiteSpace(user.PasswordVerifyToken))
//                {
//                    return RedirectToLocal(string.Empty);
//                }

//                ViewBag.UserName = user.UserName; 

//            } 


//            ViewBag.ReturnUrl = returnUrl;
//            ViewBag.Country = country;
//            return View();


//        }

//        [HttpGet]
//        public async Task<ActionResult> VerifyPhone(string returnUrl, string phone, int t = 0)
//        {

//            var countryDetails = _countryService.GetCountryByAbbr(country);

//            if (countryDetails == null)
//                return HttpNotFound();

//            var user = await UserManager.FindByNameAsync(string.Format("{0}-{1}", countryDetails.CountryId, phone));
//            if (user == null)
//                return RedirectToLocal("");

//            if (string.IsNullOrWhiteSpace(user.PhoneVerifyToken) && user.PhoneNumberConfirmed == true)
//            {
//                return RedirectToLocal(string.Empty);
//            }

//            ViewBag.UserName = user.UserName;

//            ViewBag.ReturnUrl = returnUrl;
//            ViewBag.Country = country;
//            return View();


//        }

//        [HttpPost] 
//        public async Task<ActionResult> ResendVerifyCodeee(string returnUrl, string phone)
//        {
//            var countryDetails = CurrentCountryId();
//            if (countryDetails == null || string.IsNullOrWhiteSpace(phone))
//            {
//                return Json(new { status = false });
//            } 

//            var user = await UserManager.FindByNameAsync(phone);

//            if (user == null || (string.IsNullOrWhiteSpace(user.PhoneVerifyToken) && user.PhoneNumberConfirmed == true))
//            {
//                return Json(new { status = false });
//            }

//            var smsGateway = _smsGatewayService.GetSmsGatewayByCountryId(countryDetails.CountryId);

//            // set sms manager 
//            var smsManager = new SMSManager(smsGateway)
//                .GetRequest()
//                .Numbers(string.Format("{0}{1}", countryDetails.PhoneKey, user.Phone))
//                .Token(language.ToLower() == "ar" ? "كود تفعيل حساب تسويق فور يو " : "Saudiceos account activation code: ");
            
//            user.PhoneVerifyToken = smsManager.GetToken();
//            user.TokenExpiredDate = DateTime.Now.AddMinutes(4);

//            await UserManager.UpdateAsync(user);
//            smsManager.Send();
//            return Json(new { status = true });
//        }

//        [HttpPost] 
//        public async Task<ActionResult> VerifyPhonePost(string token, string un, string l = "ar")
//        {
//            var user = await UserManager.FindByNameAsync(un);

//            if (string.IsNullOrWhiteSpace(user.PhoneVerifyToken) && user.PhoneNumberConfirmed == true)
//            {
//                return Json(new { status = false });
//            }
//            if (user.TokenExpiredDate != null && user.TokenExpiredDate < DateTime.Now)
//            {
//                return Json(new { status = false });
//            }
//            if (user.PhoneVerifyToken == token)
//            {
//                user.PhoneNumberConfirmed = true;
//                user.IsActive = true;
//                user.PhoneVerifyToken = string.Empty;
//                var result = await UserManager.UpdateAsync(user);
//                TempData["SuccessMessage"] = l == "ar"? "تم تفعيل رقم هاتقك, سجل دخول الان" : "Your account has been activated, Login Now.";
//                return Json(new { status = true });
                
//            }else
//            {
//                return Json(new { status = false });
//            }
//        }

//        [HttpPost]
//        [AllowAnonymous]
//        [ValidateAntiForgeryToken]
//        public async Task<ActionResult> Login(LoginBM model, string returnUrl)
//        {
//            var countryId = 0;
//            if(User.Identity.IsAuthenticated)
//                return RedirectToLocal(string.Empty);


//            var countryDetails = _countryService.GetCountryByAbbr(country, false);

//            ViewBag.Country = country;
//            ViewBag.Countries = _countryService.GetCountries(false);

//            if (!ModelState.IsValid)
//            {
//                return RedirectToAction("Register" , new { country, language});          
//            }
//            if (string.IsNullOrWhiteSpace(country))
//            {
//                TempData["LoginMessage"] = string.IsNullOrWhiteSpace(language) && language == "ar" ?
//                        "اختر الدوله" : "Please choose country";
//                return RedirectToAction("Register", new { LoginFailure = true });
//            }
//            else
//            { 
//                if (countryDetails == null)
//                {
//                    TempData["LoginMessage"] = !string.IsNullOrWhiteSpace(language) && language == "ar" ? 
//                        "اختر الدوله" : "Please choose country";
//                    return RedirectToAction("Register", new { LoginFailure = true });
//                }
//                else
//                {
//                    countryId = countryDetails.CountryId;
//                }
//            }
//            var userData = UserManager.FindByName(string.Format("{0}-{1}", countryId, model.Phone));

//            if (userData != null && (userData.PhoneNumberConfirmed != true || userData.IsActive != true))
//            {
//                var userCountry = _countryService.GetCountryById(userData.CountryId);

//                var smsGateway = _smsGatewayService.GetSmsGatewayByCountryId(userCountry.CountryId);

//                // set sms manager 
//                var smsManager = new SMSManager(smsGateway)
//                    .GetRequest()
//                    .Numbers(string.Format("{0}{1}", userCountry.PhoneKey, model.Phone))
//                    .Token(language.ToLower() == "ar" ? "كود تفعيل حساب تسويق فور يو " : "Saudiceos account activation code: ");

//                userData.PhoneVerifyToken = smsManager.GetToken();
//                userData.TokenExpiredDate = DateTime.Now.AddMinutes(5);
//                await UserManager.UpdateAsync(userData);
//                smsManager.Send();
//                return RedirectToAction("VerifyPhone", "Client", new { returnUrl = returnUrl, phone = userData.Phone });

//            }

//            if (userData != null && userData.IsActive == false)
//            {
//                TempData["LoginMessage"] = language.ToLower() == "ar" ? "تاكد من الرقم او كلمه المرور" : "Make sure of the phone or password";                
                 
//                return RedirectToAction("Register");

//            }
//            else if (userData == null)
//            {

//                TempData["LoginMessage"] =language.ToLower() == "ar" ? "تاكد من الرقم او كلمه المرور" : "Make sure of the phone or password";
//                return RedirectToAction("Register");
//            }


//            bool remember = model.RememberMe;
//            // This doesn't count login failures towards account lockout
//            // To enable password failures to trigger account lockout, change to shouldLockout: true
//            var result = await SignInManager.PasswordSignInAsync(string.Format("{0}-{1}", countryId, model.Phone), model.Password, remember, shouldLockout: false);
//            switch (result)
//            {
//                case SignInStatus.Success:
//                    {
//                        var user = UserManager.FindByName(string.Format("{0}-{1}", countryId, model.Phone));
//                        var userCountry = _countryService.GetCountryById(user.CountryId);

//                        if (userCountry != null)
//                        {

//                            Response.Cookies.Remove("Country");  
//                            HttpCookie cookie = new HttpCookie("Country");
//                            cookie.Value = userCountry.Abbr.ToLower();
//                            Response.Cookies.Add(cookie);
//                            ViewBag.haseFreeAds = user.FreeAdCount > 0 ? true : false;
//                        }
//                        else
//                        {
//                            Response.Cookies.Remove("Country");

//                            HttpCookie cookie = new HttpCookie("Country");
//                            cookie.Value = country;
//                            Response.Cookies.Add(cookie);
//                        }
//                        if (User.IsInRole("CountryAdmin"))
//                        {
//                            return Redirect("/admin/dashboard/details");
//                        }
//                        return RedirectToLocal(returnUrl);
//                    }
//                case SignInStatus.LockedOut:
//                    return View("Lockout");
//                case SignInStatus.RequiresVerification:
//                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
//                case SignInStatus.Failure:
//                default:
//                    TempData["LoginMessage"] = language.ToLower() == "ar" ? "تاكد من الرقم او كلمه المرور" : "Make sure of the phone or password";
//                    ModelState.AddModelError("", language == "ar" ? "محاولة تسجيل غير ناجحه" : "Invalid login attempt.");
//                    return RedirectToAction("Register");
//            }

//        }
        
//        [HttpPost]
//        [AllowAnonymous]
//        [ValidateAntiForgeryToken]
//        [OutputCache(Location = System.Web.UI.OutputCacheLocation.None, NoStore = false)]
//        public async Task<ActionResult> Register(RegisterBM model, string returnUrl)
//        {
//            ViewBag.Countries = _countryService.GetCountries(false);
//            if (ModelState.IsValid)
//            {
               
//                ViewBag.Country = country;

//                var countryDetails = _countryService.GetCountryById(model.CountryId);

//                if (country != null)
//                {
//                    var regex = new Regex(countryDetails.phoneRGX);
//                    var match = regex.Match(model.Phone);
//                    if (!match.Success || match.Index != 0 || match.Length != model.Phone.Length)
//                    {
//                        ModelState.AddModelError("", RegisterResource.ResourceManager.GetString(countryDetails.phoneValidationMsg));
//                        return View(model);
//                    }

//                    var existingAccount = await UserManager.FindByNameAsync(string.Format("{0}-{1}", countryDetails.CountryId, model.Phone));
                    
//                    if (existingAccount != null)
//                    {
//                        ModelState.AddModelError("", language == "ar" ? model.Phone + " هذا الرقم موجود بالفعل " : "This number already exists " + model.Phone);
//                        return View(model);
//                    }
                    
//                    var smsGateway = _smsGatewayService.GetSmsGatewayByCountryId(model.CountryId);

//                    // set sms manager 
//                    var smsManager = new SMSManager(smsGateway)
//                        .GetRequest()
//                        .Numbers(string.Format("{0}{1}", countryDetails.PhoneKey, model.Phone))
//                        .Token(language.ToLower() == "ar"?"كود تفعيل حساب تسويق فور يو " : "Saudiceos account activation code: ");

//                    var user = new ApplicationUser()
//                    {
//                        UserName = string.Format("{0}-{1}", countryDetails.CountryId, model.Phone),
//                        PhoneNumber = model.Phone,
//                        FirstName = model.FirstName,
//                        SecondName = model.SecondName,
//                        Name = $"{model.FirstName} {model.SecondName}",
//                        Email = String.Format("e{0}@com.com", model.Phone),
//                        PhoneVerifyToken = smsManager.GetToken(),
//                        CreationTime = DateTime.Now,
//                        Phone = model.Phone,
//                        Type = 0,
//                        CanAddAds = false,
//                        EmailConfirmed = false,
//                        IsActive = false,
//                        MembershipType = false,
//                        PhoneNumberConfirmed = false,
//                        FreeAdCount = countryDetails.FreeAdCount,
//                        CountryId = countryDetails.CountryId
//                    };

//                    // Send Message 
//                    smsManager.Send();

//                    var result = await UserManager.CreateAsync(user, model.Password);
//                    if (result.Succeeded)
//                    {
//                        //await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

//                        // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
//                        // Send an email with this link
//                        // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
//                        // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
//                        // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");
                        
//                        if (countryDetails != null)
//                        {
//                            HttpCookie cookie = new HttpCookie("Country");
//                            cookie.Value = countryDetails.Abbr;
//                            Response.Cookies.Add(cookie);
//                        }
//                        else
//                        {
//                            HttpCookie cookie = new HttpCookie("Country");
//                            cookie.Value = "KW";
//                            Response.Cookies.Add(cookie);
//                        }
//                        return RedirectToAction("VerifyPhone", "Client", new { returnUrl = returnUrl, phone = user.Phone });
//                        //return RedirectToLocal(returnUrl);
//                    }
//                    AddErrors(result);
//                }
//            }
//            // If we got this far, something failed, redisplay form
//            return View(model);
//        }

//        private ActionResult RedirectToLocal(string returnUrl)
//        {
//            if (Url.IsLocalUrl(returnUrl))
//            {
//                return Redirect(returnUrl);
//            }
//            return RedirectToAction("Index", "Advertisement");
//        }

//        [Authorize]
//        [HttpPost]
//        public ActionResult ChangePassword(ChangePasswordBindingModel model)
//        {
//            var result = SignInManager.PasswordSignIn(User.Identity.Name, model.OldPassword, false, shouldLockout: false);
//            switch (result)
//            {
//                case SignInStatus.Success:
//                {
//                    var code = UserManager.GeneratePasswordResetToken(User.Identity.GetUserId());
//                    var res = UserManager.ResetPassword(User.Identity.GetUserId(), code, model.NewPassword);

//                    if (res.Succeeded)
//                        return Json(new { data = true });
//                    else
//                        return Json(new { data = false });
//                }
//            }

//            return Json(new { data = false });
//        }

//        [Authorize] 
//        public ActionResult LogOff()
//        {
//            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
//            return RedirectToAction("Index", "Advertisement");
//        }

//        [AllowAnonymous]
//        public ActionResult ForgetPassword()
//        {
//            ViewBag.Country = country;
//            ViewBag.Countries = _countryService.GetCountries(false);
//            return View(new ForgotPasswordVM());
//        }
//        [AllowAnonymous]
//        [HttpPost]
//        public async Task<ActionResult> ForgetPasswordPost(ForgotPasswordVM phoneModel)
//        {
//            var countryDetails = CurrentCountryId();

//            if (countryDetails != null)
//            {
//                if (!ModelState.IsValid)
//                {
//                    ViewBag.Message = language.ToLower() == "ar"? "هذا الرقم غير مسجل بالنظام" : "Phone Not Found";
//                    return View("ForgetPassword", phoneModel);
//                }
                
//                var smsGateway = _smsGatewayService.GetSmsGatewayByCountryId(countryDetails.CountryId);

//                // set sms manager  "406596"
//                var smsManager = new SMSManager(smsGateway)
//                    .GetRequest()
//                    .Numbers(string.Format("{0}{1}", countryDetails.PhoneKey, phoneModel.Phone))
//                    .Token(language.ToLower() == "ar" ? "كود اعاده ضبط كلمه السر لحساب تسويق فور يو " : "Saudiceos account Password Reset code: ");
//                var user = await UserManager.FindByNameAsync(string.Format("{0}-{1}", countryDetails.CountryId, phoneModel.Phone));
                
//                if(user == null)
//                {
//                    ViewBag.Message = language.ToLower() == "ar" ? "هذا الرقم غير مسجل بالنظام" : "Phone Not Found";
//                    return View("ForgetPassword", phoneModel); 
//                }
//                user.PasswordVerifyToken = smsManager.GetToken();
//                user.PasswordTokenExpiredDate = DateTime.Now.AddMinutes(5);
//                await UserManager.UpdateAsync(user);
//                smsManager.Send();
//                return RedirectToAction("VerifyPassword", "Client", new {   phone=user.PhoneNumber});
                 
//            }
//            else
//            {
//                return HttpNotFound();
//            }
          
//        }

//        [AllowAnonymous]
//        [HttpPost]
//        public async Task<ActionResult> ResetPassword(ResetPasswordVM resetPasswordVM)
//        {
//            var countryDetails = CurrentCountryId();
            
//            if (countryDetails == null)
//                return HttpNotFound();
              
//            var user = await UserManager.FindByNameAsync(string.Format("{0}", resetPasswordVM.Phone));

//            if (user == null)
//            {
//                ViewBag.Message = language.ToLower() == "ar" ? "هذا الرقم غير مسجل بالنظام" : "Phone Not Found"; 
//                return View("ResetPassword", resetPasswordVM);
//            }

//            if (user.PasswordVerifyToken != string.Empty)
//            {
//                ViewBag.Message = language.ToLower() == "ar" ? "لا يمكن اعاده تعيين كلمه المرور" : "Can't reset password";

//                return View("ResetPassword", resetPasswordVM); 
//            } 

//            ViewBag.Phone = resetPasswordVM.Phone;
//            return View("ResetPassword", resetPasswordVM);

//        }

//        [AllowAnonymous]
//        [HttpPost]
//        public async Task<ActionResult> ResetPasswordPost(ResetPasswordVM resetPasswordVM)
//        {
//            var countryDetails = CurrentCountryId();

//            if (countryDetails != null && ModelState.IsValid)
//            { 
//                var user = await UserManager.FindByNameAsync(string.Format("{0}",  resetPasswordVM.Phone));

//                if (user == null)
//                {

//                    ViewBag.Message = language.ToLower() == "ar" ? "هذا الرقم غير مسجل بالنظام" : "Phone Not Found";
//                    return View("ResetPassword", resetPasswordVM);

//                }
//                if (user.PasswordVerifyToken == "")
//                {
//                    // Use passwordHash to add new password
//                    user.PasswordHash = UserManager.PasswordHasher.HashPassword(resetPasswordVM.Password);

//                    //update user password
//                    var result = await UserManager.UpdateAsync(user);

//                    if (!result.Succeeded)
//                    {
//                        ViewBag.Message = language.ToLower() == "ar" ? "لا يمكن اعاده تعيين كلمه المرور" : "Can't reset password";
//                        return View("ResetPassword", resetPasswordVM);
//                    }
//                    if (result.Succeeded)
//                    {
//                        TempData["SuccessMessage"] = language.ToLower() == "ar" ? "تم اعاده تعيين كلمه المرور بنجاح" : "Password changed successfully";
//                    }

//                } 
                 
//                return RedirectToAction("Register", "Client");

//            }
//            else
//            {
//                return HttpNotFound();
//            }

//        }

//        [HttpGet]
//        public async Task<ActionResult> VerifyResetPassword( string phone)
//        {
//            var countryDetails = _countryService.GetCountryByAbbr(country);

//            if (countryDetails == null)
//                return HttpNotFound();

//            var user = await UserManager.FindByNameAsync(string.Format("{0}-{1}", countryDetails.CountryId, phone));


//            if (string.IsNullOrWhiteSpace(user.PasswordVerifyToken))
//            {
//                return RedirectToLocal(string.Empty);
//            }
             
             
//            ViewBag.Country = country;
//            ViewBag.UserName = user.UserName;

//            return View();
//        }

//        public async Task<ActionResult> VerifyForgetPasswordPost(string token, string phone)
//        { 
//            if( string.IsNullOrWhiteSpace(phone))
//                return Json(new { status = false });

//            var user = await UserManager.FindByNameAsync(phone);

//            if (user == null || string.IsNullOrWhiteSpace(user.PasswordVerifyToken) )
//            {
//                return Json(new { status = false });
//            }
//            if (user.PasswordTokenExpiredDate < DateTime.Now)
//            {
//                return Json(new { status = false });
//            }
//            if (user.PasswordVerifyToken == token)
//            { 
//                user.PasswordVerifyToken = string.Empty;
//                var result = await UserManager.UpdateAsync(user);

//                return Json(new { status = true });
//            }
//            else
//            {
//                return Json(new { status = false });
//            }
//        }
//        [HttpPost]
//        public async Task<ActionResult> ResendVerifyCode(string returnUrl, string phone, int t = 0)
//        {
//            var countryDetails = CurrentCountryId();
//            if (countryDetails == null || string.IsNullOrWhiteSpace(phone))
//            {
//                return Json(new { status = false });
//            }

//            var user = await UserManager.FindByNameAsync(phone);
//            if (t == 0)
//            {
//                if (user == null || (string.IsNullOrWhiteSpace(user.PhoneVerifyToken) && user.PhoneNumberConfirmed == true))
//                {
//                    return Json(new { status = false });
//                }
//            }
//            else
//            {
//                if (user == null || (string.IsNullOrWhiteSpace(user.PasswordVerifyToken) ))
//                {
//                    return Json(new { status = false });
//                }
//            }
           
//            var smsGateway = _smsGatewayService.GetSmsGatewayByCountryId(countryDetails.CountryId);

//            // set sms manager 
//            var smsManager = new SMSManager(smsGateway)
//                .GetRequest()
//                .Numbers(string.Format("{0}{1}", countryDetails.PhoneKey, user.Phone));
                   
//            if (t == 0)
//            {
//                smsManager.Token(language.ToLower() == "ar" ? "كود تفعيل حساب تسويق فور يو " : "Saudiceos account activation code: ");

//                user.PhoneVerifyToken = smsManager.GetToken();
//                user.TokenExpiredDate = DateTime.Now.AddMinutes(4);

//            } 
//            else if (t == 1)
//            {
//                smsManager.Token(language.ToLower() == "ar" ? "كود اعاده ضبط كلمه المرور حساب تسويق فور يو " : "Saudiceos account Password Reset code: ");

//                user.PasswordVerifyToken = smsManager.GetToken();
//                user.PasswordTokenExpiredDate = DateTime.Now.AddMinutes(4);

//            }

//            await UserManager.UpdateAsync(user);
//            smsManager.Send();
//            return Json(new { status = true });
//        }
         
//        [Authorize]
//        [ChildActionOnly]
//        public ActionResult UserFirstName()
//        {
//            var user = UserManager.FindByName(User.Identity.Name);
//            ViewBag.UserName = user.FirstName;
//            return PartialView();
//        }

//        private IAuthenticationManager AuthenticationManager
//        {
//            get
//            {
//                return HttpContext.GetOwinContext().Authentication;
//            }
//        }

//        private void AddErrors(IdentityResult result)
//        {
//            foreach (var error in result.Errors)
//            {
//                ModelState.AddModelError("", error);
//            }
//        }

    
//    }
//}