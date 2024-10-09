using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MediaBazaar.Dashboard.UserControls
{
    public partial class EmployeeListItem : UserControl
    {
        string email;
        int id;
        private Employee employee;
        public EmployeeListItem(Employee e)
        {
            InitializeComponent();
            firstnameLbl.Text = e.FirstName;
            roleLbl.Text = e.GetRole();
            label1.Text = e.Email;
            email = e.Email;
            id = e.ID;
            idLBl.Text = "ID: " + e.ID.ToString();
            employee = e;
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            EmployeeSystemForms.EditEmployeeDialog editEmployeeDialog = new EmployeeSystemForms.EditEmployeeDialog(employee,0);
            editEmployeeDialog.ShowDialog();
        }

        private void endcontractBtn_Click(object sender, EventArgs e)
        {
            EmployeeManagement employeeManagement = new EmployeeManagement();
            employeeManagement.DeleteEmployee(employee.ID);
            MessageBox.Show("Done");
        }
    }
}
