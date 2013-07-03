using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeatherAPIServices.DataContract
{
    public class ForeseeWeatherInfo : WeatherInfoBase
    {
        public string ForeseWeatherID { get; set; }
        public string AreaName { get; set; }
        public string AreaCode { get; set; }
        public string CountryName { get; set; }
        public string WCCode { get; set; }
    }
}
