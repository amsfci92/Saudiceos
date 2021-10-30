using Cigarette.Enterprise.ViewModels.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.BindingModels.AdminBindingModels.City
{
    [FluentValidation.Attributes.Validator(typeof(AddCityAdminBindingModelValidator))]
    public class AddCityAdminBindingModel
    {
        public int Id { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
        public int CountryId { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<bool> IsUpdated { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<System.DateTime> DeleteDate { get; set; }
        public string DeletedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
