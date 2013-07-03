using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherAPIServices.DataContract;
using WeatherAPIServices.DAO;
using WeatherAPIServices.Common;
using WeatherHelper.Models;

namespace WeatherHelper.Controllers
{
    public class ReportController : Controller
    {
        //
        // GET: /Report/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DoQuery(DateTime STime , DateTime ETime)
        {
            try
            {
                DateTime sdate;
                DateTime edate;

                if (STime == null)
                    sdate = CommonType.MinDateTime;
                else
                    sdate = STime;

                if (ETime == null)
                    edate = CommonType.MaxDateTime;
                else
                    edate = ETime;
             
                List<WeatherInfo> weatherinfos = WeatherDataDAO.GetWeatherInfo(sdate, edate);
                if (weatherinfos != null && weatherinfos.Count > 0)
                {
                    ViewBag.WeatherInfos = weatherinfos;
                    return View("Result");
                }
                else
                {
                    ViewBag.Message = "查無資料！";
                }
                return RedirectToAction("Index");
            }
            catch (System.Net.WebException ex)
            {
                //ViewBag.ErrMsg = "網路斷線或遠端伺服器錯誤，請通知管理者";
                ErrorPageModel errModel = new ErrorPageModel
                {
                    ErrorTitle = "Network Error",
                    ErrorMsg = "網路斷線或遠端伺服器錯誤，請通知管理者"
                };

                return View("Error", errModel);
            }
            catch (System.Exception ex)
            {
                return View("Error");
            }
        }

    }
}
