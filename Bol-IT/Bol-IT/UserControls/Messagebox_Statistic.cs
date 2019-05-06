using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace Bol_IT
{
    public partial class Messagebox_Statistic : Form
    {
        #region Init

        //Tobias
        public Messagebox_Statistic()
        {
            InitializeComponent();

            //Form autosize
            Messagebox_Statistic_SizeChanged(this, new EventArgs());
            
            DataTable dataTable = DataAccessLayerFacade.GetZipcodes();

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                cbArea.Items.Add(dataTable.Rows[i]["Zipcode"]);
            }

            for (int year = DateTime.UtcNow.Year; year >= 1950; --year)
            {
                cbYear.Items.Add(year);
            }
        }

        #endregion

        #region FormAutoSize

        //Tobias
        private void Messagebox_Statistic_SizeChanged(object sender, EventArgs e)
        {
            lblArea.Font = new Font(lblArea.Font.FontFamily, this.Size.Height / 16);
            lblMonth.Font = new Font(lblMonth.Font.FontFamily, this.Size.Height / 15);
            lblStatistic.Font = new Font(lblStatistic.Font.FontFamily, this.Size.Height / 15);
            btnToFile.Font = new Font(btnToFile.Font.FontFamily, this.Size.Height / 15);
            cbArea.Font = new Font(cbArea.Font.FontFamily, this.Size.Height / 15);
            cbStatistic.Font = new Font(cbStatistic.Font.FontFamily, this.Size.Height / 15);
            cbMonth.Font = new Font(cbMonth.Font.FontFamily, this.Size.Height / 15);
            cbYear.Font = new Font(cbYear.Font.FontFamily, this.Size.Height / 15);
            lblYear.Font = new Font(lblYear.Font.FontFamily, this.Size.Height / 15);
        }

        #endregion

        #region Methods



        #endregion

        #region Events

        //Tobias
        private void cbStatistic_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbStatistic.SelectedIndex == 1)
            {
                cbArea.Enabled = false;
            }
        }

        //Tobias
        private void btnToFile_Click(object sender, EventArgs e)
        {
            string header = "";

            DataTable dataTable = new DataTable();
            switch (cbStatistic.SelectedIndex)
            {
                case 0:
                    //Område salgsstatistik

                    header = "Område salgsstatistik";
                    break;
                case 1:
                    //Kvadratmeterpris salgsstatistik
                    dataTable = DataAccessLayerFacade.StatisticSquareMeterPrice(cbYear.GetItemText(cbYear.SelectedItem), (cbMonth.SelectedIndex + 1).ToString());
                    header = "Kvadratmeterpris salgsstatistik";
                    break;
                default:
                    MessageBox.Show("Vælg hvilken statistik du kunne tænke dig");
                    break;
            }

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



                        List<int> longestString = new List<int>();

                        for (int col = 0; col < dataTable.Columns.Count; col++)
                        {
                            int stringLength = 0;
                            for (int row = 0; row < dataTable.Rows.Count - 1; row++)
                            {
                                if (stringLength < dataTable.Rows[row][col].ToString().Length)
                                {
                                    stringLength = dataTable.Rows[row][col].ToString().Length;
                                }
                            }
                            if (stringLength < dataTable.Columns[col].ColumnName.Length)
                            {
                                stringLength = dataTable.Columns[col].ColumnName.Length;
                            }
                            longestString.Add(stringLength);
                        }



                        //Skriver første linje til filen med header
                        try
                        {
                            writer.WriteLine(header);
                            writer.WriteLine();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show($"Det var ikke muligt at gemme filen: {saveFileDialog.FileName} Prøv igen.", "Fejl!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }



                        //Skriver kolone header text til filen
                        string columHeader = "";
                        for (int col = 0; col < dataTable.Columns.Count; col++)
                        {
                            try
                            {
                                if (col == 3)
                                {
                                    columHeader += $"{dataTable.Columns[col].ColumnName.PadRight(longestString[col] - 4)}";
                                }
                                else
                                {
                                    columHeader += $"{dataTable.Columns[col].ColumnName.PadRight(longestString[col] + 5)}";
                                }

                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Det var ikke muligt at gemme filen: {saveFileDialog.FileName} Prøv igen.", "Fejl!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        writer.WriteLine(columHeader);



                        //Skriver alt data til filen
                        for (int row = 0; row < dataTable.Rows.Count; row++)
                        {
                            string lines = "";
                            for (int col = 0; col < dataTable.Columns.Count; col++)
                            {

                                try
                                {
                                    lines += $"{dataTable.Rows[row][col].ToString().PadRight(longestString[col] + 5)}";
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
                        break;

                    default:
                        //Hvis det ikke er muligt at gemme vis fejlbesked til brugeren
                        MessageBox.Show($"Det var ikke muligt at gemme filen: {saveFileDialog.FileName} Prøv igen.", "Fejl!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }

        }
        #endregion
    }
}
