using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using GlobalClasses;
using System.Configuration;
using DataAccessLayer.mydatabasetobbeDataSetTableAdapters;
using static DataAccessLayer.mydatabasetobbeDataSet;
using System.Data;

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

        public static WantsToSell GetSellerInformationByCaseNr(int id)
        {
            return MethodsDataAccessLayer.GetWantsToSellByCaseNr(id);
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

        #endregion

        #region Property

        //Christoffer
        public static int CreateProperty(int sId, int desiredPrice, int timeFrame, int netPrice, int grossPrice, int ownerExpenses, int cashPrice,
            int depositPrice, string address, int zipcode, int nrOfRooms, bool garageFlag, string builtRebuild, string houseType, string energyRating,
             int resSquareMeters, int propSquareMeters, int floors, bool soldFlag, string description)
        {
            return MethodsDataAccessLayer.CreateProperty(sId, desiredPrice, timeFrame, netPrice, grossPrice, ownerExpenses, cashPrice, depositPrice, address, zipcode, nrOfRooms,
                garageFlag, builtRebuild, houseType, energyRating, resSquareMeters, propSquareMeters, floors, soldFlag, description);
        }

        public static void UpdateProperty(int caseNr, int sId, int desiredPrice, int timeFrame, int netPrice, int grossPrice, int ownerExpenses, int cashPrice,
            int depositPrice, string address, int zipcode, int nrOfRooms, bool garageFlag, string builtRebuild, string houseType, string energyRating,
             int resSquareMeters, int propSquareMeters, int floors, bool soldFlag, string description)
        {
            MethodsDataAccessLayer.UpdateProperty(caseNr, sId, desiredPrice, timeFrame, netPrice, grossPrice, ownerExpenses, cashPrice, depositPrice, 
                address, zipcode, nrOfRooms, garageFlag, builtRebuild, houseType, energyRating, resSquareMeters, propSquareMeters, floors, soldFlag, description);
        }

        //Tobias
        public static propertyDataTable GetPropertyDataTable()
        {
            return MethodsDataAccessLayer.GetPropertyDataTable();
        }

        //Tobias
        public static propertyDataTable GetPropertyDataTableByLike(string searchParameters, bool soldFlag)
        {
            return MethodsDataAccessLayer.GetPropertyDataTableByLike(searchParameters, soldFlag);
        }

        //Tobias
        public static Property GetProperty(int id)
        {
            return MethodsDataAccessLayer.GetProperty(id);
        }

        #endregion

        #region Sale

        public static saleDataTable StatisticSquareMeterPrice(decimal SearchYear, decimal SearchMonth)
        {
            return MethodsDataAccessLayer.StatisticSquareMeterPrice(SearchYear, SearchMonth);
        }

        //Tobias
        public static saleDataTable GetZipcodes()
        {
            return MethodsDataAccessLayer.GetZipcodes();
        }

        //Tobias
        public static saleDataTable StatisticsSoldArea(int zipcode)
        {
            return MethodsDataAccessLayer.StatisticsSoldArea(zipcode);
        }

        public static DataTable StatisticsSoldAreaGetAll()
        {
            return MethodsDataAccessLayer.StatisticsSoldArea();
        }


        #endregion

        #region File

        public static void CreateFile(int caseNr, string nameOfFile, string extOfFile, byte[] dataOfFile)
        {
            MethodsDataAccessLayer.CreateFile(caseNr, nameOfFile, extOfFile, dataOfFile);
        }
        
        public static byte[] GetPhotoFromId(int id)
        {
            return MethodsDataAccessLayer.GetPhotoFromId(id);
        }

        public static string GetPhotoNameFromIdAndPhoto(int id, byte[] photo)
        {
            return MethodsDataAccessLayer.GetPhotoNameFromIdAndPhoto(id, photo);
        }

        public static void UpdatePhoto(string originalFileName, int caseNr, string fileName, string extName, byte[] photo)
        {
            MethodsDataAccessLayer.UpdatePhoto(originalFileName, caseNr, fileName, extName, photo);
        }

        public static string GetPhotoExtFromName(string nameOfPhoto)
        {
            return MethodsDataAccessLayer.GetPhotoExtFromName(nameOfPhoto);
        }





        #endregion
    }
}
