using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WeatherHelper.Controllers
{
    public class ReportController : Controller
    {

        public WeatherAPIServices.DAO.WeatherDataDAO WeatherDataDAO
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
        //
        // GET: /Report/

        public ActionResult Index()
        {
            return View();
        }

    }
}
