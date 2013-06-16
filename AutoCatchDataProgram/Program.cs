using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeatherAPIServices.DataContract;
using WeatherAPIServices.Config;
using WeatherAPIServices.Services;
using WeatherAPIServices.DAO;

namespace AutoCatchDataProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime starttime;
            DateTime endtime;
            TimeSpan spentime;
            int index = 1;

            List<WCCountry> wccountries = CityAndAreaConfig.Instance.getWCCountryList();

            try
            {

                Console.WriteLine("==============================================================================");
                starttime = DateTime.Now;
                Console.WriteLine(string.Format("Program start : Time =>{0}",starttime.ToString("yyyy/MM/dd HH:mm:ss")));
                Console.WriteLine("==============================================================================");
                foreach (var item in wccountries)
                {
                    Console.WriteLine("");
                    Console.WriteLine("==============================================================================");
                    Console.WriteLine(string.Format("Index = {0} , WCCode = {1} , AreaName = {2} , Name ={3}",
                        index, item.WCCode, CityAndAreaConfig.Instance.getAreaNameByAreaCode(item.AreaCode), item.Name));

                    QueryWeatherRequest request = new QueryWeatherRequest { WCCode = item.WCCode , AreaCode = item.AreaCode};
                    QueryWeatherResponse response = QueryServices.GetWeatherInfo(request);

                    if (response != null && response.CurrentDay != null)
                    {
                        Console.WriteLine(string.Format("天氣狀況：{0} , 地點：{1} , 溫度：{2} , 舒適度：{3} , 溫度範圍：{4} ~ {5} , 濕度：{6} , 風速：{7} , 觀測時間：{8}"
                            , response.CurrentDay.WeatherStatus
                            , CityAndAreaConfig.Instance.getAreaNameByAreaCode(item.AreaCode) + " - " + CityAndAreaConfig.Instance.getWCCountryNameByWCCode(item.WCCode)
                            , response.CurrentDay.Temperature
                            , response.CurrentDay.Feelslike
                            , response.CurrentDay.Low
                            , response.CurrentDay.High
                            , response.CurrentDay.Humidity
                            , response.CurrentDay.Windspeed
                            , response.CurrentDay.Observationtime
                            ));
                        
                        WeatherDataDAO.NewWeatherData(response.CurrentDay);
                    }
                    index++;
                    Console.WriteLine("==============================================================================");
                }
                Console.WriteLine("");
                Console.WriteLine("==============================================================================");
                endtime = DateTime.Now;
                Console.WriteLine(string.Format("Program End : Time =>{0}", endtime.ToString("yyyy/MM/dd HH:mm:ss")));
                spentime = endtime - starttime;
                Console.WriteLine("Count : {0} , Spend Time:{1} 分  {2} 秒", index, spentime.Minutes,spentime.Seconds);
                Console.WriteLine("==============================================================================");

            }
            catch (System.Exception ex)
            {
                Console.WriteLine(string.Format("System Error : {0}", ex.ToString()));
            }
        }
    }
}
