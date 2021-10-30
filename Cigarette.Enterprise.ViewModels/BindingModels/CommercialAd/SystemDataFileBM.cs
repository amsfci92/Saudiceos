using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.BindingModels.CommercialAd
{
    public class SystemDataFileBM
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public Nullable<decimal> Size { get; set; }
        public string Extention { get; set; }
        public Nullable<int> Type { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<bool> IsAssinged { get; set; }
    }
}
