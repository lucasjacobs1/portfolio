using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MediaBazaar.Dashboard.UserControls
{
    public partial class ComplaintsListItem : UserControl
    {
        Complaint currentComplaint;
        public ComplaintsListItem(Complaint c)
        {
            InitializeComponent();
            
            if(c.Anonymous == 0)
            {
                complainerLbl.Text = c.Complainer.ToString();
            }
            else
            {
                complainerLbl.Text = "Anonymous";
            }
            topicLbl.Text = c.Topic.ToString();
            currentComplaint = c;
        }

        private void advancedPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void readBtn_Click(object sender, EventArgs e)
        {
            ComplaintsSystemForms.ComplainDialog complainDialog = new ComplaintsSystemForms.ComplainDialog(currentComplaint);
            complainDialog.ShowDialog();
        }
    }
}
