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
    public partial class ReshelfRequestSending : Form
    {
        ReshelfManagement reshelfManagement = new ReshelfManagement();
        ReShelfRequest placeholderRequest = new ReShelfRequest(new Product());
        ProductManagement productmanagement = new ProductManagement();
        List<Product> products = new List<Product>();

        public ReshelfRequestSending()
        {
            InitializeComponent();
            RefreshProducts();
        }

        public void RefreshProducts()
        {
            lbProducts.Items.Clear();
            for (int i = 0; i < productmanagement.GetAllProducts().Count; i++)
            {
                products.Add(productmanagement.GetAllProducts()[i]);
                lbProducts.Items.Add(products[i].Name + ", Price " + products[i].PriceInEuros + ";");
            }
        }

        private void btnSendRequest_Click(object sender, EventArgs e)
        {
            if (tbSender.Text.Length < 1)
            {
                MessageBox.Show("Please fill in your name!");
            }
            else if (rtbMessage.Text.Length > 0)
            {
                ReShelfRequest newRequest = new ReShelfRequest(products[lbProducts.SelectedIndex], rtbMessage.Text, tbSender.Text, DateTime.Now);
                placeholderRequest.AddRequest(newRequest);
                reshelfManagement.AddPendingRequest(newRequest);
                MessageBox.Show("Sent");
            }
            else
            {
                ReShelfRequest newRequest = new ReShelfRequest(products[lbProducts.SelectedIndex], tbSender.Text, DateTime.Now);
                placeholderRequest.AddRequest(newRequest);
                reshelfManagement.AddPendingRequest(newRequest);
                MessageBox.Show("Sent");
            }
        }

        private void lbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lbProducts.SelectedIndex;
            if (index != -1 & index <= products.Count)
            {
                Product product = products[index];
                MessageBox.Show(product.Description.ToString() + " Amount in stock: " + product.AmountInstock.ToString() + "& Amount sold: " + product.AmountSold.ToString());
            }
        }
    }
}
