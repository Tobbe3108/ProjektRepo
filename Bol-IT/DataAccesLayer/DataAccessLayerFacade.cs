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
        public static DataAccesLayer.mydatabasetobbeDataSetTableAdapters.agentTableAdapter agentTableAdapter = new DataAccesLayer.mydatabasetobbeDataSetTableAdapters.agentTableAdapter();
        public static DataAccesLayer.mydatabasetobbeDataSetTableAdapters.assesmentTableAdapter assesmentTableAdapter = new DataAccesLayer.mydatabasetobbeDataSetTableAdapters.assesmentTableAdapter();
        public static DataAccesLayer.mydatabasetobbeDataSetTableAdapters.buyerTableAdapter buyerTableAdapter = new DataAccesLayer.mydatabasetobbeDataSetTableAdapters.buyerTableAdapter();
        public static DataAccesLayer.mydatabasetobbeDataSetTableAdapters.externalContactsTableAdapter externalContactsTableAdapter = new DataAccesLayer.mydatabasetobbeDataSetTableAdapters.externalContactsTableAdapter();
        public static DataAccesLayer.mydatabasetobbeDataSetTableAdapters.filesTableAdapter filesTableAdapter = new DataAccesLayer.mydatabasetobbeDataSetTableAdapters.filesTableAdapter();
        public static DataAccesLayer.mydatabasetobbeDataSetTableAdapters.personalDataTableAdapter personalDataTableAdapter = new DataAccesLayer.mydatabasetobbeDataSetTableAdapters.personalDataTableAdapter();
        public static DataAccesLayer.mydatabasetobbeDataSetTableAdapters.propertyTableAdapter propertyTableAdapter = new DataAccesLayer.mydatabasetobbeDataSetTableAdapters.propertyTableAdapter();
        public static DataAccesLayer.mydatabasetobbeDataSetTableAdapters.saleTableAdapter saleTableAdapter = new DataAccesLayer.mydatabasetobbeDataSetTableAdapters.saleTableAdapter();
        public static DataAccesLayer.mydatabasetobbeDataSetTableAdapters.sellerTableAdapter sellerTableAdapter = new DataAccesLayer.mydatabasetobbeDataSetTableAdapters.sellerTableAdapter();
        public static DataAccesLayer.mydatabasetobbeDataSetTableAdapters.TableAdapterManager TableAdapterManager = new DataAccesLayer.mydatabasetobbeDataSetTableAdapters.TableAdapterManager();
        public static DataAccesLayer.mydatabasetobbeDataSetTableAdapters.wantsToSellTableAdapter wantsToSellTableAdapter = new DataAccesLayer.mydatabasetobbeDataSetTableAdapters.wantsToSellTableAdapter();
        public static DataAccesLayer.mydatabasetobbeDataSetTableAdapters.worksWithTableAdapter worksWithTableAdapter = new DataAccesLayer.mydatabasetobbeDataSetTableAdapters.worksWithTableAdapter();
        

        public static SqlConnection GetConnection()
        {
            int id = personalDataTableAdapter.
            personalDataTableAdapter.GetDataByNames();
            agentTableAdapter.Insert(id, 87);

            return new SqlConnection(connectionString: ConfigurationManager.AppSettings["AzureDB"]);
        }
    }
}
