using Cigarette.Enterprise.ViewModels.BindingModels.Advertisement_SpecificationAttribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.BindingModels.Advertisement
{
    public class AdvertisementBindingModel
    {

        public string UserId { get; set; }
        public int CategoryId { get; set; }
        public string ArabicDescription { get; set; }
        public string EnglishDescription { get; set; }
        public Nullable<System.DateTime> CreationTime { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string EnglishTitle { get; set; }
        public string ArabicTitle { get; set; }
        public Nullable<int> CityId { get; set; }
        public Nullable<int> StateId { get; set; }

        public List<Advertisement_SpecificationAttributeBindingModel> Advertisment_SpecificationAttributes;

        public AdvertisementBindingModel()
        {
            Advertisment_SpecificationAttributes = new List<Advertisement_SpecificationAttributeBindingModel>();
        }

    }
}
