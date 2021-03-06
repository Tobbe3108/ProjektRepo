﻿using System;
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
using ClosedXML.Excel;

namespace Bol_IT
{
    public partial class Sag_Edit : UserControl
    {
        #region Properties

        private string NameOfPhoto;
        private string ExtOfPhoto;
        private byte[] Photo;
        private List<Document> Documents; //
        private ImageList ListViewImages = new ImageList();

        #endregion

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

            List<Seller> sellers = DataAccessLayerFacade.GetSellers();
            sellers.ForEach(seller => cbSellerId.Items.Add(seller.SId));

            lvHouseFiles.SmallImageList = ListViewImages;
        }

        #endregion

        #region FormAutoSize

        //Tobias
        private void Sag_Edit_SizeChanged(object sender, EventArgs e)
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
                lblOwnerExpences.Font = new Font(lblOwnerExpences.Font.FontFamily, this.Size.Height / 50);
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
                btnToFile.Font = new Font(btnToFile.Font.FontFamily, this.Size.Height / 60);
                btnCreateAd.Font = new Font(btnCreateAd.Font.FontFamily, this.Size.Height / 60);
                btnDeleteCase.Font = new Font(btnDeleteCase.Font.FontFamily, this.Size.Height / 60);
                btnAddFile.Font = new Font(btnAddFile.Font.FontFamily, this.Size.Height / 50);
                btnShowFile.Font = new Font(btnShowFile.Font.FontFamily, this.Size.Height / 50);
                btnDeleteFile.Font = new Font(btnDeleteFile.Font.FontFamily, this.Size.Height / 50);
                #endregion
                lvHouseFiles.Font = new Font(lvHouseFiles.Font.FontFamily, this.Size.Height / 50);

