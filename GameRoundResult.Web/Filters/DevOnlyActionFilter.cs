using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;

namespace GameRoundResult.Web.Filters
{
    public class DevOnlyActionFilter : ActionFilterAttribute
    {
        private readonly string environment;
        private const string envDEV = "dev";
        private const string envLocal = "local";

        public DevOnlyActionFilter(IConfiguration configuration)
        {
            this.environment = configuration["Env"].ToLower();
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