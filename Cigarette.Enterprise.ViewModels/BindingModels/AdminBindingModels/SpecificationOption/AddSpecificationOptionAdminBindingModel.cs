using Cigarette.Enterprise.ViewModels.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.ViewModels.AdminViewModels.SpecificationOption
{
    [FluentValidation.Attributes.Validator(typeof(AddSpecificationOptionAdminBindingModelValidator))]

    public class AddSpecificationOptionAdminBindingModel
    {
        public int Id { get; set; }
        public int Category_SpecificationId { get; set; }
        public string EnglishName { get; set; }
        public string ArabicName { get; set; }
        public string ColorSquaresRgb { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public Nullable<System.DateTime> CreatoinTime { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<System.DateTime> DeleteDate { get; set; }
    }
}
