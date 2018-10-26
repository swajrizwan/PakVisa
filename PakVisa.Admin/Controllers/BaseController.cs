using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace PakVisa.Admin.Controllers
{
    public class BaseController : Controller
    {
        private int theUser;
        public int TheUser
        {
            get
            {
                return theUser;
            }
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.Session.GetInt32("loginId").HasValue)
            {
                context.Result = new RedirectToRouteResult(
                   new RouteValueDictionary(
                       new { area = "", controller = "Account", action = "SignIn" }));
            }
            else
            {
                theUser = context.HttpContext.Session.GetInt32("loginId").Value;
            }

            base.OnActionExecuting(context);
        }
    }
}