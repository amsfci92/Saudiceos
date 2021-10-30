//using AutoMapper;
//using Cigarette.Enterprise.BLL.AdvertisementImageServ;
//using Cigarette.Enterprise.BLL.AdvertisementServ;
//using Cigarette.Enterprise.BLL.Category_SpecificationServ;
//using Cigarette.Enterprise.BLL.CategoryServ;
//using Cigarette.Enterprise.BLL.CityServ;
//using Cigarette.Enterprise.BLL.CommercialAdServ;
//using Cigarette.Enterprise.BLL.CommercialAdsUserServ;
//using Cigarette.Enterprise.BLL.CountryServ;
//using Cigarette.Enterprise.BLL.FavoriteServ;
//using Cigarette.Enterprise.BLL.FeaturedAdvertisementServ;
//using Cigarette.Enterprise.BLL.StateServ;
//using Cigarette.Enterprise.DAL;
//using Cigarette.Enterprise.DAL.Repository.CountryRep;
//using Cigarette.Enterprise.DAL.UserInfoServ;
//using Cigarette.Enterprise.ResourceManager.Helpers;
//using Cigarette.Enterprise.ViewModels.BindingModels.Advertisement;
//using Cigarette.Enterprise.ViewModels.BindingModels.Advertisement_SpecificationAttribute;
//using Cigarette.Enterprise.ViewModels.BindingModels.UserInfo;
//using Cigarette.Enterprise.ViewModels.Pagination;
//using Cigarette.Enterprise.ViewModels.ViewModels.AdminViewModels.City;
//using Cigarette.Enterprise.ViewModels.ViewModels.AdminViewModels.Country;
//using Cigarette.Enterprise.ViewModels.ViewModels.Advertisement;
//using Cigarette.Enterprise.ViewModels.ViewModels.AdvertismentImage;
//using Cigarette.Enterprise.ViewModels.ViewModels.Category;
//using Cigarette.Enterprise.ViewModels.ViewModels.Category_SpecificationAttribute;
//using Cigarette.Enterprise.ViewModels.ViewModels.City;
//using Cigarette.Enterprise.ViewModels.ViewModels.CommercialAd;
//using Cigarette.Enterprise.ViewModels.ViewModels.Generic;
//using Cigarette.Enterprise.ViewModels.ViewModels.SpecificationAttributeOption;
//using Cigarette.Enterprise.ViewModels.ViewModels.WepAPIViewModel;
//using Cigarette.Enterprise.ViewModels.ViewModels.WepAPIViewModel.Advertisement;
//using Microsoft.Ajax.Utilities;
//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.Owin;
//using Newtonsoft.Json;
//using OperationManager.GeoLocation;
//using PagedList;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Web;
//using System.Web.Mvc;
//using Saudiceos.Enterprise.Web.Attributes;
//using Saudiceos.Enterprise.Web.helper;

//namespace Saudiceos.Enterprise.Web.Controllers
//{
//    [CountryFilter]
//    public class AdvertisementController : BaseController
//    {

//        #region Fields

//        private IAdvertisementServices _advertisementServices;
//        private ICategoryServices _categoryServices;
//        private ICategory_SpecificationServices _category_SpecificationAttributeServices;
//        private PaginationExtention _paginationExtention;
//        private ICityServices _cityServices;
//        private IStateService _stateService;
//        private IFavoriteService _favoriteService;
//        private ApplicationUserManager _userManager;
//        private IUserInfoService _userInfoService;
//        private ICountryService _countryService;
//        private IAdvertisementImageServices _advertisementImageServices;
//        private ICommercialAdService _commercialAdService;
//        private ICommercialAdsUserService _commercialAdsUserService;
//        private IFeaturedAdvertisementService _featuredAdvertisementService;

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
//        #endregion



//        #region ctor

//        public AdvertisementController(IAdvertisementServices advertisementServices,
//            ICategoryServices categoryServices,
//            ICategory_SpecificationServices category_SpecificationAttributeServices,
//            IStateService stateService,
//            ICityServices cityServices,
//            //ApplicationUserManager userManager,
//            IUserInfoService userInfoService,
//            IFavoriteService favoriteService,
//            ICountryService countryService,
//            IAdvertisementImageServices advertisementImageServices,
//            ICommercialAdService commercialAdService,
//            ICommercialAdsUserService commercialAdsUserService,
//            IFeaturedAdvertisementService featuredAdvertisementService)
//        {
//            _advertisementServices = advertisementServices;
//            _categoryServices = categoryServices;
//            _category_SpecificationAttributeServices = category_SpecificationAttributeServices;
//            _cityServices = cityServices;
//            _stateService = stateService;
//            _paginationExtention = new PaginationExtention();
//            _favoriteService = favoriteService;
//            //UserManager = userManager;
//            _userInfoService = userInfoService;
//            _countryService = countryService;
//            _advertisementImageServices = advertisementImageServices;
//            _commercialAdService = commercialAdService;
//            _commercialAdsUserService = commercialAdsUserService;
//            _featuredAdvertisementService = featuredAdvertisementService;
//        }

//        #endregion


//        #region helper
//        private CountryListItemViewModel CurrentCountryId()
//        {
//            string countery = "EG";
//            var cookieCountry = HttpContext.Request.Cookies["Country"];

//            if (cookieCountry != null && !string.IsNullOrWhiteSpace(cookieCountry.Value))
//            {
//                countery = cookieCountry.Value;
//            }

//            var countrFound = _countryService.GetCountryByAbbr(countery.ToLower(), false);


//            if (countrFound == null)
//            {
//                countrFound = _countryService.GetCountryByAbbr(countery.ToLower(), false);

//                if (countrFound == null)
//                    return null;
//            }
//            return countrFound;
//        }


//        private Advertisement PrepareAdForSearch(data model)
//        {
//            if (model == null)
//            {
//                return null;
//            }

//            if (model.array == null)
//            {
//                return null;
//            }

//            AdvertisementBindingModel adv = new AdvertisementBindingModel();

//            List<Advertisement_SpecificationAttributeBindingModel> advertisment_SpecificationAttributes =
//                new List<Advertisement_SpecificationAttributeBindingModel>();



//            for (int i = 0; i < model.array.Length; i++)
//            {

