using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MediaBazaar.Dashboard.UserControls
{
    public partial class ApprovalListItem : UserControl
    {
        Employee currentEmployee;
        public ApprovalListItem(Employee e)
        {
            InitializeComponent();
            complainerLbl.Text = e.FirstName;
            topicLbl.Text = e.Email;
            currentEmployee = e;
        }

        private void proceedBtn_Click(object sender, EventArgs e)
        {
            EmployeeSystemForms.EditEmployeeDialog editEmployeeDialog = new EmployeeSystemForms.EditEmployeeDialog(currentEmployee,3);
            editEmployeeDialog.ShowDialog();
        }
    }
}
