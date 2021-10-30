using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.BindingModels.Bundle
{
    public class BundleBM
    {
        public int Id { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
        public Nullable<int> MinPeriod { get; set; }
        public Nullable<int> MaxPeriod { get; set; }
        public Nullable<int> MoveBy { get; set; }
        public Nullable<decimal> Cost { get; set; }
        public Nullable<int> AdsCount { get; set; }
        public Nullable<int> CountryId { get; set; }
        public bool Active { get; set; }
        
    }
}
