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

        #endregion CreateMethods

        #region SearchMethods

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
        
        //Christoffer
        public static Property GetProperty(int id)
        {
            propertyDataTable pdt = new propertyDataTable();
            propertyTableAdapter.FillById(pdt, id);

            Property property = new Property
            {
                CaseNr = (int)pdt.Rows[0][1],
                NetPrice = (int)pdt.Rows[0][2],
                GrossPrice = (int)pdt.Rows[0][3],
                OwnerExpenses = (int)pdt.Rows[0][4],
                CashPrice = (int)pdt.Rows[0][5],
                DepositPrice = (int)pdt.Rows[0][6],
                Address = (string)pdt.Rows[0][7],
                ZipCode = (int)pdt.Rows[0][8],
                NrOfRooms = (int)pdt.Rows[0][9],
                GarageFlag = (bool)pdt.Rows[0][10],
                BuiltRebuild = (string)pdt.Rows[0][11],
                HouseType = (string)pdt.Rows[0][12],
                EnergyRating = (char)pdt.Rows[0][13],
                ResSquareMeters = (int)pdt.Rows[0][14],
                PropSquareMeters = (int)pdt.Rows[0][15],
                Floors = (int)pdt.Rows[0][16],
                SoldFlag = (bool)pdt.Rows[0][17],
                Description = (string)pdt.Rows[0][18],
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
                    EnergyRating = (char)pdt.Rows[i][13],
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
    }
}
