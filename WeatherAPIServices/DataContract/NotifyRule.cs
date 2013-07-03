using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeatherAPIServices.DataContract
{
    public class NotifyRule
    {
        public string RuleID { get; set; }
        public string RuleName { get; set; }
        public string RuleDetail { get; set; }
        public string SchedulingTime { get; set; }
    }
}
