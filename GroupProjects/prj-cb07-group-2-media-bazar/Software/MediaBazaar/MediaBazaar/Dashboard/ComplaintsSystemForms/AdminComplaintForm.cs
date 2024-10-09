using MediaBazaar.Data_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MediaBazaar.Dashboard.ComplaintsSystemForms
{

    public partial class AdminComplaintForm : Form
    {
        List<Complaint> complaints = new List<Complaint>();
        ComplainManagement complainManagement = new ComplainManagement();
        public AdminComplaintForm(Employee e)
        {

            InitializeComponent();
            complaints = complainManagement.GetComplaints();
            for (int i = 0; i < complaints.Count; i++)
            {
                if (complaints[i].Solved == 0)
                {
                    /*was e.name changed it to e.firstname*/
                    complainsPanel.Controls.Add(new UserControls.ComplaintsListItem(complaints[i]));
                }
            }
        }
    }
}
