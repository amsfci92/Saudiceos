using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.BindingModels.UserBundle
{
    public class UserBundleBM
    {
        public int Id { get; set; }
        public Nullable<int> BundleId { get; set; }
        public string UserId { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; } 
        public Nullable<System.DateTime> EndDate { get; set; } 
        public int Period { get; set; }
        public Nullable<int> AvailableAds { get; set; }
        public Nullable<long> PaymentTransactionId { get; set; }
    }
}
