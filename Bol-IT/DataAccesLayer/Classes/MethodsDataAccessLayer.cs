using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{
    class MethodsDataAccessLayer
    {
        #region TableAdapters
        public static mydatabasetobbeDataSetTableAdapters.agentTableAdapter agentTableAdapter = new mydatabasetobbeDataSetTableAdapters.agentTableAdapter();
        public static mydatabasetobbeDataSetTableAdapters.assesmentTableAdapter assesmentTableAdapter = new mydatabasetobbeDataSetTableAdapters.assesmentTableAdapter();
        public static mydatabasetobbeDataSetTableAdapters.buyerTableAdapter buyerTableAdapter = new mydatabasetobbeDataSetTableAdapters.buyerTableAdapter();
        public static mydatabasetobbeDataSetTableAdapters.externalContactsTableAdapter externalContactsTableAdapter = new mydatabasetobbeDataSetTableAdapters.externalContactsTableAdapter();
        public static mydatabasetobbeDataSetTableAdapters.filesTableAdapter filesTableAdapter = new mydatabasetobbeDataSetTableAdapters.filesTableAdapter();
        public static mydatabasetobbeDataSetTableAdapters.personalDataTableAdapter personalDataTableAdapter = new mydatabasetobbeDataSetTableAdapters.personalDataTableAdapter();
        public static mydatabasetobbeDataSetTableAdapters.propertyTableAdapter propertyTableAdapter = new mydatabasetobbeDataSetTableAdapters.propertyTableAdapter();
        public static mydatabasetobbeDataSetTableAdapters.saleTableAdapter saleTableAdapter = new mydatabasetobbeDataSetTableAdapters.saleTableAdapter();
        public static mydatabasetobbeDataSetTableAdapters.sellerTableAdapter sellerTableAdapter = new mydatabasetobbeDataSetTableAdapters.sellerTableAdapter();
        public static mydatabasetobbeDataSetTableAdapters.TableAdapterManager TableAdapterManager = new mydatabasetobbeDataSetTableAdapters.TableAdapterManager();
        public static mydatabasetobbeDataSetTableAdapters.wantsToSellTableAdapter wantsToSellTableAdapter = new mydatabasetobbeDataSetTableAdapters.wantsToSellTableAdapter();
        public static mydatabasetobbeDataSetTableAdapters.worksWithTableAdapter worksWithTableAdapter = new mydatabasetobbeDataSetTableAdapters.worksWithTableAdapter();
        #endregion TableAdapters

        public static void CreateAgent(string fName, string mName, string lName, int phoneNr, string address, int zipcode, string mail, int nrOfSales)
        {
            int id = personalDataTableAdapter.InsertData(fName, mName, lName, phoneNr, address, zipcode, mail);
            agentTableAdapter.InsertData(id, nrOfSales);

        }
    }
}
