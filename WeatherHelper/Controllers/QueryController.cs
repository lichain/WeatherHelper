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
    public class QueryController : Controller
    {
        //
        // GET: /Query/

        public ActionResult Index()
        {
            //List<Area> Areas = CityAndAreaConfig.Instance.getAreaList();
            //List<Country> country = CityAndAreaConfig.Instance.getCountryByAreaCode("1");

            //string clientIP = GPSLocationService.GetClientIP();
                                                                                                              
            ////string result = GPSLocation.GetMaxMindOmniData("203.74.123.39");

            //GPSLocation gpsLocationInfo = GPSLocationService.GetClientGPSLocationInfo();

            //QueryWeatherRequest request = new QueryWeatherRequest();
            //request.GPSLocationInfo = gpsLocationInfo;
            //request.WeatherCountryCode = "TWXX0019";
            //request.QueryDateTime = DateTime.Now;
            //QueryWeatherResponse response = QueryServices.GetWeatherInfo(request);

            return View();
        }

        [HttpPost]
        public ActionResult DoQuery(QueryViewModel model){

            try
            {
                if (model == null)
                    throw new ArgumentNullException("model");

                //GPSLocation gpsLocationInfo = GPSLocationService.GetClientGPSLocationInfo();

                QueryWeatherRequest request = new QueryWeatherRequest();
                //request.GPSLocationInfo = gpsLocationInfo;
                request.AreaCode = model.AreaCode;
                request.WCCode = model.WCCode;
                request.QueryDateTime = DateTime.Now;
                QueryWeatherResponse response = QueryServices.GetWeatherInfo(request);
                response.CurrentDay.QueryDate = request.QueryDateTime.ToString("yyyy/MM/dd");
                response.CurrentDay.AreaCode = model.AreaCode;
                response.CurrentDay.AreaName = CityAndAreaConfig.Instance.getAreaNameByAreaCode(model.AreaCode);
                response.CurrentDay.WCCode = model.WCCode;
                response.CurrentDay.CountryName = CityAndAreaConfig.Instance.getWCCountryNameByWCCode(model.WCCode);
                ViewBag.CurrentDay = response.CurrentDay;
                if (response == null || response.CurrentDay == null)
                {
                    ViewData["NoData"] = "true";
                    return View("Index");
                }
                else
                {
                    ViewData["NoData"] = "false";
                    return View("Result");
                }
            }
            catch (System.Net.WebException ex)
            {
                //ViewBag.ErrMsg = "網路斷線或遠端伺服器錯誤，請通知管理者";
                ErrorPageModel errModel = new ErrorPageModel { 
                    ErrorTitle = "Network Error", 
                    ErrorMsg = "網路斷線或遠端伺服器錯誤，請通知管理者" };

                return View("Error",errModel);
            }
            catch (System.Exception ex)
            {
                return View("Error");
            }

           
            //return RedirectToAction("Result");
        }

        public ActionResult DoQuery()
        {
            return RedirectToAction("Index");
        }

        public JsonResult QueryWeatherInfo(string weatherCountyCode , string Date)
        {
            QueryWeatherRequest request = new QueryWeatherRequest();
            request.WCCode = weatherCountyCode;
            QueryWeatherResponse response = QueryServices.GetWeatherInfo(request);

            return Json(new { WeatherInfo = response, IsSuccess = true, Msg = "" });
        }

    }
}
