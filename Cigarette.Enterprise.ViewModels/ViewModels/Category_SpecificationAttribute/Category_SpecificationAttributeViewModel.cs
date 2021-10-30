using Cigarette.Enterprise.ViewModels.ViewModels.SpecificationAttributeOption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.ViewModels.Category_SpecificationAttribute
{
    public class Category_SpecificationAttributeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SpeceficationType { get; set; }
        public Nullable<bool> Required { get; set; }
        public Nullable<bool> MuliSelect { get; set; }

        public List<SpecificationAttributeOptionViewModel> Options;

        public Category_SpecificationAttributeViewModel()
        {
            Options = new List<SpecificationAttributeOptionViewModel>();
        }
    }


}
