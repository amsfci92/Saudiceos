using Cigarette.Enterprise.ViewModels.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.ViewModels.AdminViewModels.State
{
    [FluentValidation.Attributes.Validator(typeof(AddStateAdminBindingModelValidator))]
    public class AddStateAdminBindingModel
    {
        public int Id { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
        public Nullable<int> CityId { get; set; }
        public Nullable<int> CountryId { get; set; }
        public bool isActive { get; set; }
        public Nullable<System.DateTime> CreatoinTime { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<bool> IsUpdated { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<System.DateTime> DeleteDate { get; set; }
    }
}
