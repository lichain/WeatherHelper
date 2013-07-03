using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeatherAPIServices.MailService
{
    public class SMTP
    {
        public string Host{get;set;}
        public string Account { get; set; }
        public string Password { get; set; }
        public string AdminName { get; set; }
        public string AdminMail { get; set; }
    }
}
