using Cigarette.Enterprise.ViewModels.BindingModels.AdminBindingModels.City;
using Cigarette.Enterprise.ViewModels.ViewModels.AdminViewModels.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.BLL.CityServ
{
    public interface ICityService
    {
        List<CityListItemViewModel> GetCountryCities(int countryId);
        bool AddCity(AddCityAdminBindingModel cityModel);
        List<CityListItemViewModel> GetCities();
    }
}
