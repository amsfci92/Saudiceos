using Cigarette.Enterprise.ResourceManager.LanguagesResourceFiles;
using Cigarette.Enterprise.ViewModels.ViewModels.Generic;
using Cigarette.Enterprise.ViewModels.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Saudiceos.Enterprise.Web.helper
{
    public static class PaginationHelper
    {
        public static IHtmlString Pagination<T>(this HtmlHelper helper, GenericOutputModel<T> Model)
            where T : class
        {

            StringBuilder Str = new StringBuilder();

            //Str.Append($"<div class='pager'><nav class='text-center'><ul class='pagination' role='navigation'>");
            Str.Append($"<div class='pagination row col-lg-12 col-md-12 col-sm-12'>");

            foreach (var item in Model.Links)
            {
                if (item.Rel == "previousPage")
                {
                    //Str.Append($"<a href='{item.Href}' class='btn btn-link'>{PaginationResource.previous}</a>");
                    //Str.Append($"<li role='presentation'><a role='button' href='{item.Href}' aria-label='Next'><i class='fa fa-chevron-right' aria-hidden='true'></i><span class='sr-only'>previous</span></a></li>");
                    Str.Append($"<a href='{item.Href}'>&laquo;</a>");
                }
            }



            for (int i = 0; i < Model.Paging.TotalPages; i++)
            {
                string selected = "";
                if (Model.Paging.Page == i + 1)
                    selected = "active";


                //Str.Append($"<a href='{Model.LinksNumbers[i].Href}' class='{selected}'>{i + 1}</a>");
                //Str.Append($"<li class='{selected}' role='presentation'><a role='button' href='{Model.LinksNumbers[i].Href}' aria-label='Page #{i}'>{i + 1}</a></li>");
                Str.Append($"<a class='{selected}'  href='{Model.LinksNumbers[i].Href}' >{i + 1}</a>");


                //if (i>12)
                //{
                //    Str.Append("<span>.......</span>");
                //    break;
                //}
            }


            foreach (var item in Model.Links)
            {
                if (item.Rel == "nextPage")
                {

                    //Str.Append($"<a href='{item.Href}' class='btn btn-link'>{PaginationResource.next}</a>");
                    //Str.Append($"<li role='presentation'><a role='button' href='{item.Href}' aria-label='Previous'><i class='fa fa-chevron-left' aria-hidden='true'></i><span class='sr-only'>next</span></a></li>");Str.Append($"<li role='presentation'><a role='button' href='{item.Href}' aria-label='Previous'><i class='fa fa-chevron-left' aria-hidden='true'></i><span class='sr-only'>next</span></a></li>");
                    Str.Append($"<a href='{item.Href}'>&raquo;</a>");
                }
            }
            //Str.Append("</ul></nav></div>");
            Str.Append("</div>");

            return new HtmlString(Str.ToString());
        }
    }
}