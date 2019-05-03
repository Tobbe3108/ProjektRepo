using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;

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
        }

        private void OpenHouse_Distribution_Load(object sender, EventArgs e)
        {
            //Eager initialization af singleton instance
            _instance = this;
        }



        //Form autosize
        private void OpenHouse_Distribution_SizeChanged(object sender, EventArgs e)
        {
            lblDistribute.Font = new Font(lblDistribute.Font.FontFamily, this.Size.Height / 50);
            lblDistribution.Font = new Font(lblDistribution.Font.FontFamily, this.Size.Height / 50);
            lblSearch.Font = new Font(lblSearch.Font.FontFamily, this.Size.Height / 50);
            btnDistribute.Font = new Font(btnDistribute.Font.FontFamily, this.Size.Height / 50);
            btnSearch.Font = new Font(btnSearch.Font.FontFamily, this.Size.Height / 50);
            btnToFile.Font = new Font(btnToFile.Font.FontFamily, this.Size.Height / 50);
            cbDistribution.Font = new Font(cbDistribution.Font.FontFamily, this.Size.Height / 50);
            rtbSearch.Font = new Font(rtbSearch.Font.FontFamily, this.Size.Height / 50);
        }
        //---//
    }
}
