using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Classes;
using DataAccessLayer.mydatabasetobbeDataSetTableAdapters;
using static DataAccessLayer.mydatabasetobbeDataSet;

namespace DataAccessLayer
{
    class MethodsDataAccessLayer
    {
        #region TableAdapters
        public static saleTableAdapter saleTableAdapter = new saleTableAdapter();
        public static agentTableAdapter agentTableAdapter = new agentTableAdapter();
        public static buyerTableAdapter buyerTableAdapter = new buyerTableAdapter();
        public static filesTableAdapter filesTableAdapter = new filesTableAdapter();
        public static sellerTableAdapter sellerTableAdapter = new sellerTableAdapter();
        public static TableAdapterManager TableAdapterManager = new TableAdapterManager();
        public static propertyTableAdapter propertyTableAdapter = new propertyTableAdapter();
        public static worksWithTableAdapter worksWithTableAdapter = new worksWithTableAdapter();
        public static assesmentTableAdapter assesmentTableAdapter = new assesmentTableAdapter();
        public static wantsToSellTableAdapter wantsToSellTableAdapter = new wantsToSellTableAdapter();
        public static personalDataTableAdapter personalDataTableAdapter = new personalDataTableAdapter();
        public static externalContactsTableAdapter externalContactsTableAdapter = new externalContactsTableAdapter();
        #endregion TableAdapters

        #region CreateMethods
        public static void CreateAgent(string fName, string mName, string lName, int phoneNr, string address, int zipcode, string mail, int nrOfSales)
        {
            int id = personalDataTableAdapter.InsertData(fName, mName, lName, phoneNr, address, zipcode, mail);
            agentTableAdapter.InsertData(id, nrOfSales);
        }
        public static void CreateSeller(string fName, string mName, string lName, int phoneNr, string address, int zipcode, string mail, int aId)
        {
            int id = personalDataTableAdapter.InsertData(fName, mName, lName, phoneNr, address, zipcode, mail);
            sellerTableAdapter.InsertData(id, aId);
        }
        public static void CreateBuyer(string fName, string mName, string lName, int phoneNr, string address, int zipcode, string mail, int aId)
        {
            int id = personalDataTableAdapter.InsertData(fName, mName, lName, phoneNr, address, zipcode, mail);
            buyerTableAdapter.InsertData(id, aId);
        }
        #endregion CreateMethods

        #region SearchMethods
        public static agentDataTable GetAgentDataTable()
        {
            agentDataTable adt = new agentDataTable();
            agentTableAdapter.Fill(adt);
            return adt;
        }
        public static propertyDataTable GetPropertyDataTable()
        {
            propertyDataTable adt = new propertyDataTable();
            propertyTableAdapter.Fill(adt);
            return adt;
        }

        public static Agent GetAgent(int id)
        {
            Agent agent = new Agent();
            agentDataTable adt = new agentDataTable();
            agentTableAdapter.FillById(adt, id);
            //agentDataTable adt = agentTableAdapter.GetDataById(id);
            //object pdt = personalDataTableAdapter.GetDataById(id);
            
            return agent;
        }
        #endregion
    }
}
