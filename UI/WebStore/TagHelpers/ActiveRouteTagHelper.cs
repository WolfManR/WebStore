using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

using System;
using System.Collections.Generic;
using System.Linq;

namespace WebStore.TagHelpers
{
    [HtmlTargetElement(Attributes = AttributeName)]
    public class ActiveRouteTagHelper : TagHelper
    {
        private const string AttributeName = "is-active-route";
        private const string IgnoreActionName = "ignore-action";

        [HtmlAttributeName("asp-action")]
        public string Action { get; set; }

        [HtmlAttributeName("asp-controller")]
        public string Controller { get; set; }

        [HtmlAttributeName("asp-all-route-data",DictionaryAttributePrefix = "asp-route-")]
        public IDictionary<string,string> RouteValues { get; set; }=new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        [ViewContext,HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var ignoreAction = output.Attributes.ContainsName(IgnoreActionName);
            if (IsActive(ignoreAction)) MakeActive(output);

            output.Attributes.RemoveAll(IgnoreActionName);
            output.Attributes.RemoveAll(AttributeName);
        }

        private bool IsActive(bool ignoreAction)
        {
            var routeValues = ViewContext.RouteData.Values;

            var currentController = routeValues["controller"].ToString();
            var currentAction = routeValues["action"].ToString();

            const StringComparison ignoreCase = StringComparison.OrdinalIgnoreCase;

            if(!string.IsNullOrEmpty(Controller) && !string.Equals(currentController,Controller,ignoreCase)) return false;
            if(!ignoreAction && !string.IsNullOrEmpty(Action) && !string.Equals(currentAction,Action,ignoreCase)) return false;

            foreach (var (key,value) in RouteValues)
            {
                if (!routeValues.ContainsKey(key) || routeValues[key].ToString() != value) return false;
            }

            return true;
        }

        private static void MakeActive(TagHelperOutput output)
        {
            var classAttribute = output.Attributes.FirstOrDefault(attribute => attribute.Name == "class");

            if(classAttribute is null) output.Attributes.Add("class","active");
            else
            {
                if (classAttribute.Value.ToString()?.Contains("active") ?? false) return;
                output.Attributes.SetAttribute("class",$"{classAttribute.Value} active");
            }
        }
    }
}