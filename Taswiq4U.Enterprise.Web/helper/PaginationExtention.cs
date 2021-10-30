using Cigarette.Enterprise.ViewModels.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Saudiceos.Enterprise.Web.helper
{
    public class PaginationExtention
    {
        private readonly UrlHelper _urlHelper;
        public PaginationExtention()
        {
            _urlHelper = new UrlHelper(System.Web.HttpContext.Current.Request.RequestContext);
        }

        public List<LinkInfo> GetLinksNumbers<T>(PagedList<T> list, string routeName)
            where T : class
        {
            var links = new List<LinkInfo>();

            for (int i = 1; i <= list.TotalPages; i++)
            {
                links.Add(CreateLink(routeName, i,
                           list.Size, "Page" + i, "GET"));
            }
            return links;
        }



        public List<LinkInfo> GetLinks<T>(PagedList<T> list, string routeName)
            where T : class
        {
            var links = new List<LinkInfo>();

            if (list.HasPreviousPage)
                links.Add(CreateLink(routeName, list.PreviousPage,
                           list.Size, "previousPage", "GET"));

            links.Add(CreateLink(routeName, list.Page,
                           list.Size, "self", "GET"));

            if (list.HasNextPage)
                links.Add(CreateLink(routeName, list.NextPage,
                           list.Size, "nextPage", "GET"));

            return links;
        }


        private LinkInfo CreateLink(string routeName, int page, int Size,
            string rel, string method)
        {
            return new LinkInfo
            {
                Href = _urlHelper.RouteUrl(routeName,
                            new { Page = page, Size = Size }),
                Rel = rel,
                Method = method
            };
        }




        public List<LinkInfo> GetLinksForSearch<T>(PagedList<T> list, string routName,
            int? cityId,
            string City, int? CategoryId, string Category, string Term)
            where T : class
        {
            var links = new List<LinkInfo>();

            if (list.HasPreviousPage)
                links.Add(CreateLinkForSearch(routName, list.PreviousPage,
                           list.Size, "previousPage", "GET", cityId, City, CategoryId, Category, Term));

            links.Add(CreateLinkForSearch(routName, list.Page,
                           list.Size, "self", "GET", cityId, City, CategoryId, Category, Term));

            if (list.HasNextPage)
                links.Add(CreateLinkForSearch(routName, list.NextPage,
                           list.Size, "nextPage", "GET", cityId, City, CategoryId, Category, Term));

            return links;
        }

        public List<LinkInfo> GetLinksNumbersForSearch<T>(PagedList<T> list, string routeName,
            int? cityId,
            string City, int? CategoryId, string Category, string Term)
            where T : class
        {
            var links = new List<LinkInfo>();

            for (int i = 1; i <= list.TotalPages; i++)
            {
                links.Add(CreateLinkForSearch(routeName, i,
                           list.Size, "Page" + i, "GET", cityId, City, CategoryId, Category, Term));
            }
            return links;
        }

        private LinkInfo CreateLinkForSearch(
            string routeName, int page, int Size,
            string rel, string method,
            int? cityId,
            string City, int? CategoryId, string Category, string Term)
        {
            if (cityId.HasValue && CategoryId.HasValue && !string.IsNullOrWhiteSpace(Term))
                return new LinkInfo
                {
                    Href = _urlHelper.RouteUrl(routeName,
                                new
                                {
                                    Page = page,
                                    Size = Size,
                                    cityId = cityId,
                                    City = City,
                                    CategoryId = CategoryId,
                                    Category = Category,
                                    Term = Term
                                }),
                    Rel = rel,
                    Method = method
                };
            else if (!cityId.HasValue && !CategoryId.HasValue && string.IsNullOrWhiteSpace(Term))
                return new LinkInfo
                {
                    Href = _urlHelper.RouteUrl(routeName,
                                new
                                {
                                    Page = page,
                                    Size = Size,
                                }),
                    Rel = rel,
                    Method = method
                };
            else if (cityId.HasValue && !CategoryId.HasValue && string.IsNullOrWhiteSpace(Term))
                return new LinkInfo
                {
                    Href = _urlHelper.RouteUrl(routeName,
                                new
                                {
                                    Page = page,
                                    Size = Size,
                                    cityId = cityId,
                                    City = City,
                                }),
                    Rel = rel,
                    Method = method
                };
            else if (!cityId.HasValue && CategoryId.HasValue && string.IsNullOrWhiteSpace(Term))
                return new LinkInfo
                {
                    Href = _urlHelper.RouteUrl(routeName,
                                new
                                {
                                    Page = page,
                                    Size = Size,
                                    CategoryId = CategoryId,
                                    Category = Category,
                                }),
                    Rel = rel,
                    Method = method
                };
            else if (!cityId.HasValue && !CategoryId.HasValue && !string.IsNullOrWhiteSpace(Term))
                return new LinkInfo
                {
                    Href = _urlHelper.RouteUrl(routeName,
                                new
                                {
                                    Page = page,
                                    Size = Size,
                                    Term = Term
                                }),
                    Rel = rel,
                    Method = method
                };
            else if (cityId.HasValue && CategoryId.HasValue && string.IsNullOrWhiteSpace(Term))
                return new LinkInfo
                {
                    Href = _urlHelper.RouteUrl(routeName,
                                new
                                {
                                    Page = page,
                                    Size = Size,
                                    cityId = cityId,
                                    City = City,
                                    CategoryId = CategoryId,
                                    Category = Category,
                                }),
                    Rel = rel,
                    Method = method
                };
            else if (cityId.HasValue && !CategoryId.HasValue && !string.IsNullOrWhiteSpace(Term))
                return new LinkInfo
                {
                    Href = _urlHelper.RouteUrl(routeName,
                                new
                                {
                                    Page = page,
                                    Size = Size,
                                    cityId = cityId,
                                    City = City,
                                    Term = Term
                                }),
                    Rel = rel,
                    Method = method
                };
            else if (!cityId.HasValue && CategoryId.HasValue && !string.IsNullOrWhiteSpace(Term))
                return new LinkInfo
                {
                    Href = _urlHelper.RouteUrl(routeName,
                                new
                                {
                                    Page = page,
                                    Size = Size,
                                    CategoryId = CategoryId,
                                    Category = Category,
                                    Term = Term
                                }),
                    Rel = rel,
                    Method = method
                };
            else
                return new LinkInfo
                {
                    Href = _urlHelper.RouteUrl(routeName,
                                new
                                {
                                    Page = page,
                                    Size = Size,
                                    cityId = cityId,
                                    City = City,
                                    CategoryId = CategoryId,
                                    Category = Category,
                                    Term = Term
                                }),
                    Rel = rel,
                    Method = method
                };


        }





        public List<LinkInfo> GetLinksForAdvSearch<T>(PagedList<T> list, string routName, int cityId, string Term)
            where T : class
        {
            var links = new List<LinkInfo>();

            if (list.HasPreviousPage)
                links.Add(CreateLinkForAdvSearch(routName, list.PreviousPage,
                           list.Size, "previousPage", "GET", cityId, Term));

            links.Add(CreateLinkForAdvSearch(routName, list.Page,
                           list.Size, "self", "GET", cityId, Term));

            if (list.HasNextPage)
                links.Add(CreateLinkForAdvSearch(routName, list.NextPage,
                           list.Size, "nextPage", "GET", cityId, Term));

            return links;
        }

        public List<LinkInfo> GetLinksNumbersForAdvSearch<T>(PagedList<T> list, string routeName, int cityId, string Term)
            where T : class
        {
            var links = new List<LinkInfo>();

            for (int i = 1; i <= list.TotalPages; i++)
            {
                links.Add(CreateLinkForAdvSearch(routeName, i,
                           list.Size, "Page" + i, "GET", cityId, Term));
            }
            return links;
        }

        private LinkInfo CreateLinkForAdvSearch(
            string routeName, int page, int Size,
            string rel, string method, int cityId, string Term)
        {
            return new LinkInfo
            {
                Href = _urlHelper.RouteUrl(routeName,
                            new { Page = page, Size = Size, cityId = cityId, Term = Term }),
                Rel = rel,
                Method = method
            };
        }




    }
}