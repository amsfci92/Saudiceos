using Cigarette.Enterprise.ResourceManager.LanguagesResourceFiles;
using Cigarette.Enterprise.ViewModels.BindingModels.AdminBindingModels.Country;
using Cigarette.Enterprise.ViewModels.ViewModels.AdminViewModels.Category;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.Validation
{
    class AddCountryBinidingModelValidator : AbstractValidator<AddCountryBindingModel>
    {
        public AddCountryBinidingModelValidator()
        {
            RuleFor(m => m.ArabicName).MaximumLength(300).NotNull().WithMessage(HomeResource.AdminTextFieldValidationMessage);

            RuleFor(m => m.EnglishName).NotNull()
                .WithMessage(m => HomeResource.AdminTextFieldValidationMessage);
        }
    }
}
