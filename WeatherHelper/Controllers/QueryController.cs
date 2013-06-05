using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherAPIServices.Services;
using WeatherAPIServices.DataContract;
using WeatherAPIServices.Config;
using WeatherHelper.Models;
//using WeatherHelper.Models;

namespace WeatherHelper.Controllers
{
    public class QueryController : BaseController
    {
        //
        // GET: /Query/

        public ActionResult Index()
        {
            List<Area> Areas = CityAndAreaConfig.Instance.getAreaList();
            List<Country> country = CityAndAreaConfig.Instance.getCountryByAreaCode("1");

            string clientIP = GPSLocationService.GetClientIP();
                                                                                                              
            //string result = GPSLocation.GetMaxMindOmniData("203.74.123.39");

            GPSLocation gpsLocationInfo = GPSLocationService.GetClientGPSLocationInfo();

            QueryWeatherRequest request = new QueryWeatherRequest();
            request.GPSLocationInfo = gpsLocationInfo;
            request.WeatherCountryCode = "TWXX0019";
            request.QueryDateTime = DateTime.Now;
            QueryWeatherResponse response = QueryServices.GetWeatherInfo(request);

            return View();
        }

        public ActionResult Result(QueryResultViewModel mode)
        {
            return View("Result");
        }

        [HttpPost]
        public ActionResult DoQuery(QueryViewModel model){

            string WeatherCountyCode = "TWXX0021"; //台灣-台北

            try
            {
                //GPSLocation gpsLocationInfo = GPSLocationService.GetClientGPSLocationInfo();

                QueryWeatherRequest request = new QueryWeatherRequest();
                //request.GPSLocationInfo = gpsLocationInfo;
                request.WeatherCountryCode = WeatherCountyCode;
                request.QueryDateTime = DateTime.Now;
                QueryWeatherResponse response = QueryServices.GetWeatherInfo(request);
            }
            catch (System.Exception ex)
            {
                return View("Error");	
            }

            return RedirectToAction("Result");
        }

        public JsonResult QueryWeatherInfo(string weatherCountyCode , string Date)
        {
            QueryWeatherRequest request = new QueryWeatherRequest();
            request.WeatherCountryCode = weatherCountyCode;
            QueryWeatherResponse response = QueryServices.GetWeatherInfo(request);

            return Json(new { WeatherInfo = response, IsSuccess = true, Msg = "" });
        }

    }
}
