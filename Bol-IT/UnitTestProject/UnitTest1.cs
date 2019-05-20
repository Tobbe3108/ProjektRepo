using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using BusinessLayer;
using DataAccessLayer;
using ClosedXML.Excel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.Xml;
using System.Text.RegularExpressions;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            Form Messagebox_UserManagment = new Form();
            Messagebox_UserManagment.Show();

            //GetLatLongFromAddress("Engblommevej 19", "Horsens", "Midtjylland", "8700");


            //Console.WriteLine(CalculateDistanceMethod.GetDistanceByAddresses("Jellingvej 15A, 7100", "Østerbrogade 20 2. Th., 7100"));
            //DataTable dataTable = new DataTable();

            //dataTable.Columns.Add("Adresse");
            //dataTable.Columns.Add("Brutto pris");
            //dataTable.Columns.Add("Netto pris");
            //dataTable.Columns.Add("Ejerudgift");
            //dataTable.Columns.Add("Udbetalingspris");
            //dataTable.Columns.Add("Kontantpris");

            //DataTable dt = new DataTable();
            //using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureDB"].ConnectionString))
            //{
            //    using (SqlCommand command = new SqlCommand())
            //    {
            //        command.Connection = connection;
            //        command.CommandText = "SELECT (address, grossPrice, netPrice, ownerExpenses, depositPrice, cashPrice) FROM property";
            //        connection.Open();
            //        SqlDataReader reader = command.ExecuteReader();
            //        dt.Load(reader);
            //        connection.Close();
            //    }

            //}
            //object[] values = new object[6];
            //for (int j = 0; j < dt.Rows.Count; j++)
            //{
            //    for (int i = 0; i <= values.Length - 1; i++)
            //    {
            //        values[i] = dt.Rows[j][i];
            //    }
            //    dataTable.Rows.Add(values);
            //}


            ////Laver en save dialog hvor brugeren kan vælge hvor filen skal gemmes
            //SaveFileDialog saveFileDialog = new SaveFileDialog
            //{
            //    InitialDirectory = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}",
            //    Title = "Gem til fil",
            //    DefaultExt = "txt",
            //    Filter = "Tekst fil (*.txt)|*.txt|Excel (*.xlsx)|*.xlsx",
            //    FilterIndex = 1,
            //    CheckFileExists = false,
            //    CheckPathExists = true,
            //    RestoreDirectory = true
            //};

            //if (saveFileDialog.ShowDialog() == DialogResult.OK) //Hvis det lykkedes for brugeren at vælge et sted at gemme filen
            //{
            //    //Hent extensionen af filen Fx .txt
            //    var extension = Path.GetExtension(saveFileDialog.FileName);

            //    switch (extension.ToLower()) //Tjekker hvilken filtype du har gemt i
            //    {
            //        case ".xlsx":
            //            var wb = new XLWorkbook(); //Laver en ny XLWorkbook som kommer fra en NuGet package der hedder closedXML man kan benytte til at oprette Excel dokumenter
            //            wb.Worksheets.Add(dataTable); //Opretter et nyt worksheet på baggrund af det oprettede datatable
            //            wb.SaveAs(Path.GetFullPath(saveFileDialog.FileName)); //Gemmer den oprettede XLWorkbook til filen som brugeren oprettede via savedialog
            //            break;



            //        default:
            //            //Hvis det ikke er muligt at gemme vis fejlbesked til brugeren
            //            MessageBox.Show($"Det var ikke muligt at gemme filen: {saveFileDialog.FileName} Prøv igen.", "Fejl!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            break;
            //    }
            //}

        }
        static string GetLatLongFromAddress(string street, string city, string state, string zip)
        {
            string bingMapsUri = string.Format(@"http://dev.virtualearth.net/REST/v1/Locations/DK/" + Regex.Replace
            (street, "#", "") + ", " + city + ", " + state + "?o=xml&amp;key=BingMapsKey");
            XmlDocument bingMapsXmlDoc = new XmlDocument();
            bingMapsXmlDoc.Load(bingMapsUri);
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(bingMapsXmlDoc.NameTable);
            nsmgr.AddNamespace("rest", "http://schemas.microsoft.com/search/local/ws/rest/v1");
            string sLong = bingMapsXmlDoc.DocumentElement.SelectSingleNode(@".//rest:Longitude", nsmgr).InnerText;
            string sLat = bingMapsXmlDoc.DocumentElement.SelectSingleNode(@".//rest:Latitude", nsmgr).InnerText;

            return sLat + "~" + sLong;
        }
    }
}
