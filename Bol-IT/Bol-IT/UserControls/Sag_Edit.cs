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
    public partial class Sag_Edit : UserControl
    {
        #region Init

        //Tobias
        //Singleton instance af Sag_Edit
        static Sag_Edit _instance;
        public static Sag_Edit Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Sag_Edit();
                }
                return _instance;
            }
        }

        private Sag_Edit()
        {
            InitializeComponent();

            //Form autosize
            Sag_Edit_SizeChanged(this, new EventArgs());

            pbHouseImage.AllowDrop = true;
        }

        private void Sag_Edit_Load(object sender, EventArgs e)
        {
            //Eager initialization af singleton instance
            _instance = this;
        }

        #endregion

        #region FormAutoSize

        //Tobias
        private void Sag_Edit_SizeChanged(object sender, EventArgs e)
        {
            lblAddress.Font = new Font(lblAddress.Font.FontFamily, this.Size.Height / 25);
            lblPrice.Font = new Font(lblPrice.Font.FontFamily, this.Size.Height / 50);
            btnCreateAd.Font = new Font(btnCreateAd.Font.FontFamily, this.Size.Height / 50);
            btnCancel.Font = new Font(btnCancel.Font.FontFamily, this.Size.Height / 50);
            btnSave.Font = new Font(btnSave.Font.FontFamily, this.Size.Height / 50);
            btnToFile.Font = new Font(btnToFile.Font.FontFamily, this.Size.Height / 50);
            rtbAddress.Font = new Font(rtbAddress.Font.FontFamily, this.Size.Height / 30);
            rtbHouseDescription.Font = new Font(rtbHouseDescription.Font.FontFamily, this.Size.Height / 50);
            rtbPrice.Font = new Font(rtbPrice.Font.FontFamily, this.Size.Height / 50);
        }

        #endregion

        #region Events

        //Tobias
        private void pbHouseImage_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        //Tobias
        private void pbHouseImage_DragDrop(object sender, DragEventArgs e)
        {
            foreach (string pic in ((string[])e.Data.GetData(DataFormats.FileDrop)))
            {
                Image image = Image.FromFile(pic);
                pbHouseImage.Image = image;
            }
        }

        #endregion


    }
}
