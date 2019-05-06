using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using BusinessLayer;
using System.Configuration;
using DataAccessLayer.mydatabasetobbeDataSetTableAdapters;
using static DataAccessLayer.mydatabasetobbeDataSet;

namespace DataAccessLayer
{
    public class DataAccessLayerFacade
    {
        #region SQL

        //Christoffer
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString: ConfigurationManager.AppSettings["AzureDB"]);
        }

        #endregion

        #region Seller

        //Christoffer
        public static void CreateSeller(string fName, string mName, string lName, int phoneNr, string address, int zipcode, string mail, int aId)
        {
            MethodsDataAccessLayer.CreateSeller(fName, mName, lName, phoneNr, address, zipcode, mail, aId);
        }

        //Christoffer
        public static List<Seller> GetSellers()
        {
            return MethodsDataAccessLayer.GetSellers();
        }

        #endregion

        #region Buyer

        //Christoffer
        public static void CreateBuyer(string fName, string mName, string lName, int phoneNr, string address, int zipcode, string mail, int aId)
        {
            MethodsDataAccessLayer.CreateBuyer(fName, mName, lName, phoneNr, address, zipcode, mail, aId);
        }

        #endregion

        #region Agent

        //Christoffer
        public static void CreateAgent(string fName, string mName, string lName, int phoneNr, string address, int zipcode, string mail, int nrOfSales)
        {
            MethodsDataAccessLayer.CreateAgent(fName, mName, lName, phoneNr, address, zipcode, mail, nrOfSales);
        }

        //Christoffer
        public static Agent GetAgentById(int id)
        {
            return MethodsDataAccessLayer.GetAgentById(id);
        }

        //Tobias
        public static agentDataTable GetAgentDataTable()
        {
            return MethodsDataAccessLayer.GetAgentDataTable();
        }

        //Tobias
        public static agentDataTable GetAgentDataTableByLike(int searchParameters)
        {
            return MethodsDataAccessLayer.GetAgentDataTableByLike(searchParameters);
        }

        public static Agent GetAgentById(int id)
        {
            return MethodsDataAccessLayer.GetAgentById(id);
        }

        #endregion

        #region Property

        //Tobias
        public static propertyDataTable GetPropertyDataTable()
        {
            return MethodsDataAccessLayer.GetPropertyDataTable();
        }

        //Tobias
        public static propertyDataTable GetPropertyDataTableByLike(string searchParameters)
        {
            return MethodsDataAccessLayer.GetPropertyDataTableByLike(searchParameters);
        }

        //Tobias
        public static Property GetProperty(int id)
        {
            return MethodsDataAccessLayer.GetProperty(id);
        }

        //Tobias
        public static propertyDataTable GetZipcodes()
        {
            return MethodsDataAccessLayer.GetZipcodes();
        }

        #endregion
    }
}
