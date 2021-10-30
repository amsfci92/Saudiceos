using Cigarette.Enterprise.ViewModels.ViewModels.SpecificationAttributeOption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.BindingModels.Advertisement_SpecificationAttribute
{
    public class Advertisement_SpecificationAttributeBindingModel
    {
        public int CategorySpecificationId { get; set; }
        //public int SpecificationAttributeOptionId { get; set; }
        public string CustomValue { get; set; }

        public List<AdvertisementSpecificationAttributeOptionBindingViewModel> Options;

        public Advertisement_SpecificationAttributeBindingModel()
        {
            Options = new List<AdvertisementSpecificationAttributeOptionBindingViewModel>();
        }

    }
    public class AdvertisementSpecificationAttributeOptionBindingViewModel
    {
        public int SpecificationOptionId { get; set; }
    }


      
}
