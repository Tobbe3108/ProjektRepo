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
    public partial class Person_ViewAll : UserControl
    {
        #region Init

        //Tobias
        //Singleton instance af Sag_Create
        static Person_ViewAll _instance;
        public static Person_ViewAll Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Person_ViewAll();
                }
                return _instance;
            }
        }

        public Person_ViewAll()
        {
            InitializeComponent();
        }

        #endregion

        private void btnToFile_Click(object sender, EventArgs e)
        {

        }

        private void btnCreatePerson_Click(object sender, EventArgs e)
        {

        }

        private void rtbSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvSager_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
