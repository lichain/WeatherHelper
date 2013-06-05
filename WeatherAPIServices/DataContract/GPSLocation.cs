using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using System.Net.Sockets;
using WeatherAPIServices.Services;
using CommonLib.String;

namespace WeatherAPIServices.DataContract
{
        public class GPSLocation
        {
                public string County {get;set;}
                public string CountyCode { get; set; }
                public string Area {get;set;}
                public string AreaCode { get; set; }
                public double Location1 { get; set; }
                public double Location2 { get; set; }
        }

        
}