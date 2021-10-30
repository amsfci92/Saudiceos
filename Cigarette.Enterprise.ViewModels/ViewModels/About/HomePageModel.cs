using Cigarette.Enterprise.ViewModels.ViewModels.AdminViewModels.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.ViewModels.About
{
    public class HomePageModel
    {
        public long AdvertisementCount { get; set; }
        public long CategoriesCount { get; set; }
        public long CountriesCount { get; set; }
        public long UsersCount { get; set; }
        public long FeaturedCount { get; set; }
        public long BundlesCount { get; set; }
        public long CommercialAdsCount { get; set; }
        public long FaqsCount { get; set; }
        public long CitiesCount { get; set; }
        public CountryListItemViewModel Country { get; set; }
    }
}
