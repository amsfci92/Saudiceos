using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.ViewModels.Category
{
    public class CategoryWithSubViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CategoryLogo { get; set; }

        public List<CategoryViewModel> SubCategories { get; set; }
        public CategoryWithSubViewModel()
        {
            SubCategories = new List<CategoryViewModel>();
        }
    }
}
