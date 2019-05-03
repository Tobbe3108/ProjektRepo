using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using BusinessLayer.Classes;
using System.Configuration;
using DataAccessLayer.mydatabasetobbeDataSetTableAdapters;

namespace DataAccessLayer
{
    public class DataAccessLayerFacade
    {        
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString: ConfigurationManager.AppSettings["AzureDB"]);
        }

        public static void CreateAgent(string fName, string mName, string lName, int phoneNr, string address, int zipcode, string mail, int nrOfSales)
        {
            MethodsDataAccessLayer.CreateAgent(fName, mName, lName, phoneNr, address, zipcode, mail, nrOfSales);
        }

        public static void CreateSeller(string fName, string mName, string lName, int phoneNr, string address, int zipcode, string mail, int aId)
        {
            MethodsDataAccessLayer.CreateSeller(fName, mName, lName, phoneNr, address, zipcode, mail, aId);
        }




    }
}
