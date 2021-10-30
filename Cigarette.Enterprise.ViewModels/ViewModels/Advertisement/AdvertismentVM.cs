using Cigarette.Enterprise.ViewModels.ViewModels.Category;
using Cigarette.Enterprise.ViewModels.ViewModels.UserInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.ViewModels.Advertisement
{
    public class AdvertismentVM
    {
        //public AdvertismentVM()
        //{
        //    this.Advertisment_Specification = new HashSet<Advertisment_Specification>();
        //    this.AdvertismentImages = new HashSet<AdvertismentImage>();
        //    this.AdvertismentImages1 = new HashSet<AdvertismentImage>();
        //    this.Favorites = new HashSet<Favorite>();
        //    this.FeaturedAdvertisments = new HashSet<FeaturedAdvertisment>();
        //}

        public int Id { get; set; }
        public string ArabicDescriptionUrl { get; set; }
        public string EnglishDescriptionUrl { get; set; }
        public string UserId { get; set; }
        public int CountryId { get; set; }
        public int CategoryId { get; set; }
        public Nullable<decimal> LocationLongtude { get; set; }
        public Nullable<decimal> LocationLatitude { get; set; }
        public string ArabicDescription { get; set; }
        public string EnglishDescription { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<bool> IsUpdated { get; set; }
        public Nullable<bool> IsDisplayed { get; set; }
        public Nullable<System.DateTime> CreationTime { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
        public Nullable<System.DateTime> DeleteTime { get; set; }
        public Nullable<decimal> Price { get; set; }
        public bool IsNogitable { get; set; }
        public string EnglishTitle { get; set; }
        public string ArabicTitle { get; set; }
        public Nullable<int> CityId { get; set; }
        public Nullable<int> StateId { get; set; }
        public string DeletedBy { get; set; }
        public Nullable<bool> IsNew { get; set; }
        public Nullable<bool> IsFree { get; set; }
        public Nullable<int> ViewCount { get; set; }

        public virtual UserInfoViewModel AspNetUser { get; set; }
        public virtual CategoryViewModel Category { get; set; }
    //    public virtual ICollection<Advertisment_Specification> Advertisment_Specification { get; set; }
    //    public virtual ICollection<AdvertismentImage> AdvertismentImages { get; set; }
    //    public virtual ICollection<AdvertismentImage> AdvertismentImages1 { get; set; }
    //    public virtual AdvertismetCategory AdvertismetCategory { get; set; }
    //    public virtual ICollection<Favorite> Favorites { get; set; }
    //    public virtual ICollection<FeaturedAdvertisment> FeaturedAdvertisments { get; set; }
    }
}