                TableLayoutPanelCellPosition pos = ((TableLayoutPanel)cbSellerId.Parent).GetCellPosition(cbSellerId);
                int height = (((TableLayoutPanel)cbSellerId.Parent).GetRowHeights()[pos.Row] - cbSellerId.Height) / 2;
                cbSellerId.Margin = new Padding(6, height, 6, height);
            }
            catch { }
        }

        #endregion

        #region Methods

        //Tobias
        public static void LoadData(string id)
        {
            Property property = DataAccessLayerFacade.GetPropertyById(Convert.ToInt32(id));
            WantsToSell wantsToSell = DataAccessLayerFacade.GetSellerInformationByCaseNr(Convert.ToInt32(id));

            Instance.rtbAddress.Text = property.Address;
            Instance.rtbNrOfRooms.Text = property.NrOfRooms.ToString();
            Instance.rtbHouseType.Text = property.HouseType;
            Instance.rtbCashPrice.Text = property.CashPrice.ToString();
            Instance.rtbDepositPrice.Text = property.DepositPrice.ToString();
            Instance.rtbZipCode.Text = property.ZipCode.ToString();
            Instance.rtbEnergyRating.Text = property.EnergyRating.ToString();
            Instance.rtbFloors.Text = property.Floors.ToString();
            Instance.rtbGrossPrice.Text = property.GrossPrice.ToString();
            Instance.rtbHouseDescription.Text = property.Description;
            Instance.rtbResSquareMeters.Text = property.ResSquareMeters.ToString();
            Instance.rtbNetPrice.Text = property.NetPrice.ToString();
            Instance.rtbFloors.Text = property.Floors.ToString();
            Instance.rtbOwnerExpences.Text = property.OwnerExpenses.ToString();
            Instance.rtbBuiltRebuilt.Text = property.BuiltRebuild.ToString();
            Instance.rtbPropSquareMeters.Text = property.PropSquareMeters.ToString();
            Instance.cbGarageFlag.Checked = property.GarageFlag;
            Instance.cbSoldFlag.Checked = property.SoldFlag;
            Instance.rtbCaseNr.Text = property.CaseNr.ToString();
            Instance.cbSellerId.Text = wantsToSell.SId.ToString();
            Instance.rtbDesiredPrice.Text = wantsToSell.DesiredPrice.ToString();
            Instance.rtbTimeFrame.Text = wantsToSell.TimeFrame.ToString();
            byte[] photo = DataAccessLayerFacade.GetPhotoFromCaseNr(int.Parse(id));
            Instance.Photo = photo;
            Instance.pbHouseImage.Image = BusinessLayerFacade.ConvertBinaryArrayToImage(photo);
            Instance.NameOfPhoto = DataAccessLayerFacade.GetPhotoNameFromCaseNrAndPhoto(int.Parse(id), photo);
            Instance.ExtOfPhoto = DataAccessLayerFacade.GetPhotoExtFromName(Instance.NameOfPhoto);

            Instance.Documents = DataAccessLayerFacade.GetDocumentsByCaseNr(int.Parse(id));
            Instance.lvHouseFiles.Clear();
            foreach (Document document in Instance.Documents)
            {
                Instance.lvHouseFiles.Items.Add(Path.ChangeExtension(document.Name, document.Extention));
            }
        }

        private void AddFile()
        {
            if (ofdOpenFile.ShowDialog() == DialogResult.OK)
            {
                //Tilføj information til listview
                Icon fileIcon = Icon.ExtractAssociatedIcon(ofdOpenFile.FileName);
                ListViewImages.Images.Add(fileIcon);
                ListViewItem listViewItem = lvHouseFiles.Items.Add(Path.GetFileName(ofdOpenFile.FileName));
                listViewItem.ImageIndex = ListViewImages.Images.Count - 1;
                //Kopier til temp placering
                BusinessLayerFacade.CopyFile(ofdOpenFile.FileName);
            }
        }
        //Christoffer
        private bool AnyBoxIsEmpty()
        {
            if (rtbTimeFrame.Text == string.Empty)
            { rtbTimeFrame.Text = "0"; }
            if (rtbDesiredPrice.Text == string.Empty)
            { rtbDesiredPrice.Text = "0"; }
            if (rtbCaseNr.Text == string.Empty)
            { rtbCaseNr.Text = "0"; }
            if (rtbNetPrice.Text == string.Empty)
            { rtbNetPrice.Text = "0"; }
            if (rtbGrossPrice.Text == string.Empty)
            { rtbGrossPrice.Text = "0"; }
            if (rtbOwnerExpences.Text == string.Empty)
            { rtbOwnerExpences.Text = "0"; }
            if (rtbCashPrice.Text == string.Empty)
            { rtbCashPrice.Text = "0"; }
            if (rtbDepositPrice.Text == string.Empty)
            { rtbDepositPrice.Text = "0"; }
            if (rtbFloors.Text == string.Empty)
            { rtbFloors.Text = "0"; }
            if (rtbNrOfRooms.Text == string.Empty)
            { rtbNrOfRooms.Text = "0"; }
            if (rtbResSquareMeters.Text == string.Empty)
            { rtbResSquareMeters.Text = "0"; }
            if (rtbZipCode.Text == string.Empty)
            { rtbZipCode.Text = "0"; }
            if (rtbPropSquareMeters.Text == string.Empty)
            { rtbPropSquareMeters.Text = "0"; }
            if (rtbBuiltRebuilt.Text == string.Empty)
            { rtbBuiltRebuilt.Text = "0"; }
            if (rtbHouseDescription.Text == string.Empty)
            { rtbHouseDescription.Text = "Ingen tekst"; }

            if (pbHouseImage.Image == null)
            { }

            if (cbSellerId.Text == string.Empty || rtbAddress.Text == string.Empty)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region Events

        //Tobias
        private void pbHouseImage_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void pbHouseImage_DragDrop(object sender, DragEventArgs e)
        {
            if ((string[])e.Data.GetData(DataFormats.FileDrop) != null)
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
        }

        //Tobias
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ReloadPrievous();
        }

        //Caspar
        //Genindlæser den forrige UserControl, og beder den om at genindlæse den releveante data.
        private static void ReloadPrievous()
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
            if (ofdOpenFile.ShowDialog() == DialogResult.OK)
            {
                pbHouseImage.ImageLocation = ofdOpenFile.FileName;
                Image image = Image.FromFile(ofdOpenFile.FileName);
                pbHouseImage.Image = image;
            }
        }



        //Christoffer og Tobias
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (AnyBoxIsEmpty())
            {
                MessageBox.Show($"Fejl i indtastning. Du har ikke udfyldt alle felter. Prøv igen..", "Fejl!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CheckForDuplicateFiles())
            {
                MessageBox.Show($"Der må ikke være dubletter af et dokument. Sørg for at alle filer er unikke og prøv igen.", "Fejl!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (DataAccessLayerFacade.CheckForSQLInjection(
                    rtbCaseNr.Text,
                    cbSellerId.Text,
                    rtbDesiredPrice.Text,
                    rtbTimeFrame.Text,
                    rtbNetPrice.Text,
                    rtbGrossPrice.Text,
                    rtbOwnerExpences.Text,
                    rtbCashPrice.Text,
                    rtbDepositPrice.Text,
                    rtbAddress.Text,
                    rtbZipCode.Text,
                    rtbNrOfRooms.Text,
                    rtbBuiltRebuilt.Text,
                    rtbHouseType.Text,
                    rtbEnergyRating.Text,
                    rtbResSquareMeters.Text,
                    rtbPropSquareMeters.Text,
                    rtbFloors.Text,
                    rtbHouseDescription.Text
                    ))
                {
                    return;
                }
                DataAccessLayerFacade.UpdateProperty
                    (
                    int.Parse(rtbCaseNr.Text),
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

                string photoName;
                string photoExtName;
                byte[] photo;
                if (pbHouseImage.ImageLocation == null)
                {
                    photoName = NameOfPhoto;
                    photoExtName = ExtOfPhoto;
                    photo = Photo;
                }
                else
                {
                    photoName = Path.GetFileNameWithoutExtension(pbHouseImage.ImageLocation);
                    photoExtName = Path.GetExtension(pbHouseImage.ImageLocation).Replace(".", "");
                    photo = BusinessLayerFacade.GetFileFromPath(pbHouseImage.ImageLocation);
                }


                DataAccessLayerFacade.UpdatePhoto
                    (
                    NameOfPhoto,
                    int.Parse(rtbCaseNr.Text),
                    photoName,
                    photoExtName,
                    photo
                    );


                // Hvis der mangler et dokument i listview, slettes det fra databasen
                foreach (Document document in Documents)
                {
                    if (!ListViewContainsDocument(document))
                    {
                        DataAccessLayerFacade.RemoveFiles(document.Name);
                    }
                }


                foreach (ListViewItem item in lvHouseFiles.Items)
                {
                    string originalFileName = null;
                    string fileName = Path.GetFileNameWithoutExtension(item.Text);
                    string extName = Path.GetExtension(item.Text);
                    byte[] data = File.ReadAllBytes(Path.GetTempPath() + item.Text);

                    //Kontrollerer om dokumentet eksisterer i databasen på forhånd

                    Document matchingDocument = Documents.Find(document => Path.ChangeExtension(document.Name, document.Extention) == item.Text);
                    if (matchingDocument != null)
                    {
                        originalFileName = matchingDocument.Name;
                    }

                    DataAccessLayerFacade.UpdateFiles
                        (
                        originalFileName,
                        int.Parse(rtbCaseNr.Text),
                        fileName,
                        extName,
                        data
                        );
                }

                MessageBox.Show("Bolig er gemt.");

                //Load Sag_ViewAll User control når tryk på knap
                if (!Form1.Instance.PnlContainer.Controls.ContainsKey("Sag_ViewAll"))
                {
                    Sag_ViewAll.Instance.Dock = DockStyle.Fill;
                    Form1.Instance.PnlContainer.Controls.Add(Sag_ViewAll.Instance);
                }
                Form1.Instance.PnlContainer.Controls["Sag_ViewAll"].BringToFront();
                Sag_ViewAll.Instance.StartDataLoad();
            }
        }

        /// <summary>
        /// Tjekker om der er filer der har samme navn, da navnet jo er primary key i databasen
        /// </summary>
        /// <returns></returns>
        private bool CheckForDuplicateFiles()
        {
            foreach (ListViewItem item in lvHouseFiles.Items)
            {
                foreach (ListViewItem itemCheck in lvHouseFiles.Items)
                {
                    //Sørger for ikke at sammenligne sig med sig selv
                    if (item == itemCheck)
                    {
                        continue;
                    }
                    if (item.Text == itemCheck.Text)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool ListViewContainsDocument(Document document)
        {
            foreach (ListViewItem item in lvHouseFiles.Items)
            {
                if (item.Text == Path.ChangeExtension(document.Name, document.Extention))
                {
                    return true;
                }
            }
            return false;
        }

        

        //Tobias
        private void btnToFile_Click(object sender, EventArgs e)
        {
            List<string> propInfoList = new List<string>
            {
                { rtbAddress.Text },
                { rtbHouseType.Text },
                { rtbResSquareMeters.Text },
                { rtbPropSquareMeters.Text },
                { rtbBuiltRebuilt.Text },
                { rtbNrOfRooms.Text },
                { rtbFloors.Text },
                { cbGarageFlag.Checked.ToString()},
                { rtbEnergyRating.Text },
                { rtbZipCode.Text },
                { rtbCaseNr.Text },
                { cbSoldFlag.Checked.ToString() },
                { cbSellerId.Text },
                { rtbDesiredPrice.Text },
                { rtbTimeFrame.Text },
                { rtbGrossPrice.Text },
                { rtbNetPrice.Text },
                { rtbOwnerExpences.Text },
                { rtbDepositPrice.Text },
                { rtbCashPrice.Text },
                { rtbHouseDescription.Text },
            };

            List<string> headersList = new List<string>
            {
                { lblAddress.Text },
                { lblHouseType.Text },
                { lblResSquareMeters.Text },
                { lblPropSquareMeters.Text },
                { lblBuiltRebuilt.Text },
                { lblNrOfRooms.Text },
                { lblFloors.Text },
                { lblGarageFlag.Text },
                { lblEnergyRating.Text },
                { lblZipCode.Text },
                { lblCaseNr.Text },
                { lblSoldFlag.Text },
                { lblSeller.Text },
                { lblDesiredPrice.Text },
                { lblTimeFrame.Text },
                { lblGrossPrice.Text },
                { lblNetPrice.Text },
                { lblOwnerExpences.Text },
                { lblDepositPrice.Text },
                { lblCashPrice.Text },
                { "Beskrivelse" },
            };



            //Laver en save dialog hvor brugeren kan vælge hvor filen skal gemmes
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                InitialDirectory = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}",
                Title = "Gem til fil",
                DefaultExt = "txt",
                Filter = "Tekst fil (*.txt)|*.txt|Excel (*.xlsx)|*.xlsx",
                FilterIndex = 1,
                CheckFileExists = false,
                CheckPathExists = true,
                RestoreDirectory = true
            };



            if (saveFileDialog.ShowDialog() == DialogResult.OK) //Hvis det lykkedes for brugeren at vælge et sted at gemme filen
            {
                //Hent extensionen af filen Fx .txt
                var extension = Path.GetExtension(saveFileDialog.FileName);

                switch (extension.ToLower()) //Tjekker hvilken filtype du har gemt i
                {
                    case ".txt":
                        //Åbner filen brugeren oprettede
                        StreamWriter writer = new StreamWriter(saveFileDialog.OpenFile());
                        List<string> list = new List<string>();

                        string lines = "";
                        foreach (var item in propInfoList)
                        {
                            lines += $"{item},";
                        }
                        writer.WriteLine(lines);
                        writer.Dispose();
                        writer.Close();

                        break;



                    case ".xlsx":
                        //Konverter 2 lists til 1 datatable
                        DataTable dataTable = new DataTable();
                        foreach (var col in headersList)
                        {
                            dataTable.Columns.Add(col);
                        }

                        object[] values = new object[propInfoList.Count];
                        for (int i = 0; i <= values.Length - 1; i++)
                        {
                            values[i] = propInfoList[i];
                        }
                        dataTable.Rows.Add(values);

                        var wb = new XLWorkbook(); //Laver en ny XLWorkbook som kommer fra en NuGet package der hedder closedXML man kan benytte til at oprette Excel dokumenter
                        wb.Worksheets.Add(dataTable, "Udskrift"); //Opretter et nyt worksheet på baggrund af det oprettede datatable
                        wb.SaveAs(Path.GetFullPath(saveFileDialog.FileName)); //Gemmer den oprettede XLWorkbook til filen som brugeren oprettede via savedialog
                        break;



                    default:
                        //Hvis det ikke er muligt at gemme vis fejlbesked til brugeren
                        MessageBox.Show($"Det var ikke muligt at gemme filen: {saveFileDialog.FileName} Prøv igen.", "Fejl!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }

            }
        }

        //Tobias
        private void btnCreateAd_Click(object sender, EventArgs e)
        {
            //Klar til at implementere API fra annonce sider
        }
        
        //Christoffer
        private void lvHouseFiles_DoubleClick(object sender, EventArgs e)
        {
            if (lvHouseFiles.Items.Count == 0)
            {
                return;
            }
            BusinessLayerFacade.ShowFile(lvHouseFiles.SelectedItems[0].Text);
        }
        private void btnShowFile_Click(object sender, EventArgs e)
        {
            if (lvHouseFiles.Items.Count == 0)
            {
                return;
            }
            BusinessLayerFacade.ShowFile(lvHouseFiles.SelectedItems[0].Text);
        }
        private void btnAddFile_Click(object sender, EventArgs e)
        {
            AddFile();
        }
        private void btnDeleteFile_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvHouseFiles.SelectedItems)
            {
                lvHouseFiles.Items.Remove(item);
            }
        }

        //Caspar
        //Sletter en ejendom fra databasen ved tryk på Slet knappen.
        private void btnDeleteCase_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Sagen bliver slettet for evigt. Ønsker du at fortsætte?", "Slet sag.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                {
                    return;
                }
                else
                {
                    int.TryParse(rtbCaseNr.Text, out int caseNr);
                    DataAccessLayerFacade.DeleteProperty(caseNr);
                    ReloadPrievous();

                }

            }
            catch (Exception exception)
            {
                MessageBox.Show($"Der skete en uventet fejl under sletning af sagen. Fejlbesked: {exception}.", "Fejl.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
