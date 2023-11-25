using Microsoft.AspNetCore.Razor.TagHelpers;

public class DespedidaTagHelper : TagHelper
{
    public string Nome { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "p";
        output.Content.SetContent($"Até mais, {Nome}!");
    }
}
