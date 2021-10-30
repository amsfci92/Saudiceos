using Cigarette.Enterprise.ViewModels.ViewModels.AdvertismentImage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.ViewModels.Advertisement
{
    public class AdvertisementViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<System.DateTime> Time { get; set; }
        public List<AdvertismentImageBM> AdvertismentImages { get; set; }
    }
}
