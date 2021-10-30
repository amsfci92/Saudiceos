using Cigarette.Enterprise.ViewModels.ViewModels.Advertisement;
using Cigarette.Enterprise.ViewModels.ViewModels.CommercialAd;
using Cigarette.Enterprise.ViewModels.ViewModels.FeaturedAdvertisement;
using Cigarette.Enterprise.ViewModels.ViewModels.UserBundle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.ViewModels.UserInfo
{
    public class UserInfoViewModel
    {
        public UserInfoViewModel()
        {
            this.Advertisements = new HashSet<AdvertismentVM>();
            this.CommercialAdsUsers = new HashSet<CommercialAdsUserVM>();
            this.FeaturedAdvertisments = new HashSet<FeaturedAdvertisementVM>();
            this.UserBundles = new HashSet<UserBundleVM>();
        }

        public string Id { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public Nullable<int> CountryId { get; set; }
        public Nullable<int> CityId { get; set; }
        public bool? PhoneNumberConfirmed { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> CreationTime { get; set; }
        public Nullable<System.DateTime> LastSeen { get; set; }
        public string Image { get; set; }
        public Nullable<bool> CanAddAds { get; set; }
        public Nullable<bool> MembershipType { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public Nullable<int> FreeAdCount { get; set; }
        public Nullable<byte> Type { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }

        public virtual ICollection<AdvertismentVM> Advertisements { get; set; }
        public virtual ICollection<CommercialAdsUserVM> CommercialAdsUsers { get; set; }
        public virtual ICollection<FeaturedAdvertisementVM> FeaturedAdvertisments { get; set; }
        public virtual ICollection<UserBundleVM> UserBundles { get; set; }

    }
}
