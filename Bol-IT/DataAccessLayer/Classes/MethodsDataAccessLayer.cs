using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GlobalClasses;
using DataAccessLayer.mydatabasetobbeDataSetTableAdapters;
using static DataAccessLayer.mydatabasetobbeDataSet;

namespace DataAccessLayer
{
    public class MethodsDataAccessLayer
    {
        public static bool CheckForSQLInjection(string[] stringCheck)
        {
            foreach (string item in stringCheck)
            {
                if (item.Contains(";"))
                {
                    MessageBox.Show("Godt forsøgt Jens");
                    return true;
                }
            }
            return false;
        }

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

        public static List<Document> GetDocumentsByCaseNr(int id)
        {
            filesDataTable fdt = new filesDataTable();
            filesTableAdapter.FillByCaseNr(fdt, id);
            
            List<Document> documents = new List<Document>();
            for (int i = 0; i < fdt.Rows.Count; i++)
            {
                if ((string)fdt.Rows[i][2] != "jpg" && (string)fdt.Rows[i][2] != "jpeg" && (string)fdt.Rows[i][2] != "png") //Kontrollerer at det ikke er et billede
                {
                Document document = new Document
                {
                    CaseNr = id,
                    Name = (string)fdt.Rows[i][1],
                    Extention = (string)fdt.Rows[i][2]
                };
                documents.Add(document);
                }
            }
            return documents;
        }

        public static Document GetDocumentByName(string name)
        {
            return new Document
            {
                Name = name,
                Data = filesTableAdapter.GetFileByName(name)
            };

        }

        public static wantsToSellTableAdapter wantsToSellTableAdapter = new wantsToSellTableAdapter();
        public static personalDataTableAdapter personalDataTableAdapter = new personalDataTableAdapter();
        public static externalContactsTableAdapter externalContactsTableAdapter = new externalContactsTableAdapter();

        #endregion TableAdapters

        #region PersonalData

        //Christoffer
        public static string GetPersonTypeById(int id)
        {
            string persontype = "";
            if (agentTableAdapter.GetDataById(id).Rows.Count != 0)
            {
                persontype = "Mægler";
            }
            if (sellerTableAdapter.GetDataById(id).Rows.Count != 0)
            {
                persontype = "Sælger";
            }
            if (buyerTableAdapter.GetDataById(id).Rows.Count != 0)
            {
                persontype = "Køber";
            }
            return persontype;
        }

        public static Dictionary<int, string> GetPersonTypeByIds(List<int> ids)
        {
            Dictionary<int, string> persontypes = new Dictionary<int, string>();
            foreach (int id in ids)
            {
                try
                {
                    if (agentTableAdapter.CheckIfIdExists(id) != null)
                    {
                        persontypes.Add(id, "Mægler");
                    }
                    else if (sellerTableAdapter.CheckIfIdExists(id) != null)
                    {
                        persontypes.Add(id, "Sælger");
                    }
                    else if (buyerTableAdapter.CheckIfIdExists(id) != null)
                    {
                        persontypes.Add(id, "Køber");
                    }
                }
                catch { }
            }

            return persontypes;
        }

        public static personalDataDataTable GetPersonalDataDataTableByLike(string searchParameters)
        {
            string[] dataTableColumnNames = { "Fornavn", "Efternavn", "Telefon nr.", "Adresse", "Postnummer", "E-mail" };

            personalDataDataTable dataTable = new personalDataDataTable();
            personalDataTableAdapter.FillByLike(dataTable, searchParameters);
            dataTable.Columns["id"].SetOrdinal(0);
            dataTable.Columns["id"].ColumnName = "Id";
            dataTable.Columns["mName"].SetOrdinal(1);
            dataTable.Columns["mName"].ColumnName = "Persontype";
            dataTable.Columns["fName"].SetOrdinal(2);

            for (int i = 2; i < dataTable.Columns.Count; i++)
            {
                dataTable.Columns[i].ColumnName = dataTableColumnNames[i - 2];
                dataTable.Columns[i].SetOrdinal(i);
            }
            return dataTable;
        }

        //Tobias
        public static personalDataDataTable GetPersonalDataDataTable()
        {
            personalDataDataTable pdt = new personalDataDataTable();
            personalDataTableAdapter.Fill(pdt);
            return pdt;
        }

        #endregion

        #region Agent

        //Christoffer
        public static void CreateAgent(string fName, string mName, string lName, int phoneNr, string address, int zipcode, string mail, int nrOfSales)
        {
            int id = (int)personalDataTableAdapter.InsertData(fName, mName, lName, phoneNr, address, zipcode, mail);
            agentTableAdapter.InsertData(id, nrOfSales);
        }

        //Christoffer
        public static agentDataTable GetAllAgentIds()
        {
            agentDataTable agents = new agentDataTable();
            agentTableAdapter.FillByAllId(agents);
            return agents;
        }

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

        //Tobias
        public static void AgentUpdateData(int id, string fName, string mName, string lName, int phoneNr, string address, int zipcode, string mail, int nrOfSales)
        {
            personalDataTableAdapter.UpdateData(fName, mName, lName, phoneNr, address, zipcode, mail, id);
            agentTableAdapter.UpdateNrOfSales(nrOfSales, id);
        }



        #endregion

        #region Seller
        //Christoffer
        public static void CreateSeller(string fName, string mName, string lName, int phoneNr, string address, int zipcode, string mail, int aId)
        {
            int id = (int)personalDataTableAdapter.InsertData(fName, mName, lName, phoneNr, address, zipcode, mail);
            sellerTableAdapter.InsertData(id, aId);
        }

