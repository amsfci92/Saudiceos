using Cigarette.Enterprise.ViewModels.ViewModels.AdminViewModels.Category;
using Cigarette.Enterprise.ViewModels.ViewModels.AdminViewModels.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.ViewModels.AdminViewModels.Country
{
    public class CountryDetailsViewModel
    {
        public List<CityListItemViewModel> Cities { get; set; }
        public List<CategoryListItemViewModel> Categories { get; set; }
        public CountryListItemViewModel Country { get; set; }
    }
}
