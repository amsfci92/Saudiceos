 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.DAL.Pagination
{
    public class PagingHeader
    {
        public PagingHeader(
           int totalItems, int page, int Size, int totalPages)
        {
            this.TotalItems = totalItems;
            this.Page = page;
            this.Size = Size;
            this.TotalPages = totalPages;
        }

        public int TotalItems { get; }
        public int Page { get; }
        public int Size { get; }
        public int TotalPages { get; }

        public string ToJson() => "";
    }
}
