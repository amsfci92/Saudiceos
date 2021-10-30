using Cigarette.Enterprise.ResourceManager.LanguagesResourceFiles;
using Cigarette.Enterprise.ViewModels.BindingModels.AdminBindingModels.City;
using Cigarette.Enterprise.ViewModels.BindingModels.AdminBindingModels.Specification;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.Validation
{

    public class AddSpecificationAdminBindingModelValidator 
        : AbstractValidator<AddSpecificationAdminBindingModel>
    {
        public AddSpecificationAdminBindingModelValidator()
        {
            RuleFor(m => m.ArabicName).NotNull().WithMessage(HomeResource.AdminNewSpecificationErrorMessage);
            RuleFor(m => m.EnglishName).NotNull().WithMessage(HomeResource.AdminNewSpecificationErrorMessage);

        }
    }
}
