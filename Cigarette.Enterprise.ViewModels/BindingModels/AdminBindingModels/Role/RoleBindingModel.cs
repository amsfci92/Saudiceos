using Cigarette.Enterprise.ViewModels.Validation;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.BindingModels.AdminBindingModels.Role
{
    [Validator(typeof(RoleBindingModelValidator))]
    public class RoleBindingModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
