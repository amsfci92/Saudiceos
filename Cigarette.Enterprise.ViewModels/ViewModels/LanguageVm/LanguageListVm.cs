using Cigarette.Enterprise.DAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.ViewModels.LanguageVm
{
    public class LanguageListVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        [JsonIgnore]

        public virtual ICollection<Country.Country> Countries { get; set; }

    }
}
