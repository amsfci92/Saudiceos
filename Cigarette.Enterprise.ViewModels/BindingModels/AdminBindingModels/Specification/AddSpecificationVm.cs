using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.BindingModels.AdminBindingModels.Specification
{
    public class AddSpecificationVm
    {

        public int Id { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
        public int DisplayOrder { get; set; }
        public int SpeceficationType { get; set; }
        public bool IsActive { get; set; }

    }
}
