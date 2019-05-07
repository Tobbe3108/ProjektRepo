﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using DataAccessLayer;
using GlobalClasses;

namespace Bol_IT
{
    public partial class Sag_ViewAll : UserControl
    {
        #region Init
        //Tobias
        //Singleton i
        static Sag_ViewAll _instance;
        public static Sag_ViewAll Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Sag_ViewAll();
                }
                return _instance;
            }
        }

        private Sag_ViewAll()
        {
            InitializeComponent();

            //Form autosize
            Sag_ViewAll_SizeChanged(this, new EventArgs());
        }

        private void Sag_ViewAll_Load(object sender, EventArgs e)
        {
            //Eager initialization af singleton instance
            _instance = this;

            rtbSearch_TextChanged(null, null);
        }

        #endregion

        #region FormAutoSize
        
        //Tobias
        private void Sag_ViewAll_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                btnCreateSag.Font = new Font(btnCreateSag.Font.FontFamily, this.Size.Height / 50);
                btnToFile.Font = new Font(btnToFile.Font.FontFamily, this.Size.Height / 50);
                btnStatistic.Font = new Font(btnStatistic.Font.FontFamily, this.Size.Height / 50);
                lblSearch.Font = new Font(lblSearch.Font.FontFamily, this.Size.Height / 50);
                rtbSearch.Font = new Font(rtbSearch.Font.FontFamily, this.Size.Height / 50);
            }
            catch (Exception) { }
        }

        #endregion

        #region Methods

        //Tobias
        //Kalder fasaden til DAL laget for at få fat i data fra property tabellen samt lidt data formatering
        private void LoadData()
        {
            try
            {
                DataTable dataTable = new DataTable();

                string SearchParameters = "";
                rtbSearch.Invoke((MethodInvoker)delegate { SearchParameters = rtbSearch.Text; });

                dataTable = DataAccessLayerFacade.GetPropertyDataTableByLike(SearchParameters);

                dataTable.Columns.Remove("netPrice");
                dataTable.Columns.Remove("grossPrice");
                dataTable.Columns.Remove("ownerExpenses");
                dataTable.Columns.Remove("cashPrice");
                dataTable.Columns.Remove("depositPrice");
                dataTable.Columns.Remove("nrOfRooms");
                dataTable.Columns.Remove("garageFlag");
                dataTable.Columns.Remove("energyRating");
                dataTable.Columns.Remove("resSquareMeters");
                dataTable.Columns.Remove("propSquareMeters");
                dataTable.Columns.Remove("floors");
                dataTable.Columns.Remove("soldFlag");
                dataTable.Columns.Remove("description");

                dgvSager.Invoke((MethodInvoker)delegate { dgvSager.DataSource = dataTable; });
            }
            catch (Exception) { }
        }

        #endregion

        #region Events

        //Tobias
        private void btnStatistic_Click(object sender, EventArgs e)
        {
            Messagebox_Statistic messagebox_Statistic = new Messagebox_Statistic();
            messagebox_Statistic.Show();
        }

        //Tobias
        private void btnCreateSag_Click(object sender, EventArgs e)
        {
            //Load Sag_Create User control når tryk på knap
            if (!Form1.Instance.PnlContainer.Controls.ContainsKey("Sag_Create"))
            {
                Sag_Create.Instance.Dock = DockStyle.Fill;
                Form1.Instance.PnlContainer.Controls.Add(Sag_Create.Instance);
            }
            Form1.Instance.PnlContainer.Controls["Sag_Create"].BringToFront();
        }

        //Tobias
        private void rtbSearch_TextChanged(object sender, EventArgs e)
        {
            Thread LoadDataThread = new Thread(() => LoadData());
            LoadDataThread.IsBackground = true;
            LoadDataThread.Start();
        }

        //Tobias
        private void dgvSager_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //---Hvis trykket på knap Rediger inde i datagridview---//
            if (dgvSager.Columns[e.ColumnIndex].Name == "Rediger")
            {
                if (e.RowIndex >= 0)
                {
                    //Load Sag_Edit User control når tryk på knap med ID fra celle
                    if (!Form1.Instance.PnlContainer.Controls.ContainsKey("Sag_Edit"))
                    {
                        Sag_Edit.Instance.Dock = DockStyle.Fill;
                        Form1.Instance.PnlContainer.Controls.Add(Sag_Edit.Instance);
                    }
                    Form1.Instance.PnlContainer.Controls["Sag_Edit"].BringToFront();

                    Sag_Edit.LoadData(dgvSager.Rows[e.RowIndex].Cells[1].Value.ToString());

                }
            }
        }

        #endregion


    }
}
