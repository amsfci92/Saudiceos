using System.ComponentModel.DataAnnotations;

namespace Cigarette.Enterprise.ViewModels.ViewModels.Advertisement
{
    public class FeaturedAdvertisementBM
    {
        [Required]
        public int AdvertismentId { get; set; }
        
        [Required]
        public int PaymentTransactionId { get; set; }
    }

}
