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
    public partial class Sag_Create : UserControl
    {
        #region Init

        //Tobias
        //Singleton instance af Sag_Create
        static Sag_Create _instance;
        public static Sag_Create Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Sag_Create();
                }
                return _instance;
            }
        }

        private Sag_Create()
        {
            InitializeComponent();

            //Form autosize
            Sag_Create_SizeChanged(this, new EventArgs());
        }

        private void Sag_Create_Load(object sender, EventArgs e)
        {
            //Eager initialization af singleton instance
            _instance = this;
        }

        #endregion

        #region FormAutoSize

        //Tobias
        private void Sag_Create_SizeChanged(object sender, EventArgs e)
        {
            lblAddress.Font = new Font(lblAddress.Font.FontFamily, this.Size.Height / 25);
            lblPrice.Font = new Font(lblPrice.Font.FontFamily, this.Size.Height / 50);
            btnCalculatePrice.Font = new Font(btnCalculatePrice.Font.FontFamily, this.Size.Height / 50);
            btnCancel.Font = new Font(btnCancel.Font.FontFamily, this.Size.Height / 50);
            btnSave.Font = new Font(btnSave.Font.FontFamily, this.Size.Height / 50);
            rtbAddress.Font = new Font(rtbAddress.Font.FontFamily, this.Size.Height / 30);
            rtbHouseDescription.Font = new Font(rtbHouseDescription.Font.FontFamily, this.Size.Height / 50);
            rtbPrice.Font = new Font(rtbPrice.Font.FontFamily, this.Size.Height / 50);
        }

        #endregion

        #region Events

        //Tobias
        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Load Sag_ViewAll User control når tryk på knap
            if (!Form1.Instance.PnlContainer.Controls.ContainsKey("Sag_ViewAll"))
            {
                Sag_ViewAll.Instance.Dock = DockStyle.Fill;
                Form1.Instance.PnlContainer.Controls.Add(Sag_ViewAll.Instance);
            }
            Form1.Instance.PnlContainer.Controls["Sag_ViewAll"].BringToFront();
        }

        #endregion


    }
}
