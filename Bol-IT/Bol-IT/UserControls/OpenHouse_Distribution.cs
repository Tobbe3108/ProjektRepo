using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer;
using BusinessLayer;
using GlobalClasses;
using System.Threading;

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

            //tilføjer kolonner til de 2 datatables til brug i dgvDistribution
            agentDistributionTable.Columns.Add("aId");
            agentDistributionTable.Columns.Add("nrOfSales");
            dgvDistribution.DataSource = agentDistributionTable;

            propDistributionTable.Columns.Add("caseNr");
            propDistributionTable.Columns.Add("address");
            propDistributionTable.Columns.Add("zipcode");
            propDistributionTable.Columns.Add("builtRebuild");
            propDistributionTable.Columns.Add("houseType");
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
            lblDistribute.Font = new Font(lblDistribute.Font.FontFamily, this.Size.Height / 50);
            lblDistribution.Font = new Font(lblDistribution.Font.FontFamily, this.Size.Height / 50);
            lblSearch.Font = new Font(lblSearch.Font.FontFamily, this.Size.Height / 50);
            btnDistribute.Font = new Font(btnDistribute.Font.FontFamily, this.Size.Height / 50);
            btnToFile.Font = new Font(btnToFile.Font.FontFamily, this.Size.Height / 50);
            cbDistribution.Font = new Font(cbDistribution.Font.FontFamily, this.Size.Height / 50);
            rtbSearch.Font = new Font(rtbSearch.Font.FontFamily, this.Size.Height / 50);
            cbSearchParam.Font = new Font(cbSearchParam.Font.FontFamily, this.Size.Height / 50);
        }

        private void dgvSearch_SizeChanged(object sender, EventArgs e)
        {
            dgvSearch.Font = new Font(dgvSearch.Font.FontFamily, this.Size.Height / 60);
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

                        dataTable = DataAccessLayerFacade.GetPropertyDataTableByLike(propertySearchParameters);

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
                        break;
                }

                dgvSearch.Invoke((MethodInvoker)delegate { dgvSearch.DataSource = dataTable; });
            }
            catch (Exception){}
        }

        #endregion

        #region Events

        //Tobias
        //Laver en thread der loader data fra databasen hver gang man ændre teksten i tekst boxen
        private void rtbSearch_TextChanged(object sender, EventArgs e)
        {
            Thread LoadDataThread = new Thread(() => LoadData());
            LoadDataThread.IsBackground = true;
            LoadDataThread.Start();
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
                            MessageBox.Show("Der skete en fejl prøv igen");
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
                            MessageBox.Show("Der skete en fejl prøv igen");
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

            switch (cbSearchParam.SelectedIndex)
            {
                case 0:
                    dgvDistribution.DataSource = agentDistributionTable;
                    break;
                case 1:
                    dgvDistribution.DataSource = propDistributionTable;
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

        #endregion
    }
}
