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
    public partial class OpenHouse_Distribution : UserControl
    {
        public OpenHouse_Distribution()
        {
            InitializeComponent();

            //Form autosize
            OpenHouse_Distribution_SizeChanged(this, new EventArgs());
        }

        //Form autosize
        private void OpenHouse_Distribution_SizeChanged(object sender, EventArgs e)
        {
            lblDistribute.Font = new Font(lblDistribute.Font.FontFamily, this.Size.Height / 40);
            lblDistribution.Font = new Font(lblDistribution.Font.FontFamily, this.Size.Height / 40);
            lblSearch.Font = new Font(lblSearch.Font.FontFamily, this.Size.Height / 40);
            btnDistribute.Font = new Font(btnDistribute.Font.FontFamily, this.Size.Height / 40);
            btnSearch.Font = new Font(btnSearch.Font.FontFamily, this.Size.Height / 40);
            btnToFile.Font = new Font(btnToFile.Font.FontFamily, this.Size.Height / 40);
            cbDistribution.Font = new Font(cbDistribution.Font.FontFamily, this.Size.Height / 40);
            rtbSearch.Font = new Font(rtbSearch.Font.FontFamily, this.Size.Height / 40);
        }
    }
}
