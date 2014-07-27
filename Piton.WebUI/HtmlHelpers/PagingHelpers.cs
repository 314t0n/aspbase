using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Piton.WebUI.Models;

namespace Piton.WebUI.HtmlHelpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html,
            PagingInfo pagingInfo, Func<int, string> pageUrl, String selectedClassName)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= pagingInfo.TotalPages; i++)
            {
                TagBuilder liTag = new TagBuilder("li");
                
                TagBuilder aTag = new TagBuilder("a");
                aTag.MergeAttribute("href", pageUrl(i));
                aTag.InnerHtml = i.ToString();
                if (i==pagingInfo.CurrentPage)
                {
                    liTag.AddCssClass(selectedClassName);
                }
                liTag.InnerHtml = aTag.ToString();
                result.Append(liTag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}