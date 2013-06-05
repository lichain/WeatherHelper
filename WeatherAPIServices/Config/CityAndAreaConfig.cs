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

        private Dictionary<string, Country> _counrtyDictionary =
    new Dictionary<string, Country>();

        private CityAndAreaConfig()
        {
            string filePath = null;
            filePath = HttpContext.Current.Server.MapPath(@"~/Config/CityAndArea.xml");
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
            _counrtyDictionary.Add(obj.WeatherCountyCode, obj);
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

        public List<Country> getCountryByAreaCode(string areaCode = "all")
        {
            
            //if (string.IsNullOrWhiteSpace(areaCode))
            //{
            //    return null;
            //}

            List<Country> result = new List<Country>();

            if (areaCode == "all" || areaCode=="")
            {
                foreach (var item in _counrtyDictionary)
                {
                    result.Add(item.Value);
                }
                return result;
            }
                
            foreach (var item in _counrtyDictionary)
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
    }
}