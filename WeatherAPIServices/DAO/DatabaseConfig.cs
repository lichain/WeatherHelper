using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace WeatherAPIServices.DAO
{
    public static class DatabaseConfig
    {
        public static Database GetWeatherHelperDatabase()
        {
            try
            {
                return EnterpriseLibraryContainer.Current.GetInstance<Database>("WeatherHelperDatabase");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
