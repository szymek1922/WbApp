using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WbApp.DataAccess
{
    public static class SqlDataAccess
    {

        public static string GetConnectionString(string connectionName = "connectionName")
        {
           return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }
        public static void SaveData<T>(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                cnn.Execute(sql);
            }
        }
    }
}