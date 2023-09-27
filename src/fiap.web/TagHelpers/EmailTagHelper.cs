using Microsoft.AspNetCore.Razor.TagHelpers;

namespace fiap.TagHelpers
{

    [HtmlTargetElement("div", Attributes = "mail-to")]
    public class EmailTagHelper : TagHelper
    {
        public string MailTo { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";

            output.Attributes.SetAttribute("href", $"mailto:{MailTo}@fiap.com.br");
            output.Attributes.SetAttribute("class", $"control-label");

            output.Content.SetContent($"enviar email para o {MailTo}");
        }
    }
}
