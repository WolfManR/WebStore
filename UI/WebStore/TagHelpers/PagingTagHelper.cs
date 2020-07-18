using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

using System;
using System.Collections.Generic;
using System.Linq;

using WebStore.Domain.ViewModels;

namespace WebStore.TagHelpers
{
    public class PagingTagHelper : TagHelper
    {
        public PageViewModel PageModel { get; set; }

        public string PageAction { get; set; }

        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<string, object> PageUrlValues { get; set; } = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var ul = new TagBuilder("ul");
            ul.AddCssClass("pagination");

            for (int i = 1, totalPages = PageModel.TotalPages; i < totalPages; i++)
                ul.InnerHtml.AppendHtml(CreateItem(i));

            output.Content.AppendHtml(ul);
        }

        private TagBuilder CreateItem(int pageNumber)
        {
            var li = new TagBuilder("li");
            var a = new TagBuilder("a");

            if (pageNumber == PageModel.PageNumber)
            {
                a.MergeAttribute("data-page",PageModel.PageNumber.ToString());
                li.AddCssClass("active");
            }
            else
            {
                PageUrlValues["page"] = pageNumber;
                a.Attributes["href"] = "#";
                foreach (var (key, value) in PageUrlValues.Where(v => v.Value != null))
                    a.MergeAttribute($"data-{key}", value.ToString());
            }

            a.InnerHtml.AppendHtml(pageNumber.ToString());
            li.InnerHtml.AppendHtml(a);
            return li;
        }
    }
}