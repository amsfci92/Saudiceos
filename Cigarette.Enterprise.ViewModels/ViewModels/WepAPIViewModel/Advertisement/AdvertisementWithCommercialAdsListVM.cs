using Cigarette.Enterprise.ViewModels.ViewModels.CommercialAd;
using PagedList;
using System.Collections.Generic;

namespace Cigarette.Enterprise.ViewModels.ViewModels.WepAPIViewModel.Advertisement
{
    public class AdvertisementWithCommercialAdsListVM
    {
        public AdvertisementWithCommercialAdsListVM()
        {
            CommercialAdsList = new HashSet<CommercialAdVM>();

        }
        
        public List<AdvertisementListVM> AdvertisementList { get; set; }
        public ICollection<CommercialAdVM> CommercialAdsList { get; set; }
    }
}
