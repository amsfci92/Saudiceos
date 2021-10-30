using Cigarette.Enterprise.ViewModels.ViewModels.Bundle;
using Cigarette.Enterprise.ViewModels.ViewModels.PaymentTransaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.ViewModels.UserBundle
{
    public class UserBundleVM
    {
        public int Id { get; set; }
        public Nullable<int> BundleId { get; set; }
        public string UserId { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<int> AvailableAds { get; set; }
        public Nullable<long> PaymentTransactionId { get; set; }
         
        public virtual BundleVM Bundle { get; set; }
        public virtual PaymentTransactionVM PaymentTransaction { get; set; }
    } 
}
