using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeatherAPIServices.DataContract;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;

namespace WeatherAPIServices.DAO
{
    public static class NotifySettingDAO
    {
        public static List<NotifyRule> getAllNotifyRule()
        {
            Database WeatherHelperDataContext = DatabaseConfig.GetWeatherHelperDatabase();
            List<NotifyRule> result = null;

            try
            {
                using (DbCommand command = WeatherHelperDataContext.GetSqlStringCommand(
                    @"select RuleID,RuleName,RuleDetail,SchedulingTime  from NotifyRule"))
                {
                    IDataReader reader = WeatherHelperDataContext.ExecuteReader(command);
                    result = new List<NotifyRule>();

                    while (reader.Read())
                    {
                        NotifyRule response = new NotifyRule();
                        response.RuleID = reader["RuleID"].ToString();
                        response.RuleName = reader["RuleName"].ToString();
                        response.RuleDetail = reader["RuleDetail"].ToString();
                        response.SchedulingTime = reader["SchedulingTime"].ToString();

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
