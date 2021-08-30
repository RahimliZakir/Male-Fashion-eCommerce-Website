using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.eCommerce.WebUI.Models.ViewModel
{
    public class PagedViewModel<T>
        where T : class
    {
        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }

        public int MaxPageIndex
        {
            get
            {

                return (int)Math.Ceiling(TotalCount * 1.0 / PageSize);

            }
        }
        public IEnumerable<T> Items { get; private set; }

        public PagedViewModel(IOrderedQueryable<T> query, int pageIndex = 1, int pageSize = 9)
        {

            if (pageIndex < 1)
            {
                pageIndex = 1;
            }

            if (pageSize < 1)
            {
                pageSize = 9;
            }

            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
            this.TotalCount = query.Count();
            this.Items = query.Skip(this.PageSize * (this.PageIndex - 1))
                .Take(this.PageSize)
                .ToList();


        }

        public IHtmlContent GetPagenation(IUrlHelper url, string action)
        {
            if (TotalCount <= PageSize)
                return HtmlString.Empty;

            // Neche dene nomre gorunmesini isteyirikse o qeder yazib gorunmeni
            // bir nov limitleyirik...

            int PageCount = 4;

            int start = 1, end = MaxPageIndex;

            if (end - start > 4)
            {
                if (PageIndex - PageCount / 2 > 1)
                {
                    start = PageIndex - PageCount / 2;
                }

                if (end > start + PageCount - 1)
                {
                    end = start + PageCount - 1;

                    if (end > MaxPageIndex)
                    {
                        end = MaxPageIndex;
                    }
                }
            }

            StringBuilder sb = new StringBuilder();

            sb.Append("<ul class='pagination-ul'>");

            if (PageIndex > 1)
            {
                var link = url.Action(action, values: new
                {
                    pageIndex = PageIndex - 1,
                    PageSize = this.PageSize
                });

                sb.Append($"<li class='prev'><a href='{link}'>" +
                    $"<i class='fa fa-chevron-left'></i></a></li>");
            }
            else
            {
                sb.Append(" <li class='prev disabled'>" +
                    "<a ><i class='fa fa-chevron-left'></i></a></li>");
            }

            for (int i = start; i <= end; i++)
            {
                if (i == PageIndex)
                {
                    sb.Append($"<li class='active'><a >{i}</a></li>");
                }
                else
                {
                    var link = url.Action(action, values: new
                    {
                        pageIndex = i,
                        PageSize = this.PageSize
                    });

                    sb.Append($"<li><a href='{link}'>{i}</a></li>");
                }
            }

            if (PageIndex < MaxPageIndex)
            {
                var link = url.Action(action, values: new
                {
                    pageIndex = PageIndex + 1,
                    PageSize = this.PageSize
                });

                sb.Append($"<li class='next'><a href='{link}'>" +
                    $"<i class='fa fa-chevron-right'></i></a></li>");
            }
            else
            {
                sb.Append(" <li class='next disabled'>" +
                    "<a ><i class='fa fa-chevron-right'></i></a></li>");
            }

            sb.Append("</ul>");


            return new HtmlString(sb.ToString());
        }
    }
}
