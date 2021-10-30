using Cigarette.Enterprise.ViewModels.ViewModels.UserInfo;
using Cigarette.Enterprise.ViewModels.ViewModels.WepAPIViewModel.Advertisement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.ViewModels.About
{
    public class AbuseReportVM
    {
        public int Id { get; set; }
        public Nullable<int> AdId { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string UserId { get; set; }
        public string Message { get; set; }
        public string Reason { get; set; }
        public Nullable<int> CountryId { get; set; }

        public virtual AdvertisementVM Advertisement { get; set; }
        public virtual UserInfoViewModel AspNetUser { get; set; }
    }
}
