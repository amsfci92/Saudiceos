using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.ViewModels.Advertisement
{
    public class AdvertisementPostViewModel
    {
        public string UserId { get; set; }
        public int CountryId { get; set; }
        public int CategoryId { get; set; }
        //public Nullable<decimal> LocationLongtude { get; set; }
        //public Nullable<decimal> LocationLatitude { get; set; }
        public string ArabicDescription { get; set; }
        public string EnglishDescription { get; set; }
        public string ArabicDescriptionUrl { get; set; }
        public string EnglishDescriptionUrl { get; set; }
        //public Nullable<bool> IsActive { get; set; }
        //public Nullable<bool> IsDeleted { get; set; }
        //public Nullable<bool> IsUpdated { get; set; }
        //public Nullable<bool> IsDisplayed { get; set; }
        public Nullable<System.DateTime> CreationTime { get; set; }
        //public Nullable<System.DateTime> UpdateTime { get; set; }
        //public Nullable<System.DateTime> DeleteTime { get; set; }
        public Nullable<decimal> Price { get; set; }
        public bool IsNogitable { get; set; }
        public string EnglishTitle { get; set; }
        public string ArabicTitle { get; set; }
        public Nullable<int> CityId { get; set; }
        //public Nullable<int> StateId { get; set; }
        //public string DeletedBy { get; set; }


        public List<AdvertisementSpecificationPostViewModel> AdvertisementSpecificationPostViewModels;

        public AdvertisementPostViewModel()
        {
            AdvertisementSpecificationPostViewModels = new List<AdvertisementSpecificationPostViewModel>();
        }
    }

    public class AdvertisementSpecificationPostViewModel
    {
        public int CategoryId { get; set; }
        public int CategorySpecificationAttributeTypeId { get; set; }
        public int SpecificationAttributeOptionId { get; set; }
        public string CustomValue { get; set; }
        public bool AllowFiltering { get; set; }
        public int DisplayOrder { get; set; }
        public List<AdvertisementSpecificationOptionPostViewModel> AdvertisementSpecificationOptionPostViewModels;
        public AdvertisementSpecificationPostViewModel()
        {
            AdvertisementSpecificationOptionPostViewModels =
                new List<AdvertisementSpecificationOptionPostViewModel>();
        }
    }

    public class AdvertisementSpecificationOptionPostViewModel
    {
        public Nullable<int> SpecificationOptionId { get; set; }
    }
}
