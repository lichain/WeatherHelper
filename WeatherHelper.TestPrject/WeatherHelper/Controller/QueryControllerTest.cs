using WeatherHelper.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using WeatherHelper.Models;
using System.Web.Mvc;

namespace WeatherHelper.TestPrject.WeatherHelper.Controllers
{
    
    
    /// <summary>
    ///This is a test class for QueryControllerTest and is intended
    ///to contain all QueryControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class QueryControllerTest
    {
        /// <summary>
        ///A test for QueryController Constructor
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/WeatherHelper")]
        public void QueryControllerConstructorTest()
        {
            QueryController target = new QueryController();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for DoQuery
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/WeatherHelper")]
        public void DoQueryTest()
        {
            QueryController target = new QueryController(); // TODO: Initialize to an appropriate value
            QueryViewModel model = null; // TODO: Initialize to an appropriate value
            ActionResult expected = null; // TODO: Initialize to an appropriate value
            ActionResult actual;
            actual = target.DoQuery(model);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Index
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/WeatherHelper")]
        public void IndexTest()
        {
            QueryController target = new QueryController(); // TODO: Initialize to an appropriate value
            ActionResult expected = null; // TODO: Initialize to an appropriate value
            ActionResult actual;
            actual = target.Index();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for QueryWeatherInfo
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/WeatherHelper")]
        public void QueryWeatherInfoTest()
        {
            QueryController target = new QueryController(); // TODO: Initialize to an appropriate value
            string weatherCountyCode = string.Empty; // TODO: Initialize to an appropriate value
            string Date = string.Empty; // TODO: Initialize to an appropriate value
            JsonResult expected = null; // TODO: Initialize to an appropriate value
            JsonResult actual;
            actual = target.QueryWeatherInfo(weatherCountyCode, Date);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

    }
}
