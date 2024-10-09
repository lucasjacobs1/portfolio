using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MediaBazaar.Dashboard.DashboardForms
{
    public partial class DashboardMain : Form
    {
        private Employee currentLogged;
        public DashboardMain(Employee e)
        {
            InitializeComponent();
            string role = e.GetRole();
            
            UpdateInformation(e.FirstName, e.Email, e.GetRole());
            timer1.Start();
            currentLogged = e;
        }
        private void UpdateInformation(string name, string email, string location)
        {
            nameLbl.Text = name; ;
            emailLbl.Text = email;
            locationLbl.Text = location;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToLongDateString();
            label4.Text = DateTime.Now.ToString("HH:mm:ssss");
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            EmployeeSystemForms.EditEmployeeDialog editEmployeeDialog = new EmployeeSystemForms.EditEmployeeDialog(currentLogged, 1);
            editEmployeeDialog.ShowDialog();
        }

        private void DashboardMain_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
