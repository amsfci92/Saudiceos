using Cigarette.Enterprise.ViewModels.ViewModels.AdminViewModels.Category;
using Cigarette.Enterprise.ViewModels.ViewModels.CommercialAdsCategory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.ViewModels.CommercialAd
{
    public class CommercialAdBM
    {
        public int Id { get; set; }
        [Required]
        public Nullable<int> imageId { get; set; }
        [Required]
        public Nullable<int> imageMobileId { get; set; }
        [Required]
        public Nullable<byte> Type { get; set; }
        [Required]
        public string Description { get; set; }
        public string Link { get; set; }
        public string WhatsappLink { get; set; }
        public string InstagramLink { get; set; }
        [Required]
        [DataType(DataType.Date)]

        public Nullable<DateTime> CreationDate { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public Nullable<DateTime >EndDate { get; set; }
        public bool Active { get; set; }
        public Nullable<int> Notification { get; set; }
        [Required]
        public Nullable<int> CountryId { get; set; }
        public long ViewsCount { get; set; }
        public int Likes { get; set; } 
        public Nullable<int> CategoryId { get; set; }
       // [Required]
        public Nullable<int> CategoryId1 { get; set; } 
        public virtual CategoryListItemViewModel Category { get; set; }

        public int OldImageId { get; set; }
        public int OldCountryId { get; set; }
        public int OldCategoryId { get; set; }
    }
}
