using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherAPIServices.Services;

namespace WeatherHelper.TestPrject.WeatherAPIServices.Services
{
    /// <summary>
    /// Summary description for QueryServicesTest
    /// </summary>
    [TestClass]
    public class QueryServicesTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetWeatherInfo_Null_Test()
        {
            QueryServices.GetWeatherInfo(null);
        }
    }
}
