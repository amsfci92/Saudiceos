using Cigarette.Enterprise.ViewModels.ViewModels.Category;
using Cigarette.Enterprise.ViewModels.ViewModels.UserInfo;
using Cigarette.Enterprise.ViewModels.ViewModels.WepAPIViewModel.Advertisement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.ViewModels.FeaturedAdvertisement
{
    public class FeaturedAdvertisementVM
    {
        public int Id { get; set; }
        public Nullable<int> AdvertismentId { get; set; }
        public string UserId { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<int> Duration { get; set; }
        public Nullable<decimal> Cost { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public Nullable<long> PaymentTransactionId { get; set; }

        public virtual AdvertisementVM Advertisement { get; set; }
        public virtual UserInfoViewModel AspNetUser { get; set; }
        public virtual CategoryViewModel Category { get; set; }
        //public virtual PaymentTransaction PaymentTransaction { get; set; }
    }
}
