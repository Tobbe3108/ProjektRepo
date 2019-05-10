using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ClosedXML.Excel;
using DataAccessLayer;

namespace Bol_IT
{
    public partial class Person_ViewAll : UserControl
    {
        #region Init

        //Tobias
        //Singleton instance af Sag_Create
        static Person_ViewAll _instance;
        public static Person_ViewAll Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Person_ViewAll();
                }
                return _instance;
            }
        }

        public Person_ViewAll()
        {
            InitializeComponent();

            dgvPerson.DataSource = DataAccessLayerFacade.GetPersonalDataDataTable();
        }

        #endregion

        #region FormAutoSize

        private void Person_ViewAll_SizeChanged(object sender, EventArgs e)
        {
            lblSearch.Font = new Font(lblSearch.Font.FontFamily, this.Size.Height / 50);
            rtbSearch.Font = new Font(rtbSearch.Font.FontFamily, this.Size.Height / 50);
            btnCreatePerson.Font = new Font(btnCreatePerson.Font.FontFamily, this.Size.Height / 50);
            btnToFile.Font = new Font(btnToFile.Font.FontFamily, this.Size.Height / 50);
        }

        #endregion

        private void btnToFile_Click(object sender, EventArgs e)
        {
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
                    case ".txt":
                        //Åbner filen brugeren oprettede
                        StreamWriter writer = new StreamWriter(saveFileDialog.OpenFile());
                        List<string> list = new List<string>();


                        //Kør igennem alle celler i hver kolone og find den celle med den længste verdi - bruges til fin formatering
                        List<int> longestString = new List<int>();

                        for (int col = 1; col < dgvPerson.Columns.Count - 1; col++)
                        {
                            int stringLength = 0;
                            for (int row = 0; row < dgvPerson.Rows.Count; row++)
                            {
                                if (stringLength < dgvPerson.Rows[row].Cells[col].Value.ToString().Length)
                                {
                                    stringLength = dgvPerson.Rows[row].Cells[col].Value.ToString().Length;
                                }
                            }
                            if (stringLength < dgvPerson.Columns[col].HeaderText.Length)
                            {
                                stringLength = dgvPerson.Columns[col].HeaderText.Length;
                            }
                            longestString.Add(stringLength);
                        }

                        //Skriver kolone header text til filen
                        string header = "";
                        for (int col = 1; col < dgvPerson.Columns.Count - 1; col++)
                        {
                            try
                            {
                                header += $"{dgvPerson.Columns[col].HeaderText.PadRight(longestString[col - 1] + 5)}";
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Det var ikke muligt at gemme filen: {saveFileDialog.FileName} Prøv igen.", "Fejl!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        writer.WriteLine(header);



                        //Skriver alt data til filen
                        for (int row = 0; row < dgvPerson.Rows.Count - 1; row++)
                        {
                            string lines = "";
                            for (int col = 1; col < dgvPerson.Columns.Count - 1; col++)
                            {
                                try
                                {
                                    lines += $"{dgvPerson.Rows[row].Cells[col].Value.ToString().PadRight(longestString[col] + 5)}";
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show($"Det var ikke muligt at gemme filen: {saveFileDialog.FileName} Prøv igen.", "Fejl!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            writer.WriteLine(lines);
                        }

                        writer.Dispose();
                        writer.Close();

                        break;



                    case ".xlsx":
                        //Lavet et nyt datatable
                        DataTable dtFromGrid = new DataTable();

                        //Tilføjer alle kolonner fra dataGridViewDataSet til det nyt datatable
                        for (int i = 1; i < dgvPerson.Columns.Count; i++)
                        {
                            dtFromGrid.Columns.Add(dgvPerson.Columns[i].HeaderText);
                        }

                        //Tilføjer alle rækker til det nye datatable med rækkens værdier
                        foreach (DataGridViewRow row in dgvPerson.Rows)
                        {
                            dtFromGrid.Rows.Add();
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                if (cell.OwningColumn.HeaderText != "Rediger")
                                {
                                    try
                                    {
                                        dtFromGrid.Rows[dtFromGrid.Rows.Count - 1][cell.ColumnIndex - 1] = cell.Value.ToString();
                                    }
                                    catch (Exception)
                                    {
                                        dtFromGrid.Rows[dtFromGrid.Rows.Count - 1][cell.ColumnIndex - 1] = " ";
                                    }
                                }
                            }
                        }

                        //Laver en ny XLWorkbook som kommer fra en NuGet package der hedder closedXML man kan benytte til at oprette Excel dokumenter
                        var wb = new XLWorkbook();
                        wb.Worksheets.Add(dtFromGrid, "Manage"); //Opretter et nyt worksheet på baggrund af det oprettede datatable
                        wb.SaveAs(Path.GetFullPath(saveFileDialog.FileName)); //Gemmer den oprettede XLWorkbook til filen som brugeren oprettede via savedialog
                        break;



                    default:
                        //Hvis det ikke er muligt at gemme vis fejlbesked til brugeren
                        MessageBox.Show($"Det var ikke muligt at gemme filen: {saveFileDialog.FileName} Prøv igen.", "Fejl!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
        }

        private void btnCreatePerson_Click(object sender, EventArgs e)
        {

        }

        private void rtbSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvSager_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
