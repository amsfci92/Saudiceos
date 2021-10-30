using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Cigarette.Enterprise.ViewModels.ViewModels.CommercialAd
{
    public class SystemDataFileVM
    {
        public SystemDataFileVM()
        {
            this.ComercialAds = new HashSet<CommercialAdVM>();
        }

        public int Id { get; set; }
        public string Url { get; set; }
        public Nullable<decimal> Size { get; set; }
        public string Extention { get; set; }
        public Nullable<int> Type { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<bool> IsAssinged { get; set; }
        [JsonIgnore]
        public virtual ICollection<CommercialAdVM> ComercialAds { get; set; }
    }
}