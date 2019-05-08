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
using System.IO;

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

            pbHouseImage.AllowDrop = true;
        }

        private void Sag_Create_Load(object sender, EventArgs e)
        {
            //Eager initialization af singleton instance
            _instance = this;

            List<Seller> sellers = DataAccessLayerFacade.GetSellers();
            sellers.ForEach(seller => cbSellerId.Items.Add(seller.SId));
            sellers.ForEach(seller => cbSellerId.AutoCompleteCustomSource.Add(seller.SId.ToString()));
        }



        #endregion

        #region FormAutoSize

        //Tobias
        private void Sag_Create_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                lblAddress.Font = new Font(lblAddress.Font.FontFamily, this.Size.Height / 25);
                lblCashPrice.Font = new Font(lblCashPrice.Font.FontFamily, this.Size.Height / 50);
                btnCalculatePrice.Font = new Font(btnCalculatePrice.Font.FontFamily, this.Size.Height / 50);
                btnCancel.Font = new Font(btnCancel.Font.FontFamily, this.Size.Height / 50);
                btnSave.Font = new Font(btnSave.Font.FontFamily, this.Size.Height / 50);
                rtbAddress.Font = new Font(rtbAddress.Font.FontFamily, this.Size.Height / 30);
                rtbHouseDescription.Font = new Font(rtbHouseDescription.Font.FontFamily, this.Size.Height / 50);
                rtbCashPrice.Font = new Font(rtbCashPrice.Font.FontFamily, this.Size.Height / 50);
            }
            catch
            {

            }
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

        //Christoffer
        private void CheckKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void CheckKeyPressDigit(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == '/'))
            {
                e.Handled = true;
            }
        }

        //Christoffer
        private void pbHouseImage_Click(object sender, EventArgs e)
        {
            if (ofdOpenPicture.ShowDialog() == DialogResult.OK)
            {
                Image image = Image.FromFile(ofdOpenPicture.FileName);
                pbHouseImage.Image = image;
                pbHouseImage.ImageLocation = ofdOpenPicture.FileName;
            }
        }

        //Christoffer
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (AnyBoxIsEmpty())
            {
                MessageBox.Show("WHAT THE FUCK DID YOU JUST BRING UPON THIS CURSED LAND");
                return;
            }
            else
            {

                int caseNr = DataAccessLayerFacade.CreateProperty
                    (
                    int.Parse(cbSellerId.Text),
                    int.Parse(rtbDesiredPrice.Text),
                    int.Parse(rtbTimeFrame.Text),
                    int.Parse(rtbNetPrice.Text),
                    int.Parse(rtbGrossPrice.Text),
                    int.Parse(rtbOwnerExpences.Text),
                    int.Parse(rtbCashPrice.Text),
                    int.Parse(rtbDepositPrice.Text),
                    rtbAddress.Text,
                    int.Parse(rtbZipCode.Text),
                    int.Parse(rtbNrOfRooms.Text),
                    cbGarageFlag.Checked,
                    rtbBuildRebuilt.Text,
                    rtbHouseType.Text,
                    rtbEnergyRating.Text,
                    int.Parse(rtbResSquareMeters.Text),
                    int.Parse(rtbPropSquareMeters.Text),
                    int.Parse(rtbFloors.Text),
                    cbSoldFlag.Checked,
                    rtbHouseDescription.Text
                    );

                string[] temp = Path.GetFileName(pbHouseImage.ImageLocation).Split('.');

                string fileName = temp[0];
                string extName = temp[1];

                DataAccessLayerFacade.CreateFile
                    (
                    caseNr,
                    fileName,
                    extName,
                    BusinessLayerFacade.GetPhotoFromPath(pbHouseImage.ImageLocation)
                    );
            }
        }

        private bool AnyBoxIsEmpty()
        {
            if (
                cbSellerId.Text == string.Empty ||
                rtbTimeFrame.Text == string.Empty ||
                rtbHouseType.Text == string.Empty ||
                rtbNetPrice.Text == string.Empty ||
                rtbGrossPrice.Text == string.Empty ||
                rtbOwnerExpences.Text == string.Empty ||
                rtbCashPrice.Text == string.Empty ||
                rtbDepositPrice.Text == string.Empty ||
                rtbAddress.Text == string.Empty ||
                rtbZipCode.Text == string.Empty ||
                rtbFloors.Text == string.Empty ||
                rtbNrOfRooms.Text == string.Empty ||
                rtbResSquareMeters.Text == string.Empty ||
                rtbZipCode.Text == string.Empty ||
                rtbPropSquareMeters.Text == string.Empty ||
                rtbBuildRebuilt.Text == string.Empty ||
                rtbEnergyRating.Text == string.Empty ||
                rtbHouseDescription.Text == string.Empty ||
                pbHouseImage.ImageLocation == null
                )
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        #endregion


    }
}
