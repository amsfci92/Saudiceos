using Cigarette.Enterprise.ViewModels.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.BindingModels.AdminBindingModels.Specification
{
    [FluentValidation.Attributes.Validator(typeof(AddSpecificationAdminBindingModelValidator))]
    public class AddSpecificationAdminBindingModel
    {
        public int Id { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public string CustomValue { get; set; }
        public bool AllowFiltering { get; set; }
        public int DisplayOrder { get; set; }
        public Nullable<bool> Required { get; set; }
        public Nullable<bool> MuliSelect { get; set; }
        public string EnglishName { get; set; }
        public string ArabicName { get; set; }
        public Nullable<int> SpeceficationId { get; set; }
    }
}
