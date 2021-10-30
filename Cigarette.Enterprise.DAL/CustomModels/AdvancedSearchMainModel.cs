using System.Collections.Generic;

namespace Cigarette.Enterprise.DAL.CustomModels
{
    public class AdvancedSearchMainModelDAL
    {
        public double PriceMin { get; set; }
        public double PriceMax { get; set; }
        public bool IsNew { get; set; }
        public int CountryId { get; set; }
        public int CategoryId { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }

        public List<SearchParamsModel> Params { get; set; }
    }
}
