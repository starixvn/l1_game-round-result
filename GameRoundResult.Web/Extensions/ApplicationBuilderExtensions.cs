using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Rewrite;

namespace GameRoundResult.Web.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseCustoRewriter(this IApplicationBuilder app)
        {
            var options = new RewriteOptions()
                .AddRedirect("(?i)zh-CN/BetHistory/(.*)", "zh-Hans/BetHistory/$1")
                .AddRedirect("(?i)zh-TW/BetHistory/(.*)", "zh-Hant/BetHistory/$1")
                .AddRedirect("(?i)zh-CN", "zh-Hans")
                .AddRedirect("(?i)zh-TW", "zh-Hant")
                .AddRedirect("(?i)vi/(.*)", "vi-VN/$1")
                .AddRedirect("(?i)id/(.*)", "id-ID/$1")
                .AddRedirect("(?i)th/(.*)", "th-TH/$1");

            return app.UseRewriter(options);
        }
    }
}