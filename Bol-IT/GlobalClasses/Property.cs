using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalClasses
{
    public class Property
    {
        #region Properties

        //Caspar
        public int CaseNr { get; set; }
        public int NetPrice { get; set; }
        public int GrossPrice { get; set; }
        public int OwnerExpenses { get; set; }
        public int CashPrice { get; set; }
        public int DepositPrice { get; set; }
        public string Address { get; set; }
        public int ZipCode { get; set; }
        public int NrOfRooms { get; set; }
        public bool GarageFlag { get; set; }
        public string BuiltRebuild { get; set; }
        public string HouseType { get; set; }
        public string EnergyRating { get; set; }
        public int ResSquareMeters { get; set; }
        public int PropSquareMeters { get; set; }
        public int Floors { get; set; }
        public bool SoldFlag { get; set; }
        public string Description { get; set; }

        #endregion
    }
}
