using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherAPIServices.DataContract;
using WeatherAPIServices.DAO;
using WeatherHelper.Models;
using WeatherAPIServices.MailService;

namespace WeatherHelper.Controllers
{
    public class NotifyCenterController : Controller
    {
        //
        // GET: /NotifyCenter/

        public ActionResult Index()
        {
            return RedirectToAction("Setting");
        }

        public ActionResult Setting()
        {
            try
            {
                List<MemberInfo> members = MemberInfoDAO.getAllMemberInfo();
                ViewBag.MemberInfos = members;

                return View("Setting");
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


        [HttpPost]
        public JsonResult DoSendMail(string UserName,string UseMail, string RuleID)
        {
            if (string.IsNullOrWhiteSpace(UserName))
                return Json(new { IsSuccess = false, Msg = "UserName not allow empty." });

            if (string.IsNullOrWhiteSpace(UseMail))
                return Json(new { IsSuccess = false, Msg = "UseMail not allow empty." });

            if (string.IsNullOrWhiteSpace(RuleID))
                return Json(new { IsSuccess = false, Msg = "RuleID not allow empty." });

            try 
            {
                NotifyRuleMail1 mail = new NotifyRuleMail1();
                mail.MailAddress = UseMail;
                mail.UserName = UserName;

                mail.Initialize();
                mail.Execute();

                return Json(new { IsSuccess = true, Msg = "" });
            }
            catch
            {
                return Json(new { IsSuccess = false, Msg = "System error." });
            }
        }
    }
}
