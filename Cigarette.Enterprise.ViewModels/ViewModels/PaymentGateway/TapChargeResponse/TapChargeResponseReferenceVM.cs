namespace Cigarette.Enterprise.ViewModels.ViewModels.PaymentGateway
{
    public class TapChargeResponseReferenceVM
    {
        public string transaction { get; set; }
        public string order { get; set; }
        public string track { get; set; }
        public string payment { get; set; }
        public string gateway { get; set; }
        public string acquirer { get; set; }  
    }
}