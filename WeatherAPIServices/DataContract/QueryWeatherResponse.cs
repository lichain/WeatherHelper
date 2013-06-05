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
            public List<WeatherInfo> OthreDays { get; set; }

            public CurrentWeatherInfo CurrentDay { get; set; }

        }
}
