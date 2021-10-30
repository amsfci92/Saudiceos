using System.Collections.Generic;

namespace Cigarette.Enterprise.ViewModels.BindingModels.WepAPIBindingModel.Advertisment
{
    public class AdvancedSearchMainModel
    {
        public double PriceMin { get; set; }
        public double PriceMax { get; set; }
        public bool IsNew { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public int CategoryId { get; set; }
        public string Key { get; set; }

        public List<AdvancedSearchParametersBM> Params { get; set; }
    }
}
