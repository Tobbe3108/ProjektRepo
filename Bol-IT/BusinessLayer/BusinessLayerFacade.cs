using System;
using System.IO;
using System.Drawing;
using GlobalClasses;
using System.Windows.Forms;
using System.Data;

namespace BusinessLayer
{
    public class BusinessLayerFacade
    {
        #region Threads

        //Tobias
        public static void SloganThreadStart(Label label)
        {
            SloganThread.SloganThreadsStart(label);
        }

        //Christoffer
        public static byte[] GetPhotoFromPath(string path)
        {
            return File.ReadAllBytes(path);
        }

        //Christoffer
        public static Image ConvertBinaryArrayToImage(byte[] photo)
        {
            if (photo == null)
            {
                return null;
            }
            using (MemoryStream ms = new MemoryStream(photo))
            {
                return Image.FromStream(ms);
            }
        }
        #endregion

        //Simone
        public static int CalculateGrossPrice(int cashPrice)
        {
            return PriceCalculator.CalculateGrossPrice(cashPrice);
        }

        public static int CalculateNetPrice(int cashPrice)
        {
            return PriceCalculator.CalculateNetPrice(cashPrice);
        }

        public static int CalculateOwnerExpences(int cashPrice)
        {
            return PriceCalculator.CalculateOwnerExpences(cashPrice);
        }

        public static int CalculateDepositPrice(int cashPrice)
        {
            return PriceCalculator.CalculateDepositPrice(cashPrice);
        }

        public static int CalculateCashPrice(int propSquareMeter, int zipcode, string condition, string interiorDesign, string style, string kitchen, string bathroom, bool gardenFlag)
        {
            return PriceCalculator.CalculateCashPrice(propSquareMeter, zipcode, condition, interiorDesign, style, kitchen, bathroom, gardenFlag);
        }
    }
}
