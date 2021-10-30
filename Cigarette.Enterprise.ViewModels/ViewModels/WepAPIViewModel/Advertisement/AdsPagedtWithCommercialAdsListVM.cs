using Cigarette.Enterprise.ViewModels.ViewModels.CommercialAd;
using PagedList;
using System.Collections.Generic;

namespace Cigarette.Enterprise.ViewModels.ViewModels.WepAPIViewModel.Advertisement
{
    public class AdsPagedtWithCommercialAdsListVM<A,C>
    {
        //public AdvertisementListVM Advertisement { get; set; }
        //public CommercialAdVM CommercialAd { get; set; }
        public A Advertisement { get; set; }
        public C CommercialAd { get; set; }
        public bool isCommercial { get; set; } = false;
    }
}