//                try
//                {
//                    string value = model.array[i].Value;
//                    string type = model.array[i].IdAndType.Split(',')[0];
//                    string property_ID = model.array[i].IdAndType.Split(',')[1];
//                    if (string.IsNullOrWhiteSpace(value) || string.IsNullOrWhiteSpace(type) || string.IsNullOrWhiteSpace(property_ID))
//                        continue;
//                    else if (type == "textBox")
//                    {
//                        advertisment_SpecificationAttributes.Add(new Advertisement_SpecificationAttributeBindingModel()
//                        {
//                            CategorySpecificationId = int.Parse(property_ID),
//                            CustomValue = value
//                        });
//                    }
//                    else if (type == "selectedList")
//                    {
//                        advertisment_SpecificationAttributes.Add(new Advertisement_SpecificationAttributeBindingModel()
//                        {
//                            CategorySpecificationId = int.Parse(property_ID),
//                            Options = new List<AdvertisementSpecificationAttributeOptionBindingViewModel>() {
//                                    new AdvertisementSpecificationAttributeOptionBindingViewModel(){
//                                        SpecificationOptionId=int.Parse(value)
//                                    }
//                                }
//                        });
//                    }
//                    else if (type == "checkBox")
//                    {
//                        advertisment_SpecificationAttributes.Add(new Advertisement_SpecificationAttributeBindingModel()
//                        {
//                            CategorySpecificationId = int.Parse(property_ID),
//                            Options = new List<AdvertisementSpecificationAttributeOptionBindingViewModel>() {
//                                    new AdvertisementSpecificationAttributeOptionBindingViewModel(){
//                                        SpecificationOptionId=int.Parse(value)
//                                    }
//                                }
//                        });
//                    }
//                    else if (type == "radioButton")
//                    {
//                        advertisment_SpecificationAttributes.Add(new Advertisement_SpecificationAttributeBindingModel()
//                        {
//                            CategorySpecificationId = int.Parse(property_ID),
//                            Options = new List<AdvertisementSpecificationAttributeOptionBindingViewModel>() {
//                                    new AdvertisementSpecificationAttributeOptionBindingViewModel(){
//                                        SpecificationOptionId=int.Parse(value)
//                                    }
//                                }
//                        });
//                    }


//                }
//                catch { }

//            }

//            var res = advertisment_SpecificationAttributes.DistinctBy(m => m.CategorySpecificationId);

//            foreach (var item in res)
//            {
//                var result = advertisment_SpecificationAttributes.Where(m => m.CategorySpecificationId == item.CategorySpecificationId);
//                adv.Advertisment_SpecificationAttributes.Add(new Advertisement_SpecificationAttributeBindingModel
//                {
//                    CategorySpecificationId = item.CategorySpecificationId,
//                    Options = result.SelectMany(m => m.Options).ToList()
//                }); ;
//            }
//            //adv.Advertisment_SpecificationAttributes = advertisment_SpecificationAttributes;
//            var temp = Mapper.Map<Advertisement>(adv);

//            return temp;
//        }


//        #endregion

//        #region methods

//        [HttpGet]
//        public ActionResult Index(PagingParams pagingParams)
//        {
//            var countryDetails = CurrentCountryId();

//            if (countryDetails == null)
//                return HttpNotFound();

//            var dbModel = _advertisementServices.LastAds(countryDetails.CountryId, pagingParams).ToList();
//            var mappedModel = dbModel.Select(a => Mapper.Map<AdvertisementListVM>(a));
//            var checkFavModel = IsFavourite(mappedModel.ToList());
//            //var outputModel = checkFavModel.ToPagedList(pagingParams.Page, pagingParams.Size);

//            var inBetween = _commercialAdService.GetInBetweenCommercialAdsByCountry(countryDetails.CountryId, 0);

//            var commercialInBetweenAds = IsLiked(inBetween);

//            var combineAdsWithComs = CombineAdsWithCommercial(checkFavModel, commercialInBetweenAds);

//            var outputModel = combineAdsWithComs.ToPagedList(pagingParams.Page, pagingParams.Size);

//            //var featuredAd = _advertisementServices.FeaturedAdvertisement(countryDetails.CountryId);
//            var featuredAd = _advertisementServices.LessViewedFeaturedAdvertisement(countryDetails.CountryId);

//            var mappedFavourotes = featuredAd.Select(a => Mapper.Map<AdvertisementListVM>(a));
//            ViewBag.FeaturedAdvertisement = IsFeatured(mappedFavourotes.ToList());

//            var categoriesWithSub = _categoryServices.GetActiveMainCategoriesForCountryWithSub(countryDetails.CountryId);
//            var categoriesModelWithSub = categoriesWithSub.Select(c => Mapper.Map<CategoryWithSubViewModel>(c)).ToList();
//            ViewBag.CategoriesWithSub = categoriesModelWithSub;

//            var citiesWithStates = _cityServices.GetCitiesWithCountry();
//            ViewBag.CitiesWithStates = new SelectList(citiesWithStates.Select(c => Mapper.Map<CityWithStatesViewModel>(c)), "Id", "Name");
//            ViewBag.Country = countryDetails.Abbr;
//            ViewBag.CountryDetails = countryDetails;
//            ViewBag.Language = language;
//            ViewBag.CommercialSliderAds = _commercialAdService.GetCommercialAdsByCountryMainSlider(countryDetails.CountryId);
//            if (User.Identity.IsAuthenticated)
//            {
//                ViewBag.haseFreeAds = UserManager.FindById(User.Identity.GetUserId()).FreeAdCount > 0 ? true : false;
//            }
//            return View(outputModel);
//        }

//        public async Task<ActionResult> Details(int id, string slug)
//        {
//            var ad = _advertisementServices.GetAdvertisementDetailsById(id);

//            var model = ad.Select(a => Mapper.Map<AdvertisementDetailsViewModel>(a)).ToList();
//            var countryDetails = CurrentCountryId();
//            ViewBag.CountryDetails = countryDetails;

//            ViewBag.Country = country;
//            ViewBag.Language = language;
//            // get the images for the Ad
//            List<AdvertismentImageBM> images = _advertisementImageServices.GetAdvertismentImage((long)id);
//            ViewBag.AdImages = images ?? new List<AdvertismentImageBM>();

//            if (User.Identity.IsAuthenticated)
//            {
//                ViewBag.IsLogin = true;

//                ViewBag.IsFav = await _favoriteService.IsFavoriteAsync(User.Identity.GetUserId(), id);

//                ViewBag.IsOwner = _advertisementServices.IsAdOwner(id, User.Identity.GetUserId());

//                ViewBag.IsFeatured = _featuredAdvertisementService.IsFeaturedAd(id);
//            }
//            else
//            {
//                ViewBag.IsOwner = false;
//                ViewBag.IsFav = false;
//                ViewBag.IsLogin = false;
//                ViewBag.IsFeatured = _featuredAdvertisementService.IsFeaturedAd(id);
//            }

//            ViewBag.AdId = id;
//            if (model != null && model.Count() > 0)
//            {
//                if (string.IsNullOrEmpty(slug))
//                    return RedirectToRoute("Details", new { id = id, slug = model.First().AdvertisementTitle.Replace(".", "").Replace(' ', '-').Replace('/', '-').Replace('$', '-').Replace('#', '-') });



//                return View(model);
//            }
//            else
//            {
//                return HttpNotFound();
//            }
//        }


//        [ChildActionOnly]
//        [HttpGet]
//        public ActionResult Searchproduct()
//        {
//            var countryDetails = CurrentCountryId(); if (countryDetails == null) return HttpNotFound();

