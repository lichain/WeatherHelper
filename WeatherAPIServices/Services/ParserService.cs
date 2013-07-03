using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using WeatherAPIServices.DataContract;
using CommonLib.Exceptions;

namespace WeatherAPIServices.Services
{
    public class ParserService
    {
        public WeatherAPIServices.DataContract.QueryWeatherResponse QueryWeatherResponse
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    
        public static QueryWeatherResponse ParserWeatherXMLInfo(XmlDocument XmlDoc, QueryWeatherRequest request)
        {
            if (XmlDoc == null)
                throw new ArgumentNullException("XmlDoc");

            if (request == null)
                throw new ArgumentNullException("request");

            QueryWeatherResponse respone = new QueryWeatherResponse();
            if (XmlDoc.SelectSingleNode(@"weatherdata/weather/current") != null)
            {
                respone.CurrentDay = new WeatherInfo();
                respone.CurrentDay.WCCode = XmlDoc.SelectSingleNode(@"weatherdata/weather").Attributes["weatherlocationcode"].InnerText.Split(':')[1];
                respone.CurrentDay.Temperature = XmlDoc.SelectSingleNode(@"weatherdata/weather/current").Attributes["temperature"].InnerText;
                respone.CurrentDay.Skycode = XmlDoc.SelectSingleNode(@"weatherdata/weather/current").Attributes["skycode"].InnerText;
                respone.CurrentDay.Skytext = XmlDoc.SelectSingleNode(@"weatherdata/weather/current").Attributes["skytext"].InnerText;
                respone.CurrentDay.Observationtime = XmlDoc.SelectSingleNode(@"weatherdata/weather/current").Attributes["observationtime"].InnerText;
                respone.CurrentDay.Observationpoint = XmlDoc.SelectSingleNode(@"weatherdata/weather/current").Attributes["observationpoint"].InnerText;
                respone.CurrentDay.Feelslike = XmlDoc.SelectSingleNode(@"weatherdata/weather/current").Attributes["feelslike"].InnerText;
                respone.CurrentDay.Humidity = XmlDoc.SelectSingleNode(@"weatherdata/weather/current").Attributes["humidity"].InnerText;
                respone.CurrentDay.Windspeed = XmlDoc.SelectSingleNode(@"weatherdata/weather/current").Attributes["windspeed"].InnerText;
                respone.CurrentDay.Winddisplay = XmlDoc.SelectSingleNode(@"weatherdata/weather/current").Attributes["winddisplay"].InnerText;
                respone.CurrentDay.WeatherStatus = ChangeSkyCodeToWeatherStatus(respone.CurrentDay.Skycode);

                respone.OthreDays = new List<ForeseeWeatherInfo>();
                for(int i = 0 ; i  <  XmlDoc.SelectNodes(@"weatherdata/weather/forecast").Count ; i++)
                {
                    ForeseeWeatherInfo weatherinfo = new ForeseeWeatherInfo();
                    weatherinfo.Low = XmlDoc.SelectNodes(@"weatherdata/weather/forecast")[i].Attributes["low"].InnerText;
                    weatherinfo.High = XmlDoc.SelectNodes(@"weatherdata/weather/forecast")[i].Attributes["high"].InnerText;
                    weatherinfo.Skycodeday = XmlDoc.SelectNodes(@"weatherdata/weather/forecast")[i].Attributes["skycodeday"].InnerText;
                    weatherinfo.Skytextday = XmlDoc.SelectNodes(@"weatherdata/weather/forecast")[i].Attributes["skytextday"].InnerText;
                    weatherinfo.Date = XmlDoc.SelectNodes(@"weatherdata/weather/forecast")[i].Attributes["date"].InnerText;
                    weatherinfo.Day = XmlDoc.SelectNodes(@"weatherdata/weather/forecast")[i].Attributes["day"].InnerText;
                    weatherinfo.Shortday = XmlDoc.SelectNodes(@"weatherdata/weather/forecast")[i].Attributes["shortday"].InnerText;
                    weatherinfo.Precip = XmlDoc.SelectNodes(@"weatherdata/weather/forecast")[i].Attributes["precip"].InnerText;
                    weatherinfo.WeatherStatus = ChangeSkyCodeToWeatherStatus(weatherinfo.Skycodeday);

                    weatherinfo.AreaCode = request.AreaCode;
                    weatherinfo.WCCode = request.WCCode;

                    respone.OthreDays.Add(weatherinfo);
                }

                if (respone.OthreDays.Count > 0)
                { 
                    respone.CurrentDay.High = respone.OthreDays[0].High;
                    respone.CurrentDay.Low = respone.OthreDays[0].Low;
                }

                return respone;
            }
            else
            {
                throw new XMLNodeNotFoundException();
            }

        }

        public static string ChangeSkyCodeToWeatherStatus(string skycode)
        {
            if (string.IsNullOrWhiteSpace(skycode))
                throw new ArgumentNullException("skycode");
                //return "-";

            string code = skycode.Trim();

            if (code == "26" || code == "27") return "陰";
            if (code == "35" || code == "39" || code == "45" || code == "46") return "小雨";
            if (code == "19" || code == "20" || code == "21" || code == "22") return "霧";
            if (code == "28" || code == "29" || code == "30" || code == "33") return "多雲";
            if (code == "5" || code == "13" || code == "14" || code == "15" || code == "16" || code == "18"
                 || code == "25" || code == "41" || code == "42") return "雪";
            if (code == "1" || code == "2" || code == "3" || code == "4" || code == "37" || code == "38"
                 || code == "47") return "雷雨";
            if (code == "31" || code == "32" || code == "34" || code == "36" || code =="44") return "晴";
            if (code == "23" || code == "24") return "中到大風";
            if (code == "9" || code == "10" || code == "11" || code == "12" || code == "40") return "中到大雨";
            if (code == "6" || code == "7" || code == "8" || code == "17") return "冰雹";

            return "晴";
        }
    }
}
