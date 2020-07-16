using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

using System;
using System.Collections.Generic;

using WebStore.Domain.ViewModels;

namespace WebStore.TagHelpers
{
    public class PagingTagHelper : TagHelper
    {
        private readonly IUrlHelperFactory urlHelperFactory;

        [ViewContext, HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        public PageViewModel PageModel { get; set; }

        public string PageAction { get; set; }

        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<string, object> PageUrlValues { get; set; } = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);

        public PagingTagHelper(IUrlHelperFactory urlHelperFactory) => this.urlHelperFactory = urlHelperFactory;


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var ul = new TagBuilder("ul");
            ul.AddCssClass("pagination");

            var urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            for (int i = 1, totalPages = PageModel.TotalPages; i < totalPages; i++)
                ul.InnerHtml.AppendHtml(CreateItem(i, urlHelper));

            output.Content.AppendHtml(ul);
        }

        private TagBuilder CreateItem(int pageNumber, IUrlHelper url)
        {
            var li = new TagBuilder("li");
            var a = new TagBuilder("a");

            if (pageNumber == PageModel.PageNumber) li.AddCssClass("active");
            else
            {
                PageUrlValues["page"] = pageNumber;
                a.Attributes["href"] = url.Action(PageAction, PageUrlValues);
            }

            a.InnerHtml.AppendHtml(pageNumber.ToString());
            li.InnerHtml.AppendHtml(a);
            return li;
        }
    }
}