using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PMS
{
    public class SessionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Check for the existence of the session variable
            ISession session = filterContext.HttpContext.Session;
            var isAuthenticated = session.Get("LoggedInUser") != null;

            // If the variable does not exist, redirect the user to the login page
            if (!isAuthenticated && ((Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)filterContext.ActionDescriptor).ActionName != "Login" 
                && ((Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)filterContext.ActionDescriptor).ActionName != "Register")
            {

                filterContext.Result =new RedirectToRouteResult(new RouteValueDictionary(new { action = "Login", controller = "Home" }));
            }
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
        }
    }
}
