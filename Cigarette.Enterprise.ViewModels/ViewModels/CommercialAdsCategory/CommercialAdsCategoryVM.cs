using Cigarette.Enterprise.ViewModels.ViewModels.CommercialAd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.ViewModels.CommercialAdsCategory
{
    public class CommercialAdsCategoryVM
    {
        public CommercialAdsCategoryVM()
        {
            ComercialAds = new HashSet<CommercialAdVM>();
        }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public Nullable<int> CountryId { get; set; }

        public virtual ICollection<CommercialAdVM> ComercialAds { get; set; } 
    }
}
