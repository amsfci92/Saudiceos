using System;

namespace Cigarette.Enterprise.ViewModels.ViewModels.AdminViewModels.Specification
{
    public class CategorySpecificationListItemViewModel
    {               
        public int Id { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public string CustomValue { get; set; }
        public bool AllowFiltering { get; set; }
        public int DisplayOrder { get; set; }
        public Nullable<bool> Required { get; set; }
        public Nullable<bool> MuliSelect { get; set; }
        public string EnglishName { get; set; }
        public string ArabicName { get; set; }
        public Nullable<int> SpeceficationId { get; set; }
        public Nullable<bool> HasOptions { get; set; }
         

        public string SpeceficationType { get; set; }
        public string CategoryName { get; set; }
    }
}
