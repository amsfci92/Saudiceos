using Cigarette.Enterprise.ViewModels.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.ViewModels.AdminViewModels.Specification
{
    public class SpecificationListItemViewModel
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public int SpeceficationType { get; set; }
        public Nullable<bool> IsActive { get; set; }  
    }
}
