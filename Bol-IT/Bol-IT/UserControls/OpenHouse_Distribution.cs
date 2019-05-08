using System;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using DataAccessLayer;
using System.Threading;
using BusinessLayer;

namespace Bol_IT
{
    public partial class OpenHouse_Distribution : UserControl
    {
        #region Fields

        //Tobias
        //Datatables til brug i dgvDistribution
        public static DataTable agentDistributionTable = new DataTable();
        public static DataTable propDistributionTable = new DataTable();

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

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void dgvSearch_SizeChanged(object sender, EventArgs e)
        {
            try
            {

                dgvSearch.Font = new Font(dgvSearch.Font.FontFamily, this.Size.Height / 60);
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region Methods

        //Tobias
        //Kalder fasaden til DAL laget for at få fat i data fra agent og property tabellerne samt lidt data formatering
        private void LoadData()
        {
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
        }

        #endregion

        #region Events

        //Tobias
        //Laver en thread der loader data fra databasen hver gang man ændre teksten i tekst boxen
        private void rtbSearch_TextChanged(object sender, EventArgs e)
        {
            if (rtbSearch.Text.Length > 0)
            {
                Thread LoadDataThread = new Thread(() => LoadData());
                LoadDataThread.IsBackground = true;
                LoadDataThread.Start();
            }
            else if (cbSearchParam.SelectedIndex == 0)
            {
                dgvSearch.DataSource = DataAccessLayerFacade.GetAgentDataTable();
            }
            else
            {
                dgvSearch.DataSource = RemoveColumns(DataAccessLayerFacade.GetPropertyDataTable());
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
                                agentDistributionTable.Rows.Add(dgvSearch.Rows[e.RowIndex].Cells[1].Value.ToString(),
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
        //Skift binding source ved skrift mellem mægler og sag
        private void cbSearchParam_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvSearch.DataSource = null;

            ButtonDeleted();

            switch (cbSearchParam.SelectedIndex)
            {
                case 0:
                    dgvDistribution.DataSource = agentDistributionTable;
                    dgvSearch.DataSource = DataAccessLayerFacade.GetAgentDataTable();
                    break;
                case 1:
                    dgvDistribution.DataSource = propDistributionTable;
                    dgvSearch.DataSource = RemoveColumns(DataAccessLayerFacade.GetPropertyDataTable());
                    break;
            }
        }

        //Caspar
        //Sletter de nedenstående columns fra datatablet, således at det står overskueligt i DataGridViewet.
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

        #endregion

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
                    dgvDistribution.DataSource = OpenHouseMethods.DistributeHouses(agentDistributionTable, propDistributionTable, cbDistribution.SelectedIndex);//Sætter datasourcen til det datatable metoden returnerer.
                    dgvDistribution.Sort(dgvDistribution.Columns["AId"], ListSortDirection.Ascending);//Sorterer DataGridViewet efter Agent Id.
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

                //Kopier dataSourcen fra DataGridViewet med fordelingen, og clear det for data.
                DataTable data = (DataTable)dgvDistribution.DataSource;
                data.Clear(); //Fjerner dataen fra kopien
                dgvDistribution.DataSource = data;

                ButtonDeleted();

                //Resetter valgene for search og fordeling.
                cbSearchParam.SelectedIndex = 0;
                cbDistribution.SelectedIndex = 0;
            }
            //Standard fejl-besked.
            catch (Exception exception)
            {
                MessageBox.Show($"Der er sket en uventet fejl af typen {exception.GetType()}.", "Fejlmeddelelse:", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    btn.UseColumnTextForButtonValue = true;
                    dgvDistribution.Columns.Insert(0, btn);//Indsætter knappen på den 0'te plads med ovenstående værdier.
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Der er sket en uventet fejl af typen {exception.GetType()}.", "Fejlmeddelelse:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
