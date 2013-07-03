using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeatherAPIServices.DataContract
{
    public class WeatherInfoBase
    {
        public string Low { get; set; }
        public string High { get; set; }
        public string Skycodeday { get; set; }
        public string Skytextday { get; set; }
        public string Date { get; set; }
        public string Day { get; set; }
        public string Shortday { get; set; }
        public string Precip { get; set; }
        public string WeatherStatus { get; set; }
        public string SkycodeImg
        {
            get
            {
                return "http://wst.s-msn.com/i/en-us/law/" + Skycodeday + ".gif";
            }
        }
    }
}
