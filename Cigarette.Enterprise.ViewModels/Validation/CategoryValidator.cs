using Cigarette.Enterprise.ResourceManager.LanguagesResourceFiles;
using Cigarette.Enterprise.ViewModels.ViewModels.AdminViewModels.Category;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.Validation
{
    class CategoryValidator : AbstractValidator<AddCategoryModel>
    {
        public CategoryValidator()
        {
            RuleFor(m => m.ArabicDescription).NotNull().WithMessage(m=> CategoryResource.AdminNewCategoryNullError)
                .MaximumLength(300);

            RuleFor(m => m.CountryId).NotNull()
                .WithMessage(m => CategoryResource.AdminNewCategoryNullError);
        }
    }
}
