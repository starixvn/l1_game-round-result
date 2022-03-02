using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Rewrite;

namespace GameRoundResult.Web.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseCustoRewriter(this IApplicationBuilder app)
        {
            var options = new RewriteOptions()
                .AddRedirect("(?i)zh-CN/GameTicket/(.*)", "zh-Hans/GameTicket/$1")
                .AddRedirect("(?i)zh-TW/GameTicket/(.*)", "zh-Hant/GameTicket/$1")
                .AddRedirect("(?i)zh-CN", "zh-Hans")
                .AddRedirect("(?i)zh-TW", "zh-Hant");

            return app.UseRewriter(options);
        }
    }
}