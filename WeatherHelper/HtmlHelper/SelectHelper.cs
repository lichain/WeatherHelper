using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherAPIServices.Config;
using WeatherAPIServices.DataContract;
using System.Text;
using WeatherAPIServices.DAO;

namespace WeatherHelper.HtmlHelper
{
    public static class SelectHelper
    {
        public static string AreaControl(string SelectID)
        {
            List<Area> Areas = CityAndAreaConfig.Instance.getAreaList();
            StringBuilder retHtml = new StringBuilder();
            retHtml.Append(string.Format("<select id={0} name={0}>",SelectID));
            retHtml.Append("<option value=\"-1\" selected=\"selected\">請選擇</optnion>");
            foreach (var item in Areas)
            {
                retHtml.Append(string.Format("<option value=\"{0}\" >{1}</optnion>",item.AreaCode, item.Name));
            }
            retHtml.Append("</select>");

            return retHtml.ToString();
        }

        public static string CountryControl(string SelectID , string AreaCode ="")
        {
            List<Country> Countries = CityAndAreaConfig.Instance.getCountryByAreaCode(AreaCode);
            StringBuilder retHtml = new StringBuilder();

            retHtml.Append(string.Format("<select id={0} name={0} >", SelectID));
            retHtml.Append("<option value=\"-1\" selected=\"selected\">請選擇</optnion>");
            foreach (var item in Countries)
            {
                retHtml.Append(string.Format("<option value=\"{0}\" data-area-code=\"{1}\" >{2}</optnion>", item.WeatherCountyCode, item.AreaCode,item.Name));
            }
            retHtml.Append("</select>");

            return retHtml.ToString();
        }

        public static string WCCountryControl(string SelectID, string AreaCode = "")
        {
            List<WCCountry> WCCountries = CityAndAreaConfig.Instance.getWCCountryByAreaCode(AreaCode);
            StringBuilder retHtml = new StringBuilder();

            retHtml.Append(string.Format("<select id={0} name={0} >", SelectID));
            retHtml.Append("<option value=\"-1\" selected=\"selected\">請選擇</optnion>");
            foreach (var item in WCCountries)
            {
                retHtml.Append(string.Format("<option value=\"{0}\" data-area-code=\"{1}\" >{2}</optnion>", item.WCCode, item.AreaCode, item.Name));
            }
            retHtml.Append("</select>");

            return retHtml.ToString();
        }


        public static string NotifyRuleControl(string radioName)
        {
            List<NotifyRule> rules = NotifySettingDAO.getAllNotifyRule();
            StringBuilder retHtml = new StringBuilder();
            int index = 0;
            foreach (var item in rules)
            {
                if(index == 0)
                    retHtml.Append(string.Format("<input type=\"radio\" class=\"NotifyRule\" name=\"{0}\" data-id=\"{1}\" checked=\"yes\" /> {2} <br>", radioName, item.RuleID, item.RuleName + " : " + item.RuleDetail + " ( 每天 " + item.SchedulingTime + " 執行 )"));
                else
                    retHtml.Append(string.Format("<input type=\"radio\" class=\"NotifyRule\" name=\"{0}\" data-id=\"{1}\" /> {2} <br>", radioName,item.RuleID, item.RuleName    + " : " + item.RuleDetail + " ( 每天 " +  item.SchedulingTime + " 執行 )"  ));
                index++;
            }

            return retHtml.ToString();
        }
    }
}