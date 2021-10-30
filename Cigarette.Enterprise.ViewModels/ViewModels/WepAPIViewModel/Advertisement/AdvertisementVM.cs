using Cigarette.Enterprise.ViewModels.ViewModels.AdvertismentImage;
using Cigarette.Enterprise.ViewModels.ViewModels.WepAPIViewModel.AdvertismentSpecification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.ViewModels.WepAPIViewModel.Advertisement
{
    public class AdvertisementVM
    {
        public AdvertisementVM()
        {
            Advertisment_Specification = new List<AdvertismentSpecificationVM>();
            AdvertismentImages = new List<AdvertismentImageBM>();
        }
        public int Id { get; set; } 
        public string ArabicDescription { get; set; }
        public string EnglishDescription { get; set; }

        public bool IsNogitable { get; set; }
        public decimal? Price { get; set; }

        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }

        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserPhone { get; set; }

        public string ArabicDescriptionUrl { get; set; }
        public string EnglishDescriptionUrl { get; set; }

        public string ArabicTitle { get; set; }
        public string EnglishTitle{ get; set; }

        public int CountryId { get; set; }
        public string CountryNameEnglish { get; set; }
        public string CountryNameArabic { get; set; }

        public decimal? LocationLatitude { get; set; }
        public decimal? LocationLongtude { get; set; }

        public bool? IsDisplayed { get; set; }
        public bool? IsDeleted { get; set; }

        public DateTime? CreationTime { get; set; }
        public DateTime? UpdateTime { get; set; }

        public int? ViewCount { get; set; }
        public int? CityId { get; set; }
        public string CityNameEnglish { get; set; }
        public string CityNameArabic { get; set; }
        public int StateId { get; set; }
        public string StateNameArabic { get; set; }
        public string StateNameEnglish { get; set; }

        public bool IsFavorite { get; set; }
        public bool IsActive { get; set; }

        public ICollection<AdvertismentSpecificationVM> Advertisment_Specification { get; set; }
        public ICollection<AdvertismentImageBM> AdvertismentImages { get; set; }
    }
}