//            var categories = _categoryServices.GetActiveMainCategoriesForCountry(countryDetails.CountryId);
//            var categoriesModel = categories.Select(c => Mapper.Map<CategoryViewModel>(c));
//            ViewBag.Categories = categoriesModel;

//            var cities = _cityServices.GetCountryCities(countryDetails.CountryId);
//            ViewBag.Cities = cities;
//            ViewBag.CountryDetails = countryDetails;
//            return PartialView();
//        }

//        [HttpGet]
//        public ActionResult GetSearchCategory(int categoryId)
//        {
//            var countryDetails = CurrentCountryId(); if (countryDetails == null) return HttpNotFound();
//            var selectedCategory = _categoryServices.GetSearchCategoryById(categoryId);

//            ViewBag.Country = countryDetails;
//            ViewBag.CountryDetails = countryDetails;
//            ViewBag.Language = language;
//            return PartialView(Mapper.Map<List<CategoryViewModel>>(selectedCategory));
//        }

//        [HttpGet]
//        public ActionResult Search(int? CityId, string City, int? CategoryId, string Category, string Term,
//            PagingParams pagingParams)
//        {
//            var countryDetails = CurrentCountryId();
//            if (countryDetails == null) return HttpNotFound();

//            var categories = _categoryServices.GetActiveMainCategoriesForCountry(countryDetails.CountryId);
//            var selectedCategory = _categoryServices.GetSearchCategoryById(CategoryId ?? 0);
//            var categoriesModel = categories.Select(c => Mapper.Map<CategoryViewModel>(c));
//            if (CategoryId.HasValue)
//            {
//                ViewBag.CategoryId = CategoryId.Value;
//                ViewBag.Category = Category;
//                ViewBag.CategoriesSelected = new SelectList(categoriesModel, "Id", "Name", CategoryId.Value);
//                ViewBag.CategorySeries = Mapper.Map<List<CategoryViewModel>>(selectedCategory);
//            }
//            else
//            {
//                ViewBag.CategoryId = null;
//                ViewBag.CategoriesList = categoriesModel;
//            }
//            //_commercialAdService.GetCommercialAdsByCountryInBetween(countryDetails.CountryId,0)

//            if (selectedCategory != null && selectedCategory.Count() > 0 && selectedCategory.FirstOrDefault().HasHorizontalMenu == true)
//            {
//                ViewBag.HorizontalMenu = _categoryServices.GetSubCategories(selectedCategory.FirstOrDefault().Id, true);
//            }

//            var cities = _cityServices.GetCountryCities(countryDetails.CountryId);
//            if (CityId.HasValue)
//            {
//                ViewBag.CityId = CityId.Value;
//                ViewBag.City = City;
//                ViewBag.CitiesSelected = new SelectList(cities, "Id", "Name", CityId.Value);
//            }
//            else
//            {
//                ViewBag.CityId = null;
//                ViewBag.City = null;
//                ViewBag.CitiesList = cities;
//            }

//            if (!string.IsNullOrWhiteSpace(Term))
//                ViewBag.Term = Term;
//            else
//                ViewBag.Term = null;
//            ViewBag.CountryDetails = countryDetails;
//            ViewBag.InputData = ".open-cat-modal";

//            var dbModel = _advertisementServices.KeySearchWithCatWithCity(Term, countryDetails.CountryId, CategoryId, 0, CityId, pagingParams, OrderBy.Newest).ToList();

//            var mappedModel = dbModel.Select(a => Mapper.Map<AdvertisementListVM>(a));
//            var checkFavModel = IsFavourite(mappedModel.ToList());
//            var outputModel = checkFavModel.ToPagedList(pagingParams.Page, pagingParams.Size);
//            return View(outputModel);
//        }



//        [HttpGet]
//        public ActionResult SearchResult(int? CityId, string City, int? CategoryId, int? Level, string Category, string Term, PagingParams pagingParams)
//        {
//            var countryDetails = CurrentCountryId(); if (countryDetails == null) return HttpNotFound();

//            var dbModel = _advertisementServices.KeySearchWithCatWithCity(Term, countryDetails.CountryId, CategoryId, Level, CityId, pagingParams, OrderBy.Newest);

//            var mappedModel = dbModel.Select(a => Mapper.Map<AdvertisementListVM>(a));
//            var checkFavModel = IsFavourite(mappedModel.ToList());
//            var outputModel = checkFavModel.ToPagedList(pagingParams.Page, pagingParams.Size);

//            ViewBag.CategoryId = CategoryId;
//            ViewBag.Category = Category;

//            ViewBag.CityId = CityId;
//            ViewBag.City = City;

//            ViewBag.Term = Term;
//            ViewBag.CountryDetails = countryDetails;
//            //ViewBag.Country = country;
//            //ViewBag.Language = language;

//            return PartialView("_SearchResultAdvertisementsList", outputModel);

//        }


//        [HttpPost]
//        public ActionResult SearchAdv(int? CityId, string City, int? CategoryId, string Category, string Term, int? Level, data modelSearch, PagingParams pagingParams)
//        {
//            var countryDetails = CurrentCountryId(); if (countryDetails == null) return HttpNotFound();

//            var categories = _categoryServices.GetActiveMainCategoriesForCountry(countryDetails.CountryId);
//            var categoriesModel = categories.Select(c => Mapper.Map<CategoryViewModel>(c));
//            if (CategoryId.HasValue)
//            {
//                ViewBag.CategoryId = CategoryId.Value;
//                ViewBag.CategoriesSelected = new SelectList(categoriesModel, "Id", "Name", CategoryId.Value);
//            }
//            else
//            {
//                ViewBag.CategoryId = null;
//                ViewBag.CategoriesList = categoriesModel;
//            }


//            var cities = _cityServices.GetCountryCities(countryDetails.CountryId);
//            if (CityId.HasValue)
//            {
//                ViewBag.CityId = CityId.Value;
//                ViewBag.City = City;
//                ViewBag.CitiesSelected = new SelectList(cities, "Id", "Name", CityId.Value);
//            }
//            else
//            {
//                ViewBag.CityId = null;
//                ViewBag.City = null;
//                ViewBag.CitiesList = cities;
//            }

//            if (!string.IsNullOrWhiteSpace(Term))
//                ViewBag.Term = Term;
//            else
//                ViewBag.Term = null;

//            ViewBag.Level = Level;

//            StringBuilder ur = new StringBuilder();
//            if (modelSearch != null && modelSearch.array != null)
//                for (int i = 0; i < modelSearch.array.Count(); i++)
//                {
//                    ur.Append(string.Format("{0}${1}$",
//                        modelSearch.array[i].IdAndType,
//                        modelSearch.array[i].Value));
//                }

//            ViewBag.arrayString = ur.ToString().Trim('$');

//            var model = _advertisementServices.KeySearchWithCatWithCityWithSp(Term,
//                countryDetails.CountryId, CategoryId, Level, CityId, OrderBy.Newest, pagingParams,
//                PrepareAdForSearch(modelSearch));
//            //Response.Headers.Add("X-Pagination", model.GetHeader().ToJson());

