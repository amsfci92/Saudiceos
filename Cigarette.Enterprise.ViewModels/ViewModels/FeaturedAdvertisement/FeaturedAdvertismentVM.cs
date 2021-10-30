using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.ViewModels.Advertisement
{
    public class FeaturedAdvertisementViewModel
    {
        [Required]
        public int AdvertismentId { get; set; } 
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [Required] 
        public int Duration { get; set; }
        public decimal Cost { get; set; }
        [Required]
        public int PaymentTransactionId { get; set; }
        public string UserId { get; set; }
    }

}
