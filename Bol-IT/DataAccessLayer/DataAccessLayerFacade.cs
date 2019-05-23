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
        /// <summary>
        /// Kontrollerer om input parameterene indeholder forbudte 
        /// </summary>
        /// <param name="checkString"></param>
        /// <returns></returns>
        public static bool CheckForSQLInjection(params string[] checkString)
        {
            return MethodsDataAccessLayer.CheckForSQLInjection(checkString);
        }

        #region SQL

        //Christoffer
        /// <summary>
        /// Returnerer en SqlConnection til brug af testing
        /// </summary>
        /// <returns></returns>
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["AzureDB"].ConnectionString);
        }

        #endregion

        #region Person

        //Christoffer
        /// <summary>
        /// Returnerer den persontype der passer på det id, der er sat ind via parameter
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetPersonTypeById(int id)
        {
            return MethodsDataAccessLayer.GetPersonTypeById(id);
        }

        public static List<Document> GetDocumentsByCaseNr(int id)
        {
            return MethodsDataAccessLayer.GetDocumentsByCaseNr(id);
        }

        #region Seller

        //Christoffer
        /// <summary>
        /// Laver en sælger person ud fra de påkrævede parameter
        /// </summary>
        /// <param name="fName"></param>
        /// <param name="mName"></param>
        /// <param name="lName"></param>
        /// <param name="phoneNr"></param>
        /// <param name="address"></param>
        /// <param name="zipcode"></param>
        /// <param name="mail"></param>
        /// <param name="aId"></param>
        public static void CreateSeller(string fName, string mName, string lName, int phoneNr, string address, int zipcode, string mail, int aId)
        {
            MethodsDataAccessLayer.CreateSeller(fName, mName, lName, phoneNr, address, zipcode, mail, aId);
        }

        /// <summary>
        /// Returnerer et objekt som giver informationer omkring relationen mellem en sælger og et hus
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static WantsToSell GetSellerInformationByCaseNr(int id)
        {
            return MethodsDataAccessLayer.GetWantsToSellByCaseNr(id);
        }

        /// <summary>
        /// Returnerer alle sælgerer i form af objekter
        /// </summary>
        /// <returns></returns>
        public static List<Seller> GetSellers()
        {
            return MethodsDataAccessLayer.GetSellers();
        }

        //Tobias
        /// <summary>
        /// Opdaterer en sælger ud fra den første parameter, Id'et, og de resterende parameter bliver herefter opdateret
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fName"></param>
        /// <param name="mName"></param>
        /// <param name="lName"></param>
        /// <param name="phoneNr"></param>
        /// <param name="address"></param>
        /// <param name="zipcode"></param>
        /// <param name="mail"></param>
        /// <param name="aId"></param>
        public static void SellerUpdateData(int id, string fName, string mName, string lName, int phoneNr, string address, int zipcode, string mail, int aId)
        {
            MethodsDataAccessLayer.SellerUpdateData(id, fName, mName, lName, phoneNr, address, zipcode, mail, aId);
        }

        public static Seller GetSellerById(int id)
        {
            return MethodsDataAccessLayer.GetSellerById(id);
        }

        #endregion

        #region Buyer

        //Christoffer
        /// <summary>
        /// Laver en køber person ud fra de påkrævede parameter
        /// </summary>
        /// <param name="fName"></param>
        /// <param name="mName"></param>
        /// <param name="lName"></param>
        /// <param name="phoneNr"></param>
        /// <param name="address"></param>
        /// <param name="zipcode"></param>
        /// <param name="mail"></param>
        /// <param name="aId"></param>
        public static void CreateBuyer(string fName, string mName, string lName, int phoneNr, string address, int zipcode, string mail, int aId)
        {
            MethodsDataAccessLayer.CreateBuyer(fName, mName, lName, phoneNr, address, zipcode, mail, aId);
        }

        //Tobias
        /// <summary>
        /// Opdaterer en køber ud fra den første parameter, Id'et, og de resterende parameter bliver herefter opdateret
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fName"></param>
        /// <param name="mName"></param>
        /// <param name="lName"></param>
        /// <param name="phoneNr"></param>
        /// <param name="address"></param>
        /// <param name="zipcode"></param>
        /// <param name="mail"></param>
        /// <param name="aId"></param>
        public static void BuyerUpdateData(int id, string fName, string mName, string lName, int phoneNr, string address, int zipcode, string mail, int aId)
        {
            MethodsDataAccessLayer.BuyerUpdateData(id, fName, mName, lName, phoneNr, address, zipcode, mail, aId);
        }

        public static Buyer GetBuyerById(int id)
        {
            return MethodsDataAccessLayer.GetBuyerById(id);
        }

        #endregion

        #region Agent

        //Christoffer
        /// <summary>
        /// Laver en køber person ud fra de påkrævede parameter
        /// </summary>
        /// <param name="fName">Fornavn</param>
        /// <param name="mName"></param>
        /// <param name="lName"></param>
        /// <param name="phoneNr"></param>
        /// <param name="address"></param>
        /// <param name="zipcode"></param>
        /// <param name="mail"></param>
        /// <param name="nrOfSales"></param>
        public static void CreateAgent(string fName, string mName, string lName, int phoneNr, string address, int zipcode, string mail, int nrOfSales)
        {
            MethodsDataAccessLayer.CreateAgent(fName, mName, lName, phoneNr, address, zipcode, mail, nrOfSales);
        }

        /// <summary>
        /// Returnerer en mælger ud fra et Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Agent GetAgentById(int id)
        {
            return MethodsDataAccessLayer.GetAgentById(id);
        }

        public static agentDataTable GetAllAgentIds()
        {
            return MethodsDataAccessLayer.GetAllAgentIds();
        }

        public static sellerDataTable GetAllSellerIds()
        {
            return MethodsDataAccessLayer.GetAllSellerIds();
        }

        public static buyerDataTable GetAllBuyerIds()
        {
            return MethodsDataAccessLayer.GetAllBuyerIds();
        }

        //Tobias
        /// <summary>
        /// Returnerer et data table af alle mægler
        /// </summary>
        /// <returns></returns>
        public static agentDataTable GetAgentDataTable()
        {
            return MethodsDataAccessLayer.GetAgentDataTable();
        }

        /// <summary>
        /// Returnerer et data table af mælger ud fra søge parameterne
        /// </summary>
        /// <param name="searchParameters"></param>
        /// <returns></returns>
        public static agentDataTable GetAgentDataTableByLike(int searchParameters)
        {
            return MethodsDataAccessLayer.GetAgentDataTableByLike(searchParameters);
        }

        /// <summary>
        /// Opdaterer en mælger ud fra den første parameter, Id'et, og de resterende parameter bliver herefter opdateret
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fName"></param>
        /// <param name="mName"></param>
        /// <param name="lName"></param>
        /// <param name="phoneNr"></param>
        /// <param name="address"></param>
        /// <param name="zipcode"></param>
        /// <param name="mail"></param>
        /// <param name="nrOfSales"></param>
        public static void AgentUpdateData(int id, string fName, string mName, string lName, int phoneNr, string address, int zipcode, string mail, int nrOfSales)
        {
            MethodsDataAccessLayer.AgentUpdateData(id, fName, mName, lName, phoneNr, address, zipcode, mail, nrOfSales);
        }

        #endregion

        #endregion

        #region Property

        //Christoffer
        /// <summary>
        /// Laver en bolig ud fra de påkrævede parameter
        /// </summary>
        /// <param name="sId"></param>
        /// <param name="desiredPrice"></param>
        /// <param name="timeFrame"></param>
        /// <param name="netPrice"></param>
        /// <param name="grossPrice"></param>
        /// <param name="ownerExpenses"></param>
        /// <param name="cashPrice"></param>
        /// <param name="depositPrice"></param>
        /// <param name="address"></param>
        /// <param name="zipcode"></param>
        /// <param name="nrOfRooms"></param>
        /// <param name="garageFlag"></param>
        /// <param name="builtRebuild"></param>
        /// <param name="houseType"></param>
        /// <param name="energyRating"></param>
        /// <param name="resSquareMeters"></param>
        /// <param name="propSquareMeters"></param>
        /// <param name="floors"></param>
        /// <param name="soldFlag"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public static int CreateProperty(int sId, int desiredPrice, int timeFrame, int netPrice, int grossPrice, int ownerExpenses, int cashPrice,
            int depositPrice, string address, int zipcode, int nrOfRooms, bool garageFlag, string builtRebuild, string houseType, string energyRating,
             int resSquareMeters, int propSquareMeters, int floors, bool soldFlag, string description)
        {
            return MethodsDataAccessLayer.CreateProperty(sId, desiredPrice, timeFrame, netPrice, grossPrice, ownerExpenses, cashPrice, depositPrice, address, zipcode, nrOfRooms,
                garageFlag, builtRebuild, houseType, energyRating, resSquareMeters, propSquareMeters, floors, soldFlag, description);
        }


        //Christoffer
        /// <summary>
        /// Opdaterer en bolig ud fra den første parameter, Id'et, og de resterende parameter bliver herefter opdateret
        /// </summary>
        /// <param name="caseNr"></param>
        /// <param name="sId"></param>
        /// <param name="desiredPrice"></param>
        /// <param name="timeFrame"></param>
        /// <param name="netPrice"></param>
        /// <param name="grossPrice"></param>
        /// <param name="ownerExpenses"></param>
        /// <param name="cashPrice"></param>
        /// <param name="depositPrice"></param>
        /// <param name="address"></param>
        /// <param name="zipcode"></param>
        /// <param name="nrOfRooms"></param>
        /// <param name="garageFlag"></param>
        /// <param name="builtRebuild"></param>
        /// <param name="houseType"></param>
        /// <param name="energyRating"></param>
        /// <param name="resSquareMeters"></param>
        /// <param name="propSquareMeters"></param>
        /// <param name="floors"></param>
        /// <param name="soldFlag"></param>
        /// <param name="description"></param>
        public static void UpdateProperty(int caseNr, int sId, int desiredPrice, int timeFrame, int netPrice, int grossPrice, int ownerExpenses, int cashPrice,
            int depositPrice, string address, int zipcode, int nrOfRooms, bool garageFlag, string builtRebuild, string houseType, string energyRating,
             int resSquareMeters, int propSquareMeters, int floors, bool soldFlag, string description)
        {
            MethodsDataAccessLayer.UpdateProperty(caseNr, sId, desiredPrice, timeFrame, netPrice, grossPrice, ownerExpenses, cashPrice, depositPrice, 
                address, zipcode, nrOfRooms, garageFlag, builtRebuild, houseType, energyRating, resSquareMeters, propSquareMeters, floors, soldFlag, description);
        }

        //Caspar
        //Sletter en ejendom fra databasen vha. dens caseNr.
        public static void DeleteProperty(int caseNr)
        {
            MethodsDataAccessLayer.DeleteProperty(caseNr);
        }

        //Tobias
        /// <summary>
        /// Returnerer alle boliger i et data table
        /// </summary>
        /// <returns></returns>
        public static propertyDataTable GetPropertyDataTable()
        {
            return MethodsDataAccessLayer.GetPropertyDataTable();
        }

        //Tobias
        /// <summary>
        /// Returnerer et data table over boliger udfra de angivende parameter, 
        /// henholdsvist en række parameter (adresse, postnummer, m.m.) og hvorvidt boligen er solgt
        /// </summary>
        /// <param name="searchParameters"></param>
        /// <param name="soldFlag"></param>
        /// <returns></returns>
        public static propertyDataTable GetPropertyDataTableByLike(string searchParameters, bool soldFlag)
        {
            return MethodsDataAccessLayer.GetPropertyDataTableByLike(soldFlag, searchParameters);
        }

        //Christoffer
        /// <summary>
        /// Returnerer et data table over boliger udfra de angivende parameter, 
        /// henholdsvist en række parameter (adresse, postnummer, m.m.)
        /// </summary>
        /// <param name="searchParameters"></param>
        /// <returns></returns>
        public static propertyDataTable GetPropertyDataTableByLikeAll(string searchParameters)
        {
            return MethodsDataAccessLayer.GetPropertyDataTableByLikeAll(searchParameters);
        }

        //Tobias
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Property GetProperty(int id)
        {
            return MethodsDataAccessLayer.GetProperty(id);
        }

        #endregion

        #region Sale
        //Tobias
        public static saleDataTable StatisticSquareMeterPrice(decimal SearchYear, decimal SearchMonth)
        {
            return MethodsDataAccessLayer.StatisticSquareMeterPrice(SearchYear, SearchMonth);
        }
        //Christoffer og Simone
        public static int StatisticSquareMeterPriceByZipcode(int zipcode)
        {
            return MethodsDataAccessLayer.StatisticSquareMeterPriceByZipcode(zipcode);
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
        //Christoffer og Simone
        public static DataTable StatisticsSoldAreaGetAll()
        {
            return MethodsDataAccessLayer.StatisticsSoldArea();
        }


        #endregion

        #region File
        //Christoffer
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
            MethodsDataAccessLayer.UpdateData(originalFileName, caseNr, fileName, extName, photo);
        }
        public static void UpdateFiles(string originalFileName, int caseNr, string fileName, string extName, byte[] data)
        {
            MethodsDataAccessLayer.UpdateData(originalFileName, caseNr, fileName, extName, data);
        }
        public static void RemoveFiles(string fileName)
        {
            MethodsDataAccessLayer.RemoveData(fileName);
        }
        public static string GetPhotoExtFromName(string nameOfPhoto)
        {
            return MethodsDataAccessLayer.GetPhotoExtFromName(nameOfPhoto);
        }
        #endregion

        #region PersonalData
        //Tobias
        public static personalDataDataTable GetPersonalDataDataTable()
        {
            return MethodsDataAccessLayer.GetPersonalDataDataTable();
        }
        public static personalDataDataTable GetPersonalDataDataTableByLike(string searchParameters)
        {
            return MethodsDataAccessLayer.GetPersonalDataDataTableByLike(searchParameters);
        }

        public static Document GetDocumentByName(string name)
        {
            return MethodsDataAccessLayer.GetDocumentByName(name);
        }

        #endregion
    }
}
