using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using DataAccessLayer;
using GlobalClasses;
using ClosedXML.Excel;
using System.IO;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Bol_IT
{
    public partial class Sag_ViewAll : UserControl
    {
        #region Init

        public bool ThreadRunning { get; set; }
        public bool ShouldRun { get; set; }

        //Tobias
        //Singleton i
        static Sag_ViewAll _instance;
        public static Sag_ViewAll Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Sag_ViewAll();
                }
                return _instance;
            }
        }

        private Sag_ViewAll()
        {
            InitializeComponent();

            //Form autosize
            Sag_ViewAll_SizeChanged(this, new EventArgs());
        }

        private void Sag_ViewAll_Load(object sender, EventArgs e)
        {
            //Eager initialization af singleton instance
            _instance = this;

            StartDataLoad();
        }

        #endregion

        #region FormAutoSize

        //Tobias
        private void Sag_ViewAll_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                btnCreateSag.Font = new Font(btnCreateSag.Font.FontFamily, this.Size.Height / 50);
                btnToFile.Font = new Font(btnToFile.Font.FontFamily, this.Size.Height / 50);
                btnStatistic.Font = new Font(btnStatistic.Font.FontFamily, this.Size.Height / 50);
                lblSearch.Font = new Font(lblSearch.Font.FontFamily, this.Size.Height / 50);
                rtbSearch.Font = new Font(rtbSearch.Font.FontFamily, this.Size.Height / 50);
                cbSoldFlag.Font = new Font(cbSoldFlag.Font.FontFamily, this.Size.Height / 50);
                dgvSager.Font = new Font(dgvSager.Font.FontFamily, this.Size.Height / 60);

            }
            catch { }
        }

        #endregion

        #region Methods

        //Tobias
        //Kalder fasaden til DAL laget for at få fat i data fra property tabellen samt lidt data formatering
        private void LoadData()
        {
            try
            {
                DataTable dataTable = new DataTable();

                string SearchParameters = "";
                bool soldFlag = false;
                rtbSearch.Invoke((MethodInvoker)delegate { SearchParameters = rtbSearch.Text; });
                cbSoldFlag.Invoke((MethodInvoker)delegate { soldFlag = cbSoldFlag.Checked; });

                if (soldFlag)
                {

                    dataTable = DataAccessLayerFacade.GetPropertyDataTableByLikeAll(SearchParameters);
                }
                else
                {
                    dataTable = DataAccessLayerFacade.GetPropertyDataTableByLike(SearchParameters, soldFlag);
                }

                dataTable.Columns.Remove("netPrice");
                dataTable.Columns.Remove("grossPrice");
                dataTable.Columns.Remove("ownerExpenses");
                dataTable.Columns.Remove("cashPrice");
                dataTable.Columns.Remove("depositPrice");
                dataTable.Columns.Remove("nrOfRooms");
                dataTable.Columns.Remove("garageFlag");
                dataTable.Columns.Remove("energyRating");
                dataTable.Columns.Remove("resSquareMeters");
                dataTable.Columns.Remove("propSquareMeters");
                dataTable.Columns.Remove("floors");
                dataTable.Columns.Remove("soldFlag");
                dataTable.Columns.Remove("description");

                dataTable.Columns["caseNr"].ColumnName = "Sags nummer";
                dataTable.Columns["address"].ColumnName = "Adresse";
                dataTable.Columns["zipcode"].ColumnName = "Postnummer";
                dataTable.Columns["builtRebuild"].ColumnName = "Bygget/Ombygget";
                dataTable.Columns["houseType"].ColumnName = "Hus type";

                dgvSager.Invoke((MethodInvoker)delegate { dgvSager.DataSource = dataTable; });

            }
            catch (Exception) { }

            ThreadRunning = false;

            if (ShouldRun)
            {
                StartDataLoad();
                ShouldRun = false;
            }
        }

        public void StartDataLoad()
        {
            if (ThreadRunning)
            {
                ShouldRun = true;
            }
            else
            {
                ThreadRunning = true;
                Thread LoadDataThread = new Thread(() => LoadData());
                LoadDataThread.Name = "DataLoadThread";
                LoadDataThread.IsBackground = true;
                LoadDataThread.Start();
            }
        }

        #endregion

        #region Events

        //Tobias
        private void btnStatistic_Click(object sender, EventArgs e)
        {
            Messagebox_Statistic messagebox_Statistic = new Messagebox_Statistic();
            messagebox_Statistic.Show();
        }

        private void btnCreateSag_Click(object sender, EventArgs e)
        {
            //Load Sag_Create User control når tryk på knap
            if (!Form1.Instance.PnlContainer.Controls.ContainsKey("Sag_Create"))
            {
                Sag_Create.Instance.Dock = DockStyle.Fill;
                Form1.Instance.PnlContainer.Controls.Add(Sag_Create.Instance);
            }
            Form1.Instance.PnlContainer.Controls["Sag_Create"].BringToFront();
        }

        private void rtbSearch_TextChanged(object sender, EventArgs e)
        {
            if (!DataAccessLayerFacade.CheckForSQLInjection(rtbSearch.Text))
            {
                StartDataLoad();
            }
        }

        private void dgvSager_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //---Hvis trykket på knap Rediger inde i datagridview---//
            if (dgvSager.Columns[e.ColumnIndex].Name == "Rediger")
            {
                if (e.RowIndex >= 0)
                {
                    //Load Sag_Edit User control når tryk på knap med ID fra celle
                    if (!Form1.Instance.PnlContainer.Controls.ContainsKey("Sag_Edit"))
                    {
                        Sag_Edit.Instance.Dock = DockStyle.Fill;
                        Form1.Instance.PnlContainer.Controls.Add(Sag_Edit.Instance);
                    }
                    Form1.Instance.PnlContainer.Controls["Sag_Edit"].BringToFront();

                    Sag_Edit.LoadData(dgvSager.Rows[e.RowIndex].Cells[1].Value.ToString());

                }
            }
        }

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

                        for (int col = 1; col < dgvSager.Columns.Count; col++)
                        {
                            int stringLength = 0;
                            for (int row = 0; row < dgvSager.Rows.Count; row++)
                            {
                                if (stringLength < dgvSager.Rows[row].Cells[col].Value.ToString().Length)
                                {
                                    stringLength = dgvSager.Rows[row].Cells[col].Value.ToString().Length;
                                }
                            }
                            if (stringLength < dgvSager.Columns[col].HeaderText.Length)
                            {
                                stringLength = dgvSager.Columns[col].HeaderText.Length;
                            }
                            longestString.Add(stringLength);
                        }

                        //Skriver kolone header text til filen
                        string header = "";
                        for (int col = 1; col < dgvSager.Columns.Count; col++)
                        {
                            try
                            {
                                header += $"{dgvSager.Columns[col].HeaderText.PadRight(longestString[col - 1] + 5)}";
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Det var ikke muligt at gemme filen: {saveFileDialog.FileName} Prøv igen.", "Fejl!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        writer.WriteLine(header);



                        //Skriver alt data til filen
                        for (int row = 0; row < dgvSager.Rows.Count; row++)
                        {
                            string lines = "";
                            for (int col = 1; col < dgvSager.Columns.Count; col++)
                            {
                                try
                                {
                                    lines += $"{dgvSager.Rows[row].Cells[col].Value.ToString().PadRight(longestString[col - 1] + 5)}";
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show($"Det var ikke muligt at gemme filen: {saveFileDialog.FileName} Prøv igen.", "Fejl!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
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
                        for (int i = 1; i < dgvSager.Columns.Count; i++)
                        {
                            dtFromGrid.Columns.Add(dgvSager.Columns[i].HeaderText);
                        }

                        //Tilføjer alle rækker til det nye datatable med rækkens værdier
                        foreach (DataGridViewRow row in dgvSager.Rows)
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
                                        return;
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

        private void cbSoldFlag_CheckedChanged(object sender, EventArgs e)
        {
            StartDataLoad();
        }

        #endregion

    }
}
