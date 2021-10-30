using Cigarette.Enterprise.ViewModels.ViewModels.UserInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.ViewModels.CommercialAd
{
    public class CommercialAdsUserVM
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public Nullable<int> CommercialAdId { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<bool> Active { get; set; }

        public virtual UserInfoViewModel AspNetUser { get; set; }
        public virtual CommercialAdVM ComercialAd { get; set; }

    }
}
