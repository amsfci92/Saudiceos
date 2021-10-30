using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.BindingModels.PaymentTransaction
{
    public class PaymentTransactionBM
    {
        public long Id { get; set; }
        public Nullable<int> PaymentMethodId { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public string UserId { get; set; }
        public Nullable<decimal> TotalPayment { get; set; }
        public string Description { get; set; }
        public string ReferenceId { get; set; }
        public bool Status { get; set; }
    }
}
