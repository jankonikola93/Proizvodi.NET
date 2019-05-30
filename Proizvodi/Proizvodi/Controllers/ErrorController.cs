using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Infrastructure.Helper;

namespace Proizvodi.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index(int errorCode)
        {
            ViewBag.ErrorMessage = Common.VratiErrorMessageZaErrorCode(errorCode);
            return View("Error");
        }
    }
}