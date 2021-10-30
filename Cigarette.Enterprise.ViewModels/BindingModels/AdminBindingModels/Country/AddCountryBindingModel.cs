using Cigarette.Enterprise.ViewModels.Validation;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Cigarette.Enterprise.ViewModels.BindingModels.AdminBindingModels.Country
{
    [Validator(typeof(AddCountryBinidingModelValidator))]
    public class AddCountryBindingModel : BaseModel
    { 
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
        [Required]
        public int CurrencyId { get; set; }
        [Required]
        public int LanguageId { get; set; }
        public int FlagId { get; set; }
        public bool isActive { get; set; }
        public Nullable<System.DateTime> CreatoinTime { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<bool> IsUpdated { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<System.DateTime> DeleteDate { get; set; }
        public string DeletedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string Flag { get; set; }
        public Nullable<decimal> FeaturedAdCost { get; set; }
        public Nullable<int> FreeAdCount { get; set; }
        [Required]
        public Nullable<int> imageId { get; set; }
        public string PhoneKey { get; set; }
        public string PaymentSecretKey { get; set; }
        public string PaymenSharedKey { get; set; }
        public string AbbrArabic { get; set; }
        public string Abbr { get; set; }

        public HttpPostedFileWrapper CountryFlag { get; set; }
        public string FlagChanged { get; set; }
    }
}
