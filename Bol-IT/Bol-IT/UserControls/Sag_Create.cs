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
                #region Labels
                lblAddress.Font = new Font(lblAddress.Font.FontFamily, this.Size.Height / 25);
                lblCashPrice.Font = new Font(lblCashPrice.Font.FontFamily, this.Size.Height / 50);
                lblNrOfRooms.Font = new Font(lblNrOfRooms.Font.FontFamily, this.Size.Height / 50);
                lblHouseType.Font = new Font(lblHouseType.Font.FontFamily, this.Size.Height / 50);
                lblDepositPrice.Font = new Font(lblDepositPrice.Font.FontFamily, this.Size.Height / 50);
                lblZipCode.Font = new Font(lblZipCode.Font.FontFamily, this.Size.Height / 50);
                lblGarageFlag.Font = new Font(lblGarageFlag.Font.FontFamily, this.Size.Height / 50);
                lblEnergyRating.Font = new Font(lblEnergyRating.Font.FontFamily, this.Size.Height / 50);
                lblGrossPrice.Font = new Font(lblGrossPrice.Font.FontFamily, this.Size.Height / 50);
                lblResSquareMeters.Font = new Font(lblResSquareMeters.Font.FontFamily, this.Size.Height / 50);
                lblNetPrice.Font = new Font(lblNetPrice.Font.FontFamily, this.Size.Height / 50);
                lblFloors.Font = new Font(lblFloors.Font.FontFamily, this.Size.Height / 50);
                lblOwnerExpense.Font = new Font(lblOwnerExpense.Font.FontFamily, this.Size.Height / 50);
                lblBuiltRebuilt.Font = new Font(lblBuiltRebuilt.Font.FontFamily, this.Size.Height / 50);
                lblPropSquareMeters.Font = new Font(lblPropSquareMeters.Font.FontFamily, this.Size.Height / 50);
                lblSeller.Font = new Font(lblSeller.Font.FontFamily, this.Size.Height / 50);
                lblSoldFlag.Font = new Font(lblSoldFlag.Font.FontFamily, this.Size.Height / 50);
                lblCaseNr.Font = new Font(lblCaseNr.Font.FontFamily, this.Size.Height / 50);
                lblDesiredPrice.Font = new Font(lblDesiredPrice.Font.FontFamily, this.Size.Height / 50);
                lblTimeFrame.Font = new Font(lblTimeFrame.Font.FontFamily, this.Size.Height / 50);
                #endregion
                #region Textboxes
                rtbDesiredPrice.Font = new Font(rtbDesiredPrice.Font.FontFamily, this.Size.Height / 50);
                rtbPropSquareMeters.Font = new Font(rtbPropSquareMeters.Font.FontFamily, this.Size.Height / 50);
                rtbBuiltRebuilt.Font = new Font(rtbBuiltRebuilt.Font.FontFamily, this.Size.Height / 50);
                rtbOwnerExpences.Font = new Font(rtbOwnerExpences.Font.FontFamily, this.Size.Height / 50);
                rtbFloors.Font = new Font(rtbFloors.Font.FontFamily, this.Size.Height / 50);
                rtbNetPrice.Font = new Font(rtbNetPrice.Font.FontFamily, this.Size.Height / 50);
                rtbResSquareMeters.Font = new Font(rtbResSquareMeters.Font.FontFamily, this.Size.Height / 50);
                rtbHouseDescription.Font = new Font(rtbHouseDescription.Font.FontFamily, this.Size.Height / 50);
                rtbGrossPrice.Font = new Font(rtbGrossPrice.Font.FontFamily, this.Size.Height / 50);
                rtbFloors.Font = new Font(rtbFloors.Font.FontFamily, this.Size.Height / 50);
                rtbZipCode.Font = new Font(rtbZipCode.Font.FontFamily, this.Size.Height / 50);
                rtbDepositPrice.Font = new Font(rtbDepositPrice.Font.FontFamily, this.Size.Height / 50);
                rtbHouseType.Font = new Font(rtbHouseType.Font.FontFamily, this.Size.Height / 50);
                rtbNrOfRooms.Font = new Font(rtbNrOfRooms.Font.FontFamily, this.Size.Height / 50);
                rtbAddress.Font = new Font(rtbAddress.Font.FontFamily, this.Size.Height / 30);
                rtbHouseDescription.Font = new Font(rtbHouseDescription.Font.FontFamily, this.Size.Height / 50);
                rtbCashPrice.Font = new Font(rtbCashPrice.Font.FontFamily, this.Size.Height / 50);
                rtbEnergyRating.Font = new Font(rtbEnergyRating.Font.FontFamily, this.Size.Height / 50);
                rtbTimeFrame.Font = new Font(rtbTimeFrame.Font.FontFamily, this.Size.Height / 50);
                rtbCaseNr.Font = new Font(rtbCaseNr.Font.FontFamily, this.Size.Height / 50);
                cbSellerId.Font = new Font(cbSellerId.Font.FontFamily, this.Size.Height / 50);
                #endregion
                #region CheckBoxes
                cbSoldFlag.Font = new Font(cbSoldFlag.Font.FontFamily, this.Size.Height / 50);
                cbGarageFlag.Font = new Font(cbGarageFlag.Font.FontFamily, this.Size.Height / 50);
                #endregion
                #region Buttons
                btnCancel.Font = new Font(btnCancel.Font.FontFamily, this.Size.Height / 50);
                btnSave.Font = new Font(btnSave.Font.FontFamily, this.Size.Height / 50);
                btnCalculatePrice.Font = new Font(btnCalculatePrice.Font.FontFamily, this.Size.Height / 50);
                btnCancel.Font = new Font(btnCancel.Font.FontFamily, this.Size.Height / 50);
                btnSave.Font = new Font(btnSave.Font.FontFamily, this.Size.Height / 50);
                #endregion
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
            Sag_ViewAll.Instance.StartDataLoad();
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
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    var path = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
                    pbHouseImage.ImageLocation = (string)path;
                }
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

        private void pbHouseImage_Click(object sender, EventArgs e)
        {
            if (ofdOpenPicture.ShowDialog() == DialogResult.OK)
            {
                Image image = Image.FromFile(ofdOpenPicture.FileName);
                pbHouseImage.Image = image;
                pbHouseImage.ImageLocation = ofdOpenPicture.FileName;
            }
        }

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
                    rtbBuiltRebuilt.Text,
                    rtbHouseType.Text,
                    rtbEnergyRating.Text,
                    int.Parse(rtbResSquareMeters.Text),
                    int.Parse(rtbPropSquareMeters.Text),
                    int.Parse(rtbFloors.Text),
                    cbSoldFlag.Checked,
                    rtbHouseDescription.Text
                    );

                

                    
                string fileName = Path.GetFileNameWithoutExtension(pbHouseImage.ImageLocation);
                string extName = Path.GetExtension(pbHouseImage.ImageLocation).Replace(".", "");

                DataAccessLayerFacade.CreateFile
                    (
                    caseNr,
                    fileName,
                    extName,
                    BusinessLayerFacade.GetPhotoFromPath(pbHouseImage.ImageLocation)
                    );
                MessageBox.Show("Bolig er gemt.");
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
                rtbBuiltRebuilt.Text == string.Empty ||
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

        //Simone
        public void UpdatePrice(int grossPrice, int netPrice, int ownerExpences, int depositPrice, int cashPrice)
        {
            Instance.rtbGrossPrice.Text = grossPrice.ToString();
            Instance.rtbNetPrice.Text = netPrice.ToString();
            Instance.rtbOwnerExpences.Text = ownerExpences.ToString();
            Instance.rtbDepositPrice.Text = depositPrice.ToString();
            Instance.rtbCashPrice.Text = cashPrice.ToString();

        }

        private bool PropSquareMetersEmpty()
        {
            if (rtbPropSquareMeters.Text == string.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnCalculatePrice_Click(object sender, EventArgs e)
        {
            if (PropSquareMetersEmpty())
            {
                MessageBox.Show("Der er ikke indtastet et grundareal, indtast grundareal og prøv igen.", "Felj!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Messagebox_PriceCalculator priceCalculator = new Messagebox_PriceCalculator();
            priceCalculator.Show();
            priceCalculator.LoadData(int.Parse(rtbPropSquareMeters.Text));


        }

        #endregion
    }
}
