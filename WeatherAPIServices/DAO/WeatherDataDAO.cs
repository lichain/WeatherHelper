using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeatherAPIServices.DataContract;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace WeatherAPIServices.DAO
{
    public class WeatherDataDAO
    {
        public static void NewWeatherData(CurrentWeatherInfo currnetDayInfo)
        {
            Database WeatherHelperDataContext = DatabaseConfig.GetWeatherHelperDatabase();

            if (currnetDayInfo == null)
                throw new ArgumentNullException("currnetDayInfo");

            try
            {
                string updateSql = @"INSERT INTO [WeatherData] ([AreaCode],[WCCode],[Temperature] ,[Skycode] ,[Skytext] ,[Observationtime] ,[Observationpoint] ,[Feelslike] ,[Humidity] ,[Windspeed] ,[Winddisplay] ,[SkycodeImg] ,[Low] ,[High] ,[Shortday] ,[WeatherStatus])
                                                    VALUES (@AreaCode,@WCCode,@Temperature,@Skycode,@Skytext,@Observationtime,@Observationpoint,@Feelslike,@Humidity,@Windspeed,@Winddisplay,@SkycodeImg,@Low,@High,@Shortday,@WeatherStatus) ";
                DbCommand queryCommand = WeatherHelperDataContext.GetSqlStringCommand(
                    updateSql);

                WeatherHelperDataContext.AddInParameter(queryCommand, "@AreaCode", DbType.Int32, Convert.ToInt32(currnetDayInfo.AreaCode));
                WeatherHelperDataContext.AddInParameter(queryCommand, "@WCCode", DbType.String, currnetDayInfo.WCCode);
                WeatherHelperDataContext.AddInParameter(queryCommand, "@Temperature", DbType.Int32, Convert.ToInt32(currnetDayInfo.Temperature));
                WeatherHelperDataContext.AddInParameter(queryCommand, "@Skycode", DbType.String, currnetDayInfo.Skycode);
                WeatherHelperDataContext.AddInParameter(queryCommand, "@Skytext", DbType.String, currnetDayInfo.Skytext);
                WeatherHelperDataContext.AddInParameter(queryCommand, "@Observationtime", DbType.String, currnetDayInfo.Observationtime);
                WeatherHelperDataContext.AddInParameter(queryCommand, "@Observationpoint", DbType.String, currnetDayInfo.Observationpoint);
                WeatherHelperDataContext.AddInParameter(queryCommand, "@Feelslike", DbType.String, currnetDayInfo.Feelslike);
                WeatherHelperDataContext.AddInParameter(queryCommand, "@Humidity", DbType.Int32, Convert.ToInt32(currnetDayInfo.Humidity));
                WeatherHelperDataContext.AddInParameter(queryCommand, "@Windspeed", DbType.String, currnetDayInfo.Windspeed);
                WeatherHelperDataContext.AddInParameter(queryCommand, "@Winddisplay", DbType.String, currnetDayInfo.Winddisplay);
                WeatherHelperDataContext.AddInParameter(queryCommand, "@SkycodeImg", DbType.String, currnetDayInfo.SkycodeImg);
                WeatherHelperDataContext.AddInParameter(queryCommand, "@Low", DbType.Int32, Convert.ToInt32(currnetDayInfo.Low));
                WeatherHelperDataContext.AddInParameter(queryCommand, "@High", DbType.Int32, Convert.ToInt32(currnetDayInfo.High));
                WeatherHelperDataContext.AddInParameter(queryCommand, "@Shortday", DbType.String, currnetDayInfo.Shortday);
                WeatherHelperDataContext.AddInParameter(queryCommand, "@WeatherStatus", DbType.String, currnetDayInfo.WeatherStatus);

                WeatherHelperDataContext.ExecuteNonQuery(queryCommand) ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
