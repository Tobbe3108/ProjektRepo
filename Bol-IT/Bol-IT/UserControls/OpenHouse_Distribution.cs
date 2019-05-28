using System;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using DataAccessLayer;
using System.Threading;
using BusinessLayer;
using System.IO;
using System.Collections.Generic;
using ClosedXML.Excel;

namespace Bol_IT
{
    public partial class OpenHouse_Distribution : UserControl
    {
        #region Fields

        //Tobias
        //Datatables til brug i dgvDistribution
        public static DataTable agentDistributionTable = new DataTable();
        public static DataTable propDistributionTable = new DataTable();
        public static bool fordelt = false;//Flag for at se om der er lavet en fordeling.

        //Christoffer
        //Til brug af thread håndtering
        public bool ThreadRunning { get; set; }
        public bool ShouldRun { get; set; }

        #endregion

        #region Init

        //Tobias
        //Singleton instance af OpenHouse_Distribution
        static OpenHouse_Distribution _instance;
        public static OpenHouse_Distribution Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new OpenHouse_Distribution();
                }
                return _instance;
            }
        }

        private OpenHouse_Distribution()
        {
            InitializeComponent();

            //Form autosize
            OpenHouse_Distribution_SizeChanged(this, new EventArgs());

            //Gør at cbSearchParam starter på mægler istedet for blank
            //Starter også "cbSearchParam_SelectedIndexChanged", sådan 
            //at den henter informationer til at starte med
            cbSearchParam.SelectedIndex = 0;

            //Sætter fordelingen efter pris som standard.
            cbDistribution.SelectedIndex = 0;

            //tilføjer kolonner til de 2 datatables til brug i dgvDistribution
            agentDistributionTable.Columns.Add("aId", typeof(int));
            agentDistributionTable.Columns.Add("nrOfSales", typeof(int));
            agentDistributionTable.Columns["aId"].Unique = true;
            dgvDistribution.DataSource = agentDistributionTable;

            propDistributionTable.Columns.Add("caseNr", typeof(int));
            propDistributionTable.Columns.Add("address");
            propDistributionTable.Columns.Add("zipcode", typeof(int));
            propDistributionTable.Columns.Add("builtRebuild");
            propDistributionTable.Columns.Add("houseType");
            propDistributionTable.Columns["caseNr"].Unique = true;
        }

        private void OpenHouse_Distribution_Load(object sender, EventArgs e)
        {
            //Eager initialization af singleton instance
            _instance = this;
        }

        #endregion

        #region FormAutoSize

        //Tobias
        private void OpenHouse_Distribution_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                lblDistribute.Font = new Font(lblDistribute.Font.FontFamily, this.Size.Height / 50);
                lblDistribution.Font = new Font(lblDistribution.Font.FontFamily, this.Size.Height / 50);
                lblSearch.Font = new Font(lblSearch.Font.FontFamily, this.Size.Height / 50);
                btnDistribute.Font = new Font(btnDistribute.Font.FontFamily, this.Size.Height / 50);
                btnToFile.Font = new Font(btnToFile.Font.FontFamily, this.Size.Height / 50);
                cbDistribution.Font = new Font(cbDistribution.Font.FontFamily, this.Size.Height / 50);
                rtbSearch.Font = new Font(rtbSearch.Font.FontFamily, this.Size.Height / 50);
                cbSearchParam.Font = new Font(cbSearchParam.Font.FontFamily, this.Size.Height / 50);
                btnReset.Font = new Font(btnReset.Font.FontFamily, this.Size.Height / 50);
                dgvSearch.Font = new Font(dgvSearch.Font.FontFamily, this.Size.Height / 60);
                dgvDistribution.Font = new Font(dgvDistribution.Font.FontFamily, this.Size.Height / 60);
            }
            catch{}
        }

        #endregion

        #region Methods
        private void StartDataLoad()
        {
            // Hvis tråden er i gang med at køre, så sætter den et flag, som den nuværende thread tjekker når den er færdig med at køre, hvilket kører threaden igen
            if (ThreadRunning)
            {
                ShouldRun = true;
            }
            else
            {
                Thread LoadDataThread = new Thread(() => LoadData());
                LoadDataThread.IsBackground = true;
                LoadDataThread.Start();
            }
        }

        //Tobias
        //Kalder fasaden til DAL laget for at få fat i data fra agent og property tabellerne samt lidt data formatering
        private void LoadData()
        {
            ThreadRunning = true;
            try
            {
                DataTable dataTable = new DataTable();
                int index = 0;
                cbSearchParam.Invoke((MethodInvoker)delegate { index = cbSearchParam.SelectedIndex; });
                switch (index)
                {
                    case 0:
                        int agentSearchParameters = 0;
                        rtbSearch.Invoke((MethodInvoker)delegate { int.TryParse(rtbSearch.Text, out agentSearchParameters); });

                        dataTable = DataAccessLayerFacade.GetAgentDataTableByLike(agentSearchParameters);
                        break;
                    case 1:
                        string propertySearchParameters = "";
                        rtbSearch.Invoke((MethodInvoker)delegate { propertySearchParameters = rtbSearch.Text; });

                        dataTable = RemoveColumns(DataAccessLayerFacade.GetPropertyDataTableByLike(propertySearchParameters, false));
                        break;
                }



                dgvSearch.Invoke((MethodInvoker)delegate { dgvSearch.DataSource = dataTable; });
            }
            catch (Exception) { }
            ThreadRunning = false;

            if (ShouldRun)
            {
                //Call the method to run the thread again
                StartDataLoad();
                ShouldRun = false;
            }
        }

        //Caspar
        //Metode til at genskabe slet-knappen hvis den er blevet slettet.
        private void ButtonDeleted()
        {
            try
            {
                //Kontrolerer om Slet-knappen er blevet fjernet igennem fordelingen. Hvis ja, oprettes den på ny.
                if (dgvDistribution.Columns[0].HeaderText != "Slet")
                {
                    DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                    btn.HeaderText = "Slet";
                    btn.Name = "Slet";
                    btn.Text = "Slet";
                    btn.ToolTipText = "Slet fra tabel.";
                    btn.UseColumnTextForButtonValue = true;
                    dgvDistribution.Columns.Insert(0, btn);//Indsætter knappen på den 0'te plads med ovenstående værdier.
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Der er sket en uventet fejl af typen {exception.GetType()}.", "Fejlmeddelelse:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Caspar
        /// <summary>
        /// Sletter de nedenstående columns fra datatablet, således at det står overskueligt i DataGridViewet.
        /// </summary>
        /// <returns></returns>
        private DataTable RemoveColumns(DataTable dataTable)
        {
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

            return dataTable;
        }

        #endregion

        #region Events

        //Tobias
        //Laver en thread der loader data fra databasen hver gang man ændre teksten i tekst boxen
        private void rtbSearch_TextChanged(object sender, EventArgs e)
        {
            if (rtbSearch.Text.Length > 0)
            {
                StartDataLoad();
            }
            //Hvis der ikke står noget, så henter den alle entries i databasen
            //Henter alle mæglerer her
            else if (cbSearchParam.SelectedIndex == 0)
            {
                try
                {
                    dgvSearch.DataSource = DataAccessLayerFacade.GetAgentDataTable();
                }
                catch (Exception){}
            }
            //Henter alle sager her
            else
            {
                try
                {
                    dgvSearch.DataSource = RemoveColumns(DataAccessLayerFacade.GetPropertyDataTable());
                }
                catch (Exception) { }
            }
        }

        //Tobias
        //Tilføjer en mægler(agent) eller en sag(property) til fordelings tabellen ved tryk på knappen tilføj
        private void dgvSearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //---Hvis trykket på knap Tilføj inde i datagridview---//
            if (dgvSearch.Columns[e.ColumnIndex].Name == "Tilføj")
            {
                if (e.RowIndex >= 0)
                {
                    //Tilføj til den rigtive tabel
                    if (dgvDistribution.DataSource == agentDistributionTable)
                    {
                        try
                        {
                            agentDistributionTable.Rows.Add(
                                dgvSearch.Rows[e.RowIndex].Cells[1].Value.ToString(),
                                dgvSearch.Rows[e.RowIndex].Cells[2].Value.ToString());
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Du har forsøgt at tilføje den samme mægler to gange.", "Fejlmeddelelse:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        try
                        {
                            propDistributionTable.Rows.Add(dgvSearch.Rows[e.RowIndex].Cells[1].Value.ToString(),
                               dgvSearch.Rows[e.RowIndex].Cells[2].Value.ToString(),
                               dgvSearch.Rows[e.RowIndex].Cells[3].Value.ToString(),
                               dgvSearch.Rows[e.RowIndex].Cells[4].Value.ToString(),
                               dgvSearch.Rows[e.RowIndex].Cells[5].Value.ToString());
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Du har forsøgt at tilføje den samme bolig to gange.", "Fejlmeddelelse:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        //Tobias
        /// <summary>
        /// Skift binding source ved skrift mellem mægler og sag
        /// </summary>
        private void cbSearchParam_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvSearch.DataSource = null;

            ButtonDeleted();

            switch (cbSearchParam.SelectedIndex)
            {
                case 0:
                    dgvDistribution.DataSource = agentDistributionTable;
                    DataTable agentDataTable = DataAccessLayerFacade.GetAgentDataTable();
                    dgvSearch.DataSource = agentDataTable;
                    agentDataTable.Columns["aId"].ColumnName = "Mægler Id";
                    agentDataTable.Columns["nrOfSales"].ColumnName = "Antal salg";

                    fordelt = false;
                    break;
                case 1:
                    dgvDistribution.DataSource = propDistributionTable;
                    DataTable propertyDataTable = RemoveColumns(DataAccessLayerFacade.GetPropertyDataTable());
                    dgvSearch.DataSource = propertyDataTable;
                    propertyDataTable.Columns["caseNr"].ColumnName = "Sagsnummer";
                    propertyDataTable.Columns["address"].ColumnName = "Adresse";
                    propertyDataTable.Columns["zipcode"].ColumnName = "Postnummer";
                    propertyDataTable.Columns["builtRebuild"].ColumnName = "Bygget/Ombygget";
                    propertyDataTable.Columns["houseType"].ColumnName = "Bolig type";
                    fordelt = false;
                    break;
            }
        }



        //Tobias
        //Slette en mægler(agent) eller en sag(property) fra fordelings tabellen ved tryk på knappen tilføj
        private void dgvDistribution_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //---Hvis trykket på knap Slet inde i datagridview---//
            if (dgvDistribution.Columns[e.ColumnIndex].Name == "Slet")
            {
                if (e.RowIndex >= 0)
                {
                    dgvDistribution.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

        //Caspar
        //Kalder metoden for fordeling af boliger ud på mægler, ved brug af en array-baseret hob. 
        private void btnDistribute_Click(object sender, EventArgs e)
        {
            try
            {
                if (agentDistributionTable.Rows.Count > 0 && propDistributionTable.Rows.Count > 0)//Kontrolerer at der er valgt både mæglere og boliger.
                {
                    if (propDistributionTable.Rows.Count < agentDistributionTable.Rows.Count)//Kontrolerer hvorvidt der er flere mæglere end boliger valgt.
                    {
                        //Besked der prompter dig til enten at fortsætte, eller anullere.
                        if (MessageBox.Show("Ikke alle mæglere bliver tildelt en bolig. Vil du fortsætte?", "Fortsæt?", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                        {
                            return;
                        }
                    }
                    if (dgvDistribution.Columns[0].HeaderText == "Slet")
                    {
                        dgvDistribution.Columns.RemoveAt(0);//Fjerner slet-knappen fra DataGridViewet.
                    }
                    dgvDistribution.DataSource = null;
                    dgvDistribution.DataSource = BusinessLayerFacade.DistributeHouses(agentDistributionTable, propDistributionTable, cbDistribution.SelectedIndex);//Sætter datasourcen til det datatable metoden returnerer.
                    dgvDistribution.Sort(dgvDistribution.Columns["AId"], ListSortDirection.Ascending);//Sorterer DataGridViewet efter Agent Id.
                    fordelt = true;
                }
                else
                {
                    //Fejlmeddelelse hvis ikke både boliger og mæglere er valgt til fordelingen.
                    MessageBox.Show("Du har ikke tilføjet boliger/mæglere til fordelingen. Prøv igen.", "Fejlmeddelelse:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Der er sket en uventet fejl af typen {exception.GetType()}.", "Fejlmeddelelse:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Caspar
        //Knap til at resette DataGridViewet for fordelingen, og de valgte boliger/mæglere i hver deres DataTable.
        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                //Clear de to DataTables
                agentDistributionTable.Clear();
                propDistributionTable.Clear();

                //Kopier dataSourcen fra DataGridViewet med fordelingen, og clear det for data. Dette gøres for ikke at fjerne collumns, men kun fjerne dataen.
                DataTable data = (DataTable)dgvDistribution.DataSource;
                data.Clear(); //Fjerner dataen fra kopien
                dgvDistribution.DataSource = data;

                //Resetter valgene for search og fordeling.
                cbSearchParam.SelectedIndex = 0;
                cbDistribution.SelectedIndex = 0;

                fordelt = false;
            }
            //Standard fejl-besked.
            catch (Exception exception)
            {
                MessageBox.Show($"Der er sket en uventet fejl af typen {exception.GetType()}.", "Fejlmeddelelse:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Tobias
        private void btnToFile_Click(object sender, EventArgs e)
        {
            if (fordelt)//Hvis der er lavet en fordeling, tilad udskrivning til fil.
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

                            for (int col = 0; col < dgvDistribution.Columns.Count; col++)
                            {
                                int stringLength = 0;
                                for (int row = 0; row < dgvDistribution.Rows.Count; row++)
                                {
                                    if (stringLength < dgvDistribution.Rows[row].Cells[col].Value.ToString().Length)
                                    {
                                        stringLength = dgvDistribution.Rows[row].Cells[col].Value.ToString().Length;
                                    }
                                }
                                if (stringLength < dgvDistribution.Columns[col].HeaderText.Length)
                                {
                                    stringLength = dgvDistribution.Columns[col].HeaderText.Length;
                                }
                                longestString.Add(stringLength);
                            }



                            //Skriver kolone header text til filen
                            string header = "";
                            for (int col = 0; col < dgvDistribution.Columns.Count; col++)
                            {
                                try
                                {
                                    header += $"{dgvDistribution.Columns[col].HeaderText.PadRight(longestString[col] + 5)}";
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show($"Det var ikke muligt at gemme filen: {saveFileDialog.FileName} Prøv igen.", "Fejl!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            writer.WriteLine(header);

                            //Skriver alt data til filen
                            for (int row = 0; row < dgvDistribution.Rows.Count; row++)
                            {
                                string lines = "";
                                for (int col = 0; col < dgvDistribution.Columns.Count; col++)
                                {
                                    try
                                    {
                                        lines += $"{dgvDistribution.Rows[row].Cells[col].Value.ToString().PadRight(longestString[col] + 5)}";
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
                            for (int i = 1; i < dgvDistribution.Columns.Count; i++)
                            {
                                dtFromGrid.Columns.Add(dgvDistribution.Columns[i].HeaderText);
                            }

                            //Tilføjer alle rækker til det nye datatable med rækkens værdier
                            foreach (DataGridViewRow row in dgvDistribution.Rows)
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
            else//Hvis ingen fordeling, fortæl brugeren dette.
            {
                MessageBox.Show("Der er ikke nogen fordeling at udskrive. Lav venligst en fordeling, og prøv igen.", "Fejlmeddelelse:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }

    #endregion
}

