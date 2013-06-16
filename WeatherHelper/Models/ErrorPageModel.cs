using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherHelper.Models
{
    public class ErrorPageModel
    {
        public string ErrorCode{get;set;}
        public string ErrorTitle { get; set; }
        public string ErrorMsg { get; set; }
        public string ErrorDetailMsg{get;set;}
    }
}