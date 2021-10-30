using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.BindingModels.WepAPIBindingModel.Advertisment
{
    public class AdvertismentSpecificationBM
    {
        public AdvertismentSpecificationBM()
        {
            AdvertismentSpecificatioOptions = new List<int>();
        }
        public int Id { get; set; }
        public string CustomValue { get; set; }
        public List<int> AdvertismentSpecificatioOptions { get; set; }
    }
}