//            //var outputModel = new GenericOutputModel<AdvertisementListVM>
//            //{
//            //    Paging = model.GetHeader(),
//            //    Links = _paginationExtention.GetLinksForSearch(model, "SearchAdv", CityId, City, CategoryId, Category, Term),
//            //    LinksNumbers = _paginationExtention.GetLinksNumbersForSearch(model, "SearchAdv", CityId, City, CategoryId, Category, Term),
//            //    Items = model.List.Select(m => Mapper.Map<AdvertisementListVM>(m)).ToList(),
//            //};
//            var outputModel = model.ToPagedList(pagingParams.Page, pagingParams.Size);
//            ViewBag.Country = countryDetails.Abbr;
//            ViewBag.Language = language;
//            ViewBag.CountryDetails = countryDetails;
//            return PartialView("SearchAdv", outputModel);
//        }

//        [HttpPost]
//        public ActionResult SearchAdvWithCategoryAndSubCategory(int? CityId, string City, int? CategoryId, string Category, string Term, int? Level, data modelSearch, PagingParams pagingParams)
//        {
//            var countryDetails = CurrentCountryId(); if (countryDetails == null) return HttpNotFound();

//            var categories = _categoryServices.GetActiveMainCategoriesForCountry(countryDetails.CountryId);
//            var categoriesModel = categories.Select(c => Mapper.Map<CategoryViewModel>(c));
//            if (CategoryId.HasValue)
//            {
//                ViewBag.CategoryId = CategoryId.Value;
//                ViewBag.CategoriesSelected = new SelectList(categoriesModel, "Id", "Name", CategoryId.Value);
//            }
//            else
//            {
//                ViewBag.CategoryId = null;
//                ViewBag.CategoriesList = categoriesModel;
//            }


//            var cities = _cityServices.GetCountryCities(countryDetails.CountryId);
//            if (CityId.HasValue)
//            {
//                ViewBag.CityId = CityId.Value;
//                ViewBag.City = City;
//                ViewBag.CitiesSelected = new SelectList(cities, "Id", "Name", CityId.Value);
//            }
//            else
//            {
//                ViewBag.CityId = null;
//                ViewBag.City = null;
//                ViewBag.CitiesList = cities;
//            }

//            if (!string.IsNullOrWhiteSpace(Term))
//                ViewBag.Term = Term;
//            else
//                ViewBag.Term = null;

//            ViewBag.Level = Level;

//            StringBuilder ur = new StringBuilder();
//            if (modelSearch != null && modelSearch.array != null)
//                for (int i = 0; i < modelSearch.array.Count(); i++)
//                {
//                    ur.Append(string.Format("{0}${1}$",
//                        modelSearch.array[i].IdAndType,
//                        modelSearch.array[i].Value));
//                }

//            ViewBag.arrayString = ur.ToString().Trim('$');

//            var categoryWithItsSubCategories = new List<int>();
//            if (CategoryId != null && CategoryId.HasValue)
//            {
//                categoryWithItsSubCategories = _categoryServices.GetActiveSubCategoriesbyCatForCountry(countryDetails.CountryId, (int)CategoryId);
//            }

//            var model = _advertisementServices.KeySearchWithCatAndSubCatWithCityWithSp(Term,
//                countryDetails.CountryId, categoryWithItsSubCategories, Level, CityId, OrderBy.Newest, pagingParams,
//                PrepareAdForSearch(modelSearch)).ToList();

//            var inBetween = _commercialAdService.GetInBetweenCommercialAdsByCountry(countryDetails.CountryId, (int)CategoryId);

//            var commercialInbetween = IsLiked(inBetween);

//            var combineAdsWithComs = CombineAdsWithCommercial(model, commercialInbetween);

//            var outputModel = combineAdsWithComs.ToPagedList(pagingParams.Page, pagingParams.Size);

//            //var outputModel = model.ToPagedList(pagingParams.Page, pagingParams.Size);

//            ViewBag.Country = countryDetails.Abbr;
//            ViewBag.Language = language;
//            ViewBag.CountryDetails = countryDetails;

//            return PartialView("SearchAdvWithCategoryAndSubCategory", outputModel);
//        }


//        [HttpPost]
//        public ActionResult SearchAdvPagedList(int? CityId, string City, int? CategoryId, string Category, string Term, int? Level, string arrayString, PagingParams pagingParams)
//        {

//            var countryDetails = CurrentCountryId(); if (countryDetails == null) return HttpNotFound();

//            var categories = _categoryServices.GetActiveMainCategoriesForCountry(countryDetails.CountryId);
//            var categoriesModel = categories.Select(c => Mapper.Map<CategoryViewModel>(c));
//            if (CategoryId.HasValue)
//            {
//                ViewBag.CategoryId = CategoryId.Value;
//                ViewBag.CategoriesSelected = new SelectList(categoriesModel, "Id", "Name", CategoryId.Value);
//            }
//            else
//            {
//                ViewBag.CategoryId = null;
//                ViewBag.CategoriesList = categoriesModel;
//            }


//            var cities = _cityServices.GetCountryCities(countryDetails.CountryId);
//            if (CityId.HasValue)
//            {
//                ViewBag.CityId = CityId.Value;
//                ViewBag.City = City;
//                ViewBag.CitiesSelected = new SelectList(cities, "Id", "Name", CityId.Value);
//            }
//            else
//            {
//                ViewBag.CityId = null;
//                ViewBag.City = null;
//                ViewBag.CitiesList = cities;
//            }

//            if (!string.IsNullOrWhiteSpace(Term))
//                ViewBag.Term = Term;
//            else
//                ViewBag.Term = null;

//            ViewBag.Level = Level;

//            List<string> arrayofIdTypeAndValue = new List<string>();

//            if (!string.IsNullOrWhiteSpace(arrayString))
//                arrayofIdTypeAndValue = arrayString.Split('$').ToList();

//            List<obj> array = new List<obj>();


//            try
//            {
//                if (arrayofIdTypeAndValue != null)
//                    for (int i = 0; i < arrayofIdTypeAndValue.Count(); i += 2)
//                    {
//                        array.Add(new obj() { IdAndType = arrayofIdTypeAndValue[i], Value = arrayofIdTypeAndValue[i + 1] });
//                    }
//            }
//            catch
//            {
//                array = new List<obj>();
//                arrayString = "";
//            }

//            ViewBag.arrayString = arrayString;

//            var model = _advertisementServices.KeySearchWithCatWithCityWithSp(Term,
//                countryDetails.CountryId, CategoryId, Level, CityId, OrderBy.Newest, pagingParams,
//                PrepareAdForSearch(new data() { ImagesIds = null, array = array.ToArray() }));
//            //Response.Headers.Add("X-Pagination", model.GetHeader().ToJson());

