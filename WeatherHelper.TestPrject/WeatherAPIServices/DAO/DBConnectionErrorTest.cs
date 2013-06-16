using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherAPIServices.DataContract;
using WeatherAPIServices.DAO;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace WeatherHelper.TestPrject.WeatherAPIServices.DAO
{
    /// <summary>
    /// Summary description for DBConnectionErrorTest
    /// </summary>
    [TestClass]
    public class DBConnectionErrorTest
    {
        [TestMethod]
        [ExpectedException(typeof(System.Data.SqlClient.SqlException))]
        public void WCCodeDAO_getWCCountryList_ConnectionString_Error_Test()
        {
            List<WCCountry> expected = WCCodeDAO.getWCCountryList();
        }

        [TestMethod]
        [ExpectedException(typeof(System.Data.SqlClient.SqlException))]
        public void WeatherDataDAO_NewWeatherData_ConnectionString_Error_Test()
        {
            CurrentWeatherInfo data = new CurrentWeatherInfo();
            WeatherDataDAO.NewWeatherData(data);
        }
    }
}
