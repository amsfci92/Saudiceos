
using Cigarette.Enterprise.ViewModels.ViewModels.AdminViewModels.Category;
using Cigarette.Enterprise.ViewModels.ViewModels.Bundle;
using Cigarette.Enterprise.ViewModels.ViewModels.CurrencyVm;
using Cigarette.Enterprise.ViewModels.ViewModels.LanguageVm;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.ViewModels.AdminViewModels.Country
{
    public class CountryListItemViewModel
    {
        public int CountryId { get; set; }
        public string ArabicDescription { get; set; }
        public string EnglishDescription { get; set; }
        public string Name { get; set; }
        public string  Flag { get; set; }
        public decimal FeaturedAdCost { get; set; }
        public int FreeAdCount { get; set; }
        public string PhoneKey { get; set; }
        public int imageId { get; set; }
        public CurrencyListVm Currency { get; set; }
        public LanguageListVm language { get; set; }
        public string Abbr { get; set; }
        public string phoneRGX { get; set; }
        public string phoneValidationMsg { get; set; }
        public virtual ICollection<CategoryListItemViewModel> Categories { get; set; }
        [JsonIgnore]
        public virtual ICollection<BundleVM> Bundles { get; set; }

    }
}
