using System.IO;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;

namespace GameRoundResult.Web.Extensions
{
    public static class HtmlContentExtensions
    {
        public static string GetHtmlString(this IHtmlContent htmlContent)
        {
            using var writer = new StringWriter();
            htmlContent.WriteTo(writer, HtmlEncoder.Default);

            return writer.ToString();
        }
    }
}