using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Xml;
using WeatherAPIServices.DataContract;

namespace WeatherAPIServices.Config
{
    public class CityAndAreaConfig
    {

        private static CityAndAreaConfig _instance;

        private Dictionary<string, Area> _areaDictionary =
                new Dictionary<string, Area>();

        private Dictionary<string, Country> _countryDictionary =
               new Dictionary<string, Country>();

        private Dictionary<string, WCCountry> _wccountryDictionary = 
                new Dictionary<string, WCCountry>();

        private CityAndAreaConfig()
        {
            string filePath = null;
            if (HttpContext.Current == null || File.Exists(HttpContext.Current.Server.MapPath(@"~/Config/CityAndArea.xml")) == false)
            {
                if (File.Exists(@"C:\Config\WeatherHelperConfig\CityAndArea.xml") == false)
                {
                    throw new Exception("CityAndArea.xml file not exist!");
                }
                else
                {
                    filePath = @"C:\Config\WeatherHelperConfig\CityAndArea.xml";
                }
            }
            else
            {
                filePath = HttpContext.Current.Server.MapPath(@"~/Config/CityAndArea.xml");
            }
            InitXMLObj(filePath);
        }
        private void InitXMLObj(string path)
        {
            XmlDocument doc = new XmlDocument();

            try
            {
                doc.Load(path);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("XML Load failed.", ex);
            }

            XmlNodeList productItems =
                doc.DocumentElement.SelectNodes("Area");

            foreach (XmlElement productitem in productItems)
            {
                SetAreaObj(productitem);
            }

            productItems =
                doc.DocumentElement.SelectNodes("WeatherCode");

            foreach (XmlElement productitem in productItems)
            {
                SetCounrtyObj(productitem);
            }

            productItems =
                doc.DocumentElement.SelectNodes("WC");

            foreach (XmlElement productitem in productItems)
            {
                SetWCCounrtyObj(productitem);
            }

        }
        private void SetAreaObj(XmlElement productitem)
        {
            Area obj = new Area();
            obj.AreaCode = productitem.GetAttribute("AreaCode");
            obj.Name = productitem.GetAttribute("Name");
            _areaDictionary.Add(obj.AreaCode, obj);
        }

        private void SetCounrtyObj(XmlElement productitem)
        {
            Country obj = new Country();
            obj.WeatherCountyCode = productitem.GetAttribute("WeatherCountyCode");
            obj.Name = productitem.GetAttribute("Name");
            obj.AreaCode = productitem.GetAttribute("AreaCode");
            _countryDictionary.Add(obj.WeatherCountyCode, obj);
        }

        private void SetWCCounrtyObj(XmlElement productitem)
        {
            WCCountry obj = new WCCountry();
            obj.WCCode = productitem.GetAttribute("WC_Code");
            obj.Name = productitem.GetAttribute("Name");
            obj.AreaCode = productitem.GetAttribute("AreaCode");
            _wccountryDictionary.Add(obj.WCCode, obj);
        }

        public static CityAndAreaConfig Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CityAndAreaConfig();
                }

                return _instance;
            }
        }

        public List<Area> getAreaList()
        {
            List<Area> result = new List<Area>();
            foreach(var item in _areaDictionary)
            {
                //Area area = new Area();
                result.Add(item.Value);
            }
            return result;
        }

        public List<WCCountry> getWCCountryList()
        {
            List<WCCountry> result = new List<WCCountry>();
            foreach (var item in _wccountryDictionary)
            {
                result.Add(item.Value);
            }
            return result;
        }

        public string getAreaNameByAreaCode(string areacode)
        {
            if (string.IsNullOrWhiteSpace(areacode))
            {
                throw new ArgumentNullException("areacode");
            }

            return _areaDictionary[areacode].Name;
        }

        public string getCountryNameByWeatherCode(string weathercode)
        {
            if (string.IsNullOrWhiteSpace(weathercode))
            {
                throw new ArgumentNullException("weathercode");
            }

            return _countryDictionary[weathercode].Name;
        }

        public List<Country> getCountryByAreaCode(string areaCode = "all")
        {
            
            //if (string.IsNullOrWhiteSpace(areaCode))
            //{
            //    return null;
            //}

            List<Country> result = new List<Country>();

            if (areaCode == "all" || areaCode=="")
            {
                foreach (var item in _countryDictionary)
                {
                    result.Add(item.Value);
                }
                return result;
            }
                
            foreach (var item in _countryDictionary)
            {
                if (areaCode.Trim() == item.Value.AreaCode)
                {
                    result.Add(item.Value);
                }
            }

            if (result.Count > 0)
                return result;
            else
                return null;
        }

        public List<WCCountry> getWCCountryByAreaCode(string areaCode = "all")
        {

            //if (string.IsNullOrWhiteSpace(areaCode))
            //{
            //    return null;
            //}

            List<WCCountry> result = new List<WCCountry>();

            if (areaCode == "all" || areaCode == "")
            {
                foreach (var item in _wccountryDictionary)
                {
                    result.Add(item.Value);
                }
                return result;
            }

            foreach (var item in _wccountryDictionary)
            {
                if (areaCode.Trim() == item.Value.AreaCode)
                {
                    result.Add(item.Value);
                }
            }

            if (result.Count > 0)
                return result;
            else
                return null;
        }

        public string getWCCountryNameByWCCode(string WCCode)
        {
            if (string.IsNullOrWhiteSpace(WCCode))
            {
                throw new ArgumentNullException("WCCode");
            }

            return _wccountryDictionary[WCCode].Name;
        }
    }
}