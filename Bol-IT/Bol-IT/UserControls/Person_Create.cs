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
    public partial class Person_Create : UserControl
    {
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

        #region Events

        private void btnSaveToFile_Click(object sender, EventArgs e)
        {

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

        }

        #endregion
    }
}
