using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherAPIServices.Config;
using WeatherAPIServices.DataContract;
using System.Text;

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
    }
}