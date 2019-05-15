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
using System.Threading;
using ClosedXML.Excel;
using System.IO;
using GlobalClasses;

namespace Bol_IT
{
    public partial class Person_Create : UserControl
    {
        #region Fields

        public string TypeChange { get; set; }

        public int id { get; set; }

        #endregion

        #region Init

        //Tobias
        //Singleton instance af Sag_Create
        static Person_Create _instance;
        public static Person_Create Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Person_Create();
                }
                return _instance;
            }
        }

        public Person_Create()
        {
            InitializeComponent();
        }

        #endregion

        #region FormAutoSize

        //Tobias
        private void Person_Create_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                lblAddress.Font = new Font(lblAddress.Font.FontFamily, this.Size.Height / 50);
                lblFName.Font = new Font(lblFName.Font.FontFamily, this.Size.Height / 50);
                lblLName.Font = new Font(lblLName.Font.FontFamily, this.Size.Height / 50);
                lblMail.Font = new Font(lblMail.Font.FontFamily, this.Size.Height / 50);
                lblMName.Font = new Font(lblMName.Font.FontFamily, this.Size.Height / 50);
                lblPhoneNr.Font = new Font(lblPhoneNr.Font.FontFamily, this.Size.Height / 50);
                lblType.Font = new Font(lblType.Font.FontFamily, this.Size.Height / 50);
                lblTypeChainging.Font = new Font(lblTypeChainging.Font.FontFamily, this.Size.Height / 50);
                lblZipcode.Font = new Font(lblZipcode.Font.FontFamily, this.Size.Height / 50);
                btnCancel.Font = new Font(btnCancel.Font.FontFamily, this.Size.Height / 50);
                btnSave.Font = new Font(btnSave.Font.FontFamily, this.Size.Height / 50);
                btnSaveToFile.Font = new Font(btnSaveToFile.Font.FontFamily, this.Size.Height / 50);

                rtbAddress.Font = new Font(rtbAddress.Font.FontFamily, this.Size.Height / 50);
                rtbFName.Font = new Font(rtbFName.Font.FontFamily, this.Size.Height / 50);
                rtbLName.Font = new Font(rtbLName.Font.FontFamily, this.Size.Height / 50);
                rtbMail.Font = new Font(rtbMail.Font.FontFamily, this.Size.Height / 50);
                rtbMName.Font = new Font(rtbMName.Font.FontFamily, this.Size.Height / 50);
                rtbPhoneNr.Font = new Font(rtbPhoneNr.Font.FontFamily, this.Size.Height / 50);
                rtbTypeChainging.Font = new Font(rtbTypeChainging.Font.FontFamily, this.Size.Height / 50);
                rtbZipcode.Font = new Font(rtbZipcode.Font.FontFamily, this.Size.Height / 50);
            }
            catch{}
        }

        #endregion

        #region Methods

        private bool Sanitizer()
        {
            if (DataAccessLayerFacade.CheckForSQLInjection(rtbFName.Text, rtbMName.Text, rtbLName.Text, rtbPhoneNr.Text, rtbAddress.Text, rtbZipcode.Text, rtbMail.Text, rtbTypeChainging.Text))
            {
                MessageBox.Show("Felterne må ikke indeholde ';' Ret venligst dette", "Felj!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (rtbAddress.Text == string.Empty || rtbFName.Text == string.Empty || rtbLName.Text == string.Empty || rtbMail.Text == string.Empty || rtbMName.Text == string.Empty || rtbPhoneNr.Text == string.Empty || rtbTypeChainging.Text == string.Empty || rtbZipcode.Text == string.Empty)
            {
                MessageBox.Show("Der må ikke være nogle tomme felter. Ret vejligt dette", "Felj!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!rtbMail.Text.ToString().Contains('@') || !rtbMail.Text.ToString().Contains('.'))
            {
                MessageBox.Show("Mailadressen skal indeholde '@' og '.' Ret venligt dette", "Felj!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (rtbZipcode.Text.Length != 4 || !rtbZipcode.Text.All(char.IsDigit))
            {
                MessageBox.Show("Postnummeret skal bestå af 4 tal. Ret venligst dette", "Felj!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (rtbPhoneNr.Text.Length != 8 || !rtbPhoneNr.Text.All(char.IsDigit))
            {
                MessageBox.Show("Telefonnummeret skal bestå af 8 tal. Ret venligst dette", "Felj!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!rtbTypeChainging.Text.All(char.IsDigit))
            {
                switch (cbType.SelectedIndex)
                {
                    case 0:
                        MessageBox.Show("Antal salg skal være et tal. Ret venligst dette", "Felj!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 1:
                    case 2:
                        MessageBox.Show("Mægler nummer skal være et tal. Ret venligst dette", "Felj!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
                return false;
            }

            return true;
        }

        private void LoadData()
        {
            switch (DataAccessLayerFacade.GetPersonTypeById(id))
            {
                case "Mægler":
                    Agent agent = DataAccessLayerFacade.GetAgentById(id);
                    cbType.Invoke((MethodInvoker)delegate { cbType.SelectedIndex = 0; });
                    rtbAddress.Invoke((MethodInvoker)delegate { rtbAddress.Text = agent.Address; });
                    rtbFName.Invoke((MethodInvoker)delegate { rtbFName.Text = agent.FName; });
                    rtbLName.Invoke((MethodInvoker)delegate { rtbLName.Text = agent.LName; });
                    rtbMail.Invoke((MethodInvoker)delegate { rtbMail.Text = agent.Mail; });
                    rtbMName.Invoke((MethodInvoker)delegate { rtbMName.Text = agent.MName; });
                    rtbPhoneNr.Invoke((MethodInvoker)delegate { rtbPhoneNr.Text = agent.PhoneNr.ToString(); });
                    rtbTypeChainging.Invoke((MethodInvoker)delegate { rtbTypeChainging.Text = agent.NrOfSales.ToString(); });
                    rtbZipcode.Invoke((MethodInvoker)delegate { rtbZipcode.Text = agent.Zipcode.ToString(); });
                    break;



                case "Sælger":
                    Seller seller = DataAccessLayerFacade.GetSellerById(id);
                    cbType.Invoke((MethodInvoker)delegate { cbType.SelectedIndex = 1; });
                    rtbAddress.Invoke((MethodInvoker)delegate { rtbAddress.Text = seller.Address; });
                    rtbFName.Invoke((MethodInvoker)delegate { rtbFName.Text = seller.FName; });
                    rtbLName.Invoke((MethodInvoker)delegate { rtbLName.Text = seller.LName; });
                    rtbMail.Invoke((MethodInvoker)delegate { rtbMail.Text = seller.Mail; });
                    rtbMName.Invoke((MethodInvoker)delegate { rtbMName.Text = seller.MName; });
                    rtbPhoneNr.Invoke((MethodInvoker)delegate { rtbPhoneNr.Text = seller.PhoneNr.ToString(); });
                    rtbTypeChainging.Invoke((MethodInvoker)delegate { rtbTypeChainging.Text = seller.AId.ToString(); });
                    rtbZipcode.Invoke((MethodInvoker)delegate { rtbZipcode.Text = seller.Zipcode.ToString(); });
                    break;



                case "Køber":
                    Buyer buyer = DataAccessLayerFacade.GetBuyerById(id);
                    cbType.Invoke((MethodInvoker)delegate { cbType.SelectedIndex = 2; });
                    rtbAddress.Invoke((MethodInvoker)delegate { rtbAddress.Text = buyer.Address; });
                    rtbFName.Invoke((MethodInvoker)delegate { rtbFName.Text = buyer.FName; });
                    rtbLName.Invoke((MethodInvoker)delegate { rtbLName.Text = buyer.LName; });
                    rtbMail.Invoke((MethodInvoker)delegate { rtbMail.Text = buyer.Mail; });
                    rtbMName.Invoke((MethodInvoker)delegate { rtbMName.Text = buyer.MName; });
                    rtbPhoneNr.Invoke((MethodInvoker)delegate { rtbPhoneNr.Text = buyer.PhoneNr.ToString(); });
                    rtbTypeChainging.Invoke((MethodInvoker)delegate { rtbTypeChainging.Text = buyer.AId.ToString(); });
                    rtbZipcode.Invoke((MethodInvoker)delegate { rtbZipcode.Text = buyer.Zipcode.ToString(); });
                    break;
            }
        }

        public void StartLoadData()
        {
            Thread LoadDataThread = new Thread(() => LoadData());
            LoadDataThread.IsBackground = true;
            LoadDataThread.Start();
        }

        #endregion

        #region Events

        private void btnSaveToFile_Click(object sender, EventArgs e)
        {
            if (Sanitizer())
            {
                List<string> propInfoList = new List<string>
                {
                    { rtbFName.Text },
                    { rtbMName.Text },
                    { rtbLName.Text },
                    { rtbAddress.Text },
                    { rtbZipcode.Text },
                    { rtbPhoneNr.Text },
                    { rtbMail.Text },
                    { rtbTypeChainging.Text },
                };

                List<string> headersList = new List<string>
                {
                    { lblFName.Text },
                    { lblMName.Text },
                    { lblLName.Text },
                    { lblAddress.Text },
                    { lblZipcode.Text },
                    { lblPhoneNr.Text },
                    { lblMail.Text },
                    { cbType.SelectedItem.ToString() },
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
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Load Person_ViewAll User control når tryk på knap
            if (!Form1.Instance.PnlContainer.Controls.ContainsKey("Person_ViewAll"))
            {
                Person_ViewAll.Instance.Dock = DockStyle.Fill;
                Form1.Instance.PnlContainer.Controls.Add(Person_ViewAll.Instance);
            }
            Form1.Instance.PnlContainer.Controls["Person_ViewAll"].BringToFront();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Sanitizer())
            {
                if (TypeChange == "Create")
                {
                    try
                    {
                        switch (cbType.SelectedIndex)
                        {
                            case 0:
                                DataAccessLayerFacade.CreateAgent(rtbFName.Text, rtbMName.Text, rtbLName.Text, Convert.ToInt32(rtbPhoneNr.Text), rtbAddress.Text, Convert.ToInt32(rtbZipcode.Text), rtbMail.Text, Convert.ToInt32(rtbTypeChainging.Text));
                                break;
                            case 1:
                                DataAccessLayerFacade.CreateSeller(rtbFName.Text, rtbMName.Text, rtbLName.Text, Convert.ToInt32(rtbPhoneNr.Text), rtbAddress.Text, Convert.ToInt32(rtbZipcode.Text), rtbMail.Text, Convert.ToInt32(rtbTypeChainging.Text));
                                break;
                            case 2:
                                DataAccessLayerFacade.CreateBuyer(rtbFName.Text, rtbMName.Text, rtbLName.Text, Convert.ToInt32(rtbPhoneNr.Text), rtbAddress.Text, Convert.ToInt32(rtbZipcode.Text), rtbMail.Text, Convert.ToInt32(rtbTypeChainging.Text));
                                break;
                        }

                        MessageBox.Show("Det lykkedes at oprette personen på databasen");
                    }
                    catch
                    {
                        MessageBox.Show("Der skete en fejl med at oprette personen på databasen. Prøv igen", "Felj!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (TypeChange == "Update")
                {
                    try
                    {
                        switch (cbType.SelectedIndex)
                        {
                            case 0:
                                DataAccessLayerFacade.AgentUpdateData(id, rtbFName.Text, rtbMName.Text, rtbLName.Text, Convert.ToInt32(rtbPhoneNr.Text), rtbAddress.Text, Convert.ToInt32(rtbZipcode.Text), rtbMail.Text, Convert.ToInt32(rtbTypeChainging.Text));
                                break;
                            case 1:
                                DataAccessLayerFacade.SellerUpdateData(id, rtbFName.Text, rtbMName.Text, rtbLName.Text, Convert.ToInt32(rtbPhoneNr.Text), rtbAddress.Text, Convert.ToInt32(rtbZipcode.Text), rtbMail.Text, Convert.ToInt32(rtbTypeChainging.Text));
                                break;
                            case 2:
                                DataAccessLayerFacade.BuyerUpdateData(id, rtbFName.Text, rtbMName.Text, rtbLName.Text, Convert.ToInt32(rtbPhoneNr.Text), rtbAddress.Text, Convert.ToInt32(rtbZipcode.Text), rtbMail.Text, Convert.ToInt32(rtbTypeChainging.Text));
                                break;
                        }

                        MessageBox.Show("Det lykkedes at opdatere personen på databasen");
                    }
                    catch
                    {
                        MessageBox.Show("Det lykkedes ikke at opdatere personnen på databasen. Prøv igen", "Felj!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbType.SelectedIndex)
            {
                case 0:
                    lblTypeChainging.Text = "Antal salg";
                    break;
                case 1:
                case 2:
                    lblTypeChainging.Text = "Mægler nummer";
                    break;
            }
        }

        private void CheckKeyPressChar(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void CheckKeyPressDigit(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void CheckKeyPressDigitOrChar(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        #endregion
    }
}
