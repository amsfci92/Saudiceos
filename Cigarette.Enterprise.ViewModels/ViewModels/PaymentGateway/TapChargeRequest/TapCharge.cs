namespace Cigarette.Enterprise.ViewModels.ViewModels.PaymentGateway
{
    public class TapCharge
    {
        public double amount { get; set; }
        public string currency { get; set; }
        public bool threeDSecure { get; set; }
        public bool saveCard { get; set; }
        public string description { get; set; }
        public string statement_descriptor { get; set; }

        public TapChargeMetaData metadata { get; set; }
        public TapChargeReference reference { get; set; }
        public TapChargeCustomer customer { get; set; }
        public TapChargeReceipt receipt { get; set; }
        public TapChargeSource source { get; set; }
        public TapChargePhone phone { get; set; }
        public TapChargeUrl post { get; set; }
        public TapChargeUrl redirect { get; set; }
    }
} 