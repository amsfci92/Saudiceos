using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.ViewModels.AdminViewModels.Specification
{
    public class SpecificationVm
    {
        public int Id { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
        public int DisplayOrder { get; set; }
        public int SpeceficationType { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}
