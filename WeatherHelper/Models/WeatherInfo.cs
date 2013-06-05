using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherHelper.Models
{
        public enum WeatherStatus{
                SunnyDay,
                //sunny, but partly cloudy, and sometimes shower,
                RainyDay,
                SometimesRainyDay
        }

        public class WeatherInfo
        {
                public DateTime Date { get; set; }
                public WeatherStatus Status {get;set;}
                public int Temperature_Max { get; set; }
                public int Temperature_Min { get; set; }
                public int RainyProbability { get; set; }
        }
}