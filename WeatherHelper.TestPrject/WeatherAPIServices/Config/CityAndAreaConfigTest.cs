using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherAPIServices.Config;
using WeatherAPIServices.DataContract;

namespace WeatherHelper.TestPrject.WeatherAPIServices.Config
{
    /// <summary>
    /// Summary description for CityAndAreaConfigTest
    /// </summary>
    [TestClass]
    public class CityAndAreaConfigTest
    {
        [TestMethod]
        public void getAreaNameByAreaCodeTest()
        {
            Assert.AreEqual(CityAndAreaConfig.Instance.getAreaNameByAreaCode("1"), "臺北市");
            Assert.AreEqual(CityAndAreaConfig.Instance.getAreaNameByAreaCode("2"), "高雄市");
            Assert.AreEqual(CityAndAreaConfig.Instance.getAreaNameByAreaCode("3"), "新北市");
            Assert.AreEqual(CityAndAreaConfig.Instance.getAreaNameByAreaCode("4"), "台中市");
            Assert.AreEqual(CityAndAreaConfig.Instance.getAreaNameByAreaCode("5"), "台南市");
            Assert.AreEqual(CityAndAreaConfig.Instance.getAreaNameByAreaCode("6"), "宜蘭縣");
            Assert.AreEqual(CityAndAreaConfig.Instance.getAreaNameByAreaCode("7"), "桃園縣");
            Assert.AreEqual(CityAndAreaConfig.Instance.getAreaNameByAreaCode("8"), "新竹縣");
            Assert.AreEqual(CityAndAreaConfig.Instance.getAreaNameByAreaCode("9"), "苗栗縣");
            Assert.AreEqual(CityAndAreaConfig.Instance.getAreaNameByAreaCode("10"), "彰化縣");
            Assert.AreEqual(CityAndAreaConfig.Instance.getAreaNameByAreaCode("11"), "南投縣");
            Assert.AreEqual(CityAndAreaConfig.Instance.getAreaNameByAreaCode("12"), "雲林縣");
            Assert.AreEqual(CityAndAreaConfig.Instance.getAreaNameByAreaCode("13"), "嘉義縣");
            Assert.AreEqual(CityAndAreaConfig.Instance.getAreaNameByAreaCode("14"), "屏東縣");
            Assert.AreEqual(CityAndAreaConfig.Instance.getAreaNameByAreaCode("15"), "台東縣");
            Assert.AreEqual(CityAndAreaConfig.Instance.getAreaNameByAreaCode("16"), "花蓮縣");
            Assert.AreEqual(CityAndAreaConfig.Instance.getAreaNameByAreaCode("17"), "澎湖縣");
            Assert.AreEqual(CityAndAreaConfig.Instance.getAreaNameByAreaCode("18"), "基隆市");
            Assert.AreEqual(CityAndAreaConfig.Instance.getAreaNameByAreaCode("19"), "新竹市");
            Assert.AreEqual(CityAndAreaConfig.Instance.getAreaNameByAreaCode("20"), "嘉義市");
            Assert.AreEqual(CityAndAreaConfig.Instance.getAreaNameByAreaCode("21"), "連江縣");
            Assert.AreEqual(CityAndAreaConfig.Instance.getAreaNameByAreaCode("22"), "金門縣");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void getAreaNameByAreaCode_Null_Test()
        {
            CityAndAreaConfig.Instance.getAreaNameByAreaCode(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void getAreaNameByAreaCode_WhiteSpace_Test()
        {
            CityAndAreaConfig.Instance.getAreaNameByAreaCode("       ");
        }

        [TestMethod]
        public void getCountryNameByWeatherCode_Test()
        {
            List<Area> expected =  CityAndAreaConfig.Instance.getAreaList() ;

            List<Area> actual = new List<Area>();
            Area actual_item ;
            actual_item =new Area {AreaCode="1"	,Name="臺北市" };
            actual.Add(actual_item);
            actual_item =new Area {AreaCode="2"	,Name="高雄市" };
            actual.Add(actual_item);
            actual_item =new Area {AreaCode="3"	,Name="新北市" };
            actual.Add(actual_item);
            actual_item =new Area {AreaCode="4"	,Name="台中市" };
            actual.Add(actual_item);
            actual_item =new Area {AreaCode="5"	,Name="台南市" };
            actual.Add(actual_item);
            actual_item =new Area {AreaCode="6"	,Name="宜蘭縣" };
            actual.Add(actual_item);
            actual_item =new Area {AreaCode="7"	,Name="桃園縣" };
            actual.Add(actual_item);
            actual_item =new Area {AreaCode="8"	,Name="新竹縣" };
            actual.Add(actual_item);
            actual_item =new Area {AreaCode="9"	,Name="苗栗縣" };
            actual.Add(actual_item);
            actual_item =new Area {AreaCode="10",Name="彰化縣"};
            actual.Add(actual_item);
            actual_item =new Area {AreaCode="11",Name="南投縣"};
            actual.Add(actual_item);
            actual_item =new Area {AreaCode="12",Name="雲林縣"};
            actual.Add(actual_item);
            actual_item =new Area {AreaCode="13",Name="嘉義縣"};
            actual.Add(actual_item);
            actual_item =new Area {AreaCode="14",Name="屏東縣"};
            actual.Add(actual_item);
            actual_item =new Area {AreaCode="15",Name="台東縣"};
            actual.Add(actual_item);
            actual_item =new Area {AreaCode="16",Name="花蓮縣"};
            actual.Add(actual_item);
            actual_item =new Area {AreaCode="17",Name="澎湖縣"};
            actual.Add(actual_item);
            actual_item =new Area {AreaCode="18",Name="基隆市"};
            actual.Add(actual_item);
            actual_item =new Area {AreaCode="19",Name="新竹市"};
            actual.Add(actual_item);
            actual_item =new Area {AreaCode="20",Name="嘉義市"};
            actual.Add(actual_item);
            actual_item =new Area {AreaCode="21",Name="連江縣"};
            actual.Add(actual_item);
            actual_item =new Area {AreaCode="22",Name="金門縣"};
            actual.Add(actual_item);
            
            for(int i = 0; i < actual.Count ; i++){
                Assert.AreEqual(expected[i].Name,actual[i].Name);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void getCountryNameByWeatherCode_WhiteSpace_Test()
        {
            CityAndAreaConfig.Instance.getCountryNameByWeatherCode("       ");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void getCountryNameByWeatherCode_Null_Test()
        {
            CityAndAreaConfig.Instance.getCountryNameByWeatherCode(null);
        }

        [TestMethod]
        public void getWCCountryNameByWCCode_Test()
        {
            Assert.AreEqual(CityAndAreaConfig.Instance.getWCCountryNameByWCCode("TWXX0001")	,"彰化 (彰化縣彰化市)");
            Assert.AreEqual(CityAndAreaConfig.Instance.getWCCountryNameByWCCode("TWXX0002"), "嘉義 (嘉義市西區)");
            Assert.AreEqual(CityAndAreaConfig.Instance.getWCCountryNameByWCCode("TWXX0003")	,"基隆 (基隆市安樂區)");
            Assert.AreEqual(CityAndAreaConfig.Instance.getWCCountryNameByWCCode("TWXX0005")	,"旗山 (高雄市旗山區)");
            Assert.AreEqual(CityAndAreaConfig.Instance.getWCCountryNameByWCCode("TWXX0006")	,"竹東 (新竹縣竹東鎮)");
            Assert.AreEqual(CityAndAreaConfig.Instance.getWCCountryNameByWCCode("TWXX0007")	,"豐原 (台中市豐原區)");
            Assert.AreEqual(CityAndAreaConfig.Instance.getWCCountryNameByWCCode("TWXX0009")	,"新竹 (新竹市東區)");
            Assert.AreEqual(CityAndAreaConfig.Instance.getWCCountryNameByWCCode("TWXX0010")	,"新店 (新北市新店區)");
            Assert.AreEqual(CityAndAreaConfig.Instance.getWCCountryNameByWCCode("TWXX0011")	,"花蓮 (花蓮縣花蓮市)");
            Assert.AreEqual(CityAndAreaConfig.Instance.getWCCountryNameByWCCode("TWXX0014")	,"苗栗 (苗栗縣苗栗市)");
            Assert.AreEqual(CityAndAreaConfig.Instance.getWCCountryNameByWCCode("TWXX0015")	,"屏東 (屏東縣屏東市)");
            Assert.AreEqual(CityAndAreaConfig.Instance.getWCCountryNameByWCCode("TWXX0016")	,"蘇澳 (宜蘭縣蘇澳鎮)");
            Assert.AreEqual(CityAndAreaConfig.Instance.getWCCountryNameByWCCode("TWXX0017")	,"大濁水 (宜蘭縣南澳鄉)");
            Assert.AreEqual(CityAndAreaConfig.Instance.getWCCountryNameByWCCode("TWXX0018")	,"大板埒 (屏東縣南灣)");
            Assert.AreEqual(CityAndAreaConfig.Instance.getWCCountryNameByWCCode("TWXX0019")	,"台中 (台中市北區)");
            Assert.AreEqual(CityAndAreaConfig.Instance.getWCCountryNameByWCCode("TWXX0021")	,"台北 (台北市中山區)");
            Assert.AreEqual(CityAndAreaConfig.Instance.getWCCountryNameByWCCode("TWXX0024")	,"淡水 (新北市淡水區)");
            Assert.AreEqual(CityAndAreaConfig.Instance.getWCCountryNameByWCCode("TWXX0025")	,"桃園 (桃園縣桃園市)");
            Assert.AreEqual(CityAndAreaConfig.Instance.getWCCountryNameByWCCode("TWXX0026")	,"大武 (台東縣大武鄉)");
            Assert.AreEqual(CityAndAreaConfig.Instance.getWCCountryNameByWCCode("10028648")	,"板橋市");
            Assert.AreEqual(CityAndAreaConfig.Instance.getWCCountryNameByWCCode("29496")		,"三重市");
            Assert.AreEqual(CityAndAreaConfig.Instance.getWCCountryNameByWCCode("37364")		,"永和市");
            Assert.AreEqual(CityAndAreaConfig.Instance.getWCCountryNameByWCCode("14392")		,"新莊市");
            Assert.AreEqual(CityAndAreaConfig.Instance.getWCCountryNameByWCCode("7371127")	,"中壢市");
            Assert.AreEqual(CityAndAreaConfig.Instance.getWCCountryNameByWCCode("10034496")	,"竹南鎮");
            Assert.AreEqual(CityAndAreaConfig.Instance.getWCCountryNameByWCCode("32433")		,"台南");
            Assert.AreEqual(CityAndAreaConfig.Instance.getWCCountryNameByWCCode("10480429")	,"永康市");
            Assert.AreEqual(CityAndAreaConfig.Instance.getWCCountryNameByWCCode("16133")		,"高雄");
            Assert.AreEqual(CityAndAreaConfig.Instance.getWCCountryNameByWCCode("10209491")	,"鳳山市");
            Assert.AreEqual(CityAndAreaConfig.Instance.getWCCountryNameByWCCode("24933")		,"屏東");
            Assert.AreEqual(CityAndAreaConfig.Instance.getWCCountryNameByWCCode("7365022")	,"鵝鑾鼻");
            Assert.AreEqual(CityAndAreaConfig.Instance.getWCCountryNameByWCCode("32435")		,"台東");
            Assert.AreEqual(CityAndAreaConfig.Instance.getWCCountryNameByWCCode("7372779")	,"成功鎮");
            Assert.AreEqual(CityAndAreaConfig.Instance.getWCCountryNameByWCCode("10209499")	,"卑南鄉");
            Assert.AreEqual(CityAndAreaConfig.Instance.getWCCountryNameByWCCode("7359057")	,"玉里鎮");
            Assert.AreEqual(CityAndAreaConfig.Instance.getWCCountryNameByWCCode("7370247")	,"富里鄉");
            Assert.AreEqual(CityAndAreaConfig.Instance.getWCCountryNameByWCCode("10209389")	,"光復鄉");
            Assert.AreEqual(CityAndAreaConfig.Instance.getWCCountryNameByWCCode("10107142")	,"馬公市");
            Assert.AreEqual(CityAndAreaConfig.Instance.getWCCountryNameByWCCode("7359486"), "烏石鼻");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void getWCCountryNameByWCCode_Null_Test()
        {
            CityAndAreaConfig.Instance.getWCCountryNameByWCCode(null);
        }

        [TestMethod]
        public void getWCCountryList_Test()
        {
            List<WCCountry> expected = CityAndAreaConfig.Instance.getWCCountryList();
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

            for (int i = 0; i < actual.Count; i++)
            {
                Assert.AreEqual(expected[i].Name, actual[i].Name);
                Assert.AreEqual(expected[i].AreaCode, actual[i].AreaCode);
                Assert.AreEqual(expected[i].WCCode, actual[i].WCCode);
            }
        }
    }
}
