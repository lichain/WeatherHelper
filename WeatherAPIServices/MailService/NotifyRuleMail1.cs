using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeatherAPIServices.DataContract;
using WeatherAPIServices.DAO;

namespace WeatherAPIServices.MailService
{
    public class NotifyRuleMail1 : MailBase
    {
        public string UserName { get; set; }

        public override void Initialize()
        {
            base.Initialize();
            _initMailBody();
        }

        public override void Execute()
        {
            base.Execute();
        }

        private void _initMailBody()
        {
            List<ForeseeWeatherInfo> ForeseeWeatherData = WeatherDataDAO.GetForeseeWeatherData();

            MailSubject = string.Format("預測天氣信({0}  ~  {1})", ForeseeWeatherData[0].Date, ForeseeWeatherData[ForeseeWeatherData.Count-1].Date);

            StringBuilder retHtml = new StringBuilder();
            retHtml.Append("<table class=\"table\" style=\"width: 80%; border: 1px solid #E8EEF4; border-color: #DDDDDD #DDDDDD #DDDDDD -moz-use-text-color;\" ><tbody>");
            retHtml.Append("<tr><th style=\"border: 1px solid #DDDDDD;\">時間</th><th style=\"border: 1px solid #DDDDDD;\">地點</th><th style=\"border: 1px solid #DDDDDD;\">溫度</th><th style=\"border: 1px solid #DDDDDD;\">天氣狀況</th><th style=\"border: 1px solid #DDDDDD;\">天氣說明</th></tr>");
            foreach (var w in ForeseeWeatherData)
            {
                retHtml.Append("<tr>");
                retHtml.Append(string.Format("<td style=\"border: 1px solid #DDDDDD;\">{0}</td>",w.Date)) ;
                retHtml.Append(string.Format("<td style=\"border: 1px solid #DDDDDD;\">{0}</td>", w.AreaName + " - " + w.CountryName));
                retHtml.Append(string.Format("<td style=\"border: 1px solid #DDDDDD;\">{0}</td>", w.Low + " ~ " + w.High));
                retHtml.Append(string.Format("<td style=\"border: 1px solid #DDDDDD;\"><img width=\"55\" height=\"45\" title=\"{0}\" src=\"{1}\" /></td>", w.WeatherStatus, w.SkycodeImg));
                retHtml.Append(string.Format("<td style=\"border: 1px solid #DDDDDD;\">{0}</td>", w.WeatherStatus));
                retHtml.Append("</tr>");

            }
            retHtml.Append("</tbody></table>");

            MailBody = "<html><body><strong>Hi ##USERNAME##：</strong><br><br><br>##DATA##</body></html>"
                //.Replace(BOOTSTRAPCSS, "https://dl.dropboxusercontent.com/u/29103482/css/bootstrap.min.css")
                .Replace(USER_NAME,UserName)
                .Replace(DATA,retHtml.ToString());

        }
    }
}
