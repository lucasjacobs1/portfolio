using MediaBazaar.Data_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MediaBazaar.Dashboard.RegistrationKeySystem
{
    public partial class InsertKeyDialog : Form
    {
        public InsertKeyDialog()
        {
            InitializeComponent();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginMain loginMain = new LoginMain();
            loginMain.Show();
        }

        private void solveBtn_Click(object sender, EventArgs e)
        {
            KeySystemData keySystem = new KeySystemData();
            if(keySystem.ValidateKey(textBox1.Text))
            {
                this.Close();
                EmployeeSystemForms.EditEmployeeDialog editEmployeeDialog = new EmployeeSystemForms.EditEmployeeDialog(textBox1.Text, 2);
                editEmployeeDialog.Show();
            }
            else
            {
                MessageBox.Show("Wrong key");
            }
        }
    }
}
