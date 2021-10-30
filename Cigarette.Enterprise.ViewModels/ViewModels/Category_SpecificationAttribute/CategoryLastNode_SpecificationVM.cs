using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.ViewModels.Category_SpecificationAttribute
{
    public class CategoryLastNode_SpecificationVM
    {
        public CategoryLastNode_SpecificationVM()
        {
            Specification_Options = new List<CategoryLastNode_Specification_OptionsVM>();
        }

        public int Id { get; set; }
        
        public string CustomValue { get; set; }
        
        public int DisplayOrder { get; set; }
        public Nullable<bool> Required { get; set; }
        public Nullable<bool> MuliSelect { get; set; }
        public string EnglishName { get; set; }
        public string ArabicName { get; set; }
        
        
        
        public Nullable<bool> IsCustomValue { get; set; }

        public CategoryLastNode_Specification_SpecificationVM Specification { get; set; }
        public List<CategoryLastNode_Specification_OptionsVM> Specification_Options { get; set; }
    }

    public class CategoryLastNode_Specification_OptionsVM
    {
        public int Id { get; set; }
        
        public string EnglishName { get; set; }
        public string ArabicName { get; set; }
        public string ColorSquaresRgb { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public bool? IsDeleted { get; set; }
    }
    public class CategoryLastNode_Specification_SpecificationVM
    {
        public int Id { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
        public int DisplayOrder { get; set; }
        public int SpeceficationType { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> HasOptions { get; set; }
    }
}
