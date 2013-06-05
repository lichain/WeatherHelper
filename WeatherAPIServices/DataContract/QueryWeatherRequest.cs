using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeatherAPIServices.DataContract
{
        public class QueryWeatherRequest
        {
                //public string CountyCode { get;set;}
                //public County County { get; set; }
                //public Area Area { get; set; }
            public GPSLocation GPSLocationInfo { get; set; }
            public string WeatherCountryCode { get; set; }
            public DateTime QueryDateTime { get; set; }
        }
}
