using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccesLayer.mydatabasetobbeDataSetTableAdapters;

namespace DataAccesLayer
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
    }
}
