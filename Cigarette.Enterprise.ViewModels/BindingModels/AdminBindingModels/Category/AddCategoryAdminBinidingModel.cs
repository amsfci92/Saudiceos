using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.BindingModels.AdminBindingModels.Category
{

    public class AddCategoryAdminBinidingModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CountryId { get; set; }
        public string ArabicDescription { get; set; }
        public string EnglishDescription { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDelneted { get; set; }
        public Nullable<bool> IsUpdated { get; set; }
        public Nullable<bool> IsDisplayed { get; set; }

        public Nullable<System.DateTime> CreationTime { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
        public Nullable<System.DateTime> DeleteTime { get; set; }
    }
}
