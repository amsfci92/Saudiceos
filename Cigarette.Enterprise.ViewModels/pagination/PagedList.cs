using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.Pagination
{
    public class PagedList<T> where T : class
    {
        public PagedList(IQueryable<T> source, int page = 1, int Size=10)
        {

            this.TotalItems = source.Count();
            this.Page = page;
            this.Size = Size;
            this.List = source.Skip(Size * (page - 1))
                            .Take(Size)
                            .ToList();

        }

        public int TotalItems { get; }
        public int Page { get; }
        public int Size { get; }
        public List<T> List { get; }
        public int TotalPages =>
              (int)Math.Ceiling(this.TotalItems / (double)this.Size);
        public bool HasPreviousPage => this.Page > 1;
        public bool HasNextPage => this.Page < this.TotalPages;
        public int NextPage =>
               this.HasNextPage ? this.Page + 1 : this.TotalPages;
        public int PreviousPage =>
               this.HasPreviousPage ? this.Page - 1 : 1;

        public PagingHeader GetHeader()
        {
            return new PagingHeader(
                 this.TotalItems, this.Page,
                 this.Size, this.TotalPages);
        }
    }
}
