using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using KingSite.Purview.Services;
using KingSite.Purview.Domain;
using System.Web.Routing;

namespace KingSite.Purview.MVC {
    [Authorize]
    [HandleError]
    public class BaseController : Controller {

        protected override void OnActionExecuting(ActionExecutingContext filterContext) {
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string actionName = filterContext.ActionDescriptor.ActionName;
            bool b = MembershipEx.CanDo(User.Identity.Name, controllerName, actionName);
            if (!b) {
                filterContext.HttpContext.Response.Write("没有访问权限");
                filterContext.HttpContext.Response.End();
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
