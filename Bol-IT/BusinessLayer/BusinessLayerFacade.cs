using System;
using System.IO;
using System.Drawing;
using GlobalClasses;
using System.Windows.Forms;
using System.Data;
using DataAccessLayer;

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

        public static void NotifyAboutMessage(Label lblMessage)
        {
            LoginMethods.StartNotifyAboutMessage(lblMessage);
        }
        #endregion

        #region PriceCalculation

        //Simone
        /// <summary>
        /// Beregner brutto prisen ud fra total prisen
        /// </summary>
        /// <param name="cashPrice"></param>
        /// <returns></returns>
        public static int CalculateGrossPrice(int cashPrice)
        {
            return PriceCalculator.CalculateGrossPrice(cashPrice);
        }

        /// <summary>
        /// Beregner total prisen ud fra grund areal, postnummer, stand, indretning, stil, køkken, badeværelse og have
        /// </summary>
        /// <param name="propSquareMeter"></param>
        /// <param name="zipcode"></param>
        /// <param name="condition"></param>
        /// <param name="interiorDesign"></param>
        /// <param name="style"></param>
        /// <param name="kitchen"></param>
        /// <param name="bathroom"></param>
        /// <param name="gardenFlag"></param>
        /// <returns></returns>
        public static int CalculateCashPrice(int propSquareMeter, int zipcode, string condition, string interiorDesign, string style, string kitchen, string bathroom, bool gardenFlag)
        {
            return PriceCalculator.CalculateCashPrice(propSquareMeter, zipcode, condition, interiorDesign, style, kitchen, bathroom, gardenFlag);
        }

        /// <summary>
        /// Beregner netto prisen ud fra total prisen  
        /// </summary>
        /// <param name="cashPrice"></param>
        /// <returns></returns>
        public static int CalculateNetPrice(int cashPrice)
        {
            return PriceCalculator.CalculateNetPrice(cashPrice);
        }

        /// <summary>
        /// Beregner ejerudgiften ud fra total prisen
        /// </summary>
        /// <param name="cashPrice"></param>
        /// <returns></returns>
        public static int CalculateOwnerExpences(int cashPrice)
        {
            return PriceCalculator.CalculateOwnerExpences(cashPrice);
        }

        /// <summary>
        /// Beregner udbetalingen ud fra total prisen
        /// </summary>
        /// <param name="cashPrice"></param>
        /// <returns></returns>
        public static int CalculateDepositPrice(int cashPrice)
        {
            return PriceCalculator.CalculateDepositPrice(cashPrice);
        }

        #endregion

        #region Login
        public static void CreateNewUser(string username, string password)
        {
            Encryption encryption = EncryptString(password);
            DataAccessLayerFacade.CreateNewUser(username, encryption.Salt, encryption.Hash);
        }
        public static void UpdateUser(string username, string password)
        {
            Encryption encryption = EncryptString(password);
            DataAccessLayerFacade.UpdateUser(username, encryption.Salt, encryption.Hash);
        }

        public static bool TryLogon(string username, string password)
        {
            return LoginMethods.TestPassword(username, password);
        }

        public static Encryption EncryptString(string password)
        {
            return LoginMethods.Encrypt(password);
        }
        public static void NotifyAdminAboutPasswordReset(string username)
        {
            //Klar til at implementere et password reset system
            Encryption encryption = EncryptString("");
            MethodsDataAccessLayer.UpdateUser(username, encryption.Salt, encryption.Hash);
        }

        #endregion

        #region Files
        public static void ShowFile(string path)
        {
            FileMethods.ShowFile(path);
        }

        public static void CopyFile(string fileName)
        {
            FileMethods.CopyFile(fileName);
        }

        //Christoffer
        public static byte[] GetFileFromPath(string path)
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

        #region HouseDistribution
        //Caspar
        public static DataTable DistributeHouses(DataTable agentDataTable, DataTable propertyDataTable, int sortMethod)
        {
            return BusinessLayer.OpenHouseMethods.DistributeHouses(agentDataTable, propertyDataTable, sortMethod);
        }
        #endregion
        

        //Tobias
        public static bool Sanitizer(RichTextBox rtbFName, RichTextBox rtbMName, RichTextBox rtbLName, RichTextBox rtbPhoneNr, RichTextBox rtbAddress, RichTextBox rtbZipcode, RichTextBox rtbMail, RichTextBox rtbTypeChainging, ComboBox cbType)
        {
            return SanitizerMethod.Sanitizer(rtbFName, rtbMName, rtbLName, rtbPhoneNr, rtbAddress, rtbZipcode, rtbMail, rtbTypeChainging, cbType);
        }
    }
}
