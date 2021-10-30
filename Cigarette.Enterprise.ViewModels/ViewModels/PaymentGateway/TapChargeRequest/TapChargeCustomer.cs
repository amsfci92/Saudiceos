namespace Cigarette.Enterprise.ViewModels.ViewModels.PaymentGateway
{
    public class TapChargeCustomer
    {
        public string id { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public TapChargePhone phone { get; set; } 
    }
} 