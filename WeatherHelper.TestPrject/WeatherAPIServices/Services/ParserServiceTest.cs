using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherAPIServices.Services;
using CommonLib.Exceptions;
using System.Xml;
using WeatherAPIServices.DataContract;

namespace WeatherHelper.TestPrject.WeatherAPIServices.Services
{
    /// <summary>
    /// Summary description for ParserServiceTest
    /// </summary>
    [TestClass]
    public class ParserServiceTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ParserWeatherXMLInfo_Null_Test()
        {
            ParserService.ParserWeatherXMLInfo(null);
        }

        [TestMethod]
        [ExpectedException(typeof(XMLNodeNotFoundException))]
        public void ParserWeatherXMLInfo_Error_XML_Data_Test()
        {
            XmlDocument xmlConditions = new XmlDocument();
            xmlConditions.Load("http://weather.yahooapis.com/forecastrss?w=2502265");

            ParserService.ParserWeatherXMLInfo(xmlConditions);
        }

        [TestMethod]
        public void ParserWeatherXMLInfo_WCCode_Pass_Test()
        {
            XmlDocument xmlConditions = new XmlDocument();
            xmlConditions.Load("http://weather.msn.com/data.aspx?weadegreetype=C&wealocations=wc:TWXX0019");

            QueryWeatherResponse response  = ParserService.ParserWeatherXMLInfo(xmlConditions);
            Assert.AreEqual(response.CurrentDay.WCCode, "TWXX0019");
        }

        [TestMethod]
        public void ParserWeatherXMLInfo_OtherDays_Count_Pass_Test()
        {
            XmlDocument xmlConditions = new XmlDocument();
            xmlConditions.Load("http://weather.msn.com/data.aspx?weadegreetype=C&wealocations=wc:TWXX0019");

            QueryWeatherResponse response = ParserService.ParserWeatherXMLInfo(xmlConditions);
            Assert.AreEqual(response.OthreDays.Count, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ChangeSkyCodeToWeatherStatus_Null_Test()
        {
            ParserService.ChangeSkyCodeToWeatherStatus(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ChangeSkyCodeToWeatherStatus_WhiteSpace_Test()
        {
            ParserService.ChangeSkyCodeToWeatherStatus("        ");
        }


        [TestMethod]
        public void ChangeSkyCodeToWeatherStatus_SkyCode_Pass_Test()
        {
            Assert.AreEqual(ParserService.ChangeSkyCodeToWeatherStatus("26"), "陰");
            Assert.AreEqual(ParserService.ChangeSkyCodeToWeatherStatus("27"), "陰");

            Assert.AreEqual(ParserService.ChangeSkyCodeToWeatherStatus("35"), "小雨");
            Assert.AreEqual(ParserService.ChangeSkyCodeToWeatherStatus("39"), "小雨");
            Assert.AreEqual(ParserService.ChangeSkyCodeToWeatherStatus("45"), "小雨");
            Assert.AreEqual(ParserService.ChangeSkyCodeToWeatherStatus("46"), "小雨");

            Assert.AreEqual(ParserService.ChangeSkyCodeToWeatherStatus("19"), "霧");
            Assert.AreEqual(ParserService.ChangeSkyCodeToWeatherStatus("20"), "霧");
            Assert.AreEqual(ParserService.ChangeSkyCodeToWeatherStatus("21"), "霧");
            Assert.AreEqual(ParserService.ChangeSkyCodeToWeatherStatus("22"), "霧");

            Assert.AreEqual(ParserService.ChangeSkyCodeToWeatherStatus("28"), "多雲");
            Assert.AreEqual(ParserService.ChangeSkyCodeToWeatherStatus("29"), "多雲");
            Assert.AreEqual(ParserService.ChangeSkyCodeToWeatherStatus("30"), "多雲");
            Assert.AreEqual(ParserService.ChangeSkyCodeToWeatherStatus("33"), "多雲");

            Assert.AreEqual(ParserService.ChangeSkyCodeToWeatherStatus("5"), "雪");
            Assert.AreEqual(ParserService.ChangeSkyCodeToWeatherStatus("13"), "雪");
            Assert.AreEqual(ParserService.ChangeSkyCodeToWeatherStatus("14"), "雪");
            Assert.AreEqual(ParserService.ChangeSkyCodeToWeatherStatus("15"), "雪");
            Assert.AreEqual(ParserService.ChangeSkyCodeToWeatherStatus("16"), "雪");
            Assert.AreEqual(ParserService.ChangeSkyCodeToWeatherStatus("18"), "雪");
            Assert.AreEqual(ParserService.ChangeSkyCodeToWeatherStatus("25"), "雪");
            Assert.AreEqual(ParserService.ChangeSkyCodeToWeatherStatus("41"), "雪");
            Assert.AreEqual(ParserService.ChangeSkyCodeToWeatherStatus("42"), "雪");

            Assert.AreEqual(ParserService.ChangeSkyCodeToWeatherStatus("1"), "雷雨");
            Assert.AreEqual(ParserService.ChangeSkyCodeToWeatherStatus("2"), "雷雨");
            Assert.AreEqual(ParserService.ChangeSkyCodeToWeatherStatus("3"), "雷雨");
            Assert.AreEqual(ParserService.ChangeSkyCodeToWeatherStatus("4"), "雷雨");
            Assert.AreEqual(ParserService.ChangeSkyCodeToWeatherStatus("37"), "雷雨");
            Assert.AreEqual(ParserService.ChangeSkyCodeToWeatherStatus("38"), "雷雨");
            Assert.AreEqual(ParserService.ChangeSkyCodeToWeatherStatus("47"), "雷雨");

            Assert.AreEqual(ParserService.ChangeSkyCodeToWeatherStatus("31"), "晴");
            Assert.AreEqual(ParserService.ChangeSkyCodeToWeatherStatus("32"), "晴");
            Assert.AreEqual(ParserService.ChangeSkyCodeToWeatherStatus("34"), "晴");
            Assert.AreEqual(ParserService.ChangeSkyCodeToWeatherStatus("36"), "晴");
            Assert.AreEqual(ParserService.ChangeSkyCodeToWeatherStatus("44"), "晴");

            Assert.AreEqual(ParserService.ChangeSkyCodeToWeatherStatus("23"), "中到大風");
            Assert.AreEqual(ParserService.ChangeSkyCodeToWeatherStatus("24"), "中到大風");

            Assert.AreEqual(ParserService.ChangeSkyCodeToWeatherStatus("9"), "中到大雨");
            Assert.AreEqual(ParserService.ChangeSkyCodeToWeatherStatus("10"), "中到大雨");
            Assert.AreEqual(ParserService.ChangeSkyCodeToWeatherStatus("11"), "中到大雨");
            Assert.AreEqual(ParserService.ChangeSkyCodeToWeatherStatus("12"), "中到大雨");
            Assert.AreEqual(ParserService.ChangeSkyCodeToWeatherStatus("40"), "中到大雨");

            Assert.AreEqual(ParserService.ChangeSkyCodeToWeatherStatus("6"), "冰雹");
            Assert.AreEqual(ParserService.ChangeSkyCodeToWeatherStatus("7"), "冰雹");
            Assert.AreEqual(ParserService.ChangeSkyCodeToWeatherStatus("8"), "冰雹");
            Assert.AreEqual(ParserService.ChangeSkyCodeToWeatherStatus("17"), "冰雹");

            Assert.AreEqual(ParserService.ChangeSkyCodeToWeatherStatus("100"), "晴");
        }
    }
}
