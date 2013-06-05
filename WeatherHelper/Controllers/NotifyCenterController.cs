using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WeatherHelper.Controllers
{
    public class NotifyCenterController : Controller
    {
        //
        // GET: /NotifyCenter/

        public ActionResult Index()
        {
            return View("Setting");
        }

    }
}
