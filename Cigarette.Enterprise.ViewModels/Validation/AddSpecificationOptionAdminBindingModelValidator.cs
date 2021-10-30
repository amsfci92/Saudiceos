using Cigarette.Enterprise.ResourceManager.LanguagesResourceFiles;
using Cigarette.Enterprise.ViewModels.BindingModels.AdminBindingModels.City;
using Cigarette.Enterprise.ViewModels.ViewModels.AdminViewModels.SpecificationOption;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.Validation
{

    public class AddSpecificationOptionAdminBindingModelValidator 
        : AbstractValidator<AddSpecificationOptionAdminBindingModel>
    {
        public AddSpecificationOptionAdminBindingModelValidator()
        {
            RuleFor(x => x.ArabicName).NotEmpty().WithMessage(HomeResource.AdminNewSpecificationErrorMessage);
            RuleFor(x => x.EnglishName).NotEmpty().WithMessage(HomeResource.AdminNewSpecificationErrorMessage);
        }
    }
}
