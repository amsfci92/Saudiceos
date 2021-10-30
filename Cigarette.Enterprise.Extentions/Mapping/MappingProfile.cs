using AutoMapper;
using Cigarette.Enterprise.DAL;
using Cigarette.Enterprise.ResourceManager.Helpers;
using Cigarette.Enterprise.ViewModels.BindingModels.AdminBindingModels.City;
using Cigarette.Enterprise.ViewModels.BindingModels.AdminBindingModels.Country;
using Cigarette.Enterprise.ViewModels.BindingModels.AdminBindingModels.Specification;
using Cigarette.Enterprise.ViewModels.ViewModels.AdminViewModels.Category;
using Cigarette.Enterprise.ViewModels.ViewModels.AdminViewModels.City;
using Cigarette.Enterprise.ViewModels.ViewModels.AdminViewModels.Country;
using Cigarette.Enterprise.ViewModels.ViewModels.AdminViewModels.Specification;
using Cigarette.Enterprise.ViewModels.ViewModels.AdminViewModels.SpecificationOption;
using Cigarette.Enterprise.ViewModels.ViewModels.Advertisement;
using Cigarette.Enterprise.ViewModels.ViewModels.Product;

using Cigarette.Enterprise.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cigarette.Enterprise.ViewModels.ViewModels.Category;
using Cigarette.Enterprise.ViewModels.ViewModels.Category_SpecificationAttribute;
using Cigarette.Enterprise.ViewModels.ViewModels.SpecificationAttributeOption;
using Cigarette.Enterprise.ViewModels.BindingModels.Advertisement_SpecificationAttribute;
using Cigarette.Enterprise.ViewModels.BindingModels.Advertisement;
using Cigarette.Enterprise.ViewModels.ViewModels.City;
using Cigarette.Enterprise.ViewModels.BindingModels.UserInfo;
using Cigarette.Enterprise.ViewModels.ViewModels.WepAPIViewModel;
using Cigarette.Enterprise.ViewModels.ViewModels.LanguageVm;
using Cigarette.Enterprise.ViewModels.ViewModels.CurrencyVm;
using Cigarette.Enterprise.ViewModels.ViewModels.WepAPIViewModel.Advertisement;
using Cigarette.Enterprise.ViewModels.BindingModels.WepAPIBindingModel.Advertisment;
using Cigarette.Enterprise.DAL.CustomModels;
using Cigarette.Enterprise.ViewModels.ViewModels.AdvertismentImage;
using Cigarette.Enterprise.ViewModels.ViewModels.WepAPIViewModel.AdvertismentSpecificationOptions;
using Cigarette.Enterprise.ViewModels.ViewModels.WepAPIViewModel.AdvertismentSpecification;
using Cigarette.Enterprise.ViewModels.ViewModels.CommercialAd;
using Cigarette.Enterprise.ViewModels.ViewModels.Bundle;
using Cigarette.Enterprise.ViewModels.BindingModels.Bundle;
using Cigarette.Enterprise.ViewModels.ViewModels.CommercialAdsCategory;
using Cigarette.Enterprise.ViewModels.ViewModels.UserBundle;
using Cigarette.Enterprise.ViewModels.BindingModels.PaymentTransaction;
using Cigarette.Enterprise.ViewModels.ViewModels.PaymentTransaction;
using Cigarette.Enterprise.ViewModels.BindingModels.UserBundle;
using Cigarette.Enterprise.ViewModels.ViewModels.PaymentGateway;
using Cigarette.Enterprise.ViewModels.ViewModels.SmsGateway;
using Cigarette.Enterprise.ViewModels.ViewModels.ContactUs;
using Cigarette.Enterprise.ViewModels.BindingModels.CommercialAd;
using Cigarette.Enterprise.ViewModels.ViewModels.AdminViewModels.State;
using Cigarette.Enterprise.ViewModels.ViewModels.FeaturedAdvertisement;
using Cigarette.Enterprise.ViewModels.ViewModels.UserInfo;
using Cigarette.Enterprise.ViewModels.ViewModels.CountryAdmin;
using Cigarette.Enterprise.ViewModels.ViewModels.About;

