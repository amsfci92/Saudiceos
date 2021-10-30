using Cigarette.Enterprise.ViewModels.ViewModels.AdvertismentImage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.ViewModels.Advertisement
{
    public class AdvertisementDetailsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AdvertisementDescription { get; set; }
        public string AdvertisementEnglishDescription { get; set; }
        public string PriceTextAr { get; set; }
        public string PriceTextEn { get; set; } 
        public string AdvertisementTitle { get; set; }
        public string AdvertisementTitleEn { get; set; }
        public bool IsNogitable { get; set; }
        public string Phone { get; set; }
        public Nullable<System.DateTime> AdvertisementCreationTime { get; set; }
        public Nullable<decimal> AdvertisementLocationLatitude { get; set; }
        public Nullable<decimal> AdvertisementLocationLongtude { get; set; }
        public Nullable<decimal> AdvertisementPrice { get; set; }
        public string StateName { get; set; }
        public string FullName { get; set; }
        public string CityName { get; set; }
        public string UserName { get; set; }
        public string CategoryDescription { get; set; }
        public string Advertisment_SpecificationAttributeCustomValue { get; set; }
        public string SpecificationAttributeOptionName { get; set; }
        public string Category_SpecificationAttributeName { get; set; }
        public string Category_SpecificationAttributeCustomValue { get; set; }
        public Nullable<int> Views { get; set; }

    }
}
