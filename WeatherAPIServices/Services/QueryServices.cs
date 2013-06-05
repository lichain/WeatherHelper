using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeatherAPIServices.DataContract;
using System.Xml;

namespace WeatherAPIServices.Services
{
        public class QueryServices                                                                                     
        {
            const string WeadegreeType = "C";

            private const string MSN_WEATHER_API_URL = "http://weather.msn.com/data.aspx?weadegreetype=C&wealocations=wc:{0}";

            public static QueryWeatherResponse GetWeatherInfo(QueryWeatherRequest request)
            {
                XmlDocument xmlConditions = new XmlDocument();
                xmlConditions.Load(string.Format(MSN_WEATHER_API_URL, request.WeatherCountryCode));

                //Parser MSN-Weather-info XML
                return ParserService.ParserWeatherXMLInfo(xmlConditions);
            }

        }
}
