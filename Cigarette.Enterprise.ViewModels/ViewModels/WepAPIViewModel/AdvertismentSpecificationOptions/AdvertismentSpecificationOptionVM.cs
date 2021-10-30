using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.ViewModels.WepAPIViewModel.AdvertismentSpecificationOptions
{
    public class AdvertismentSpecificationOptionVM
    {
        public int Id { get; set; }
        public int? AdvertismentSpecificationId { get; set; }

        public string NameEnglish { get; set; }
        public string NameArabic { get; set; }


        public int SpecificationOptionId { get; set; }
    }
}
