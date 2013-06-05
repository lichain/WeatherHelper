using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeatherAPIServices.DataContract
{
    public class CurrentWeatherInfo : WeatherInfo
    {
        public string Temperature { get; set; }
        public string Skycode { get; set; }
        public string Skytext { get; set; }
        public string Observationtime { get; set; }
        public string Observationpoint { get; set; }    //觀察點
        public string Feelslike { get; set; }
        public string Humidity { get; set; }   //濕度
        public string Windspeed { get; set; } //風速
        public string Winddisplay { get; set; }
    }
}