//            //var outputModel = new GenericOutputModel<AdvertisementListVM>
//            //{
//            //    Paging = model.GetHeader(),
//            //    Links = _paginationExtention.GetLinksForSearch(model, "SearchAdv", CityId, City, CategoryId, Category, Term),
//            //    LinksNumbers = _paginationExtention.GetLinksNumbersForSearch(model, "SearchAdv", CityId, City, CategoryId, Category, Term),
//            //    Items = model.List.Select(m => Mapper.Map<AdvertisementListVM>(m)).ToList(),
//            //};
//            var outputModel = model.ToPagedList(pagingParams.Page, pagingParams.Size);
//            ViewBag.Country = countryDetails.Abbr;
//            ViewBag.Language = language;
//            ViewBag.CountryDetails = countryDetails;
//            return PartialView("SearchAdv", outputModel);
//        }

//        [HttpPost]
//        public ActionResult SearchAdvWithCatAndSubCatPagedList(int? CityId, string City, int? CategoryId, string Category, string Term, int? Level, string arrayString, PagingParams pagingParams)
//        {

//            var countryDetails = CurrentCountryId(); if (countryDetails == null) return HttpNotFound();

//            var categories = _categoryServices.GetActiveMainCategoriesForCountry(countryDetails.CountryId);
//            var categoriesModel = categories.Select(c => Mapper.Map<CategoryViewModel>(c));
//            if (CategoryId.HasValue)
//            {
//                ViewBag.CategoryId = CategoryId.Value;
//                ViewBag.CategoriesSelected = new SelectList(categoriesModel, "Id", "Name", CategoryId.Value);
//            }
//            else
//            {
//                ViewBag.CategoryId = null;
//                ViewBag.CategoriesList = categoriesModel;
//            }


//            var cities = _cityServices.GetCountryCities(countryDetails.CountryId);
//            if (CityId.HasValue)
//            {
//                ViewBag.CityId = CityId.Value;
//                ViewBag.City = City;
//                ViewBag.CitiesSelected = new SelectList(cities, "Id", "Name", CityId.Value);
//            }
//            else
//            {
//                ViewBag.CityId = null;
//                ViewBag.City = null;
//                ViewBag.CitiesList = cities;
//            }

//            if (!string.IsNullOrWhiteSpace(Term))
//                ViewBag.Term = Term;
//            else
//                ViewBag.Term = null;

//            ViewBag.Level = Level;

//            List<string> arrayofIdTypeAndValue = new List<string>();

//            if (!string.IsNullOrWhiteSpace(arrayString))
//                arrayofIdTypeAndValue = arrayString.Split('$').ToList();

//            List<obj> array = new List<obj>();


//            try
//            {
//                if (arrayofIdTypeAndValue != null)
//                    for (int i = 0; i < arrayofIdTypeAndValue.Count(); i += 2)
//                    {
//                        array.Add(new obj() { IdAndType = arrayofIdTypeAndValue[i], Value = arrayofIdTypeAndValue[i + 1] });
//                    }
//            }
//            catch
//            {
//                array = new List<obj>();
//                arrayString = "";
//            }

//            ViewBag.arrayString = arrayString;

//            var categoryWithItsSubCategories = new List<int>();
//            if (CategoryId != null && CategoryId.HasValue)
//            {
//                categoryWithItsSubCategories = _categoryServices.GetActiveSubCategoriesbyCatForCountry(countryDetails.CountryId, (int)CategoryId);
//            }

//            var model = _advertisementServices.KeySearchWithCatAndSubCatWithCityWithSp(Term,
//                countryDetails.CountryId, categoryWithItsSubCategories, Level, CityId, OrderBy.Newest, pagingParams,
//                PrepareAdForSearch(new data() { ImagesIds = null, array = array.ToArray() }));

//            var outputModel = model.ToPagedList(pagingParams.Page, pagingParams.Size);
//            ViewBag.Country = countryDetails.Abbr;
//            ViewBag.Language = language;
//            ViewBag.CountryDetails = countryDetails;
//            return PartialView("SearchAdvWithCategoryAndSubCategory", outputModel);
//        }


//        [ChildActionOnly]
//        public ActionResult FirstModelCategoryList()
//        {
//            var countryDetails = CurrentCountryId(); if (countryDetails == null) return HttpNotFound();

//            var categories = _categoryServices.GetActiveMainCategoriesForCountry(countryDetails.CountryId);
//            var categoriesModel = categories.Select(c => Mapper.Map<CategoryViewModel>(c)).ToList();
//            ViewBag.Categories = categoriesModel;
//            return PartialView();
//        }

//        public ActionResult SecondModelAdding(int id)
//        {
//            var countryDetails = CurrentCountryId(); if (countryDetails == null) return HttpNotFound();

//            ViewBag.SelectedCategory = id;
//            var categories = _categoryServices.GetActiveMainCategoriesForCountry(countryDetails.CountryId);
//            var categoriesModel = categories.Select(c => Mapper.Map<CategoryViewModel>(c)).ToList();
//            ViewBag.Categories = categoriesModel;

//            var secondCategories = _categoryServices.GetActiveSecondLevelCategoriesForCountry(countryDetails.CountryId, id);
//            var secondCategoriesModel = secondCategories.Select(c => Mapper.Map<CategoryViewModel>(c)).ToList();
//            ViewBag.SecondCategories = secondCategoriesModel;

//            return PartialView();
//        }

//        public ActionResult SecondListInMoelAdding(int id)
//        {
//            var countryDetails = CurrentCountryId(); if (countryDetails == null) return HttpNotFound();

//            var secondCategories = _categoryServices.GetActiveSecondLevelCategoriesForCountry(countryDetails.CountryId, id);
//            var secondCategoriesModel = secondCategories.Select(c => Mapper.Map<CategoryViewModel>(c)).ToList();
//            ViewBag.SecondCategories = secondCategoriesModel;

//            return PartialView();
//        }


//        public ActionResult ThirdListInModelAdding(int id)
//        {
//            var countryDetails = CurrentCountryId(); if (countryDetails == null) return HttpNotFound();

//            var thirdCategories = _categoryServices.GetActiveThirdLevelCategoriesForCountry(countryDetails.CountryId, id);
//            var thirdCategoriesModel = thirdCategories.Select(c => Mapper.Map<CategoryViewModel>(c)).ToList();
//            ViewBag.ThirdCategories = thirdCategoriesModel;

//            return PartialView();
//        }


//        public ActionResult CategoryList(bool jsEnabled = false)
//        {
//            var countryDetails = CurrentCountryId(); if (countryDetails == null) return HttpNotFound();

//            var categories = _categoryServices.GetActiveMainCategoriesForCountry(countryDetails.CountryId);
//            var categoriesModel = categories.Select(c => Mapper.Map<CategoryViewModel>(c)).ToList();
//            ViewBag.Categories = categoriesModel;
//            ViewBag.Country = countryDetails.Abbr;
//            ViewBag.Language = language;
//            ViewBag.JSEnabled = jsEnabled;
//            return PartialView();
//        }
//        public ActionResult CategoryListFooter()
//        {
//            var countryDetails = CurrentCountryId(); if (countryDetails == null) return HttpNotFound();

