using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
namespace WebAppMVCCORE
{
    public class TestFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var value = filterContext.HttpContext.Session.GetString("userName");
            if (value == null)
            {
                filterContext.Result =
       new RedirectToRouteResult(
           new RouteValueDictionary{{ "controller", "StateManagement" },
                                          { "action", "SetValues" }

                                         });
            }
        }
    }
}
