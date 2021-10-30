using Cigarette.Enterprise.ViewModels.ViewModels.PaymentTransaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.ViewModels.PaymentGateway
{
    public class PaymentGatewayVM
    {
        public PaymentGatewayVM()
        {
            this.PaymentTransactions = new HashSet<PaymentTransactionVM>();
        }

        public int Id { get; set; }
        public string GatewayLink { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public Nullable<int> Order { get; set; }
        public string Logo { get; set; }
        public Nullable<int> CountryId { get; set; }
         
        public virtual ICollection<PaymentTransactionVM> PaymentTransactions { get; set; }
    }
}
