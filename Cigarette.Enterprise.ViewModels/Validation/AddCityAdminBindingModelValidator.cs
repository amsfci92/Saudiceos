using Cigarette.Enterprise.ResourceManager.LanguagesResourceFiles;
using Cigarette.Enterprise.ViewModels.BindingModels.AdminBindingModels.City;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.Validation
{

    public class AddCityAdminBindingModelValidator : AbstractValidator<AddCityAdminBindingModel>
    {
        public AddCityAdminBindingModelValidator()
        {
            RuleFor(m => m.ArabicName).NotNull().WithMessage(HomeResource.AdminTextFieldValidationMessage);
            RuleFor(m => m.EnglishName).NotNull().WithMessage(HomeResource.AdminTextFieldValidationMessage);

        }
    }
}
