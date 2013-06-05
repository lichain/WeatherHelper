using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeatherAPIServices.DataContract
{
    public class WeatherInfo
    {
        //public DateTime Date { get; set; }
        //public WeatherStatus Status { get; set; }
        //public int Temperature_Max { get; set; }
        //public int Temperature_Min { get; set; }
        //public int RainyProbability { get; set; }

        public string Low { get; set; }
        public string High { get; set; }
        public string Skycodeday { get; set; }
        public string Date { get; set; }
        public string Day { get; set; }
        public string Shortday { get; set; }
        public string Precip { get; set; }
        public string WeatherStatus { get; set; }
    }
}
