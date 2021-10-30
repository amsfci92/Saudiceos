using Cigarette.Enterprise.DAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.ViewModels.CurrencyVm
{
    public class CurrencyListVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbr { get; set; }
        [JsonIgnore]
        public virtual ICollection<Country.Country> Countries { get; set; }
    }
}