//            var categories = _categoryServices.GetActiveMainCategoriesForCountry(countryDetails.CountryId);
//            var categoriesModel = categories.Select(c => Mapper.Map<CategoryViewModel>(c)).ToList();
//            ViewBag.Categories = categoriesModel;
//            ViewBag.Country = countryDetails.Abbr;
//            ViewBag.Language = language;
//            return PartialView();
//        }


//        public ActionResult CategorySP(int id)
//        {
//            var cat_SP = _category_SpecificationAttributeServices.GetLastNodeCategorySpecification(id);
//            ViewBag.Country = country;
//            ViewBag.Language = language;
//            return View(cat_SP);
//        }
//        public ActionResult CategorySpecificationDetails(int id)
//        {
//            var cat_SP = _category_SpecificationAttributeServices.GetLastNodeCategorySpecification(id);
//            ViewBag.Country = country;
//            ViewBag.Language = language;
//            return View(cat_SP);
//        }
//        public ActionResult CategorySPForSearch(int id)
//        {
//            var cat_SP = _category_SpecificationAttributeServices.GetLastNodeCategorySpecification(id);
//            ViewBag.Country = country;
//            ViewBag.Language = language;
//            return PartialView(cat_SP);
//        }

//        public ActionResult CityStates(int cityId)
//        {
//            var model = _stateService.GetStatesWithCity(cityId);
//            ViewBag.Country = country;
//            ViewBag.Language = language;
//            return PartialView(model);
//        }

//        [HttpGet]
//        public ActionResult QuickView(int id)
//        {
//            var ad = _advertisementServices.GetAdvertisementDetailsById(id);
//            var countryDetails = CurrentCountryId();
//            var model = ad.Select(a => Mapper.Map<AdvertisementDetailsViewModel>(a)).ToList();
//            ViewBag.AdImages = _advertisementImageServices.GetAdvertismentImage((long)id);
//            ViewBag.CountryDetails = countryDetails;
//            ViewBag.Country = country;
//            ViewBag.Language = language;
//            return PartialView(model);
//        }

//        public ActionResult CategoriesWithSubcategories()
//        {
//            ViewBag.Country = country;
//            ViewBag.Language = language;
//            return PartialView();
//        }


//        [Authorize]
//        public async Task<ActionResult> Favorites(PagingParams pagingParams)
//        {
//            var userId = User.Identity.GetUserId();
//            var countryDetails = CurrentCountryId();
//            var dbModel = await _favoriteService.GetUSerFavoriteAdsAsyncQuer(userId);
//            var mappedModel = dbModel.ToList().Select(a => Mapper.Map<AdvertisementListVM>(a));
//            var checkFavModel = IsFavourite(mappedModel.ToList());
//            var outputModel = checkFavModel.ToPagedList(pagingParams.Page, pagingParams.Size);

//            ViewBag.Country = country;
//            ViewBag.Language = language;
//            ViewBag.CountryDetails = countryDetails;
//            return View(outputModel);
//        }

//        [Authorize]
//        [HttpPost]
//        public async Task<ActionResult> AddToFavorites(int addvertisementId)
//        {
//            var userId = User.Identity.GetUserId();
//            var isFav = await _favoriteService.AddToFavoriteAsync(userId, addvertisementId, true);
//            return Json(new { data = isFav });
//        }


//        [Authorize]
//        [HttpPost]
//        public async Task<ActionResult> AddAndRemoveFavorites(int addvertisementId)
//        {
//            var userId = User.Identity.GetUserId();
//            var isFav = await _favoriteService.AddToFavoriteAsync(userId, addvertisementId, false);
//            return Json(new { data = isFav });
//        }
//        [Authorize]
//        [HttpPost]
//        public async Task<ActionResult> IsFav(int id)
//        {
//            var userId = User.Identity.GetUserId();
//            var isFav = await _favoriteService.IsFavoriteAsync(userId, id);
//            return Json(new { data = isFav, JsonRequestBehavior.AllowGet });
//        }

//        [Authorize]
//        public ActionResult UserProfile(PagingParams pagingParams)
//        {
//            ViewBag.pagingParams = pagingParams;

//            var user = UserManager.FindByName(User.Identity.Name);
//            ViewBag.UserName = user.FirstName + " " + user.SecondName;

//            ViewBag.Phone = user.UserName;
//            var userInfo = _userInfoService.GetUSerInfo(user.Id);
//            ViewBag.Address = userInfo?.Address;

//            ViewBag.AdCount = _advertisementServices.GetUserAdCount(user.Id);
//            ViewBag.Country = country;
//            ViewBag.Language = language;
//            ViewBag.FreeAdsCount = userInfo.FreeAdCount;
//            return View();
//        }

//        [Authorize]
//        [ChildActionOnly]
//        public ActionResult UserProfileAdvertisement(PagingParams pagingParams)
//        {
//            var userId = User.Identity.GetUserId();
//            var model = _advertisementServices.GetAdvertisementsByUserIdQuer(userId, OrderBy.Newest).ToList();

//            var countryDetails = CurrentCountryId();

//            var mappedModel = model.Select(a => Mapper.Map<AdvertisementListVM>(a));

//            var checkedModel = IsFeatured(mappedModel.ToList());

//            var outputModel = checkedModel.ToPagedList(pagingParams.Page, pagingParams.Size);

//            ViewBag.Country = country;
//            ViewBag.Language = language;
//            ViewBag.CountryDetails = countryDetails;
//            return PartialView(outputModel);
//        }

//        [ChildActionOnly]
//        public ActionResult CountryCurrency(decimal price)
//        {
//            var countryDetails = CurrentCountryId();
//            ViewBag.Country = countryDetails;
//            ViewBag.Price = price;
//            return PartialView();
//        }

//        [Authorize]
//        public ActionResult DashSetting(PagingParams pagingParams)
//        {
//            ViewBag.pagingParams = pagingParams;
//            var userId = User.Identity.GetUserId();
//            ViewBag.FreeAdCount = _advertisementServices.GetFreeAdCount(userId);

//            var user = UserManager.FindByName(User.Identity.Name);

//            ViewBag.FirstName = user.FirstName;
//            ViewBag.SecondName = user.SecondName;

//            ViewBag.UserName = user.FirstName + " " + user.SecondName;
//            ViewBag.Country = country;
//            ViewBag.Language = language;
//            ViewBag.Phone = user.UserName;

//            ViewBag.Email = user.Email;

//            return View();
//        }


//        [Authorize]
//        [HttpPost]
//        public ActionResult ChangeUserData(UserDataBindingModel model)
//        {
//            if (!ModelState.IsValid)
//            {
//                return Json(new { data = false });
//            }
//            var user = _userInfoService.GetUserByUserId(User.Identity.GetUserId());

//            if (user == null)
//            {
//                return Json(new { data = false });
//            }

//            user.FirstName = model.FirstName;
//            //user.SecondName = model.SecondName;
//            //user.Phone = model.Phone;
//            //user.Email = model.Email;

