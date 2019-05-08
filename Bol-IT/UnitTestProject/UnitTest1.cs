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

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Console.WriteLine(CalculateDistanceMethod.GetDistanceByAddresses("Jellingvej 15A, 7100", "Østerbrogade 20 2. Th., 7100"));
            DataTable dataTable = new DataTable();

            dataTable.Columns["Adresse"].SetOrdinal(0);
            dataTable.Columns["Brutto pris"].SetOrdinal(1);
            dataTable.Columns["Netto pris"].SetOrdinal(2);
            dataTable.Columns["Ejerudgift"].SetOrdinal(3);
            dataTable.Columns["Udbetalingspris"].SetOrdinal(4);
            dataTable.Columns["Kontantpris"].SetOrdinal(5);

            using (SqlConnection connection = DataAccessLayerFacade.GetConnection())
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM property";

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        
                    }
                }

            }

            dataTable = DataAccessLayerFacade.StatisticsSoldAreaGetAll();


            //Laver en save dialog hvor brugeren kan vælge hvor filen skal gemmes
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                InitialDirectory = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}",
                Title = "Gem til fil",
                DefaultExt = "txt",
                Filter = "Tekst fil (*.txt)|*.txt|Excel (*.xlsx)|*.xlsx",
                FilterIndex = 1,
                CheckFileExists = false,
                CheckPathExists = true,
                RestoreDirectory = true
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK) //Hvis det lykkedes for brugeren at vælge et sted at gemme filen
            {
                //Hent extensionen af filen Fx .txt
                var extension = Path.GetExtension(saveFileDialog.FileName);

                switch (extension.ToLower()) //Tjekker hvilken filtype du har gemt i
                {
                    case ".xlsx":
                        var wb = new XLWorkbook(); //Laver en ny XLWorkbook som kommer fra en NuGet package der hedder closedXML man kan benytte til at oprette Excel dokumenter
                        wb.Worksheets.Add(dataTable); //Opretter et nyt worksheet på baggrund af det oprettede datatable
                        wb.SaveAs(Path.GetFullPath(saveFileDialog.FileName)); //Gemmer den oprettede XLWorkbook til filen som brugeren oprettede via savedialog
                        break;



                    default:
                        //Hvis det ikke er muligt at gemme vis fejlbesked til brugeren
                        MessageBox.Show($"Det var ikke muligt at gemme filen: {saveFileDialog.FileName} Prøv igen.", "Fejl!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }

        }
    }
}
