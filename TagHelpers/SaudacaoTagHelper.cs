using Microsoft.AspNetCore.Razor.TagHelpers;

public class SaudacaoTagHelper : TagHelper
{
    public string Nome { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "p";
        output.Content.SetContent($"Olá, {Nome}!");
    }
}
