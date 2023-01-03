using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;

namespace GameRoundResult.Web.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum | AttributeTargets.Interface | AttributeTargets.Delegate)]
    public sealed class DevOnlyAttribute : ActionFilterAttribute
    {
        private readonly string environment;
        private const string envDEV = "dev";
        private const string envLocal = "local";

        public DevOnlyAttribute(IConfiguration configuration)
        {
            this.environment = configuration["Env"].ToLowerInvariant();
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!environment.Contains(envDEV) && !environment.Contains(envLocal))
            {
                context.Result = new RedirectToActionResult("NotAuthorized", "Error", null);
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}