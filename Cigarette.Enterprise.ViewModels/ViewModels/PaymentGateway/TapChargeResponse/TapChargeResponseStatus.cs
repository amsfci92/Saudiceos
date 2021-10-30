namespace Cigarette.Enterprise.ViewModels.ViewModels.PaymentGateway
{
    public class TapChargeResponseStatus
    {
        public static string INITIATED { get; set; } = "INITIATED".ToUpper();
        public static string IN_PROGRESS { get; set; } = "IN_PROGRESS".ToUpper();
        public static string Expired { get; set; } = "Expired".ToUpper();
        public static string Abandoned { get; set; } = "Abandoned".ToUpper();
        public static string Authorized { get; set; } = "Authorized".ToUpper();
        public static string Declined { get; set; } = "Declined".ToUpper();
    }
}