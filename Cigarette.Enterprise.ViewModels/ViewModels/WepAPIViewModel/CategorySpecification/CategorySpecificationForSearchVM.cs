using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Cigarette.Enterprise.ViewModels.ViewModels.WepAPIViewModel
{
    public class CategorySpecificationForSearchVM
    {
        public CategorySpecificationForSearchVM()
        {
            this.SpecificationOptions = new HashSet<CategorySpecificationOptionVM>();
        }

        public int Id { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public string CustomValue { get; set; }
        public bool IsCustomValue { get; set; }
        public Nullable<bool> Required { get; set; }
        public Nullable<bool> MuliSelect { get; set; }
        public string EnglishName { get; set; }
        public string ArabicName { get; set; }
        public Nullable<int> SpeceficationId { get; set; }

        public bool HasRange { get; set; } 

        public virtual CategoryVM Category { get; set; }

        [JsonIgnore]
        public virtual CategorySpecificationVM Specification { get; set; }

        public virtual ICollection<CategorySpecificationOptionVM> SpecificationOptions { get; set; }
    }
}
