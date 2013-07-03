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
    public static class WCCodeDAO
    {
        public static List<WCCountry> getWCCountryList()
        {
            Database WeatherHelperDataContext = DatabaseConfig.GetWeatherHelperDatabase();
            List<WCCountry> result = null;

            try
            {
                using (DbCommand command = WeatherHelperDataContext.GetSqlStringCommand(
                    @"select AreaCode,WCCode,WCCountryName from WCCode order by AreaCode"))
                {
                    IDataReader reader = WeatherHelperDataContext.ExecuteReader(command);
                    result = new List<WCCountry>();

                    while (reader.Read())
                    {
                        WCCountry response = new WCCountry();
                        response.AreaCode = reader["AreaCode"].ToString();
                        response.WCCode = reader["WCCode"].ToString();
                        response.Name = reader["WCCountryName"].ToString();
                     
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
