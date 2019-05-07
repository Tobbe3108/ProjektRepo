using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalClasses;
using DataAccessLayer.mydatabasetobbeDataSetTableAdapters;
using static DataAccessLayer.mydatabasetobbeDataSet;

namespace DataAccessLayer
{
    public class MethodsDataAccessLayer
    {
        #region TableAdapters

        //Christoffer
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

        //Christoffer
        public static void CreateAgent(string fName, string mName, string lName, int phoneNr, string address, int zipcode, string mail, int nrOfSales)
        {
            int id = personalDataTableAdapter.InsertData(fName, mName, lName, phoneNr, address, zipcode, mail);
            agentTableAdapter.InsertData(id, nrOfSales);
        }

        //Christoffer
        public static void CreateSeller(string fName, string mName, string lName, int phoneNr, string address, int zipcode, string mail, int aId)
        {
            int id = personalDataTableAdapter.InsertData(fName, mName, lName, phoneNr, address, zipcode, mail);
            sellerTableAdapter.InsertData(id, aId);
        }

        //Christoffer
        public static void CreateBuyer(string fName, string mName, string lName, int phoneNr, string address, int zipcode, string mail, int aId)
        {
            int id = personalDataTableAdapter.InsertData(fName, mName, lName, phoneNr, address, zipcode, mail);
            buyerTableAdapter.InsertData(id, aId);
        }

        //Christoffer
        public static int CreateProperty(int sId, int desiredPrice, int timeFrame, int netPrice, int grossPrice, int ownerExpenses, int cashPrice,
            int depositPrice, string address, int zipcode, int nrOfRooms, bool garageFlag, string builtRebuild, string houseType, string energyRating,
             int resSquareMeters, int propSquareMeters, int floors, bool soldFlag, string description)
        {
            int caseNr = (int)propertyTableAdapter.InsertData(netPrice, grossPrice, ownerExpenses, cashPrice, depositPrice, address, zipcode, nrOfRooms,
                garageFlag, builtRebuild, houseType, energyRating, resSquareMeters, propSquareMeters, floors, soldFlag, description);


            wantsToSellTableAdapter.InsertData(sId, caseNr, desiredPrice, timeFrame);

            return caseNr;
        }

        public static void CreateFile(int caseNr, string nameOfFile, string extOfFile, byte[] dataOfFile)
        {
            filesTableAdapter.InsertData(caseNr, nameOfFile, extOfFile, dataOfFile);
        }

        #endregion CreateMethods

        #region SearchMethods

        #region Agent
        //Christoffer
        public static agentDataTable GetAgentDataTable()
        {
            agentDataTable adt = new agentDataTable();
            agentTableAdapter.Fill(adt);
            return adt;
        }

        //Tobias
        public static agentDataTable GetAgentDataTableByLike(int searchParameters)
        {
            agentDataTable adt = new agentDataTable();
            agentTableAdapter.FillByLike(adt, searchParameters);
            return adt;
        }

        #region ReturnObjects

        //Christoffer
        public static Agent GetAgentById(int id)
        {
            agentDataTable adt = new agentDataTable();
            agentTableAdapter.FillById(adt, id);
            personalDataDataTable pddt = new personalDataDataTable();
            personalDataTableAdapter.FillById(pddt, id);

            Agent agent = new Agent
            {
                AId = (int)adt.Rows[0][0],
                NrOfSales = (int)adt.Rows[0][1],
                FName = (string)pddt.Rows[0][1],
                MName = (string)pddt.Rows[0][2],
                LName = (string)pddt.Rows[0][3],
                PhoneNr = (int)pddt.Rows[0][4],
                Address = (string)pddt.Rows[0][5],
                Zipcode = (int)pddt.Rows[0][6],
                Mail = (string)pddt.Rows[0][7]
            };
            return agent;
        }

        //Christoffer
        public static List<Agent> GetAgents()
        {
            agentDataTable adt = new agentDataTable();
            agentTableAdapter.Fill(adt);
            personalDataDataTable pddt = new personalDataDataTable();
            personalDataTableAdapter.Fill(pddt);

            List<Agent> agents = new List<Agent>();
            for (int i = 0; i < adt.Rows.Count; i++)
            {
                Agent agent = new Agent
                {
                    AId = (int)adt.Rows[i][0],
                    NrOfSales = (int)adt.Rows[i][1],
                    FName = (string)pddt.Rows[i][1],
                    MName = (string)pddt.Rows[i][2],
                    LName = (string)pddt.Rows[i][3],
                    PhoneNr = (int)pddt.Rows[i][4],
                    Address = (string)pddt.Rows[i][5],
                    Zipcode = (int)pddt.Rows[i][6],
                    Mail = (string)pddt.Rows[i][7]
                };
                agents.Add(agent);
            }
            return agents;
        }

        public static string GetPhotoExtFromName(string nameOfPhoto)
        {
            try
            {

                return filesTableAdapter.GetPhotoExtFromName(nameOfPhoto);
            }
            catch (Exception)
            {

                return null;
            }
        }

