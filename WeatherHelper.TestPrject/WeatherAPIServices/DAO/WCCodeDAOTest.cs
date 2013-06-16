using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherAPIServices.Services;
using WeatherAPIServices.DataContract;
using WeatherAPIServices.DAO;

namespace WeatherHelper.TestPrject.WeatherAPIServices.DAO
{
    /// <summary>
    /// Summary description for WCCodeDAOTest
    /// </summary>
    [TestClass]
    public class WCCodeDAOTest
    {
        [TestMethod]
        public void getWCCountryList_Test()
        {
            List<WCCountry> expected = WCCodeDAO.getWCCountryList();

            List<WCCountry> actual = new List<WCCountry>();
            WCCountry actual_item;
            actual_item = new WCCountry { AreaCode = "10", WCCode = "TWXX0001", Name = "彰化 (彰化縣彰化市)" };
            actual.Add(actual_item);
            actual_item = new WCCountry { AreaCode = "13", WCCode = "TWXX0002", Name = "嘉義 (嘉義市西區)" };
            actual.Add(actual_item);
            actual_item = new WCCountry { AreaCode = "18", WCCode = "TWXX0003", Name = "基隆 (基隆市安樂區)" };
            actual.Add(actual_item);
            actual_item = new WCCountry { AreaCode = "2", WCCode = "TWXX0005", Name = "旗山 (高雄市旗山區)" };
            actual.Add(actual_item);
            actual_item = new WCCountry { AreaCode = "8", WCCode = "TWXX0006", Name = "竹東 (新竹縣竹東鎮)" };
            actual.Add(actual_item);
            actual_item = new WCCountry { AreaCode = "4", WCCode = "TWXX0007", Name = "豐原 (台中市豐原區)" };
            actual.Add(actual_item);
            actual_item = new WCCountry { AreaCode = "19", WCCode = "TWXX0009", Name = "新竹 (新竹市東區)" };
            actual.Add(actual_item);
            actual_item = new WCCountry { AreaCode = "3", WCCode = "TWXX0010", Name = "新店 (新北市新店區)" };
            actual.Add(actual_item);
            actual_item = new WCCountry { AreaCode = "16", WCCode = "TWXX0011", Name = "花蓮 (花蓮縣花蓮市)" };
            actual.Add(actual_item);
            actual_item = new WCCountry { AreaCode = "9", WCCode = "TWXX0014", Name = "苗栗 (苗栗縣苗栗市)" };
            actual.Add(actual_item);
            actual_item = new WCCountry { AreaCode = "14", WCCode = "TWXX0015", Name = "屏東 (屏東縣屏東市)" };
            actual.Add(actual_item);
            actual_item = new WCCountry { AreaCode = "6", WCCode = "TWXX0016", Name = "蘇澳 (宜蘭縣蘇澳鎮)" };
            actual.Add(actual_item);
            actual_item = new WCCountry { AreaCode = "6", WCCode = "TWXX0017", Name = "大濁水 (宜蘭縣南澳鄉)" };
            actual.Add(actual_item);
            actual_item = new WCCountry { AreaCode = "14", WCCode = "TWXX0018", Name = "大板埒 (屏東縣南灣)" };
            actual.Add(actual_item);
            actual_item = new WCCountry { AreaCode = "4", WCCode = "TWXX0019", Name = "台中 (台中市北區)" };
            actual.Add(actual_item);
            actual_item = new WCCountry { AreaCode = "1", WCCode = "TWXX0021", Name = "台北 (台北市中山區)" };
            actual.Add(actual_item);
            actual_item = new WCCountry { AreaCode = "3", WCCode = "TWXX0024", Name = "淡水 (新北市淡水區)" };
            actual.Add(actual_item);
            actual_item = new WCCountry { AreaCode = "7", WCCode = "TWXX0025", Name = "桃園 (桃園縣桃園市)" };
            actual.Add(actual_item);
            actual_item = new WCCountry { AreaCode = "15", WCCode = "TWXX0026", Name = "大武 (台東縣大武鄉)" };
            actual.Add(actual_item);
            actual_item = new WCCountry { AreaCode = "3", WCCode = "10028648", Name = "板橋市" };
            actual.Add(actual_item);
            actual_item = new WCCountry { AreaCode = "3", WCCode = "29496", Name = "三重市" };
            actual.Add(actual_item);
            actual_item = new WCCountry { AreaCode = "3", WCCode = "37364", Name = "永和市" };
            actual.Add(actual_item);
            actual_item = new WCCountry { AreaCode = "3", WCCode = "14392", Name = "新莊市" };
            actual.Add(actual_item);
            actual_item = new WCCountry { AreaCode = "7", WCCode = "7371127", Name = "中壢市" };
            actual.Add(actual_item);
            actual_item = new WCCountry { AreaCode = "9", WCCode = "10034496", Name = "竹南鎮" };
            actual.Add(actual_item);
            actual_item = new WCCountry { AreaCode = "5", WCCode = "32433", Name = "台南" };
            actual.Add(actual_item);
            actual_item = new WCCountry { AreaCode = "5", WCCode = "10480429", Name = "永康市" };
            actual.Add(actual_item);
            actual_item = new WCCountry { AreaCode = "2", WCCode = "16133", Name = "高雄" };
            actual.Add(actual_item);
            actual_item = new WCCountry { AreaCode = "2", WCCode = "10209491", Name = "鳳山市" };
            actual.Add(actual_item);
            actual_item = new WCCountry { AreaCode = "14", WCCode = "24933", Name = "屏東" };
            actual.Add(actual_item);
            actual_item = new WCCountry { AreaCode = "14", WCCode = "7365022", Name = "鵝鑾鼻" };
            actual.Add(actual_item);
            actual_item = new WCCountry { AreaCode = "15", WCCode = "32435", Name = "台東" };
            actual.Add(actual_item);
            actual_item = new WCCountry { AreaCode = "15", WCCode = "7372779", Name = "成功鎮" };
            actual.Add(actual_item);
            actual_item = new WCCountry { AreaCode = "15", WCCode = "10209499", Name = "卑南鄉" };
            actual.Add(actual_item);
            actual_item = new WCCountry { AreaCode = "16", WCCode = "7359057", Name = "玉里鎮" };
            actual.Add(actual_item);
            actual_item = new WCCountry { AreaCode = "16", WCCode = "7370247", Name = "富里鄉" };
            actual.Add(actual_item);
            actual_item = new WCCountry { AreaCode = "16", WCCode = "10209389", Name = "光復鄉" };
            actual.Add(actual_item);
            actual_item = new WCCountry { AreaCode = "17", WCCode = "10107142", Name = "馬公市" };
            actual.Add(actual_item);
            actual_item = new WCCountry { AreaCode = "15", WCCode = "7359486", Name = "烏石鼻" };
            actual.Add(actual_item);

            Assert.AreEqual(expected.Count, actual.Count);

            foreach (var item in expected)
            {
                WCCountry find_item = new WCCountry();
                find_item = actual.Find(delegate(WCCountry p) { return (p.WCCode == item.WCCode); });
                Assert.AreEqual(item.AreaCode, find_item.AreaCode);
                Assert.AreEqual(item.Name, find_item.Name);
                Assert.AreEqual(item.WCCode, find_item.WCCode);
            }

            //actual.Sort((x) => Int32.);
            //IEnumerable<WCCountry> query = null;
            //query = from items in actual orderby Convert.ToInt32(items.AreaCode) select items;

            //foreach(var exp in expected)
            //int index = 0 ;
            //foreach(var item in query)
            //{

            //    Assert.AreEqual(expected[index].AreaCode, item.AreaCode);
            //    Assert.AreEqual(expected[index].Name, item.Name);
            //    Assert.AreEqual(expected[index].WCCode, item.WCCode);
            //    //Assert.AreEqual(expected[i].Name, actual[i].Name);
            //    //Assert.AreEqual(expected[i].AreaCode, actual[i].AreaCode);
            //    //Assert.AreEqual(expected[i].WCCode, actual[i].WCCode);
            //    index++;
            //}
        }


        [TestMethod]
        [ExpectedException(typeof(System.Data.SqlClient.SqlException))]
        public void getWCCountryList_ConnectionString_Error_Test()
        {
            List<WCCountry> expected = WCCodeDAO.getWCCountryList();
        }
    }
}
