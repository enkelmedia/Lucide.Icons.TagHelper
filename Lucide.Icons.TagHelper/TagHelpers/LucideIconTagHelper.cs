using System.IO;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.FileProviders;

namespace Lucide.Icons.TagHelper.TagHelpers;

/// <summary>
/// Tag Helper to render inline icons from Lucide icon library.
/// </summary>
[HtmlTargetElement("lucide-icon", Attributes = "name")]
public class LucideIconTagHelper : Microsoft.AspNetCore.Razor.TagHelpers.TagHelper
{
    private readonly IFileProvider _fileProvider;

    public LucideIconTagHelper(IWebHostEnvironment env)
    {
        _fileProvider = env.WebRootFileProvider;
    }

    public string Name { get; set; } = string.Empty;
    
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var relativePath = $"/lucide-icons/{Name}.svg";
        var file = _fileProvider.GetFileInfo(relativePath);

        if (!file.Exists)
        {
            output.SuppressOutput();
            return;
        }

        string svg;
        using (var stream = file.CreateReadStream())
        using (var reader = new StreamReader(stream))
        {
            svg = reader.ReadToEnd();
        }

        svg = MinifySvg(svg);

        output.TagName = null;
        output.Content.SetHtmlContent(svg);
    }

    private static string MinifySvg(string svg)
    {
        svg = svg.Replace("\n", "").Replace("\r", "").Replace("\t", "");

        while (svg.Contains("  "))
            svg = svg.Replace("  ", " ");

        svg = Regex.Replace(svg, @">\s+<", "><");

        return svg.Trim();
    }
}
