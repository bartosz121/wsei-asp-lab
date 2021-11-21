using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wsei_Lab5.TagHelpers
{
    [HtmlTargetElement("alert")]
    public class AlertTagHelper: TagHelper
    {
        public string Type { get; set; } = "primary";
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.Add("class", $"alert alert-{Type}");
        }
    }
}
