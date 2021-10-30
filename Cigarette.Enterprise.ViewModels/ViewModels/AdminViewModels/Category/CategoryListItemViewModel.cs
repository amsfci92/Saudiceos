using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.ViewModels.AdminViewModels.Category
{
    public class CategoryListItemViewModel
    {
        public CategoryListItemViewModel()
        {
            SubCategories = new HashSet<CategoryListItemViewModel>();
        }

        public int Id { get; set; }
        public int CountryId { get; set; }
        public string ArabicDescription { get; set; }
        public string EnglishDescription { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public Nullable<bool> IsCommercialCategory { get; set; }
        public byte categoryLevel { get; set; }
        public string ImageUrl { get; set; }
        public bool HasHorizontalMenu { get; set; }
        public bool HasSub { get { return SubCategories.Any(); } set { } }
        public Nullable<int> imageId { get; set; }
        public bool? SearchForAll { get; set; }
        public ICollection<CategoryListItemViewModel> SubCategories { get; set; }
        public string CategoryLogo { get; set; }

        public List<CategoryListItemViewModel> SubCats { get; set; }
    }
}
