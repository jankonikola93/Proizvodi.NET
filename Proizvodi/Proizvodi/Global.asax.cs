using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Infrastructure;
using Infrastructure.Helper;

namespace Proizvodi
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            UnityConfig.RegisterComponents();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error()
        {
            if (HttpContext.Current == null) return;
            HttpContext context = HttpContext.Current;
            Exception exception = context.Server.GetLastError();
            HttpException httpException = exception as HttpException;
            var errorCode = (int)Enums.ErrorCodes.Other;

            if (exception != null && !string.IsNullOrEmpty(exception.Message) && exception.Message.Contains("master was not found or no view engine supports the searched locations"))
            {
                errorCode = (int)Enums.ErrorCodes.NotFound;
            }

            if (httpException != null)
            {
                int httpCode = httpException.GetHttpCode();
                errorCode = Common.VratiErrorCodeZaHttpStatus(httpCode);
            }

            Response.Clear();
            context.Server.ClearError();

            UrlHelper urlHelp = new UrlHelper(HttpContext.Current.Request.RequestContext);
            Response.Redirect(urlHelp.Action("Index", "Error", new { errorCode = errorCode }));
        }
    }
}
