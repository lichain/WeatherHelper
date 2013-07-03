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
    public static class MemberInfoDAO
    {
        public static List<MemberInfo> getAllMemberInfo()
        {
            Database WeatherHelperDataContext = DatabaseConfig.GetWeatherHelperDatabase();
            List<MemberInfo> result = null;

            try
            {
                using (DbCommand command = WeatherHelperDataContext.GetSqlStringCommand(
                    @"select UserNO,UserID,UserName,UserEmail  from MemberInfo"))
                {
                    IDataReader reader = WeatherHelperDataContext.ExecuteReader(command);
                    result = new List<MemberInfo>();

                    while (reader.Read())
                    {
                        MemberInfo response = new MemberInfo();
                        response.UserNO = Convert.ToInt32(reader["UserNO"]);
                        response.UserID = reader["UserID"].ToString();
                        response.UserName = reader["UserName"].ToString();
                        response.UserEmail = reader["UserEmail"].ToString();

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
