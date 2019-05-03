using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using BusinessLayer.Classes;
using System.Configuration;

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
