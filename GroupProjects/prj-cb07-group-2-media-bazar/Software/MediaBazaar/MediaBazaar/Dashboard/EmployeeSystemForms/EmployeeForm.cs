using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MediaBazaar.Dashboard.EmployeeSystemForms
{
    public partial class EmployeeForm : Form
    {
        
        List<Employee> employees = new List<Employee>();
        EmployeeManagement EmployeeManagement = new EmployeeManagement();
        List<Employee> waitingEmployee = new List<Employee>();
        public EmployeeForm()
        {

            InitializeComponent();
            flowLayoutPanel1.VerticalScroll.Visible = true;
            for (int i = 0; i < EmployeeManagement.GetEmployees().Count; i++)
            {
                employees.Add(EmployeeManagement.GetEmployees()[i]);
                flowLayoutPanel1.Controls.Add(new UserControls.EmployeeListItem(employees[i]));
            }
            waitingEmployee = EmployeeManagement.GetWaitingEmployees();
            if(waitingEmployee.Count != 0)
            {
                label2.Visible = true;
                approvementLbl.Visible = true;
                approveBtn.Visible = true;
                approvementLbl.Text = waitingEmployee.Count.ToString();
                approvementLbl.ForeColor = Color.Red;
                
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {        
            flowLayoutPanel1.Controls.Clear();
            List<Employee> filteredEmployess = new List<Employee>();
            if (Regex.IsMatch(textBox1.Text, @"^\d+$"))
            {
                filteredEmployess = employees.Where(e => e.ID.Equals(Convert.ToInt32(textBox1.Text))).ToList();
                if (filteredEmployess.Count > 0)
                {
                    for (int i = 0; i < filteredEmployess.Count; i++)
                    {
                        flowLayoutPanel1.Controls.Add(new UserControls.EmployeeListItem(filteredEmployess[i]));
                    }
                }
                else
                {
                    flowLayoutPanel1.Controls.Clear();
                }
            }
            else {

            filteredEmployess = employees.Where(e =>e.FirstName.ToUpper().Contains(textBox1.Text.ToUpper())).ToList();
            
            if (filteredEmployess.Count > 0)
            {
                for (int i = 0; i < filteredEmployess.Count; i++)
                {                   
                    flowLayoutPanel1.Controls.Add(new UserControls.EmployeeListItem(filteredEmployess[i]));
                }
            }
            else
            {
                flowLayoutPanel1.Controls.Clear();
            }
            }
        }

        private void approveBtn_Click(object sender, EventArgs e)
        {
            EmployeeSystemForms.WaitingEmployees waitingEmployees = new WaitingEmployees();
            waitingEmployees.Show();
        }
    }
}
