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

        public static saleTableAdapter saleTableAdapter()
        {
            return MethodsDataAccessLayer.saleTableAdapter;
        }

        public static agentTableAdapter agentTableAdapter()
        {
            return MethodsDataAccessLayer.agentTableAdapter;
        }

        public static buyerTableAdapter buyerTableAdapter()
        {
            return MethodsDataAccessLayer.buyerTableAdapter;
        }

        public static filesTableAdapter filesTableAdapter()
        {
            return MethodsDataAccessLayer.filesTableAdapter;
        }

        public static sellerTableAdapter sellerTableAdapter()
        {
            return MethodsDataAccessLayer.sellerTableAdapter;
        }

        public static TableAdapterManager TableAdapterManager()
        {
            return MethodsDataAccessLayer.TableAdapterManager;
        }

        public static propertyTableAdapter propertyTableAdapter()
        {
            return MethodsDataAccessLayer.propertyTableAdapter;
        }

        public static worksWithTableAdapter worksWithTableAdapter()
        {
            return MethodsDataAccessLayer.worksWithTableAdapter;
        }

        public static assesmentTableAdapter assesmentTableAdapter()
        {
            return MethodsDataAccessLayer.assesmentTableAdapter;
        }

        public static wantsToSellTableAdapter wantsToSellTableAdapter()
        {
            return MethodsDataAccessLayer.wantsToSellTableAdapter;
        }

        public static personalDataTableAdapter personalDataTableAdapter()
        {
            return MethodsDataAccessLayer.personalDataTableAdapter;
        }

        public static externalContactsTableAdapter externalContactsTableAdapter()
        {
            return MethodsDataAccessLayer.externalContactsTableAdapter;
        }




    }
}
