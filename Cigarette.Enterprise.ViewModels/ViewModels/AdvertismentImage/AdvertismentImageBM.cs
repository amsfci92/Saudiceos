using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.ViewModels.AdvertismentImage
{
    public class AdvertismentImageBM
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public decimal? Size { get; set; }
        public bool IsImage { get; set; }
        public DateTime? CreationDate { get; set; } 
    }
}