//            int res = _userInfoService.Update(user);

//            return Json(new { data = true });
//        }

//        [Authorize]
//        [ChildActionOnly]
//        public ActionResult DashSettingAdvertisement(PagingParams pagingParams)
//        {
//            var userId = User.Identity.GetUserId();
//            var model = _advertisementServices.GetAdvertisementsByUserIdQuer(userId, OrderBy.Newest);
//            var countryDetails = CurrentCountryId();
//            //Response.Headers.Add("X-Pagination", model.GetHeader().ToJson());

//            //var outputModel = new GenericOutputModel<AdvertisementListVM>
//            //{
//            //    Paging = model.GetHeader(),
//            //    Links = _paginationExtention.GetLinks(model, "DashSetting"),
//            //    LinksNumbers = _paginationExtention.GetLinksNumbers(model, "DashSetting"),
//            //    Items = model.List.ToList()
//            //};

//            var outputModel = model.ToPagedList(pagingParams.Page, pagingParams.Size);


//            ViewBag.Country = country;
//            ViewBag.Language = language;
//            ViewBag.CountryDetails = countryDetails;
//            return PartialView(outputModel);
//        }


//        public ActionResult AddReply(int AdId)
//        {
//            ViewBag.AdId = AdId;

//            return View();
//        }


//        [Authorize]
//        [HttpPost]
//        public async Task<ActionResult> DeleteAd(int id)
//        {
//            if (!_advertisementServices.IsAdOwner(id, User.Identity.GetUserId()))
//                return Json(new { data = false });

//            await _advertisementServices.DeleteAd(id);

//            return Json(new { data = true });
//        }


//        [Authorize]
//        [HttpGet]
//        public ActionResult Edit(int id)
//        {
//            var countryDetails = CurrentCountryId(); if (countryDetails == null) return HttpNotFound();

//            var userId = User.Identity.GetUserId();

//            var user = _userInfoService.GetUSerInfo(userId);

//            var adDetails = _advertisementServices.GetAdvertisementById(id);

//            if (adDetails == null)
//                return HttpNotFound();

//            var selectedCategory = _categoryServices.GetSearchCategoryById(adDetails.CategoryId ?? 0);
//            var result = _advertisementServices.GetAdvertisementForEditById(id);
//            var adSpec = _category_SpecificationAttributeServices.GetCategorySpecificationsById(adDetails.CategoryId.Value, false);

//            for (int i = 0; i < adDetails.Advertisment_Specification.Count(); i++)
//                AssignCurrentSpec(adDetails, adSpec, i);

//            var categorySpecefications = _category_SpecificationAttributeServices
//                .GetCategorySpecificationsById(adDetails.CategoryId.Value);
//            //if (user.CountryId != countryDetails.CountryId)
//            //    return View("AddReplyNotAllowed");

//            ViewBag.CategorySeries = Mapper.Map<List<CategoryViewModel>>(selectedCategory);
//            ViewBag.AdSpDetails = adSpec;

//            //var categories = _categoryServices.GetAllCategoriesByCountryId(countryDetails.CountryId);
//            var categories = _categoryServices.GetActiveMainCategoriesForCountry(countryDetails.CountryId);
//            var categoriesModel = categories.Select(c => Mapper.Map<CategoryViewModel>(c));
//            ViewBag.Categories = categoriesModel;

//            var cities = _cityServices.GetCountryCities(countryDetails.CountryId);
//            ViewBag.Cities = cities;

//            ViewBag.Country = country;
//            ViewBag.Language = language;
//            return View("Add", result);
//        }



//        [Authorize]
//        [HttpPost]
//        public async Task<ActionResult> Add(data model)
//        {
//            var countryDetails = CurrentCountryId(); if (countryDetails == null) return HttpNotFound();

//            var userId = User.Identity.GetUserId();

//            var user = _userInfoService.GetUSerInfo(userId);

//            if (user.CountryId != countryDetails.CountryId)
//                return View("AddReplyNotAllowed");

//            if (model.array == null)
//            {
//                return Json(new { data = false });
//            }

//            AdvertisementBindingModel adv = new AdvertisementBindingModel();

//            List<Advertisement_SpecificationAttributeBindingModel> advertisment_SpecificationAttributes =
//                new List<Advertisement_SpecificationAttributeBindingModel>();

//            adv.UserId = User.Identity.GetUserId();
//            int cityId = 0;


//            for (int i = 0; i < model.array.Length; i++)
//            {
//                if (model.array[i].IdAndType == "cat3")
//                {
//                    int.TryParse(model.array[i].Value, out var number);
//                    adv.CategoryId = number;
//                }
//                else if (model.array[i].IdAndType == "city")
//                {
//                    int.TryParse(model.array[i].Value, out var ara);
//                    cityId = int.Parse(model.array[i].Value);
//                    adv.CityId = ara;
//                }
//                else if (string.Compare(model.array[i].IdAndType, "state", true) == 0)
//                {
//                    int.TryParse(model.array[i].Value, out var num);
//                    adv.StateId = num;
//                }
//                else if (model.array[i].IdAndType == "Tilte")
//                {
//                    adv.ArabicTitle = model.array[i].Value;
//                    adv.EnglishTitle = model.array[i].Value;
//                }
//                else if (model.array[i].IdAndType == "Price")
//                {
//                    adv.Price = decimal.Parse(model.array[i].Value);
//                }
//                else if (model.array[i].IdAndType == "Description")
//                {
//                    adv.ArabicDescription = model.array[i].Value;
//                    adv.EnglishDescription = model.array[i].Value;
//                }
//                else
//                {
//                    try
//                    {
//                        string value = model.array[i].Value;
//                        string type = model.array[i].IdAndType.Split(',')[0];
//                        string property_ID = model.array[i].IdAndType.Split(',')[1];
//                        if (type == "textBox")
//                        {
//                            advertisment_SpecificationAttributes.Add(new Advertisement_SpecificationAttributeBindingModel()
//                            {
//                                CategorySpecificationId = int.Parse(property_ID),
//                                CustomValue = value
//                            });
//                        }
//                        else if (type == "selectedList")
//                        {
//                            advertisment_SpecificationAttributes.Add(new Advertisement_SpecificationAttributeBindingModel()
//                            {
//                                CategorySpecificationId = int.Parse(property_ID),
//                                Options = new List<AdvertisementSpecificationAttributeOptionBindingViewModel>() {
//                                    new AdvertisementSpecificationAttributeOptionBindingViewModel(){
//                                        SpecificationOptionId=int.Parse(value)
//                                    }
//                                }
//                            });
//                        }
//                        else if (type == "checkBox")
//                        {
//                            advertisment_SpecificationAttributes.Add(new Advertisement_SpecificationAttributeBindingModel()
//                            {
//                                CategorySpecificationId = int.Parse(property_ID),
//                                Options = new List<AdvertisementSpecificationAttributeOptionBindingViewModel>() {
//                                    new AdvertisementSpecificationAttributeOptionBindingViewModel(){
//                                        SpecificationOptionId=int.Parse(value)
//                                    }
//                                }
//                            });
//                        }
//                        else if (type == "radioButton")
//                        {
//                            advertisment_SpecificationAttributes.Add(new Advertisement_SpecificationAttributeBindingModel()
//                            {
//                                CategorySpecificationId = int.Parse(property_ID),
//                                Options = new List<AdvertisementSpecificationAttributeOptionBindingViewModel>() {
//                                    new AdvertisementSpecificationAttributeOptionBindingViewModel(){
//                                        SpecificationOptionId=int.Parse(value)
//                                    }
//                                }
//                            });
//                        }


