using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public abstract class DataAccessLayerAbstract
    {
        public static void CreateEntry()
        {

        }

        public static void EditEntry(int id)
        {

        }

        public static BusinessLayer.Classes.DataType GetEntry(int id)
        {
            throw new NotImplementedException();
        }

        private static SqlConnection GetConnection()
        {
            return new SqlConnection(DataAccesLayer.Properties.Settings.Default.ConnectionString);
        }
    }
}
