using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.ViewModels.WepAPIViewModel
{
    public class CategorySpecificationOptionVM
    {
        public int Id { get; set; }
        public bool IsSelected { get; set; }

        public string ArabicName { get; set; }
        public string EnglishName { get; set; } 
    }
}
