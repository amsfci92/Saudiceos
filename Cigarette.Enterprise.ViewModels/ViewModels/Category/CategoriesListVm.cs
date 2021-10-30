using Cigarette.Enterprise.DAL;
using Cigarette.Enterprise.ViewModels.ViewModels.Advertisement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.ViewModels.Category
{
    public class CategoriesListVm
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CountryId { get; set; }
        public string EnglishName { get; set; }
        public string ArabicName { get; set; }
        public byte categoryLevel { get; set; }
        public virtual ICollection<AdvertisementViewModel> Advertisements { get; set; } 
        public virtual ICollection<CategoryViewModel> ChildCategories { get; set; }
        public virtual ICollection<Country.Country> Countries { get; set; }
         

    }
}