        #endregion
        #endregion

        #region Files
        //Christoffer
        public static byte[] GetPhotoFromId(int id)
        {
            filesDataTable files = filesTableAdapter.GetDataByCaseNr(id);

            for (int i = 0; i < files.Rows.Count; i++)
            {
                if ((string)files.Rows[i][2] == "jpg" || (string)files.Rows[i][2] == "png")
                {
                    return (byte[])files.Rows[i][3];
                }
            }

            return null;
        }
        public static string GetPhotoNameFromIdAndPhoto(int id, byte[] photo)
        {
            try
            {

                return filesTableAdapter.GetPhotoNameByCaseIdAndPhoto(id, photo);
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region Property
        //Christoffer
        public static propertyDataTable GetPropertyDataTable()
        {
            propertyDataTable adt = new propertyDataTable();
            propertyTableAdapter.Fill(adt);
            return adt;
        }



        //Christoffer & Tobias
        public static propertyDataTable GetPropertyDataTableByLike(string searchParameters)
        {
            propertyDataTable pdt = new propertyDataTable();
            propertyTableAdapter.FillByLike(pdt, searchParameters);
            return pdt;
        }

        //Tobias
        public static propertyDataTable GetZipcodes()
        {
            propertyDataTable pdt = new propertyDataTable();
            propertyTableAdapter.GetZipcodes(pdt);
            return pdt;
        }

        #region ReturnObjects
        public static WantsToSell GetWantsToSellByCaseNr(int caseNr)
        {
            wantsToSellDataTable wtsdt = new wantsToSellDataTable();
            wantsToSellTableAdapter.FillByCaseNr(wtsdt, caseNr);

            WantsToSell wantsToSell = new WantsToSell()
            {
                SId = (int)wtsdt.Rows[0][0],
                CaseNr = (int)wtsdt.Rows[0][1],
                DesiredPrice = (int)wtsdt.Rows[0][2],
                TimeFrame = (int)wtsdt.Rows[0][3]
            };

            return wantsToSell;
        }

        //Christoffer
        public static Property GetProperty(int id)
        {
            propertyDataTable pdt = new propertyDataTable();
            propertyTableAdapter.FillById(pdt, id);

            Property property = new Property
            {
                CaseNr = (int)pdt.Rows[0][0],
                NetPrice = (int)pdt.Rows[0][1],
                GrossPrice = (int)pdt.Rows[0][2],
                OwnerExpenses = (int)pdt.Rows[0][3],
                CashPrice = (int)pdt.Rows[0][4],
                DepositPrice = (int)pdt.Rows[0][5],
                Address = (string)pdt.Rows[0][6],
                ZipCode = (int)pdt.Rows[0][7],
                NrOfRooms = (int)pdt.Rows[0][8],
                GarageFlag = (bool)pdt.Rows[0][9],
                BuiltRebuild = (string)pdt.Rows[0][10],
                HouseType = (string)pdt.Rows[0][11],
                EnergyRating = (string)pdt.Rows[0][12],
                ResSquareMeters = (int)pdt.Rows[0][13],
                PropSquareMeters = (int)pdt.Rows[0][14],
                Floors = (int)pdt.Rows[0][15],
                SoldFlag = (bool)pdt.Rows[0][16],
                Description = (string)pdt.Rows[0][17],
            };

            return property;
        }

        //Christoffer
        public static List<Property> GetProperties()
        {
            propertyDataTable pdt = new propertyDataTable();
            propertyTableAdapter.Fill(pdt);

            List<Property> properties = new List<Property>();
            for (int i = 0; i < pdt.Rows.Count; i++)
            {
                Property property = new Property
                {
                    CaseNr = (int)pdt.Rows[i][1],
                    NetPrice = (int)pdt.Rows[i][2],
                    GrossPrice = (int)pdt.Rows[i][3],
                    OwnerExpenses = (int)pdt.Rows[i][4],
                    CashPrice = (int)pdt.Rows[i][5],
                    DepositPrice = (int)pdt.Rows[i][6],
                    Address = (string)pdt.Rows[i][7],
                    ZipCode = (int)pdt.Rows[i][8],
                    NrOfRooms = (int)pdt.Rows[i][9],
                    GarageFlag = (bool)pdt.Rows[i][10],
                    BuiltRebuild = (string)pdt.Rows[i][11],
                    HouseType = (string)pdt.Rows[i][12],
                    EnergyRating = (string)pdt.Rows[i][13],
                    ResSquareMeters = (int)pdt.Rows[i][14],
                    PropSquareMeters = (int)pdt.Rows[i][15],
                    Floors = (int)pdt.Rows[i][16],
                    SoldFlag = (bool)pdt.Rows[i][17],
                    Description = (string)pdt.Rows[i][18],
                };
                properties.Add(property);
            }
            return properties;
        }

        #endregion

        #endregion

        #region Seller

        #region ReturnObjects
        //Christoffer
        public static List<Seller> GetSellers()
        {
            sellerDataTable sdt = new sellerDataTable();
            sellerTableAdapter.Fill(sdt);
            personalDataDataTable pddt = new personalDataDataTable();
            personalDataTableAdapter.Fill(pddt);

            List<Seller> sellers = new List<Seller>();
            for (int i = 0; i < sdt.Rows.Count; i++)
            {
                Seller seller = new Seller
                {
                    SId = (int)sdt.Rows[i][0],
                    AId = (int)sdt.Rows[i][1],
                    FName = (string)pddt.Rows[i][1],
                    MName = (string)pddt.Rows[i][2],
                    LName = (string)pddt.Rows[i][3],
                    PhoneNr = (int)pddt.Rows[i][4],
                    Address = (string)pddt.Rows[i][5],
                    Zipcode = (int)pddt.Rows[i][6],
                    Mail = (string)pddt.Rows[i][7]
                };
                sellers.Add(seller);
            }
            return sellers;
        }

        //Christoffer
        public static Seller GetSellerById(int id)
        {
            sellerDataTable sdt = new sellerDataTable();
            sellerTableAdapter.FillById(sdt, id);
            personalDataDataTable pddt = new personalDataDataTable();
            personalDataTableAdapter.FillById(pddt, id);

            Seller seller = new Seller
            {
                SId = (int)sdt.Rows[0][0],
                AId = (int)sdt.Rows[0][1],
                FName = (string)pddt.Rows[0][1],
                MName = (string)pddt.Rows[0][2],
                LName = (string)pddt.Rows[0][3],
                PhoneNr = (int)pddt.Rows[0][4],
                Address = (string)pddt.Rows[0][5],
                Zipcode = (int)pddt.Rows[0][6],
                Mail = (string)pddt.Rows[0][7]
            };
            return seller;
        }

        #endregion

        #endregion

        #region Buyer

        #region ReturnObjects
        //Christoffer
        public static List<Buyer> GetBuyers()
        {
            buyerDataTable bdt = new buyerDataTable();
            buyerTableAdapter.Fill(bdt);
            personalDataDataTable pddt = new personalDataDataTable();
            personalDataTableAdapter.Fill(pddt);

            List<Buyer> buyers = new List<Buyer>();
            for (int i = 0; i < bdt.Rows.Count; i++)
            {
                Buyer buyer = new Buyer
                {
                    BId = (int)bdt.Rows[i][0],
                    AId = (int)bdt.Rows[i][1],
                    FName = (string)pddt.Rows[i][1],
                    MName = (string)pddt.Rows[i][2],
                    LName = (string)pddt.Rows[i][3],
                    PhoneNr = (int)pddt.Rows[i][4],
                    Address = (string)pddt.Rows[i][5],
                    Zipcode = (int)pddt.Rows[i][6],
                    Mail = (string)pddt.Rows[i][7]
                };
                buyers.Add(buyer);
            }
            return buyers;
        }

        //Christoffer
        public static Buyer GetBuyerById(int id)
        {
            buyerDataTable bdt = new buyerDataTable();
            buyerTableAdapter.FillById(bdt, id);
            personalDataDataTable pddt = new personalDataDataTable();
            personalDataTableAdapter.FillById(pddt, id);

            Buyer buyer = new Buyer
            {
                BId = (int)bdt.Rows[0][0],
                AId = (int)bdt.Rows[0][1],
                FName = (string)pddt.Rows[0][1],
                MName = (string)pddt.Rows[0][2],
                LName = (string)pddt.Rows[0][3],
                PhoneNr = (int)pddt.Rows[0][4],
                Address = (string)pddt.Rows[0][5],
                Zipcode = (int)pddt.Rows[0][6],
                Mail = (string)pddt.Rows[0][7]
            };
            return buyer;
        }


        #endregion

        #endregion

        #endregion

        #region UpdateMethods

        #region Property

        public static void UpdateProperty(int caseNr, int sId, int desiredPrice, int timeFrame, int netPrice, int grossPrice, int ownerExpenses, int cashPrice,
            int depositPrice, string address, int zipcode, int nrOfRooms, bool garageFlag, string builtRebuild, string houseType, string energyRating,
             int resSquareMeters, int propSquareMeters, int floors, bool soldFlag, string description)
        {
            propertyTableAdapter.UpdateData(netPrice, grossPrice, ownerExpenses, cashPrice, depositPrice, address, zipcode, nrOfRooms, garageFlag,
                builtRebuild, houseType, energyRating, resSquareMeters, propSquareMeters, floors, soldFlag, description, caseNr);

            wantsToSellTableAdapter.UpdateData(sId, desiredPrice, timeFrame, caseNr);
        }

        #endregion

        #region Files
        //Christoffer
        public static void UpdatePhoto(string originalFileName, int caseNr, string fileName, string extName, byte[] photo)
        {
            if (originalFileName == string.Empty)
            {
                if (photo == null)
                {
                    return;
                }
                filesTableAdapter.InsertData(caseNr, fileName, extName, photo);
            }
            else
            {
                filesTableAdapter.UpdateData(fileName, extName, photo, originalFileName);
            }
        }
        #endregion

        #endregion
    }
}
