using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Practices.EnterpriseLibrary.Data;
using WeatherAPIServices.DAO;

namespace WeatherHelper.TestPrject.WeatherAPIServices.DAO
{
    /// <summary>
    /// Summary description for DatabaseConfigTest
    /// </summary>
    [TestClass]
    public class DatabaseConfigTest
    {
        [TestMethod]
        public void DatabaseConfig_GetWeatherHelperDatabase_ConnectionString_Error_Test()
        {
            Database db = DatabaseConfig.GetWeatherHelperDatabase();
            Assert.AreEqual(db.ConnectionString ,@"Data Source=.\sqlexpress;Initial Catalog=WeatherHelper;Persist Security Info=True;User ID=lichain;Password=1q2w3e4r``");
        }
    }
}
