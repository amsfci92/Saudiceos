using Cigarette.Enterprise.ViewModels.ViewModels.AdminViewModels.Country;
using Cigarette.Enterprise.ViewModels.ViewModels.Category;
using Cigarette.Enterprise.ViewModels.ViewModels.CommercialAdsCategory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.ViewModels.CommercialAd
{
    public class CommercialAdVM
    {
        public CommercialAdVM()
        {
            CommercialAdsUsers = new List<CommercialAdsUserVM>();
        }

        public int Id { get; set; }
        public Nullable<int> imageId { get; set; }
        public Nullable<int> imageMobileId { get; set; }
        public Nullable<byte> Type { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string InstagramLink { get; set; }
        public string WhatsappLink { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<int> Notification { get; set; }
        public Nullable<int> CountryId { get; set; }
        public Nullable<long> ViewsCount { get; set; }
        public Nullable<int> Likes { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public bool isLiked { get; set; }

        [JsonIgnore]
        public virtual CountryListItemViewModel Country  { get; set; }
        public virtual CategoryViewModel Category { get; set; } 
        public virtual SystemDataFileVM SystemDataFile { get; set; }
        public virtual SystemDataFileVM SystemDataFile1 { get; set; }
        public virtual ICollection<CommercialAdsUserVM> CommercialAdsUsers { get; set; }
    }
}
