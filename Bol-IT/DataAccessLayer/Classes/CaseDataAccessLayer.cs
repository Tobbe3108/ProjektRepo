using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer.Classes;
using System.Data.SqlClient;

namespace DataAccessLayer.Classes
{
    public class PropertyDataAccessLayer
    {
        //Singleton instance af Form1
        static PropertyDataAccessLayer _instance;
        public static PropertyDataAccessLayer Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PropertyDataAccessLayer();
                }
                return _instance;
            }
        }
        public void CreateEntry(Property property)
        {
            using (SqlConnection connection = DataAccessLayerFacade.GetConnection())
            {
                using (SqlCommand command = new SqlCommand())
                {                    
                    command.CommandText = "";
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void EditEntry(int id, Property property)
        {
            using (SqlConnection connection = DataAccessLayerFacade.GetConnection())
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "";
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public Property GetEntry(int id)
        {
            Property retval = new Property();

            using (SqlConnection connection = DataAccessLayerFacade.GetConnection())
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "";
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            return retval;
        }
    }
}
