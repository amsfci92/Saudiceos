using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.VM.Breadcrumb
{
    public class BreadcrumbVM
    {
        public string Title { get; set; }
        public List<BreadcrumbItem> BreadcrumbItems { get; set; }
    }

    public enum AdPlace
    {
        HomePage = 0,
        CeoPage = 1,
        NewsPage = 2,
        ServicePage = 3,
        AllPages = 4
    }
    public enum AdType
    {
        Fixed = 0,
        Slider = 1, 
    }
}
