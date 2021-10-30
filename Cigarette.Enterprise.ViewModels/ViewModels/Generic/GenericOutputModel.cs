using Cigarette.Enterprise.ViewModels.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.ViewModels.Generic
{
    public class GenericOutputModel<T> where T :class
    {
        public PagingHeader Paging { get; set; }
        public List<LinkInfo> Links { get; set; }
        public List<LinkInfo> LinksNumbers { get; set; }
        public List<T> Items { get; set; }
    }
}
