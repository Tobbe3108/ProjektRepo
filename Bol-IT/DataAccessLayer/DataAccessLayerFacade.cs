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
        /// Kontrollerer om input parameterene indeholder forbudte, 
        /// returnerer true hvis parameterne potentielt kunne injectes med kode. 
        /// Giver en messagebox hvis den returnerer false. 
        /// Hvis der ikke er noget galt, returnerer den false
        /// </summary>
        public static bool CheckForSQLInjection(params string[] checkString)
        {
            return MethodsDataAccessLayer.CheckForSQLInjection(checkString);
        }

        public static SqlConnection GetConnection()
        {
            return MethodsDataAccessLayer.GetConnection();
        }

        #region SQL




        #endregion

        #region Personer

        #region PersonalData
        //Tobias
        /// <summary>
        /// Får alle personinformationer og returnerer dem i et dataTable
        /// </summary>
        /// <returns></returns>
        public static personalDataDataTable GetPersonalDataDataTable()
        {
            return MethodsDataAccessLayer.GetPersonalDataDataTable();
        }
        /// <summary>
        /// Finder alle personer som matcher søgeparameterne og returnerer dem i et dataTable. 
        /// Søgeparameter kigger på id, navne, adresser, email, numre osv.
        /// </summary>
        public static personalDataDataTable GetPersonalDataDataTableByLike(string searchParameters)
        {
            return MethodsDataAccessLayer.GetPersonalDataDataTableByLike(searchParameters);
        }
        
        //Christoffer
        /// <summary>
        /// Returnerer den persontype der passer på det id, der er sat ind via parameter
        /// </summary>
        public static string GetPersonTypeById(int id)
        {
            return MethodsDataAccessLayer.GetPersonTypeById(id);
        }

        #endregion
        
        #region Seller

        //Christoffer
        /// <summary>
        /// Laver en sælger person ud fra de påkrævede parameter
        /// </summary>
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
        public static void SellerUpdateData(int id, string fName, string mName, string lName, int phoneNr, string address, int zipcode, string mail, int aId)
        {
            MethodsDataAccessLayer.SellerUpdateData(id, fName, mName, lName, phoneNr, address, zipcode, mail, aId);
        }
        /// <summary>
        /// Finder en sælger ud fra dens id og returnerer den som et objekt
        /// </summary>
        public static Seller GetSellerById(int id)
        {
            return MethodsDataAccessLayer.GetSellerById(id);
        }
        /// <summary>
        /// Returnerer alle sælgernes Id'er i en dataTable
        /// </summary>
        public static sellerDataTable GetAllSellerIds()
        {
            return MethodsDataAccessLayer.GetAllSellerIds();
        }

        #endregion

        #region Buyer

        //Christoffer
        /// <summary>
        /// Laver en køber person ud fra de påkrævede parameter
        /// </summary>
        public static void CreateBuyer(string fName, string mName, string lName, int phoneNr, string address, int zipcode, string mail, int aId)
        {
            MethodsDataAccessLayer.CreateBuyer(fName, mName, lName, phoneNr, address, zipcode, mail, aId);
        }

        //Tobias
        /// <summary>
        /// Opdaterer en køber ud fra den første parameter, Id'et, og de resterende parameter bliver herefter opdateret
        /// </summary>
        public static void BuyerUpdateData(int id, string fName, string mName, string lName, int phoneNr, string address, int zipcode, string mail, int aId)
        {
            MethodsDataAccessLayer.BuyerUpdateData(id, fName, mName, lName, phoneNr, address, zipcode, mail, aId);
        }
        /// <summary>
        /// Finder en køber ud fra dens id og returnerer den som et objekt
        /// </summary>
        public static Buyer GetBuyerById(int id)
        {
            return MethodsDataAccessLayer.GetBuyerById(id);
        }
        /// <summary>
        /// Returnerer alle købernes Id'er i en dataTable
        /// </summary>
        public static buyerDataTable GetAllBuyerIds()
        {
            return MethodsDataAccessLayer.GetAllBuyerIds();
        }
        #endregion

        #region Agent

        //Christoffer
        /// <summary>
        /// Laver en køber person ud fra de påkrævede parameter
        /// </summary>
        public static void CreateAgent(string fName, string mName, string lName, int phoneNr, string address, int zipcode, string mail, int nrOfSales)
        {
            MethodsDataAccessLayer.CreateAgent(fName, mName, lName, phoneNr, address, zipcode, mail, nrOfSales);
        }
        /// <summary>
        /// Returnerer en mælger ud fra et Id
        /// </summary>
        public static Agent GetAgentById(int id)
        {
            return MethodsDataAccessLayer.GetAgentById(id);
        }
        /// <summary>
        /// Returnerer alle agenternes Id'er i en dataTable
        /// </summary>
        public static agentDataTable GetAllAgentIds()
        {
            return MethodsDataAccessLayer.GetAllAgentIds();
        }
        
        //Tobias
        /// <summary>
        /// Returnerer et data table af alle mægler
        /// </summary>
        public static agentDataTable GetAgentDataTable()
        {
            return MethodsDataAccessLayer.GetAgentDataTable();
        }

        /// <summary>
        /// Returnerer et data table af mælger ud fra søge parameterne
        /// </summary>
        public static agentDataTable GetAgentDataTableByLike(int searchParameters)
        {
            return MethodsDataAccessLayer.GetAgentDataTableByLike(searchParameters);
        }

        /// <summary>
        /// Opdaterer en mælger ud fra den første parameter, Id'et, og de resterende parameter bliver herefter opdateret
        /// </summary>
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
        /// Får og returnerer alle boliger i et data table
        /// </summary>
        public static propertyDataTable GetPropertyDataTable()
        {
            return MethodsDataAccessLayer.GetPropertyDataTable();
        }

        //Tobias
        /// <summary>
        /// Returnerer et data table over boliger udfra de angivende parameter, 
        /// henholdsvist en række parameter (adresse, postnummer, m.m.) og hvorvidt boligen er solgt
        /// </summary>
        public static propertyDataTable GetPropertyDataTableByLike(string searchParameters, bool soldFlag)
        {
            return MethodsDataAccessLayer.GetPropertyDataTableByLike(soldFlag, searchParameters);
        }

        //Christoffer
        /// <summary>
        /// Returnerer et data table over boliger udfra de angivende parameter, 
        /// henholdsvist en række parameter (adresse, postnummer, m.m.)
        public static propertyDataTable GetPropertyDataTableByLikeAll(string searchParameters)
        {
            return MethodsDataAccessLayer.GetPropertyDataTableByLikeAll(searchParameters);
        }

        //Tobias
        /// <summary>
        /// Finder en property efter dens id og returnerer den som et objekt
        /// </summary>
        public static Property GetPropertyById(int id)
        {
            return MethodsDataAccessLayer.GetPropertyById(id);
        }

        #endregion

        #region Sale
        //Tobias
        /// <summary>
        /// Finder kvadratmeter prisen i boliger der er solgt ud fra år og måned og returnerer dem i en dataTable
        /// </summary>
        public static saleDataTable StatisticSquareMeterPrice(decimal SearchYear, decimal SearchMonth)
        {
            return MethodsDataAccessLayer.StatisticSquareMeterPrice(SearchYear, SearchMonth);
        }
        //Christoffer og Simone
        //Tobias
        /// <summary>
        /// Finder kvadratmeter prisen i boliger der er solgt ud fra et postnummer og returnerer dem i en dataTable
        /// </summary>
        public static int StatisticSquareMeterPriceByZipcode(int zipcode)
        {
            return MethodsDataAccessLayer.StatisticSquareMeterPriceByZipcode(zipcode);
        }

        //Tobias
        /// <summary>
        /// Returnerer et dataTable over alle unikke postnumre
        /// </summary>
        public static saleDataTable GetZipcodes()
        {
            return MethodsDataAccessLayer.GetZipcodes();
        }



        //Tobias
        /// <summary>
        /// Får salgsinformations over boliger solgt ud fra et postnummer, og returnerer dem i et dataTable med informationerne: 
        /// salesDate, fName, lName, aId, address, zipcode, caseNr, salesPrice
        /// </summary>
        public static saleDataTable StatisticsSoldArea(int zipcode)
        {
            return MethodsDataAccessLayer.StatisticsSoldArea(zipcode);
        }
        //Christoffer og Simone
        /// <summary>
        /// Får salgsinformations over boliger solgt, og returnerer dem i et dataTable med informationerne: 
        /// salesDate, fName, lName, aId, address, zipcode, caseNr, salesPrice
        /// </summary>
        public static DataTable StatisticsSoldAreaGetAll()
        {
            return MethodsDataAccessLayer.StatisticsSoldArea();
        }


        #endregion

        #region File
        //Christoffer
        /// <summary>
        /// Opretter en ny fil på et case nummer og som har et unikt filnavn
        /// </summary>
        public static void CreateFile(int caseNr, string nameOfFile, string extOfFile, byte[] dataOfFile)
        {
            MethodsDataAccessLayer.CreateFile(caseNr, nameOfFile, extOfFile, dataOfFile);
        }
        /// <summary>
        /// Finder dokumenter på et case nummer og returnerer dem som en liste over objekter
        /// </summary>
        public static List<Document> GetDocumentsByCaseNr(int id)
        {
            return MethodsDataAccessLayer.GetDocumentsByCaseNr(id);
        }
        /// <summary>
        /// Finder et case nummers photo og returnerer det som et byte array
        /// </summary>
        public static byte[] GetPhotoFromCaseNr(int caseNr)
        {
            return MethodsDataAccessLayer.GetPhotoFromCaseNr(caseNr);
        }
        /// <summary>
        /// Finder primary key navnet ud fra et case nummer og et photo byte array og returnerer det som en string
        /// </summary>
        public static string GetPhotoNameFromCaseNrAndPhoto(int caseNr, byte[] photo)
        {
            return MethodsDataAccessLayer.GetPhotoNameFromCaseNrAndPhoto(caseNr, photo);
        }
        /// <summary>
        /// Får en fil ud fra et navn og returnerer den som et dokument
        /// </summary>
        public static Document GetDocumentByName(string name)
        {
            return MethodsDataAccessLayer.GetDocumentByName(name);
        }
        /// <summary>
        /// Opdaterer et fil entry med et photo ud fra dens originalFileName
        /// </summary>
        public static void UpdatePhoto(string originalFileName, int caseNr, string fileName, string extName, byte[] photo)
        {
            MethodsDataAccessLayer.UpdateData(originalFileName, caseNr, fileName, extName, photo);
        }
        /// <summary>
        /// Opdaterer et fil entry med en fil ud fra dens originalFileName
        /// </summary>
        public static void UpdateFiles(string originalFileName, int caseNr, string fileName, string extName, byte[] data)
        {
            MethodsDataAccessLayer.UpdateData(originalFileName, caseNr, fileName, extName, data);
        }
        /// <summary>
        /// Fjerner en fil ud fra dens filnavn
        /// </summary>
        public static void RemoveFiles(string fileName)
        {
            MethodsDataAccessLayer.RemoveData(fileName);
        }
        /// <summary>
        /// Finder extentionen på et entry ud fra filnavnet
        /// </summary>
        public static string GetPhotoExtFromName(string nameOfPhoto)
        {
            return MethodsDataAccessLayer.GetPhotoExtFromName(nameOfPhoto);
        }
        #endregion
        
        #region Login
        /// <summary>
        /// Finder et login entry til test af et login forsøg og returnerer informationerne i et dataTable
        /// </summary>
        public static DataTable GetEncryptionByUsername(string testUsername)
        {
            return MethodsDataAccessLayer.GetEncryptionByUsername(testUsername);
        }
        /// <summary>
        /// Laver et login entry ud fra brugernavnet og de 2 byte arrays til brug af opbevaring og validering af kodeordet
        /// </summary>
        public static void CreateNewUser(string username, byte[] salt, byte[] hash)
        {
            MethodsDataAccessLayer.CreateNewUser(username, salt, hash);
        }

        /// <summary>
        /// Opdaterer en bruger ud fra det første parameter, username, som er unik
        /// </summary>
        public static void UpdateUser(string username, byte[] salt, byte[] hash)
        {
            MethodsDataAccessLayer.UpdateUser(username, salt, hash);
        }
        /// <summary>
        /// Søger i databasen efter et brugernavn, og returnerer true hvis brugernavnet findes, ellers returnerer den false
        /// </summary>
        public static bool UserExists(string username)
        {
            if (MethodsDataAccessLayer.GetEncryptionByUsername(username).Rows.Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

    }
}
