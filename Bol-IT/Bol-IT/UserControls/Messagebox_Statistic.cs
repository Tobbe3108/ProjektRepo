using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            dudYear.Items.AddRange(Enumerable.Range(1950, DateTime.Today.Year).ToList());
        }

        #endregion

        #region FormAutoSize

        //Tobias
        private void Messagebox_Statistic_SizeChanged(object sender, EventArgs e)
        {
            lblArea.Font = new Font(lblArea.Font.FontFamily, this.Size.Height / 15);
            lblMonth.Font = new Font(lblMonth.Font.FontFamily, this.Size.Height / 15);
            lblStatistic.Font = new Font(lblStatistic.Font.FontFamily, this.Size.Height / 15);
            btnToFile.Font = new Font(btnToFile.Font.FontFamily, this.Size.Height / 15);
            cbArea.Font = new Font(cbArea.Font.FontFamily, this.Size.Height / 15);
            cbStatistic.Font = new Font(cbStatistic.Font.FontFamily, this.Size.Height / 15);
            dudMonth.Font = new Font(dudMonth.Font.FontFamily, this.Size.Height / 15);
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
            if (cbStatistic.SelectedIndex == 0)
            {
                //Område salgsstatistik

            }
            else
            {
                //Kvadratmeterpris salgsstatistik

            }
        }
        #endregion
    }
}
