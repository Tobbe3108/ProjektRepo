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
            lblCashPrice.Font = new Font(lblCashPrice.Font.FontFamily, this.Size.Height / 50);
            btnCreateAd.Font = new Font(btnCreateAd.Font.FontFamily, this.Size.Height / 50);
            btnCancel.Font = new Font(btnCancel.Font.FontFamily, this.Size.Height / 50);
            btnSave.Font = new Font(btnSave.Font.FontFamily, this.Size.Height / 50);
            btnToFile.Font = new Font(btnToFile.Font.FontFamily, this.Size.Height / 50);
            rtbAddress.Font = new Font(rtbAddress.Font.FontFamily, this.Size.Height / 30);
            rtbHouseDescription.Font = new Font(rtbHouseDescription.Font.FontFamily, this.Size.Height / 50);
            rtbCashPrice.Font = new Font(rtbCashPrice.Font.FontFamily, this.Size.Height / 50);
            lblBuiltRebuilt.Font = new Font(lblBuiltRebuilt.Font.FontFamily, this.Size.Height / 50);
            lblCaseNr.Font = new Font(lblCaseNr.Font.FontFamily, this.Size.Height / 50);
            lblDepositPrice.Font = new Font(lblDepositPrice.Font.FontFamily, this.Size.Height / 50);
            lblEnergyRating.Font = new Font(lblEnergyRating.Font.FontFamily, this.Size.Height / 50);
            lblFloors.Font = new Font(lblFloors.Font.FontFamily, this.Size.Height / 50);
            lblGarageFlag.Font = new Font(lblGarageFlag.Font.FontFamily, this.Size.Height / 50);
            lblGrossPrice.Font = new Font(lblGrossPrice.Font.FontFamily, this.Size.Height / 50);
            lblHouseType.Font = new Font(lblHouseType.Font.FontFamily, this.Size.Height / 50);
            lblNetPrice.Font = new Font(lblNetPrice.Font.FontFamily, this.Size.Height / 50);
            lblNrOfRooms.Font = new Font(lblNrOfRooms.Font.FontFamily, this.Size.Height / 50);
            lblOwnerExpences.Font = new Font(lblOwnerExpences.Font.FontFamily, this.Size.Height / 50);
            lblPropSquareMeters.Font = new Font(lblPropSquareMeters.Font.FontFamily, this.Size.Height / 50);
            lblResSquareMeters.Font = new Font(lblResSquareMeters.Font.FontFamily, this.Size.Height / 50);
            lblSoldFlag.Font = new Font(lblSoldFlag.Font.FontFamily, this.Size.Height / 50);
            lblZipCode.Font = new Font(lblZipCode.Font.FontFamily, this.Size.Height / 50);
            cbGarageFlag.Font = new Font(cbGarageFlag.Font.FontFamily, this.Size.Height / 50);
            cbSoldFlag.Font = new Font(cbSoldFlag.Font.FontFamily, this.Size.Height / 50);
            rtbZipCode.Font = new Font(rtbZipCode.Font.FontFamily, this.Size.Height / 50);
            rtbResSquareMeters.Font = new Font(rtbResSquareMeters.Font.FontFamily, this.Size.Height / 50);
            rtbPropSquareMeters.Font = new Font(rtbPropSquareMeters.Font.FontFamily, this.Size.Height / 50);
            rtbOwnerExpences.Font = new Font(rtbOwnerExpences.Font.FontFamily, this.Size.Height / 50);
            rtbNrOfRooms.Font = new Font(rtbNrOfRooms.Font.FontFamily, this.Size.Height / 50);
            rtbNetPrice.Font = new Font(rtbNetPrice.Font.FontFamily, this.Size.Height / 50);
            rtbHouseType.Font = new Font(rtbHouseType.Font.FontFamily, this.Size.Height / 50);
            rtbHouseDescription.Font = new Font(rtbHouseDescription.Font.FontFamily, this.Size.Height / 50);
            rtbGrossPrice.Font = new Font(rtbGrossPrice.Font.FontFamily, this.Size.Height / 50);
            rtbFloors.Font = new Font(rtbFloors.Font.FontFamily, this.Size.Height / 50);
            rtbEnergyRating.Font = new Font(rtbEnergyRating.Font.FontFamily, this.Size.Height / 50);
            rtbDepositPrice.Font = new Font(rtbDepositPrice.Font.FontFamily, this.Size.Height / 50);
            rtbCaseNr.Font = new Font(rtbCaseNr.Font.FontFamily, this.Size.Height / 50);
            rtbBuiltRebuilt.Font = new Font(rtbBuiltRebuilt.Font.FontFamily, this.Size.Height / 50);
        }

        #endregion

        #region Methods

        public static void LoadData(string id)
        {
            Property property = DataAccessLayerFacade.GetProperty(Convert.ToInt32(id));

            Instance.rtbAddress.Text = property.Address;
            Instance.rtbBuiltRebuilt.Text = property.BuiltRebuild;
            Instance.rtbCaseNr.Text = property.CaseNr.ToString();
            Instance.rtbCashPrice.Text = property.CashPrice.ToString();
            Instance.rtbDepositPrice.Text = property.DepositPrice.ToString();
            Instance.rtbEnergyRating.Text = property.EnergyRating.ToString();
            Instance.rtbFloors.Text = property.Floors.ToString();
            Instance.rtbGrossPrice.Text = property.GrossPrice.ToString();
            Instance.rtbHouseDescription.Text = property.Description;
            Instance.rtbHouseType.Text = property.HouseType;
            Instance.rtbNetPrice.Text = property.NetPrice.ToString();
            Instance.rtbNrOfRooms.Text = property.NrOfRooms.ToString();
            Instance.rtbOwnerExpences.Text = property.OwnerExpenses.ToString();
            Instance.rtbPropSquareMeters.Text = property.PropSquareMeters.ToString();
            Instance.rtbResSquareMeters.Text = property.ResSquareMeters.ToString();
            Instance.rtbZipCode.Text = property.ZipCode.ToString();
            Instance.cbGarageFlag.Checked = property.GarageFlag;
            Instance.cbSoldFlag.Checked = property.SoldFlag;
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