//                    }
//                    catch { }
//                }
//            }


//            adv.Advertisment_SpecificationAttributes = advertisment_SpecificationAttributes;
//            var temp = Mapper.Map<Advertisement>(adv);
//            temp.CountryId = await _cityServices.GetCountyIdByCityId(cityId);
//            var adId = _advertisementServices.Add(temp);
//            if (model.ImagesIds != null)
//                _advertisementImageServices.UpdateImagesForAdvertisment(model.ImagesIds.ToList(), adId);

//            ViewBag.Country = country;
//            ViewBag.Language = language;
//            return Json(new { data = true, AdId = adId });
//        }

//        [Authorize]
//        [HttpPost]
//        public ActionResult AddFeaturedAd(int adId)
//        {
//            if (adId != 0 && User.Identity.IsAuthenticated)
//            {
//                if (UserManager.FindById(User.Identity.GetUserId()).FreeAdCount >= 2)
//                {
//                    var result = _featuredAdvertisementService.AddFeaturedAdvertisment(adId);

//                    if (result == "Done")
//                    {
//                        _userInfoService.DeductTwoFreeAds(User.Identity.GetUserId());
//                    }

//                    return Json(new { result = result });
//                }
//                return Json(new { result = "NoBalance" });
//            }
//            return Json(new { result = "Failed" });
//        }

//        #endregion

//        #region Helpers
//        private void AssignCurrentSpec(AdvertisementVM ad, IEnumerable<CategorySpecificationVM> adSpec, int i)
//        {
//            var tempAdSpec = ad.Advertisment_Specification.ElementAt(i);

//            if (tempAdSpec.CustomValue != null)
//            {
//                var specAd = adSpec.FirstOrDefault(m => m.SpeceficationId == tempAdSpec.CategorySpecificationId);
//                specAd.Value = tempAdSpec.CustomValue;
//            }
//            else if (tempAdSpec.AdvertismentSpecificatioOptions.Count() > 0)
//                for (int j = 0; j < tempAdSpec.AdvertismentSpecificatioOptions.Count(); j++)
//                {
//                    var option = tempAdSpec.AdvertismentSpecificatioOptions.ElementAt(j);
//                    var specAd = adSpec.FirstOrDefault(m => m.Id == tempAdSpec.CategorySpecificationId);
//                    if (specAd != null)
//                    {
//                        var specAdOption = specAd.SpecificationOptions.FirstOrDefault(m => m.Id == option.SpecificationOptionId);

//                        if (specAdOption != null)
//                            specAdOption.IsSelected = true;
//                    }

//                }
//        }

//        private List<AdvertisementListVM> IsFavourite(List<AdvertisementListVM> model)
//        {
//            var userId = User.Identity.GetUserId();
//            if (userId != null)
//            {
//                var favourites = _favoriteService.GetUserFavouriteAdvertisments(userId);
//                foreach (var item in model)
//                {
//                    var isExist = favourites.Where(x => x == item.Id).Any();
//                    item.IsFavorite = isExist;
//                }
//                return model;
//            }

//            return model;
//        }

//        private List<CommercialAdVM> IsLiked(List<CommercialAdVM> model)
//        {
//            var userId = User.Identity.GetUserId();
//            if (userId != null)
//            {
//                var likedAds = _commercialAdsUserService.GetUserLikedAds(userId);

//                foreach (var item in model)
//                {
//                    var isExist = likedAds.Where(x => x.CommercialAdId == item.Id).Any();
//                    item.isLiked = isExist;
//                }

//                return model;
//            }

//            return model;
//        }

//        private List<AdvertisementListVM> IsFeatured(List<AdvertisementListVM> model)
//        {
//            var userId = User.Identity.GetUserId();
//            if (userId != null)
//            {
//                var featured = _featuredAdvertisementService.GetFeaturedAdvertisementsByUserId(userId);
//                foreach (var item in model)
//                {
//                    var isExist = featured.Where(x => x.AdvertismentId == item.Id && x.EndDate >= DateTime.Now).Any();
//                    item.IsFeatured = isExist;
//                }
//                return model;
//            }

//            return model;
//        }

//        //private List<AdsPagedtWithCommercialAdsListVM> CombineAdsWithCommercial(List<AdvertisementListVM> ads, List<CommercialAdVM> commercials)
//        //{

//        //    List<AdsPagedtWithCommercialAdsListVM> models = new List<AdsPagedtWithCommercialAdsListVM>();

//        //    int count = 0;int commercialIndex = 0;

//        //    foreach(var ad in ads)
//        //    {
//        //        count++;

//        //        var model = new AdsPagedtWithCommercialAdsListVM();

//        //        model.Advertisement = ad;

//        //        if (commercials.Count() > 0 && count != 1 &&count % 6 == 1 )
//        //        {
//        //            model.CommercialAd = commercials.Skip(commercialIndex).Take(1).FirstOrDefault();
//        //            model.isCommercial = true;
//        //            commercialIndex++;
//        //        }
//        //        models.Add(model);
//        //    }
//        //    return models;

//        //}

//        private List<AdsPagedtWithCommercialAdsListVM<A, C>> CombineAdsWithCommercial<A, C>(List<A> ads, List<C> commercials)
//        {

//            List<AdsPagedtWithCommercialAdsListVM<A, C>> models = new List<AdsPagedtWithCommercialAdsListVM<A, C>>();

//            int count = 0; int commercialIndex = 0;

//            foreach (var ad in ads)
//            {
//                count++;

//                var model = new AdsPagedtWithCommercialAdsListVM<A, C>();

//                model.Advertisement = ad;
//                models.Add(model);

//                if (commercials.Count() > 0 && count % 6 == 0)
//                {
//                    var modl = new AdsPagedtWithCommercialAdsListVM<A, C>();
//                    modl.CommercialAd = commercials.Skip(commercialIndex).Take(1).FirstOrDefault();
//                    modl.isCommercial = true;
//                    commercialIndex++;
//                    models.Add(modl);
//                }

//            }
//            return models;

//        }




//        #endregion
//    }


//    public class obj
//    {
//        public string IdAndType { get; set; }
//        public string Value { get; set; }
//    }
//    public class data
//    {
//        public int[] ImagesIds { get; set; }
//        public obj[] array { get; set; }

//    }

//}