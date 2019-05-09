using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLayer
{
    public class PriceCalculator
    {
        public static int CalculateGrossPrice(int cashPrice)
        {
            return Convert.ToInt32(cashPrice*0.004);
        }

        public static int CalculateNetPrice(int cashPrice)
        {
            return Convert.ToInt32(cashPrice * 0.0035);
        }

        public static int CalculateOwnerExpences(int cashPrice)
        {
            return Convert.ToInt32(cashPrice * 0.0015);
        }


        public static int CalculateDepositPrice(int cashPrice)
        {
            return Convert.ToInt32(cashPrice * 0.0545);
        }
        public static int CalculateCashPrice(int propSquareMeter ,int zipcode, string condition, string interiorDesign, string style, string kitchen, string bathroom, bool gardenFlag)
        {
            
            double cashPrice = DataAccessLayerFacade.StatisticSquareMeterPriceByZipcode(zipcode) * propSquareMeter;

            switch (condition)
            {
                case "Dårlig":
                    cashPrice -= cashPrice * 0.05;
                    break;
                case "Normalt":
                    break;
                case "Fint":
                    cashPrice += cashPrice * 0.05;
                    break;
            }

            switch (interiorDesign)
            {
                case "Dårlig":
                    cashPrice -= cashPrice * 0.05;
                    break;
                case "Normalt":
                    break;
                case "Fint":
                    cashPrice += cashPrice * 0.05;
                    break;
            }

            switch (style)
            {
                case "Dårlig":
                    cashPrice -= cashPrice * 0.05;
                    break;
                case "Normalt":
                    break;
                case "Fint":
                    cashPrice += cashPrice * 0.05;
                    break;
            }

            switch (kitchen)
            {
                case "Gammelt":
                    cashPrice -= cashPrice * 0.05;
                    break;
                case "Standard":;
                    break;
                case "Nyt":
                    cashPrice += cashPrice * 0.05;
                    break;
            }

            switch (bathroom)
            {
                case "Gammelt":
                    cashPrice -= cashPrice * 0.05;
                    break;
                case "Standard":
                    ;
                    break;
                case "Nyt":
                    cashPrice += cashPrice * 0.05;
                    break;
            }

            switch (gardenFlag)
            {
                case true:
                    cashPrice += cashPrice * 0.025;
                    break;
                case false:
                    break;
            }

            return Convert.ToInt32(cashPrice);
        }
    }
}
