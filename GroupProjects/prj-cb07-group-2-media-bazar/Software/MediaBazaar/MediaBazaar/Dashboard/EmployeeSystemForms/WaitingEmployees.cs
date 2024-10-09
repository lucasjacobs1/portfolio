using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MediaBazaar.Dashboard.EmployeeSystemForms
{
    

    public partial class WaitingEmployees : Form
    {
        EmployeeManagement EmployeeManagement = new EmployeeManagement();
        List<Employee> waitingEmployee = new List<Employee>();
        public WaitingEmployees()
        {   
            InitializeComponent();
            for (int i = 0; i < EmployeeManagement.GetWaitingEmployees().Count; i++)
            {
                waitingEmployee.Add(EmployeeManagement.GetWaitingEmployees()[i]);
                flowLayoutPanel1.Controls.Add(new UserControls.ApprovalListItem(waitingEmployee[i]));
            }

        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
