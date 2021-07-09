using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.DependencyInjection;

namespace GameRoundResult.Web.Extensions
{
    public static class ControllerExtensions
    {
        public static async Task<string> RenderViewAsync<TModel>(this Controller controller, string viewName, TModel model)
        {
            if (string.IsNullOrEmpty(viewName))
            {
                viewName = controller.ControllerContext.ActionDescriptor.ActionName;
            }

            controller.ViewData.Model = model;

            using var writer = new StringWriter();
            var viewEngine = controller.HttpContext.RequestServices.GetRequiredService<ICompositeViewEngine>();
            ViewEngineResult viewResult = viewEngine.FindView(controller.ControllerContext, viewName, false);

            var viewContext = new ViewContext(
                controller.ControllerContext,
                viewResult.View,
                controller.ViewData,
                controller.TempData,
                writer,
                new HtmlHelperOptions()
            );

            await viewResult.View.RenderAsync(viewContext);

            return writer.GetStringBuilder().ToString();
        }
    }
}