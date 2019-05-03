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
using System.Threading;

namespace Bol_IT
{ 
    public partial class OpenHouse_Distribution : UserControl
    {
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

            cbSearchParam.SelectedIndex = 0;
        }

        private void OpenHouse_Distribution_Load(object sender, EventArgs e)
        {
            //Eager initialization af singleton instance
            _instance = this;
        }

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
                        dataTable = DataAccessLayerFacade.GetAgentDataTable();
                        break;
                    case 1:
                        dataTable = DataAccessLayerFacade.GetPropertyDataTable();
                        break;
                }

                dgvSearch.Invoke((MethodInvoker)delegate { dgvSearch.DataSource = dataTable; });
            }
            catch (Exception){}
        }

        private void rtbSearch_TextChanged(object sender, EventArgs e)
        {
            Thread LoadDataThread = new Thread(() => LoadData());
            LoadDataThread.IsBackground = true;
            LoadDataThread.Start();
        }

        //Form autosize
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
        //---//
    }
}
