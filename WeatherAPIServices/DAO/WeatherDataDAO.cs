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
    public static class WeatherDataDAO
    {
        public static void NewWeatherData(WeatherInfo currnetDayInfo)
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

        public static void AddForeseeWeatherData(List<WeatherInfo> othersDayInfo)
        {
            Database WeatherHelperDataContext = DatabaseConfig.GetWeatherHelperDatabase();

            if (othersDayInfo == null || othersDayInfo.Count == 0)
                throw new ArgumentNullException("othersDayInfo");

            try
            {
                string updateSql = @"INSERT INTO [ForeseeWeatherData] ([AreaCode],[WCCode],[Skycodeday], [Skytextday],[Date],[Day],[Shortday],[Precip],[SkycodeImg] ,[Low] ,[High]  ,[WeatherStatus])
                                                    VALUES (@AreaCode,@WCCode,@Skycodeday,@Skytextday,@Date,@Day,@Shortday,@Precip,@SkycodeImg,@Low,@High,@WeatherStatus) ";
                DbCommand queryCommand = WeatherHelperDataContext.GetSqlStringCommand(
                    updateSql);

                foreach (var day in othersDayInfo)
                {
                    queryCommand.Parameters.Clear();
                    WeatherHelperDataContext.AddInParameter(queryCommand, "@AreaCode", DbType.Int32, Convert.ToInt32(day.AreaCode));
                    WeatherHelperDataContext.AddInParameter(queryCommand, "@WCCode", DbType.String, day.WCCode);
                    WeatherHelperDataContext.AddInParameter(queryCommand, "@Skycodeday", DbType.String, day.Skycodeday);
                    WeatherHelperDataContext.AddInParameter(queryCommand, "@Skytextday", DbType.String, day.Skytextday);
                    WeatherHelperDataContext.AddInParameter(queryCommand, "@Date", DbType.String, day.Date);
                    WeatherHelperDataContext.AddInParameter(queryCommand, "@Day", DbType.String, day.Day);
                    WeatherHelperDataContext.AddInParameter(queryCommand, "@Shortday", DbType.String, day.Shortday);
                    WeatherHelperDataContext.AddInParameter(queryCommand, "@Precip", DbType.Int32, Convert.ToInt32(day.Precip));
                    WeatherHelperDataContext.AddInParameter(queryCommand, "@SkycodeImg", DbType.String, day.SkycodeImg);
                    WeatherHelperDataContext.AddInParameter(queryCommand, "@Low", DbType.Int32, Convert.ToInt32(day.Low));
                    WeatherHelperDataContext.AddInParameter(queryCommand, "@High", DbType.Int32, Convert.ToInt32(day.High));
                    WeatherHelperDataContext.AddInParameter(queryCommand, "@WeatherStatus", DbType.String, day.WeatherStatus);

                    WeatherHelperDataContext.ExecuteNonQuery(queryCommand);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<WeatherInfo> GetWeatherInfo(DateTime sdate , DateTime edate , int q_count = 1000)
        {
             Database WeatherHelperDataContext = DatabaseConfig.GetWeatherHelperDatabase();

             if (q_count <= 0 || q_count > 1000)
                 throw new ArgumentOutOfRangeException("q_count should > 0 and q_count should <= 10000");

             List<WeatherInfo> result = null;

            try
            {
                using (DbCommand command = WeatherHelperDataContext.GetSqlStringCommand(
                    @"SELECT TOP " + q_count  + @" 
                           [AreaName]
                          ,[WCCountryName]
                          ,[WeatherID]
                          ,[AreaCode]
                          ,[WCCode]
                          ,[Temperature]
                          ,[Skycode]
                          ,[Skytext]
                          ,[Observationtime]
                          ,[Observationpoint]
                          ,[Feelslike]
                          ,[Humidity]
                          ,[Windspeed]
                          ,[Winddisplay]
                          ,[SkycodeImg]
                          ,[Low]
                          ,[High]
                          ,[Shortday]
                          ,[WeatherStatus]
                          ,[CDate] 
                            FROM [V_WeatherData]
                            where  (CDate <= @edate and CDate >= @sdate) 
                           order by left(CDate,8), CAST([AreaCode] as int) 
"))
                {
                    WeatherHelperDataContext.AddInParameter(command, "@sdate", DbType.DateTime, sdate);
                    WeatherHelperDataContext.AddInParameter(command, "@edate", DbType.DateTime, edate);
                    IDataReader reader = WeatherHelperDataContext.ExecuteReader(command);
                    result = new List<WeatherInfo>();

                    while (reader.Read())
                    {
                        WeatherInfo response = new WeatherInfo();
                        response.AreaName = reader["AreaName"].ToString();
                        response.CountryName = reader["WCCountryName"].ToString();
                        response.WeatherID = reader["WeatherID"].ToString();
                        response.AreaCode = reader["AreaCode"].ToString();
                        response.WCCode = reader["WCCode"].ToString();
                        response.Temperature = reader["Temperature"].ToString();
                        response.Skycode = reader["Skycode"].ToString();
                        response.Skytext = reader["Skytext"].ToString();
                        response.Observationtime = reader["Observationtime"].ToString();
                        response.Observationpoint = reader["Observationpoint"].ToString();
                        response.Feelslike = reader["Feelslike"].ToString();
                        response.Humidity = reader["Humidity"].ToString();
                        response.Windspeed = reader["Windspeed"].ToString();
                        response.Winddisplay = reader["Winddisplay"].ToString();
                        //response.SkycodeImg = reader["SkycodeImg"].ToString();
                        response.Low = reader["Low"].ToString();
                        response.High = reader["High"].ToString();
                        response.Shortday = reader["Shortday"].ToString();
                        response.WeatherStatus = reader["WeatherStatus"].ToString();
                        response.CDate = Convert.ToDateTime(reader["CDate"]);
                     
                        result.Add(response);
                    }

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ForeseeWeatherInfo> GetForeseeWeatherData()
        {
            Database WeatherHelperDataContext = DatabaseConfig.GetWeatherHelperDatabase();

            List<ForeseeWeatherInfo> result = null;

            try
            {
                using (DbCommand command = WeatherHelperDataContext.GetSqlStringCommand(
                    @"select * from V_FWeatherData order by [date],areacode"))
                {
                    IDataReader reader = WeatherHelperDataContext.ExecuteReader(command);
                    result = new List<ForeseeWeatherInfo>();

                    while (reader.Read())
                    {
                        ForeseeWeatherInfo response = new ForeseeWeatherInfo();
                        response.AreaName = reader["AreaName"].ToString();
                        response.CountryName = reader["WCCountryName"].ToString();
                        response.ForeseWeatherID = reader["ForeseWeatherID"].ToString();
                        response.AreaCode = reader["AreaCode"].ToString();
                        response.WCCode = reader["WCCode"].ToString();
                        response.Skycodeday = reader["Skycodeday"].ToString();
                        response.Date = reader["Date"].ToString();
                        response.Skytextday = reader["Skytextday"].ToString();
                        response.Day = reader["Day"].ToString();
                        response.Shortday = reader["Shortday"].ToString();
                        response.Precip = reader["Precip"].ToString();
                        //response.SkycodeImg = reader["SkycodeImg"].ToString();
                        response.Low = reader["Low"].ToString();
                        response.High = reader["High"].ToString();
                        response.WeatherStatus = reader["WeatherStatus"].ToString();

                        result.Add(response);
                    }

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
