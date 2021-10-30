using Cigarette.Enterprise.ViewModels.BindingModels.AdminBindingModels.Country;
using Cigarette.Enterprise.ViewModels.ViewModels.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.ViewModels.SmsGateway
{
    public class SmsGatewayVM
    {
        public int Id { get; set; }
        public string UrlDescription { get; set; }
        public int CountryId { get; set; } 

        public virtual AddCountryBindingModel Country { get; set; }
    }
}
