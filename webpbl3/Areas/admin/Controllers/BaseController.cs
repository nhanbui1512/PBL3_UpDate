using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using webpbl3.Common;

namespace webpbl3.Areas.admin.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var sess = (UserLogin)Session[CommonConstant.USER_SESSION];
            if(sess == null || sess.Quyen != 1)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "adminPage", action = "LoginPage", Area = "admin" }));

            }
            base.OnActionExecuted(filterContext);
        }

    }
}