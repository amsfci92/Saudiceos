using Cigarette.Enterprise.ViewModels.ViewModels.PaymentGateway;
using Cigarette.Enterprise.ViewModels.ViewModels.UserBundle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.ViewModels.PaymentTransaction
{
    public class PaymentTransactionVM
    {
        public PaymentTransactionVM()
        {
             
            this.UserBundles = new HashSet<UserBundleVM>();
        }

        public long Id { get; set; }
        public Nullable<int> PaymentMethodId { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public string UserId { get; set; }
        public Nullable<decimal> TotalPayment { get; set; }
        public string Description { get; set; }
         
        public virtual PaymentGatewayVM PaymentGateway { get; set; }
        public virtual ICollection<UserBundleVM> UserBundles { get; set; }
        public string ReferenceId { get; set; }
    }
}
