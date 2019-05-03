using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Classes
{
    public class Property
    {
        public int CaseNr { get; set; }
        public int NetPrice { get; set; }
        public int GrossPrice { get; set; }
        public int OwnerExpenses { get; set; }
        public int CashPrice { get; set; }
        public int DepositPrice { get; set; }
        public string Adress { get; set; }
        public int ZipCode { get; set; }
        public int NrOfRooms { get; set; }
        public bool GarageFlag { get; set; }
        public int BuiltRebuild { get; set; }
        public string HouseType { get; set; }
        public char EnergyRating { get; set; }
        public int ResSquareMeters { get; set; }
        public int Floors { get; set; }
        public bool SoldFlag { get; set; }
        public string Description { get; set; }

        public Property(int caseNr, int netPrice, int grossPrice, int ownerExpenses, int cashPrice, int depositPrice, string adress, int zipCode, int nrOfRooms, 
                        bool garageFlag, int builtRebuild, string houseType, char energyRating, int resSquareMeters, int floors, bool soldFlag, string description)
        {
            CaseNr = caseNr;
            NetPrice = netPrice;
            GrossPrice = grossPrice;
            OwnerExpenses = ownerExpenses;
            CashPrice = cashPrice;
            DepositPrice = depositPrice;
            Adress = adress;
            ZipCode = zipCode;
            NrOfRooms = nrOfRooms;
            GarageFlag = garageFlag;
            BuiltRebuild = builtRebuild;
            HouseType = houseType;
            EnergyRating = energyRating;
            ResSquareMeters = resSquareMeters;
            Floors = floors;
            SoldFlag = soldFlag;
            Description = description;
        }
    }
}
