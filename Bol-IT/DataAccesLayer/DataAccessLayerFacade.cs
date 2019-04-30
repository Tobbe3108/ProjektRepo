using System;
using System.Configuration;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DataAccessLayerFacade
    {
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString: ConfigurationManager.AppSettings["AzureDB"]);
        }
    }
}
