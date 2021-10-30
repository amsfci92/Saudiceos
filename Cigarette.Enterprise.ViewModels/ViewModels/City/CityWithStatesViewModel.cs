using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.ViewModels.City
{
    public class CityWithStatesViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CityStatesViewModel> States;
        public CityWithStatesViewModel()
        {
            States = new List<CityStatesViewModel>();
        }
    }

    public class CityStatesViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
