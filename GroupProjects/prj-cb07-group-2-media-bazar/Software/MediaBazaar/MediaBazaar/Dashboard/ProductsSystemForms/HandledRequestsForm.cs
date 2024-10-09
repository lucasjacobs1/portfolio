using MediaBazaar.Data_Layer;
using MediaBazaar.Logic_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaBazaar.Dashboard.ProductsSystemForms
{
    public partial class HandledRequestsForm : Form
    {
        ReshelfManagement reshelfManagement = new ReshelfManagement();

        List<ReShelfRequest> acceptedRequests = new List<ReShelfRequest>();
        List<ReShelfRequest> rejectedRequests = new List<ReShelfRequest>();
        public HandledRequestsForm()
        {
            InitializeComponent();
            RefreshAcceptedRequests();
            RefreshRejectedRequests();
        }

        private void RefreshRejectedRequests()
        {
            lbRejectedRequests.Items.Clear();
            foreach(ReShelfRequest request in reshelfManagement.GetAllRejectedRequests())
            {
                rejectedRequests.Add(request);
                lbRejectedRequests.Items.Add(request.Product.Name.ToString());
            }
        }

        private void RefreshAcceptedRequests()
        {
            lbAcceptedRequests.Items.Clear();
            foreach(ReShelfRequest request in reshelfManagement.GetAllAcceptedRequests())
            {
                acceptedRequests.Add(request);
                lbAcceptedRequests.Items.Add(request.Product.Name.ToString());
            }
        }

        private void lbAcceptedRequests_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lbAcceptedRequests.SelectedIndex;
            if (index != -1 & index <= acceptedRequests.Count)
            {
                ReShelfRequest request = acceptedRequests[index];
                MessageBox.Show("This request was approved\n" + "sent by " + request.Sender.ToString() + ", at " + request.DateSent.ToString());
                lblMessage.Text = request.Message.ToString();
            }
        }

        private void lbRejectedRequests_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lbRejectedRequests.SelectedIndex;
            if (index != -1 & index <= rejectedRequests.Count)
            {
                ReShelfRequest request = rejectedRequests[index];
                MessageBox.Show("This request was rejected\n" + "sent by " + request.Sender.ToString() + ", at " + request.DateSent.ToString() + "\nReason of reject: "+ request.Reason.ToString());
                lblMessage.Text = request.Message.ToString();
            }
        }
    }
}
