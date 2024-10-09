using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MediaBazaar.Dashboard.ComplaintsSystemForms
{
    public partial class EmployeeComplaintForm : Form
    {
        int complID;
        EmployeeManagement EmployeeManagement = new EmployeeManagement();
        List<Employee> ManagersList = new List<Employee>();
        Data_Layer.ComplainManagement complainManagement = new Data_Layer.ComplainManagement();
        public EmployeeComplaintForm(int id)
        {
            InitializeComponent();
            complID = id;
          ManagersList = EmployeeManagement.GetAllManagers();
            receiverPicker.SelectedIndex = 0;

            foreach (Employee e in ManagersList)
            {
                //was e.name changed it to e.firstname
                receiverPicker.Items.Add(e.FirstName);
            }

        }
        private int GetReceiverID()
        {
            if (receiverPicker.SelectedIndex != 0)
            {
                //was x.name changed it to x.firstname
                Employee e = ManagersList.Find(x => x.FirstName == receiverPicker.SelectedItem.ToString());
                
                return e.ID;
            }
            
            return -1;
            

        }
        private void sendButton_Click(object sender, EventArgs e)
        {

        }
    }
}
