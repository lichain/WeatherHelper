using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherAPIServices.DAO;

namespace WeatherHelper.TestPrject.WeatherAPIServices.DAO
{
    /// <summary>
    /// Summary description for WeatherDataDAOTest
    /// </summary>
    [TestClass]
    public class WeatherDataDAOTest
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NewWeatherData_Null_Test()
        {
            WeatherDataDAO.NewWeatherData(null);
        }
    }
}
