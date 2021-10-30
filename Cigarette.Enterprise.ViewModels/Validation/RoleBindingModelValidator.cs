using Cigarette.Enterprise.ResourceManager.LanguagesResourceFiles;
using Cigarette.Enterprise.ViewModels.BindingModels.AdminBindingModels.Role;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.Validation
{

    public class RoleBindingModelValidator : AbstractValidator<RoleBindingModel>
    {
        public RoleBindingModelValidator()
        {
            RuleFor(m => m.Name).NotEmpty().WithMessage(m => HomeResource.CountryNameNotNull);
        }
    }
}
