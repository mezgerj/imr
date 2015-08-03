using System.Web.Mvc;
using System.Web.Routing;

namespace Inspinia_MVC5.Filters
{
    public class ApplicationSessionCheckFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.HttpContext.Session["Application"] == null ||
                filterContext.HttpContext.Session["Application_Name"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { action = "ChooseApplication", controller = "Home" }));
            }
            else
            {
                base.OnActionExecuted(filterContext);
            }
        }
    }
}