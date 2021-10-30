using Cigarette.Enterprise.ViewModels.ViewModels.WepAPIViewModel.AdvertismentSpecificationOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.ViewModels.WepAPIViewModel.AdvertismentSpecification
{
    public class AdvertismentSpecificationVM
    {
        public AdvertismentSpecificationVM()
        {
            AdvertismentSpecificatioOptions = new List<AdvertismentSpecificationOptionVM>();
        }

        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int AdvertismentId { get; set; }
        public int CategorySpecificationId { get; set; } 
        public string NameEnglish { get; set; }
        public string NameArabic { get; set; }
        public string CustomValue { get; set; }

        public List<AdvertismentSpecificationOptionVM> AdvertismentSpecificatioOptions { get; set; }
        public CategorySpecificationVM CategorySpecificationVM { get; set; }
        public List<AdvertismentSpecificationOptionVM> AdvertismentSpecificationOptions { get; set; }
    }
}