        //Christoffer
        public static sellerDataTable GetAllSellerIds()
        {
            sellerDataTable sellers = new sellerDataTable();
            sellerTableAdapter.FillByAllId(sellers);
            return sellers;
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

        //Tobias
        public static void SellerUpdateData(int id, string fName, string mName, string lName, int phoneNr, string address, int zipcode, string mail, int aId)
        {
            personalDataTableAdapter.UpdateData(fName, mName, lName, phoneNr, address, zipcode, mail, id);
            sellerTableAdapter.UpdateAId(aId, id);
        }

        #endregion

        #region Buyer
        //Christoffer
        public static void CreateBuyer(string fName, string mName, string lName, int phoneNr, string address, int zipcode, string mail, int aId)
        {
            int id = (int)personalDataTableAdapter.InsertData(fName, mName, lName, phoneNr, address, zipcode, mail);
            buyerTableAdapter.InsertData(id, aId);
        }

        //Christoffer
        public static buyerDataTable GetAllBuyerIds()
        {
            buyerDataTable buyers = new buyerDataTable();
            buyerTableAdapter.FillByAllId(buyers);
            return buyers;
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

        //Tobias
        public static void BuyerUpdateData(int id, string fName, string mName, string lName, int phoneNr, string address, int zipcode, string mail, int aId)
        {
            personalDataTableAdapter.UpdateData(fName, mName, lName, phoneNr, address, zipcode, mail, id);
            buyerTableAdapter.UpdateAId(aId, id);
        }


        #endregion

        #region Property
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

        //Christoffer
        public static propertyDataTable GetPropertyDataTable()
        {
            propertyDataTable adt = new propertyDataTable();
            propertyTableAdapter.Fill(adt);
            return adt;
        }

        //Christoffer & Tobias
        public static propertyDataTable GetPropertyDataTableByLike(bool soldFlag, string searchParameters)
        {
            propertyDataTable pdt = new propertyDataTable();
            propertyTableAdapter.FillByLike(pdt, soldFlag, searchParameters);
            return pdt;
        }

        

        //Christoffer
        public static propertyDataTable GetPropertyDataTableByLikeAll(string searchParameters)
        {
            propertyDataTable pdt = new propertyDataTable();
            propertyTableAdapter.FillByLikeAll(pdt, searchParameters);
            return pdt;
        }

        //Tobias
        public static saleDataTable GetZipcodes()
        {
            saleDataTable pdt = new saleDataTable();
            try
            {
                saleTableAdapter.GetZipcodes(pdt);
            }
            catch (Exception)
            { }

            return pdt;
        }

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

        //Caspar
        public static void DeleteProperty(int caseNr)
        {
            MessageBox.Show("Funktionalitet ikke tilføjet endnu.", "Fejl.", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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

        public static void UpdateProperty(int caseNr, int sId, int desiredPrice, int timeFrame, int netPrice, int grossPrice, int ownerExpenses, int cashPrice,
            int depositPrice, string address, int zipcode, int nrOfRooms, bool garageFlag, string builtRebuild, string houseType, string energyRating,
             int resSquareMeters, int propSquareMeters, int floors, bool soldFlag, string description)
        {
            propertyTableAdapter.UpdateData(netPrice, grossPrice, ownerExpenses, cashPrice, depositPrice, address, zipcode, nrOfRooms, garageFlag,
                builtRebuild, houseType, energyRating, resSquareMeters, propSquareMeters, floors, soldFlag, description, caseNr);

            wantsToSellTableAdapter.UpdateData(sId, desiredPrice, timeFrame, caseNr);
        }

        #endregion

        #region File
        public static void CreateFile(int caseNr, string nameOfFile, string extOfFile, byte[] dataOfFile)
        {
            filesTableAdapter.InsertData(caseNr, nameOfFile, extOfFile, dataOfFile);
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

        //Christoffer
        public static void UpdateData(string originalFileName, int caseNr, string fileName, string extName, byte[] data)
        {
            if (originalFileName == null)
            {
                if (data == null)
                {
                    return;
                }
                filesTableAdapter.InsertData(caseNr, fileName, extName, data);
            }
            else
            {
                filesTableAdapter.UpdateData(fileName, extName, data, originalFileName);
            }
        }
        public static void RemoveData(string fileName)
        {
            {
                filesTableAdapter.DeleteData(fileName);
            }
        }

        #endregion

        #region Sale

        public static saleDataTable StatisticSquareMeterPrice(decimal SearchYear, decimal SearchMonth)
        {
            saleDataTable sdt = new saleDataTable();
            saleTableAdapter.StatisticSquareMeterPrice(sdt, SearchYear, SearchMonth);
            return sdt;
        }

        public static int StatisticSquareMeterPriceByZipcode(int zipcode)
        {
            return Convert.ToInt32((decimal)saleTableAdapter.StatisticSquareMeterPriceByZipcode(zipcode));
        }

        public static saleDataTable StatisticsSoldArea(int zipcode)
        {
            saleDataTable sdt = new saleDataTable();
            saleTableAdapter.StatisticAreaPrice(sdt, zipcode);
            return sdt;
        }

        public static saleDataTable StatisticsSoldArea()
        {
            saleDataTable sdt = new saleDataTable();
            saleTableAdapter.StatisticAll(sdt);
            return sdt;
        }

        #endregion

    }

}