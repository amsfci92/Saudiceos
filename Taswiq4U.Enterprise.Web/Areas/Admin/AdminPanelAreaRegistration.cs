using System.Web.Mvc;

namespace Saudiceos.Enterprise.Web.Areas.AdminPanel
{
    public class AdminPanelAreaRegistration : AreaRegistration
    {
        public override string AreaName => "Admin";

        public override void RegisterArea(AreaRegistrationContext context)
        {
            ///
            /// Admin Category
         //   ///
         //   context.MapRoute(
         //       name: "Admin.Category.AddCategory",
         //       url: "Admin/Category/AddCat/{countryId}",
         //       defaults: new { controller = "Category", action = "AddCat", area = "Admin", countryId = UrlParameter.Optional }
         //       );

         //   context.MapRoute(
         //       name: "Admin.Category.EditCategory",
         //       url: "Admin/Category/EditCat/{CatId}",
         //       defaults: new { controller = "Category", action = "EditCat", area = "Admin", CatId = UrlParameter.Optional }
         //       );

         //   context.MapRoute(
         //       name: "Admin.Category.AddSubCategory",
         //       url: "Admin/Category/AddSubCat/{catId}",
         //       defaults: new { controller = "Category", action = "AddSubCat", area = "Admin", catId = UrlParameter.Optional }
         //       );

         //   context.MapRoute(
         //       name: "Admin.Category.EditSubCategory",
         //       url: "Admin/Category/EditSubCat/{catId}",
         //       defaults: new { controller = "Category", action = "EditSubCat", area = "Admin", catId = UrlParameter.Optional }
         //       );


         //   context.MapRoute(
         //       name: "Admin.Category.GetAllCategories",
         //       url: "Admin/Categories",
         //       defaults: new { controller = "Category", action = "GetAllCategories", area = "Admin" }
         //       );

         //   context.MapRoute(
         //       name: "Admin.Category.AllCategories",
         //       url: "Admin/Category/AllCategories",
         //       defaults: new { controller = "Category", action = "AllCategories", area = "Admin" }
         //       );

         //   context.MapRoute(
         //       name: "Admin.Category.CountryCategoriesList",
         //       url: "Admin/Category/List/{countryId}",
         //       defaults: new { controller = "Category", action = "CategoriesList", area = "Admin", countryId = UrlParameter.Optional }
         //   );

         //   context.MapRoute(
         //       name: "Admin.Category.AdminCategoriesList",
         //       url: "Admin/Country/Categories",
         //       defaults: new { controller = "Category", action = "AdminCategoriesList", area = "Admin" }
         //   );

         //   context.MapRoute(
         //      name: "Admin.Category.Details",
         //      url: "Admin/Category/{catId}",
         //      defaults: new { Controller = "Category", action = "CategoryDetails", Area = "Admin" });

         //   context.MapRoute(
         //       name: "Admin.Country.DeleteCategory",
         //       url: "Admin/Category/Delete/{catId}",
         //       defaults: new { controller = "Category", action = "Delete", area = "Admin", catId = UrlParameter.Optional }
         //       );

         //   context.MapRoute(
         //       name: "Admin.Country.UnDeleteCategory",
         //       url: "Admin/Category/UnDelete/{catId}",
         //       defaults: new { controller = "Category", action = "UnDelete", area = "Admin", catId = UrlParameter.Optional }
         //       );


         //   context.MapRoute(
         //       name: "Admin.Category.SubCategories",
         //       url: "Admin/Category/SubCategories/{catId}",
         //       defaults: new { controller = "Category", action = "SubCategories", area = "Admin", catId = UrlParameter.Optional }
         //   );
         //   ///
         //   /// Admin Country
         //   ///
         //   context.MapRoute(
         //       name: "Admin.Country.AddCountry",
         //       url: "Admin/Country/Add",
         //       defaults: new { controller = "Country", action = "AddCountry", area = "Admin" }
         //       );

         //   context.MapRoute(
         //       name: "Admin.Country.Edit",
         //       url: "Admin/Country/Edit/{id}",
         //       defaults: new { controller = "Country", action = "EditCountry", area = "Admin", id = UrlParameter.Optional }
         //       );


         //   context.MapRoute(
         //       name: "Admin.Country.CountriesList",
         //       url: "Admin/Countries",
         //       defaults: new { controller = "Country", action = "CountriesList", area = "Admin" }
         //       );

         //   context.MapRoute(
         //       name: "Admin.Country.CountryCity",
         //       url: "Admin/CountryCity/{countryId}",
         //       defaults: new { controller = "Country", action = "CountryCity", area = "Admin", countryId = UrlParameter.Optional }
         //       );

         //   context.MapRoute(
         //       name: "Admin.Country.AdminCountryCity",
         //       url: "Admin/Country/Cities",
         //       defaults: new { controller = "Country", action = "AdminCountryCity", area = "Admin" }
         //       );

         //   context.MapRoute(
         //       name: "Admin.Country.DeleteCountry",
         //       url: "Admin/Country/Delete/{countryId}",
         //       defaults: new { controller = "Country", action = "Delete", area = "Admin", countryId = UrlParameter.Optional }
         //       );

         //   context.MapRoute(
         //       name: "Admin.Specification.Added",
         //       url: "Admin/Specification/Added",
         //       defaults: new { Controller = "Specification", action = "AddSpecification", Area = "Admin" });

         //   context.MapRoute(
         //       name: "Admin.Specification.Edit",
         //       url: "Admin/Specification/Edit/{SpecId}",
         //       defaults: new { Controller = "Specification", action = "EditSpecification", Area = "Admin", SpecId = UrlParameter.Optional });


         //   context.MapRoute(
         //       name: "Admin.Specification.Add",
         //       url: "Admin/Specification/Add",
         //       defaults: new { Controller = "Specification", action = "AddSpecificationForm", Area = "Admin" });

         //   context.MapRoute(
         //       name: "Admin.Specification.Specifications.List",
         //       url: "Admin/Category/{catId}/Specifications",
         //       defaults: new { Controller = "Specification", action = "GetAllSpecification", Area = "Admin" });

         //   context.MapRoute(
         //     name: "Admin.Category.CategorySpecifications.List",
         //     url: "Admin/Category/{catId}/Specifications",
         //     defaults: new { Controller = "Specification", action = "GetAllCategorySpecification", Area = "Admin" });

         //   context.MapRoute(
         //       name: "Admin.Specification.DeleteCategorySpecification",
         //       url: "Admin/Specification/Delete/{SpecificationId}",
         //       defaults: new { controller = "Specification", action = "Delete", area = "Admin", SpecificationId = UrlParameter.Optional }
         //       );


         //   // User Roles
         //   context.MapRoute(
         //     name: "Admin.UserRoles.Add",
         //     url: "Admin/UserRoles/Add",
         //     defaults: new { Controller = "RoleManager", action = "AddUSerRoles", Area = "Admin" });

         //   // All USer Roles 
         //   context.MapRoute(
         //     name: "Admin.UserRoles.All",
         //     url: "Admin/UserRoles",
         //     defaults: new { Controller = "RoleManager", action = "UserRoles", Area = "Admin" });

         //   // All USer Roles 
         //   context.MapRoute(
         //     name: "Admin.UserRoles.Delete",
         //     url: "Admin/UserRoles/Delete/{roleId}",
         //     defaults: new { Controller = "RoleManager", action = "DeleteUserRoles", Area = "Admin" });


         //   // CategoryDetails
         //   context.MapRoute(
         //       name: "Admin.Country.CountryDetails",
         //       url: "Admin/Country/{countryId}",
         //       defaults: new
         //       {
         //           controller = "Country",
         //           action = "CountryDetails",
         //           area = "Admin",
         //           countryId = UrlParameter.Optional
         //       }
         //   );

         //   context.MapRoute(
         //       name: "Admin.Country.CountryAdmin",
         //       url: "Admin/CountryDetails",
         //       defaults: new
         //       {
         //           controller = "Country",
         //           action = "CountryAdmin",
         //           area = "Admin"
         //       }
         //   );

         //   /// CountryDetails
         //   /// Admin City 
         //   ///

         //   context.MapRoute(
         //       name: "Admin.City.CityDetails",
         //       url: "Admin/City/CityDetails/{cityId}",
         //       defaults: new { controller = "City", action = "CityDetails", area = "Admin", cityId = UrlParameter.Optional }
         //   );

         //   context.MapRoute(
         //       name: "Admin.City.CountryCitiesList",
         //       url: "Admin/City/List/{countryId}",
         //       defaults: new { controller = "City", action = "CountryCities", area = "Admin", countryId = UrlParameter.Optional }
         //   );

         //   context.MapRoute(
         //       name: "Admin.City.CityStates",
         //       url: "Admin/City/CityStates/{cityId}",
         //       defaults: new { controller = "City", action = "CityStates", area = "Admin", cityId = UrlParameter.Optional }
         //   );

         //   context.MapRoute(
         //       name: "Admin.City.EditCity",
         //       url: "Admin/City/Edit/{cityId}",
         //       defaults: new { controller = "City", action = "EditCity", area = "Admin", cityId = UrlParameter.Optional }
         //   );

         //   context.MapRoute(
         //       name: "Admin.City.DeleteCity",
         //       url: "Admin/City/Delete/{cityId}",
         //       defaults: new { controller = "City", action = "Delete", area = "Admin", cityId = UrlParameter.Optional }
         //   );

         //   context.MapRoute(
         //      name: "Admin.City.AllCountryCitiesList",
         //      url: "Admin/Cities",
         //      defaults: new { controller = "City", action = "AllCountryCities", area = "Admin" }
         //  );

         //   context.MapRoute(
         //       name: "Admin.City.AddCity",
         //       url: "Admin/City/Add/{countryId}",
         //       defaults: new { controller = "City", action = "AddCity", area = "Admin", countryId = UrlParameter.Optional }
         //   );
         //   /// admin bundle
         //   /// 


         //   context.MapRoute(
         //       name: "Admin.Bundle.AddBundle",
         //       url: "Admin/Bundle/AddBundle/{countryId}",
         //       defaults: new { controller = "Bundle", action = "AddBundle", area = "Admin", countryId = UrlParameter.Optional }
         //   );

         //   context.MapRoute(
         //       name: "Admin.Bundle.List",
         //       url: "Admin/Bundle/List",
         //       defaults: new { controller = "Bundle", action = "List", area = "Admin" }
         //   );

         //   context.MapRoute(
         //       name: "Admin.Bundle.CountryList",
         //       url: "Admin/Bundle/CountryList",
         //       defaults: new { controller = "Bundle", action = "CountryList", area = "Admin" }
         //   );

         //   context.MapRoute(
         //       name: "Admin.Bundle.CountryBundle",
         //       url: "Admin/Bundle/CountryBundle/{countryId}",
         //       defaults: new { controller = "Bundle", action = "CountryBundle", area = "Admin", countryId = UrlParameter.Optional }
         //   );


         //   context.MapRoute(
         //       name: "Admin.Bundle.ActivateBundle",
         //       url: "Admin/Bundle/Activate/{bundleId}",
         //       defaults: new { controller = "Bundle", action = "Activate", area = "Admin", bundleId = UrlParameter.Optional }
         //   );
         //   context.MapRoute(
         //       name: "Admin.Bundle.EditBundle",
         //       url: "Admin/Bundle/EditBundle/{bundleId}",
         //       defaults: new { controller = "Bundle", action = "EditBundle", area = "Admin", bundleId = UrlParameter.Optional }
         //   );

         //   context.MapRoute(
         //       name: "Admin.Bundle.DeactivateBundle",
         //       url: "Admin/Bundle/DeActivate/{bundleId}",
         //       defaults: new { controller = "Bundle", action = "DeActivate", area = "Admin", bundleId = UrlParameter.Optional }
         //   );

         //   /// Admin Users 
         //   ///
         //   context.MapRoute(
         //       name: "Admin.User.List",
         //       url: "Admin/User/List",
         //       defaults: new { controller = "User", action = "List", area = "Admin" }
         //   );

         //   context.MapRoute(
         //      name: "Admin.User.NewAdmin",
         //      url: "Admin/SystemAdmins/Add/{username}",
         //      defaults: new { controller = "User", action = "NewAdmin", area = "Admin", username = UrlParameter.Optional }
         //  );

         //   context.MapRoute(
         //      name: "Admin.User.NewCountryAdmin",
         //      url: "Admin/CountryAdmins/Add/{countryId}/{username}",
         //      defaults: new { controller = "User", action = "NewCountryAdmin", area = "Admin", countryId = UrlParameter.Optional, username = UrlParameter.Optional }
         //  );


         //   context.MapRoute(
         //     name: "Admin.User.AdminList",
         //     url: "Admin/SystemAdmins",
         //     defaults: new { controller = "User", action = "AdminList", area = "Admin" }
         // );


         //   context.MapRoute(
         //     name: "Admin.User.CountryUserList",
         //     url: "Admin/Users/CountryUsers",
         //     defaults: new { controller = "User", action = "CountryList", area = "Admin" }
         // );

         //   context.MapRoute(
         //    name: "Admin.User.CountryAdminList",
         //    url: "Admin/CountryAdmins",
         //    defaults: new { controller = "User", action = "CountryAdminList", area = "Admin" }
         //);

         //   context.MapRoute(
         //    name: "Admin.User.CountryAdmin",
         //    url: "Admin/CountryAdmin",
         //    defaults: new { controller = "User", action = "CountryAdmin", area = "Admin" }
         //);

         //   context.MapRoute(
         //      name: "Admin.User.CountryAdmins",
         //      url: "Admin/User/CountryAdmins/{countryId}",
         //      defaults: new { controller = "User", action = "GetCountryAdmins", area = "Admin", countryId = UrlParameter.Optional }
         //  );

         //   context.MapRoute(
         //       name: "Admin.User.CountryList",
         //       url: "Admin/User/CountryList/{country}",
         //       defaults: new { controller = "User", action = "CountryUsers", area = "Admin", country = UrlParameter.Optional }
         //   );

         //   context.MapRoute(
         //       name: "Admin.User.Activate",
         //       url: "Admin/User/Activate/{username}",
         //       defaults: new { controller = "User", action = "Activate", area = "Admin", username = UrlParameter.Optional }
         //   );

         //   context.MapRoute(
         //       name: "Admin.User.InActive",
         //       url: "Admin/User/InActive/{username}",
         //       defaults: new { controller = "User", action = "InActive", area = "Admin", username = UrlParameter.Optional }
         //   );

         //   context.MapRoute(
         //       name: "Admin.User.Details",
         //       url: "Admin/User/Details/{username}",
         //       defaults: new { controller = "User", action = "Details", area = "Admin", username = UrlParameter.Optional }
         //   );


         //   //sms gateway

         //   context.MapRoute(
         //       name: "Admin.Sms.Gatewaies",
         //       url: "Admin/Sms/Gateway",
         //       defaults: new { controller = "Sms", action = "Index", area = "Admin" }
         //   );

         //   context.MapRoute(
         //       name: "Admin.Sms.CountryGatewaies",
         //       url: "Admin/Sms/CountryGateway",
         //       defaults: new { controller = "Sms", action = "Country", area = "Admin" }
         //   );

         //   context.MapRoute(
         //       name: "Admin.Sms.Edit",
         //       url: "Admin/Sms/Edit/{countryId}",
         //       defaults: new { controller = "Sms", action = "Edit", area = "Admin", countryId = UrlParameter.Optional }
         //   );

         //   context.MapRoute(
         //       name: "Admin.Sms.CountryGateway",
         //       url: "Admin/Sms/CountryGateway/{countryId}",
         //       defaults: new { controller = "Sms", action = "GetCountrySmsGateway", area = "Admin", countryId = UrlParameter.Optional }
         //   );

         //   ///advertisement
         //   ///

         //   context.MapRoute(
         //       name: "Admin.Advertisment.List",
         //       url: "Admin/Advertisment/List",
         //       defaults: new { controller = "Advertisment", action = "List", area = "Admin" }
         //   );

         //   context.MapRoute(
         //       name: "Admin.Advertisment.CountryList",
         //       url: "Admin/Advertisment/CountryList",
         //       defaults: new { controller = "Advertisment", action = "CountryList", area = "Admin" }
         //   );

         //   context.MapRoute(
         //       name: "Admin.Advertisment.ChangeStatus",
         //       url: "Admin/Advertisment/ChangeStatus/{advertismentId}",
         //       defaults: new { controller = "Advertisment", action = "ChangeStatus", area = "Admin", advertismentId = UrlParameter.Optional }
         //   );


         //   context.MapRoute(
         //       name: "Admin.Advertisment.CountryAdvertisment",
         //       url: "Admin/Advertisment/CountryAdvertisment/{country}/{category}",
         //       defaults: new
         //       {
         //           controller = "Advertisment",
         //           action = "CountryAdvertisment",
         //           area = "Admin",
         //           country = UrlParameter.Optional,
         //           category = UrlParameter.Optional
         //       }
         //   );
         //   /// featured advertisments
         //   /// 
         //   context.MapRoute(
         //       name: "Admin.Advertisment.FeaturedList",
         //       url: "Admin/Advertisment/Featured",
         //       defaults: new { controller = "Advertisment", action = "FeaturedList", area = "Admin" }
         //   );

         //   context.MapRoute(
         //       name: "Admin.Advertisment.CountryFeaturedList",
         //       url: "Admin/Advertisment/CountryFeaturedList",
         //       defaults: new { controller = "Advertisment", action = "CountryFeaturedList", area = "Admin" }
         //   );

         //   context.MapRoute(
         //       name: "Admin.Advertisment.CountryFeaturedAdvertisment",
         //       url: "Admin/Advertisment/Country/Featured/{country}/{category}",
         //       defaults: new
         //       {
         //           controller = "Advertisment",
         //           action = "CountryFeaturedAdvertisment",
         //           area = "Admin",
         //           country = UrlParameter.Optional,
         //           category = UrlParameter.Optional
         //       }
         //   );


         //   /// Admin State 
         //   ///
         //   context.MapRoute(
         //       name: "Admin.State.AddState",
         //       url: "Admin/State/Add/{cityId}",
         //       defaults: new { controller = "State", action = "AddState", area = "Admin", cityId = UrlParameter.Optional }
         //   );

         //   context.MapRoute(
         //       name: "Admin.State.EditState",
         //       url: "Admin/State/Edit/{stateId}",
         //       defaults: new { controller = "State", action = "EditState", area = "Admin", stateId = UrlParameter.Optional }
         //   );

         //   context.MapRoute(
         //       name: "Admin.State.Delete",
         //       url: "Admin/State/Delete/{stateId}",
         //       defaults: new { controller = "State", action = "Delete", area = "Admin", stateId = UrlParameter.Optional }
         //   );

         //   // Admin Specifications Options
         //   ///
         //   context.MapRoute(
         //       name: "Admin.SpecificationOptions.List",
         //       url: "Admin/SpecificationOptions/OptionsList/{SpecificationId}",
         //       defaults: new { controller = "SpecificationOptions", action = "OptionsList", area = "Admin", SpecificationId = UrlParameter.Optional }
         //   );

         //   context.MapRoute(
         //       name: "Admin.SpecificationOptions.Add",
         //       url: "Admin/SpecificationOptions/Add/{SpecificationId}",
         //       defaults: new { controller = "SpecificationOptions", action = "Add", area = "Admin", SpecificationId = UrlParameter.Optional }
         //   );

         //   context.MapRoute(
         //       name: "Admin.SpecificationOptions.Edit",
         //       url: "Admin/SpecificationOptions/Edit/{optionId}",
         //       defaults: new { controller = "SpecificationOptions", action = "Edit", area = "Admin", optionId = UrlParameter.Optional }
         //   );

         //   context.MapRoute(
         //       name: "Admin.SpecificationOptions.DeleteSpecificationOption",
         //       url: "Admin/SpecificationOptions/Delete/{OptionId}",
         //       defaults: new { controller = "SpecificationOptions", action = "Delete", area = "Admin", OptionId = UrlParameter.Optional }
         //       );

         //   //Admin Ads
         //   context.MapRoute(
         //       name: "Admin.Ads.AddNew",
         //       url: "Admin/Ads/New",
         //       defaults: new { controller = "Ads", action = "New", area = "Admin" }
         //       );

         //   context.MapRoute(
         //       name: "Admin.Ads.List",
         //       url: "Admin/Ads/List",
         //       defaults: new { controller = "Ads", action = "List", area = "Admin" }
         //       );

         //   context.MapRoute(
         //       name: "Admin.Ads.CountryList",
         //       url: "Admin/Ads/CountryList",
         //       defaults: new { controller = "Ads", action = "CountryList", area = "Admin" }
         //       );

         //   context.MapRoute(
         //       name: "Admin.Ads.AdsListByType",
         //       url: "Admin/Ads/AdsListByType/{countryId}/{type}",
         //       defaults: new { controller = "Ads", action = "AdsListByType", area = "Admin", countryId = UrlParameter.Optional, type = UrlParameter.Optional }
         //       );

         //   context.MapRoute(
         //       name: "Admin.Ads.Details",
         //       url: "Admin/Ads/Details/{id}",
         //       defaults: new { controller = "Ads", action = "Details", area = "Admin", id = UrlParameter.Optional }
         //       );

         //   context.MapRoute(
         //       name: "Admin.Ads.Edit",
         //       url: "Admin/Ads/Edit/{id}",
         //       defaults: new { controller = "Ads", action = "Edit", area = "Admin", id = UrlParameter.Optional }
         //       );

         //   context.MapRoute(
         //       name: "Admin.Ads.Delete",
         //       url: "Admin/Ads/Delete/{id}",
         //       defaults: new { controller = "Ads", action = "Delete", area = "Admin", id = UrlParameter.Optional }
         //       );

         //   context.MapRoute(
         //       name: "Admin.Ads.CountryCats",
         //       url: "Admin/Ads/CountryCats/{CountryId}",
         //       defaults: new { controller = "Ads", action = "CountryCats", area = "Admin", CountryId = UrlParameter.Optional }
         //       );

         //   context.MapRoute(
         //      name: "Admin.Ads.CountryInBetweenCats",
         //      url: "Admin/Ads/CountryInBetweenCats/{CountryId}",
         //      defaults: new { controller = "Ads", action = "CountryInBetweenCats", area = "Admin", CountryId = UrlParameter.Optional }
         //      );

         //   context.MapRoute(
         //      name: "Admin.Ads.SubCats",
         //      url: "Admin/Ads/SubCats/{CatId}",
         //      defaults: new { controller = "Ads", action = "SubCats", area = "Admin", CatId = UrlParameter.Optional }
         //      );

         //   //ISSUES
         //   context.MapRoute(
         //      name: "Admin.UserIssues.Issues",
         //      url: "Admin/UserIssues/List",
         //      defaults: new { controller = "UserIssues", action = "Issues", area = "Admin" }
         //      );

         //   context.MapRoute(
         //      name: "Admin.UserIssues.CountryIssuesList",
         //      url: "Admin/UserIssues/CountryIssuesList",
         //      defaults: new { controller = "UserIssues", action = "CountryIssuesList", area = "Admin" }
         //      );

         //   context.MapRoute(
         //      name: "Admin.UserIssues.CountryIssues",
         //      url: "Admin/UserIssues/CountryList/{country}",
         //      defaults: new { controller = "UserIssues", action = "CountryIssues", area = "Admin", country = UrlParameter.Optional }
         //      );

         //   context.MapRoute(
         //      name: "Admin.UserIssues.AbuseReports",
         //      url: "Admin/AbuseReports/List",
         //      defaults: new { controller = "UserIssues", action = "AbuseReport", area = "Admin" }
         //      );

         //   context.MapRoute(
         //      name: "Admin.UserIssues.CountryAbuseReport",
         //      url: "Admin/AbuseReports/Country",
         //      defaults: new { controller = "UserIssues", action = "CountryReports", area = "Admin" }
         //      );

         //   context.MapRoute(
         //      name: "Admin.UserIssues.AbuseReports.Country",
         //      url: "Admin/AbuseReports/CountryList/{country}",
         //      defaults: new { controller = "UserIssues", action = "CountryAbuseReports", area = "Admin", country = UrlParameter.Optional }
         //      );

         //   //ABOUT

         //   context.MapRoute(
         //      name: "Admin.About.Edit",
         //      url: "Admin/About/Info/{countryId}",
         //      defaults: new { controller = "About", action = "Edit", area = "Admin", countryId = UrlParameter.Optional }
         //      );

         //   context.MapRoute(
         //      name: "Admin.About.List",
         //      url: "Admin/About/CountryInfo",
         //      defaults: new { controller = "About", action = "Index", area = "Admin" }
         //      );


         //   context.MapRoute(
         //      name: "Admin.About.CountryContactInfo",
         //      url: "Admin/About/CountryContactInfo",
         //      defaults: new { controller = "About", action = "CountryInfo", area = "Admin" }
         //      );

         //   context.MapRoute(
         //      name: "Admin.About.Refresh",
         //      url: "Admin/About/Country/Info/{countryId}",
         //      defaults: new { controller = "About", action = "GetCountryInfo", area = "Admin", countryId = UrlParameter.Optional }
         //      );

         //   context.MapRoute(
         //      name: "Admin.Faq.List",
         //      url: "Admin/Faq/List",
         //      defaults: new { controller = "Faq", action = "List", area = "Admin" }
         //      );

         //   context.MapRoute(
         //      name: "Admin.Faq.Add",
         //      url: "Admin/Faq/Add",
         //      defaults: new { controller = "Faq", action = "Add", area = "Admin" }
         //      );

         //   context.MapRoute(
         //      name: "Admin.Faq.Edit",
         //      url: "Admin/Faq/Edit/{Id}",
         //      defaults: new { controller = "Faq", action = "Edit", area = "Admin", Id = UrlParameter.Optional }
         //      );
              
        }
    }
}