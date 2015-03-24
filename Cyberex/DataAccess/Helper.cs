using System;
using System.Data;
using System.Configuration;

using System.Collections.Generic;
using System.Data.SqlClient;

public static class Helper
{


    public static string GetDBConnectionString()
    {
        return System.Configuration.ConfigurationManager.AppSettings.Get("Constr");
    }

  
}
