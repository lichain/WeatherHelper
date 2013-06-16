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

            public ParserService ParserService
            {
                get
                {
                    throw new System.NotImplementedException();
                }
                set
                {
                }
            }

            public static QueryWeatherResponse GetWeatherInfo(QueryWeatherRequest request)
            {
                if (request == null)
                    throw new ArgumentNullException("request");

                XmlDocument xmlConditions = new XmlDocument();
                xmlConditions.Load(string.Format(MSN_WEATHER_API_URL, request.WCCode));

                //Parser MSN-Weather-info XML
                QueryWeatherResponse response = ParserService.ParserWeatherXMLInfo(xmlConditions);
                response.CurrentDay.AreaCode = request.AreaCode;
                response.CurrentDay.WCCode = request.WCCode;
                response.CurrentDay.Shortday = response.OthreDays[0].Shortday;

                return response;
            }

        }
}
