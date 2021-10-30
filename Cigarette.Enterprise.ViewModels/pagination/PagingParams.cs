using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.Pagination
{
    public class PagingParams
    {
        
        public int Page { get; set; } = 1;
        public int Size { get; set; } = 16;
    }
}
