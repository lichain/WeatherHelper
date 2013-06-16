using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherHelper.Models;
using WeatherAPIServices.DataContract;
using WeatherAPIServices.Services;
using WeatherAPIServices.Config;

namespace WeatherHelper.Controllers
{
    public class AdvancedQueryController : Controller
    {
        public WeatherAPIServices.Services.QueryServices QueryServices
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
        // GET: /AdvancedQuery/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DoQuery(QueryViewModel model)
        {

            try
            {

                QueryWeatherRequest request = new QueryWeatherRequest();
                //request.GPSLocationInfo = gpsLocationInfo;
                request.WCCode = model.WCCode;
                request.QueryDateTime = DateTime.Now;
                QueryWeatherResponse response = QueryServices.GetWeatherInfo(request);
                response.CurrentDay.QueryDate = request.QueryDateTime.ToString("yyyy/MM/dd");
                response.CurrentDay.AreaCode = model.AreaCode;
                response.CurrentDay.AreaName = CityAndAreaConfig.Instance.getAreaNameByAreaCode(model.AreaCode);
                response.CurrentDay.WCCode = model.WCCode;
                response.CurrentDay.CountryName = CityAndAreaConfig.Instance.getWCCountryNameByWCCode(model.WCCode);
                ViewBag.CurrentDay = response.CurrentDay;
                ViewBag.OtherDays = response.OthreDays;
            }
            catch (System.Exception ex)
            {
                return View("Error");
            }

            return View("Result");
            //return RedirectToAction("Result");
        }

    }
}
