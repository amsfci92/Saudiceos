using AutoMapper;
using Cigarette.Enterprise.DAL;
using Cigarette.Enterprise.DAL.Repository;
using Cigarette.Enterprise.ViewModels.BindingModels.AdminBindingModels.City;
using Cigarette.Enterprise.ViewModels.ViewModels.AdminViewModels.City;
using System.Collections.Generic;
using System.Linq;

namespace Cigarette.Enterprise.BLL.CityServ
{
    public class CityService : ICityService
    {
        private IUnitOfWork unitOfWork { get; }
        public CityService(
            IUnitOfWork unitOfWork
            )
        {
            this.unitOfWork = unitOfWork;
        }

        public bool AddCity(AddCityAdminBindingModel cityModel)
        {
            City entity = Mapper.Map<City>(cityModel);

            int result = unitOfWork.Cities.Add(entity);

            if (result == 0)
            {
                return false;
            }

            return true;
        }

        public List<CityListItemViewModel> GetCountryCities(int countryId)
        {
            List<City> cities = unitOfWork.Cities.GetCitiesByCountry(countryId);

            var mappedCities = cities.Select(
                m =>  Mapper.Map<CityListItemViewModel>(m)
                ).ToList();

            return mappedCities;
        }

        public List<CityListItemViewModel> GetCities()
        {
            List<City> cities = unitOfWork.Cities.GetAll().ToList();

            var mappedCities = cities.Select(
                m => Mapper.Map<CityListItemViewModel>(m)
                ).ToList();

            return mappedCities;
        }
    }
}
