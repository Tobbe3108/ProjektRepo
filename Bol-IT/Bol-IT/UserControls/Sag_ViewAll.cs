using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bol_IT
{
    public partial class Sag_ViewAll : UserControl
    {
        public Sag_ViewAll()
        {
            InitializeComponent();

            //Form autosize
            Sag_ViewAll_SizeChanged(this, new EventArgs());
        }


        //Form autosize
        private void Sag_ViewAll_SizeChanged(object sender, EventArgs e)
        {
            btnSag.Font = new Font(btnSag.Font.FontFamily, this.Size.Height / 50);
            btnSearch.Font = new Font(btnSearch.Font.FontFamily, this.Size.Height / 50);
            btnStatistic.Font = new Font(btnStatistic.Font.FontFamily, this.Size.Height / 50);
            btnToFile.Font = new Font(btnToFile.Font.FontFamily, this.Size.Height / 50);
            lblSearch.Font = new Font(lblSearch.Font.FontFamily, this.Size.Height / 50);
            rtbSearch.Font = new Font(rtbSearch.Font.FontFamily, this.Size.Height / 50);
        }

        private void btnStatistic_Click(object sender, EventArgs e)
        {
            Messagebox_Statistic messagebox_Statistic = new Messagebox_Statistic();
            messagebox_Statistic.Show();
        }
    }
}
