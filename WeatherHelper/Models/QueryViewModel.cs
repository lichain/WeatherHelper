using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherHelper.Models
{
    public class QueryViewModel
    {
        public string AreaName { get; set; }
        public string AreaCode { get; set; }
        public string CountryName { get; set; }
        public string WCCode { get; set; }
        public string CurrnetDate { get; set; }
    }
}