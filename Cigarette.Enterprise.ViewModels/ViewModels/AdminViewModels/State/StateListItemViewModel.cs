using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.ViewModels.AdminViewModels.State
{
    public class StateListItemViewModel
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public int CountryId { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
       
    }
}
