using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeatherAPIServices.Common
{
    public static class CommonType
    {
        public static DateTime MinDateTime = new DateTime(1999, 1, 1);
        public static DateTime MaxDateTime = DateTime.Now.AddYears(100);
    }
}