namespace Cigarette.Enterprise.Extentions.Mapping
{
    public class MappingProfile : Profile
    {
        public static void Initialize()
        {
            //Entity to Model

            //Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMap<Category_Specification, CategorySpecificationListItemViewModel>();
            //    cfg.CreateMap<Product, ProductViewModel>()
            //        .ForMember(d => d.Name,
            //            opt => opt.MapFrom(src => (CultureHelper.IsArabic()) ? src.NameAr : src.Name)
            //        );


            //    cfg.CreateMap<Advertisement, AdvertisementViewModel>()
            //    .ForMember(d => d.Title,
            //            opt => opt.MapFrom(src => (CultureHelper.IsArabic()) ? src.ArabicTitle : src.EnglishTitle))
            //    .ForMember(d => d.Time,
            //            opt => opt.MapFrom(src => (src.IsUpdated == true) ? src.UpdateTime : src.CreationTime)
            //        )
            //        .ForMember(d=>d.Title,
            //        opt=>opt.MapFrom(src=> (CultureHelper.IsArabic())?src.ArabicTitle:src.EnglishTitle)
                 
            //        );
            //    cfg.CreateMap<Advertisement, AdvertisementDetailsViewModel>()
            //    .ForMember(d => d.FullName, o => o.MapFrom(s => $"{s.AspNetUser.FirstName ?? "User"} {s.AspNetUser.SecondName ?? ""}"));
            //    cfg.CreateMap<AdvertisementDetailsViewModel, Advertisement>();
            //    cfg.CreateMap<AddCategoryModel, Category>()
            //    .ForMember(d => d.ArabicName, o => o.MapFrom(s => s.ArabicDescription))
            //    .ForMember(d => d.EnglishName, o => o.MapFrom(s => s.EnglishDescription))
            //    .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
            //    .IgnoreAllPropertiesWithAnInaccessibleSetter();

            //    cfg.CreateMap<Category, AddCategoryModel>()
            //    .ForMember(d => d.ArabicDescription, o => o.MapFrom(s => s.ArabicName))
            //    .ForMember(d => d.EnglishDescription, o => o.MapFrom(s => s.EnglishName))
            //    .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
            //    .IgnoreAllPropertiesWithAnInaccessibleSetter();

            //    cfg.CreateMap<AddCountryBindingModel, Country>()
            //    .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
            //    .IgnoreAllPropertiesWithAnInaccessibleSetter();

            //    cfg.CreateMap<Country, AddCountryBindingModel>()
            //    .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
            //    .IgnoreAllPropertiesWithAnInaccessibleSetter();

            //    cfg.CreateMap<FeaturedAdvertisementVM, FeaturedAdvertisment>();
            //    cfg.CreateMap<FeaturedAdvertisment, FeaturedAdvertisementVM>();

            //    cfg.CreateMap<CommercialAdsUserVM, CommercialAdsUser>();
            //    cfg.CreateMap<CommercialAdsUser, CommercialAdsUserVM>();

            //    cfg.CreateMap<AdvertismentVM, Advertisement>();
            //    cfg.CreateMap<Advertisement, AdvertismentVM>();

            //    cfg.CreateMap<LanguageListVm, Language>()
            //    .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
            //    .IgnoreAllPropertiesWithAnInaccessibleSetter();

            //    cfg.CreateMap<CurrencyListVm, Currency>()
            //    .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
            //    .IgnoreAllPropertiesWithAnInaccessibleSetter();


            //    cfg.CreateMap<AddCityAdminBindingModel, City>()
            //    .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
            //    .IgnoreAllPropertiesWithAnInaccessibleSetter();

            //    cfg.CreateMap<Country, CountryListItemViewModel>()
            //    .ForMember(m => m.Name,
            //    src => src.MapFrom(m => (CultureHelper.IsArabic() ? m.ArabicName : m.EnglishName)))
            //    .ForMember(m => m.CountryId, s => s.MapFrom(m => m.Id))
            //    .ForMember(m => m.ArabicDescription, s => s.MapFrom(m => m.ArabicName))
            //    .ForMember(m => m.EnglishDescription, s => s.MapFrom(m => m.EnglishName))
            //    .ForMember(m => m.Categories, s => s.MapFrom(m => m.Categories)).
            //    ForMember(m => m.language, s => s.MapFrom(m => m.Language)).
            //    ForMember(m => m.Currency, s => s.MapFrom(m => m.Currency))
            //     .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
            //    .IgnoreAllPropertiesWithAnInaccessibleSetter();

            //    cfg.CreateMap<CountryAdminBM, CountryAdmin>();
            //    cfg.CreateMap<CountryAdmin, CountryAdminBM>();

            //    cfg.CreateMap<Language, LanguageListVm>()
            //    .ForMember(m => m.Name, src => src.MapFrom(m => m.Name))
            //    .ForMember(m => m.Id, s => s.MapFrom(m => m.Id))
            //    .ForMember(m => m.Active, s => s.MapFrom(m => m.Active))
            //    .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
            //    .IgnoreAllPropertiesWithAnInaccessibleSetter();

            //    cfg.CreateMap<Currency, CurrencyListVm>()
            //    .ForMember(m => m.Name, src => src.MapFrom(m => m.Name))
            //    .ForMember(m => m.Id, s => s.MapFrom(m => m.Id))
            //    .ForMember(m => m.Abbr, s => s.MapFrom(m => m.Abbr))
            //    .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
            //    .IgnoreAllPropertiesWithAnInaccessibleSetter();


            //    cfg.CreateMap<Category, CategoryListItemViewModel>()
            //   .ForMember(m => m.Name,
            //   src => src.MapFrom(m => (CultureHelper.IsArabic() ? m.ArabicName : m.EnglishName)))
            //   .ForMember(m => m.ArabicDescription, s => s.MapFrom(m => m.ArabicName))
            //   .ForMember(m => m.EnglishDescription, s => s.MapFrom(m => m.EnglishName))
            //   .IgnoreAllPropertiesWithAnInaccessibleSetter()
            //   .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();


            //    cfg.CreateMap<Specification, SpecificationListItemViewModel>()
            //   .ForMember(m => m.Name,
            //   src => src.MapFrom(m => (CultureHelper.IsArabic() ? m.ArabicName : m.EnglishName)))
            //    .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
            //   .IgnoreAllPropertiesWithAnInaccessibleSetter();

            //    cfg.CreateMap<Category_Specification, CategorySpecificationListItemViewModel>()
            //  .ForMember(m => m.SpeceficationType,
            //  src => src.MapFrom(m => (CultureHelper.IsArabic() ? m.Specification.ArabicName : m.Specification.EnglishName)))
            //   .ForMember(m => m.CategoryName,
            //  src => src.MapFrom(m => (CultureHelper.IsArabic() ? m.Category.ArabicName : m.Category.EnglishName)))

            //  .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
            //  .IgnoreAllPropertiesWithAnInaccessibleSetter();

            //    cfg.CreateMap<SpecificationOption, SpecificationOptionListItemViewModel>()
            // .ForMember(m => m.ArabicName,
            // src => src.MapFrom(m => (CultureHelper.IsArabic() ? m.ArabicName : m.EnglishName)))
            //  .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
            // .IgnoreAllPropertiesWithAnInaccessibleSetter();

            //    cfg.CreateMap<City, CityListItemViewModel>()
            //.ForMember(m => m.Name,
            //src => src.MapFrom(m => (CultureHelper.IsArabic() ? m.ArabicName : m.EnglishName)))
            // .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
            //.IgnoreAllPropertiesWithAnInaccessibleSetter();

            //    cfg.CreateMap<AddSpecificationOptionAdminBindingModel, SpecificationOption>()
            //  .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
            // .IgnoreAllPropertiesWithAnInaccessibleSetter();

            //    cfg.CreateMap<SpecificationOption, AddSpecificationOptionAdminBindingModel>()
            //  .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
            // .IgnoreAllPropertiesWithAnInaccessibleSetter();


            //    cfg.CreateMap<AddSpecificationAdminBindingModel, Category_Specification>()
            //  .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
            // .IgnoreAllPropertiesWithAnInaccessibleSetter();

            //    cfg.CreateMap<Category_Specification, AddSpecificationAdminBindingModel>()
            //  .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
            // .IgnoreAllPropertiesWithAnInaccessibleSetter();

            //    cfg.CreateMap<AddStateAdminBindingModel, State>()
            //  .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
            // .IgnoreAllPropertiesWithAnInaccessibleSetter();

            //    cfg.CreateMap<State, AddStateAdminBindingModel>()
            //  .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
            // .IgnoreAllPropertiesWithAnInaccessibleSetter();

            //    cfg.CreateMap<GetAdvertisementDetailsById_Result, AdvertisementDetailsViewModel>()
            //        .ForMember(d => d.AdvertisementTitle,
            //            opt => opt.MapFrom(src => src.AdvertisementArabicTitle )
            //        )
            //           .ForMember(d => d.AdvertisementTitleEn,
            //            opt => opt.MapFrom(src => src.AdvertisementEnglishTitle )
            //        )
            //        .ForMember(d => d.AdvertisementDescription,
            //            opt => opt.MapFrom(src =>  src.AdvertisementArabicDescription )
            //        )
            //        .ForMember(d => d.CategoryDescription,
            //            opt => opt.MapFrom(src => CultureHelper.IsArabic() ? src.CategoryArabicDescription : src.CategoryEnglishDescription)
            //        )
            //        .ForMember(d => d.Category_SpecificationAttributeName,
            //            opt => opt.MapFrom(src => CultureHelper.IsArabic() ? src.Category_SpecificationAttributeArabicName : src.Category_SpecificationAttributeEnglishName)
            //        )
            //        .ForMember(d => d.CityName,
            //            opt => opt.MapFrom(src => CultureHelper.IsArabic() ? src.CityArabicName : src.CityEnglishName)
            //        )
            //        .ForMember(d => d.SpecificationAttributeOptionName,
            //            opt => opt.MapFrom(src => CultureHelper.IsArabic() ? src.SpecificationAttributeOptionArabicName : src.SpecificationAttributeOptionEnglishName)
            //        )
            //        .ForMember(d => d.StateName,
            //            opt => opt.MapFrom(src => CultureHelper.IsArabic() ? src.StateArabicName : src.StateEnglishName)
            //        )
            //        .IgnoreAllPropertiesWithAnInaccessibleSetter()
            //        .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            //    cfg.CreateMap<ContactUsBM, ContactU>();


            //    cfg.CreateMap<Category, CategoryViewModel>()
            //        .ForMember(d => d.Name,
            //            opt => opt.MapFrom(src => (CultureHelper.IsArabic()) ? src.ArabicName : src.EnglishName)
            //        )
            //        .ForMember(d => d.NameAr, opt => opt.MapFrom(src => src.ArabicName))
            //        .ForMember(d => d.NameEn, opt => opt.MapFrom(src => src.EnglishName));

            //    cfg.CreateMap<Category, CategoryWithSubViewModel>()
            //    .ForMember(d => d.Name,
            //            opt => opt.MapFrom(src => (CultureHelper.IsArabic()) ? src.ArabicName : src.EnglishName)
            //        )
            //        .ForMember(d => d.SubCategories,
            //        opt => opt.MapFrom(src => src.SubCategories.Select(x => Mapper.Map<CategoryViewModel>(x))));


            //    cfg.CreateMap<SpecificationOption, SpecificationAttributeOptionViewModel>()
            //        .ForMember(d => d.Name,
            //           opt => opt.MapFrom(src => (CultureHelper.IsArabic()) ? src.ArabicName : src.EnglishName)
            //       );



            //    cfg.CreateMap<Category_Specification, Category_SpecificationAttributeViewModel>()
            //        .ForMember(d => d.Name,
            //            opt => opt.MapFrom(src => (CultureHelper.IsArabic()) ? src.ArabicName : src.EnglishName)
            //        )
            //       .ForMember(d => d.SpeceficationType,
            //               opt => opt.MapFrom(src => src.Specification.SpeceficationType))
            //     .ForMember(d => d.Options,
            //            opt => opt.MapFrom(src => src.SpecificationOptions.Select(o => Mapper.Map<SpecificationAttributeOptionViewModel>(o))));

            //    cfg.CreateMap<AdvertisementSpecificationAttributeOptionBindingViewModel, AdvertismentSpecificatioOption>();

            //    cfg.CreateMap<Advertisement_SpecificationAttributeBindingModel, Advertisment_Specification>()
            //    .ForMember(dest => dest.AdvertismentSpecificatioOptions,
            //    opt => opt.MapFrom(src => src.Options.Select(x => Mapper.Map<AdvertismentSpecificatioOption>(x))));

            //    cfg.CreateMap<AdvertisementBindingModel, Advertisement>()
            //        .ForMember(d => d.Advertisment_Specification,
            //            opt => opt.MapFrom(src => src.Advertisment_SpecificationAttributes.Select(a => Mapper.Map<Advertisment_Specification>(a))));



            //    cfg.CreateMap<State, CityStatesViewModel>()
            //        .ForMember(d => d.Name,
            //             opt => opt.MapFrom(src => CultureHelper.IsArabic() ? src.ArabicName : src.EnglishName));

            //    cfg.CreateMap<City, CityWithStatesViewModel>()
            //         .ForMember(d => d.Name,
            //            opt => opt.MapFrom(src => CultureHelper.IsArabic() ? src.ArabicName : src.EnglishName))
            //        .ForMember(d => d.States,
            //            opt => opt.MapFrom(src => src.States.Select(s => Mapper.Map<CityStatesViewModel>(s))));


            //    cfg.CreateMap<Specification, CategoryLastNode_Specification_SpecificationVM>();
            //    cfg.CreateMap<SpecificationOption, CategoryLastNode_Specification_OptionsVM>();

            //    cfg.CreateMap<Category_Specification, CategoryLastNode_SpecificationVM>()
            //    .ForMember(dest => dest.Specification, opt => opt.MapFrom(src => Mapper.Map<CategoryLastNode_Specification_SpecificationVM>(src.Specification)))
            //    .ForMember(dest => dest.Specification_Options, opt => opt.MapFrom(src => src.SpecificationOptions.Select(x => Mapper.Map<CategoryLastNode_Specification_OptionsVM>(x))));


            //    ////+++++++++++++++++++++/////
            //    ////     API MAPPING     /////
            //    ////+++++++++++++++++++++/////

            //    cfg.CreateMap<UserDataBM, AspNetUser>();
            //    cfg.CreateMap<AspNetUser, UserDataBM>()
            //     .ForMember(x => x.LastName, y => y.MapFrom(m => m.SecondName));

            //    // Category Mapping
            //    cfg.CreateMap<Category_Specification, Category_SpecificationAttributeViewModel>()
            //    .ForMember(m => m.Id, m => m.MapFrom(p => p.Id));

            //    // Spec options mapping
            //    cfg.CreateMap<CategorySpecificationOptionVM, SpecificationOption>();
            //    cfg.CreateMap<SpecificationOption, CategorySpecificationOptionVM>();

            //    // Spec options mapping
            //    cfg.CreateMap<SpecificationVm, Specification>();
            //    cfg.CreateMap<Specification, SpecificationVm>();

            //    // Spec options mapping
            //    cfg.CreateMap<AdvertismentImageBM, AdvertismentImage>()
            //    .IgnoreAllPropertiesWithAnInaccessibleSetter()
            //    .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            //    cfg.CreateMap<AdvertismentImage, AdvertismentImageBM>()
            //    .IgnoreAllPropertiesWithAnInaccessibleSetter()
            //    .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            //    // SearchParamsModel
            //    cfg.CreateMap<SearchParamsModel, AdvancedSearchParametersBM>();
            //    cfg.CreateMap<AdvancedSearchParametersBM, SearchParamsModel>();

            //    // AdvancedSearchMainModel
            //    cfg.CreateMap<AdvancedSearchMainModel, AdvancedSearchMainModelDAL>()
            //    .IgnoreAllPropertiesWithAnInaccessibleSetter()
            //    .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            //    //.ForMember(m => m.Params, n =>
            //    //n.MapFrom(mm => mm.Params.Select(m => Mapper.Map<AdvancedSearchParametersBM>(m)).ToList()));

            //    cfg.CreateMap<AdvancedSearchMainModelDAL, AdvancedSearchMainModel>();

            //    //sms
            //    cfg.CreateMap<SmsGatewayBM, SmsGatewayVM>();
            //    cfg.CreateMap<SmsGatewayVM, SmsGatewayBM>();

            //    cfg.CreateMap<SmsGatewayBM, SmsGatway>();
            //    cfg.CreateMap<SmsGatway, SmsGatewayBM>();

            //    cfg.CreateMap<SmsGatway, SmsGatewayVM>();
            //    cfg.CreateMap<SmsGatewayVM, SmsGatway>();



            //    // about
            //    cfg.CreateMap<AboutBM, AboutVM>();
            //    cfg.CreateMap<AboutVM, AboutBM>();

            //    cfg.CreateMap<AboutBM, About>();
            //    cfg.CreateMap<About, AboutBM>();

            //    cfg.CreateMap<About, AboutVM>();
            //    cfg.CreateMap<AboutVM, About>();


            //    cfg.CreateMap<FeaturedAdvertisementListVM, Advertisement>();
            //    cfg.CreateMap<Advertisement, FeaturedAdvertisementListVM>()
            //    .ForMember(m => m.ArabicDescription, m => m.MapFrom(mf => mf.ArabicDescription))
            //    .ForMember(m => m.EnglishDescription, m => m.MapFrom(mf => mf.EnglishDescription))

            //    .ForMember(m => m.ArabicTitle, m => m.MapFrom(mf => mf.ArabicTitle))
            //    .ForMember(m => m.EnglishTitle, m => m.MapFrom(mf => mf.EnglishTitle))

            //    .ForMember(m => m.CategoryName, m => m.MapFrom(mf => mf.Category.ArabicName))

            //    .ForMember(m => m.CityNameArabic, m => m.MapFrom(mf => mf.City.ArabicName))
            //    .ForMember(m => m.CityNameEnglish, m => m.MapFrom(mf => mf.City.EnglishName))

            //    .ForMember(m => m.CountryNameArabic, m => m.MapFrom(mf => mf.City.Country.ArabicName))
            //    .ForMember(m => m.CountryNameEnglish, m => m.MapFrom(mf => mf.City.Country.EnglishName))

            //    .ForMember(m => m.EnglishDescriptionUrl, m => m.MapFrom(mf => mf.EnglishDescriptionUrl))
            //    .ForMember(m => m.ArabicDescriptionUrl, m => m.MapFrom(mf => mf.ArabicDescriptionUrl))

            //    .ForMember(m => m.StateNameArabic, m => m.MapFrom(mf => mf.State.ArabicName))
            //    .ForMember(m => m.StateNameEnglish, m => m.MapFrom(mf => mf.State.EnglishName))
            //    .ForMember(m => m.StateNameEnglish, m => m.MapFrom(mf => mf.State.EnglishName))
            //    .ForMember(m => m.StateNameEnglish, m => m.MapFrom(mf => mf.State.EnglishName))

            //    .ForMember(m => m.UserPhone, m => m.MapFrom(mf => mf.State.EnglishName))
            //    .ForMember(m => m.UserName, m => m.MapFrom(mf => mf.AspNetUser.UserName))
            //    .ForMember(m => m.UserId, m => m.MapFrom(mf => mf.AspNetUser.Id))

            //    // Mapping Featured Time
            //    .ForMember(m => m.StartTime, m =>
            //    m.MapFrom(mf => mf.FeaturedAdvertisments.FirstOrDefault().StartDate))
            //    .ForMember(m => m.EndTime, m =>
            //    m.MapFrom(mf => mf.FeaturedAdvertisments.FirstOrDefault().EndDate))

            //    .IgnoreAllPropertiesWithAnInaccessibleSetter()
            //    .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            //    // Advertisment View Mapping
            //    cfg.CreateMap<AdvertisementListVM, Advertisement>();
            //    cfg.CreateMap<Advertisement, AdvertisementListVM>()
            //    .ForMember(m => m.ArabicDescription, m => m.MapFrom(mf => mf.ArabicDescription))
            //    .ForMember(m => m.EnglishDescription, m => m.MapFrom(mf => mf.EnglishDescription))

            //    .ForMember(m => m.ArabicTitle, m => m.MapFrom(mf => mf.ArabicTitle))
            //    .ForMember(m => m.EnglishTitle, m => m.MapFrom(mf => mf.EnglishTitle))

            //    .ForMember(m => m.CategoryName, m => m.MapFrom(mf => mf.Category.ArabicName))

            //    .ForMember(m => m.CityNameArabic, m => m.MapFrom(mf => mf.City.ArabicName))
            //    .ForMember(m => m.CityNameEnglish, m => m.MapFrom(mf => mf.City.EnglishName))

            //    .ForMember(m => m.CountryNameArabic, m => m.MapFrom(mf => mf.City.Country.ArabicName))
            //    .ForMember(m => m.CountryNameEnglish, m => m.MapFrom(mf => mf.City.Country.EnglishName))

            //    .ForMember(m => m.EnglishDescriptionUrl, m => m.MapFrom(mf => mf.EnglishDescriptionUrl))
            //    .ForMember(m => m.ArabicDescriptionUrl, m => m.MapFrom(mf => mf.ArabicDescriptionUrl))

            //    .ForMember(m => m.StateNameArabic, m => m.MapFrom(mf => mf.State.ArabicName))
            //    .ForMember(m => m.StateNameEnglish, m => m.MapFrom(mf => mf.State.EnglishName))
            //    .ForMember(m => m.StateNameEnglish, m => m.MapFrom(mf => mf.State.EnglishName))
            //    .ForMember(m => m.StateNameEnglish, m => m.MapFrom(mf => mf.State.EnglishName))

            //    .ForMember(m => m.UserPhone, m => m.MapFrom(mf => mf.State.EnglishName))
            //    .ForMember(m => m.UserName, m => m.MapFrom(mf => mf.AspNetUser.UserName))
            //    .ForMember(m => m.UserId, m => m.MapFrom(mf => mf.AspNetUser.Id))

            //    //.ForMember(m => m.AdvertismentImages, m => m.MapFrom(mf => Mapper.Map<List< AdvertismentImage >, List<AdvertismentPhotoBM>>(mf.AdvertismentImages.ToList()))

            //    .IgnoreAllPropertiesWithAnInaccessibleSetter()
            //    .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            //    // images Mapping 
            //    cfg.CreateMap<AdvertismentPhotoBM, AdvertismentImage>()
            //     .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
            //    .IgnoreAllPropertiesWithAnInaccessibleSetter();

            //    cfg.CreateMap<AdvertismentImage, AdvertismentPhotoBM>()
            //    .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
            //    .IgnoreAllPropertiesWithAnInaccessibleSetter();

            //    // Featured ds
            //    cfg.CreateMap<FeaturedAdvertisementViewModel, FeaturedAdvertisment>();

            //    // Advertisment Mapping
            //    cfg.CreateMap<Advertisement, AdvertisementVM>()
            //    .ForMember(m => m.StateNameArabic, m => m.MapFrom(mf => mf.State.ArabicName))
            //    .ForMember(m => m.CityNameArabic, m => m.MapFrom(mf => mf.City.ArabicName))
            //    .ForMember(m => m.CategoryName, m => m.MapFrom(mf => mf.Category.ArabicName))
            //    .ForMember(m => m.CityNameEnglish, m => m.MapFrom(mf => mf.City.EnglishName))
            //    .ForMember(m => m.StateNameEnglish, m => m.MapFrom(mf => mf.State.EnglishName))
            //    .ForMember(m => m.CityNameEnglish, m => m.MapFrom(mf => mf.City.EnglishName))
            //    .ForMember(m => m.CountryNameArabic, m => m.MapFrom(mf => mf.City.Country.EnglishName))
            //    .ForMember(m => m.CountryNameEnglish, m => m.MapFrom(mf => mf.City.Country.EnglishName))
            //    .ForMember(m => m.UserPhone, m => m.MapFrom(mf => mf.AspNetUser.PhoneNumber))
            //    .ForMember(m => m.UserName, m => m.MapFrom(mf => mf.AspNetUser.UserName)) 

            //    .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
            //    .IgnoreAllPropertiesWithAnInaccessibleSetter();


            //    //   AdvertismentSpecificatioOption Mapping

            //    cfg.CreateMap<AdvertismentSpecificatioOption, AdvertismentSpecificationOptionVM>()
            //    .ForMember(m => m.NameArabic, m => m.MapFrom(mf => mf.SpecificationOption.ArabicName))
            //    .ForMember(m => m.NameEnglish, m => m.MapFrom(mf => mf.SpecificationOption.EnglishName))
            //    .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
            //    .IgnoreAllPropertiesWithAnInaccessibleSetter();


            //    // Advertisment_Specification Mpping

            //    cfg.CreateMap<Advertisment_Specification, AdvertismentSpecificationVM>()
            //    .ForMember(m => m.NameArabic, m => m.MapFrom(mf => mf.Category_Specification.ArabicName))
            //    .ForMember(m => m.NameEnglish, m => m.MapFrom(mf => mf.Category_Specification.EnglishName))
            //    .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
            //    .IgnoreAllPropertiesWithAnInaccessibleSetter();

            //    // AdvertismentListBM Mpping

            //    cfg.CreateMap<AddAdvertisementBM, Advertisement>()
            //    .ForMember(m => m.ArabicTitle, m => m.MapFrom(mf => mf.Title))
            //    .ForMember(m => m.EnglishTitle, m => m.MapFrom(mf => mf.Title))
            //    .ForMember(m => m.IsActive, m => m.MapFrom(mf => true))
            //    .ForMember(m => m.IsDisplayed, m => m.MapFrom(mf => false))
            //    .ForMember(m => m.IsDeleted, m => m.MapFrom(mf => false))
            //    .ForMember(m => m.CreationTime, m => m.MapFrom(mf => DateTime.Now))
            //    .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
            //    .IgnoreAllPropertiesWithAnInaccessibleSetter();

            //    cfg.CreateMap<AddAdvertisementWebBM, AddAdvertisementBM>()
            //    .ForMember(m => m.Title, m => m.MapFrom(mf => mf.Title))
            //    .ForMember(m => m.Photos, m => m.MapFrom(mf => mf.Images))
            //    .ForMember(m => m.ArabicDescription, m => m.MapFrom(mf => mf.Description))
            //    .ForMember(m => m.EnglishDescription, m => m.MapFrom(mf => mf.Description))
            //    .ForMember(m => m.Advertisment_Specification, m => m.MapFrom(mf => mf.CustomFields))
            //    .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
            //    .IgnoreAllPropertiesWithAnInaccessibleSetter();

            //    // AdvertismentListBM Mpping

            //    cfg.CreateMap<AdvertismentSpecificatioOption, int>()
            //     .ConvertUsing(m => (int)m.SpecificationOptionId);

            //    cfg.CreateMap<int, AdvertismentSpecificatioOption>()
            //    .ForMember(m => m.CreatoinTime, m => m.MapFrom(mf => DateTime.Now))
            //    .ForMember(m => m.SpecificationOptionId, m => m.MapFrom(mf => mf));


            //    // AdvertismentSpecificationBM Mpping
            //    cfg.CreateMap<Advertisment_Specification, AdvertismentSpecificationBM>()
            //     .ForMember(m => m.Id, m => m.MapFrom(mf => mf.CategorySpecificationId))
            //     .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
            //     .IgnoreAllPropertiesWithAnInaccessibleSetter();

            //    // AdvertismentSpecificationBM Mpping
            //    cfg.CreateMap<AdvertismentSpecificationBM, Advertisment_Specification>()
            //     .ForMember(m => m.CategorySpecificationId, m => m.MapFrom(mf => mf.Id))
            //     .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
            //     .IgnoreAllPropertiesWithAnInaccessibleSetter();

            //    cfg.CreateMap<ComercialAd, CommercialAdVM>()
            //     .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
            //     .IgnoreAllPropertiesWithAnInaccessibleSetter();

            //    cfg.CreateMap<CommercialAdBM, ComercialAd>()
            //     .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
            //     .IgnoreAllPropertiesWithAnInaccessibleSetter();

            //    cfg.CreateMap<Bundle, BundleVM>()
            //     .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
            //     .IgnoreAllPropertiesWithAnInaccessibleSetter();

            //    cfg.CreateMap<BundleBM, Bundle>()
            //     .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
            //     .IgnoreAllPropertiesWithAnInaccessibleSetter();

            //    cfg.CreateMap<UserBundle, UserBundleVM>()
            //     .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
            //     .IgnoreAllPropertiesWithAnInaccessibleSetter();

            //    cfg.CreateMap<UserBundleBM, UserBundle>()
            //     .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
            //     .IgnoreAllPropertiesWithAnInaccessibleSetter();

            //    cfg.CreateMap<PaymentTransaction, PaymentTransactionVM>()
            //     .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
            //     .IgnoreAllPropertiesWithAnInaccessibleSetter();

            



            ////Mapper.Initialize(cfg => {
            ////    cfg.CreateMap<Product, ProductViewModel>()
            ////        .ForMember(d => d.Name,
            ////            opt => opt.MapFrom(src => src.Name)
            ////        );
            ////});

            //    cfg.CreateMap<PaymentTransactionBM, PaymentTransaction>()
            //     .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
            //     .IgnoreAllPropertiesWithAnInaccessibleSetter();

            //    //PaymentGateway Mapping
            //    cfg.CreateMap<PaymentGateway, PaymentGatewayVM>()
            //     .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
            //     .IgnoreAllPropertiesWithAnInaccessibleSetter();

            //    //PaymentGateway Mapping
            //    cfg.CreateMap<PaymentGateway, PaymentGatewayListItemVM>()
            //     .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
            //     .IgnoreAllPropertiesWithAnInaccessibleSetter();

            //    cfg.CreateMap<PaymentGatewayBM, PaymentGateway>()
            //     .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
            //     .IgnoreAllPropertiesWithAnInaccessibleSetter();

            //    //   cfg.CreateMap<CommercialAdsCategory, CommercialAdsCategoryVM>()
            //    //.IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
            //    //.IgnoreAllPropertiesWithAnInaccessibleSetter();

            //    //   cfg.CreateMap<CommercialAdsCategoryBM, CommercialAdsCategory>()
            //    //.IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
            //    //.IgnoreAllPropertiesWithAnInaccessibleSetter();

            //    cfg.CreateMap<CommercialAdBM, ComercialAd>()
            //     .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
            //     .IgnoreAllPropertiesWithAnInaccessibleSetter();

            //    cfg.CreateMap<ComercialAd, CommercialAdBM>()
            //     .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
            //     .IgnoreAllPropertiesWithAnInaccessibleSetter();


            //    cfg.CreateMap<ComercialAd, CommercialAdVM>()
            //     .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
            //     .IgnoreAllPropertiesWithAnInaccessibleSetter();

            //    cfg.CreateMap<CommercialAdVM, ComercialAd>()
            // .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
            // .IgnoreAllPropertiesWithAnInaccessibleSetter();

            //    cfg.CreateMap<SystemDataFile, SystemDataFileBM>()
            //     .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
            //     .IgnoreAllPropertiesWithAnInaccessibleSetter();

            //    cfg.CreateMap<SystemDataFileBM, SystemDataFile>()
            //    .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
            //    .IgnoreAllPropertiesWithAnInaccessibleSetter();

            //    cfg.CreateMap<SystemDataFile, SystemDataFileVM>()
            //     .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
            //     .IgnoreAllPropertiesWithAnInaccessibleSetter();

            //    cfg.CreateMap<SystemDataFileVM, SystemDataFile>()
            //    .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
            //    .IgnoreAllPropertiesWithAnInaccessibleSetter();

            //});
        }
    }
}