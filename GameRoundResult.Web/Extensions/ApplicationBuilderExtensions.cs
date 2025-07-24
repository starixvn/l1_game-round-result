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
                .AddRedirect("(?i)^id/BetHistory/(.*)", "id-ID/BetHistory/$1")
                .AddRedirect("(?i)^th/BetHistory/(.*)", "th-TH/BetHistory/$1")
                .AddRedirect("(?i)vi/BetHistory/(.*)", "vi-VN/BetHistory/$1")
                .AddRedirect("(?i)zh_CN/BetHistory/(.*)", "zh-Hans/BetHistory/$1")
                .AddRedirect("(?i)zh_TW/BetHistory/(.*)", "zh-Hant/BetHistory/$1")
                .AddRedirect("(?i)zh-CN", "zh-Hans")
                .AddRedirect("(?i)zh-TW", "zh-Hant")
                .AddRedirect("(?i)ja/BetHistory/(.*)", "ja-JP/BetHistory/$1");

            return app.UseRewriter(options);
        }
    }
}