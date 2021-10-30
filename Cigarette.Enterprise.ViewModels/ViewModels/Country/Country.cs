using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.ViewModels.Country
{
        public partial class Country
        {
            

            public int Id { get; set; }
            public string ArabicName { get; set; }
            public string EnglishName { get; set; }
            public bool isActive { get; set; }
            public Nullable<System.DateTime> CreatoinTime { get; set; }
            public Nullable<bool> IsDeleted { get; set; }
            public Nullable<bool> IsUpdated { get; set; }
            public Nullable<System.DateTime> UpdateDate { get; set; }
            public Nullable<System.DateTime> DeleteDate { get; set; }
            public string DeletedBy { get; set; }
            public string UpdatedBy { get; set; }
            public Nullable<int> LanguageId { get; set; }
            public Nullable<int> CurrencyId { get; set; }
            public string Flag { get; set; }

         
        }

}
