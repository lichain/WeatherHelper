using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeatherAPIServices.DataContract
{
        public class QueryWeatherResponse
        {
            //public WeatherInfo Day1 { get; set; }
            //public WeatherInfo Day2 { get; set; }
            //public WeatherInfo Day3 { get; set; }
            //public WeatherInfo Day4 { get; set; }
            //public WeatherInfo Day5 { get; set; }
            public List<ForeseeWeatherInfo> OthreDays { get; set; }

            public WeatherInfo CurrentDay { get; set; }

        }
}
