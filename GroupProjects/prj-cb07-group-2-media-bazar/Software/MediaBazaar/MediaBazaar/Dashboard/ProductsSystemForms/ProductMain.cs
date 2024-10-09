using MediaBazaar.Data_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MediaBazaar.Logic_Layer;

namespace MediaBazaar.Dashboard.ProductsSystemForms
{
    public partial class ProductMain : Form
    {
        ReshelfManagement reshelfManagement = new ReshelfManagement();
        ReShelfRequest placeholderRequest = new ReShelfRequest(new Product());
        ProductManagement productmanagement = new ProductManagement();
        List<Product> products = new List<Product>();

        public ProductMain()
        {
            InitializeComponent();
            RefreshProducts();
        }

        public void RefreshProducts()
        {
            products.Clear();
            lbProductSearchResult.Items.Clear();
            for (int i = 0; i < productmanagement.GetAllProducts().Count; i++)
            {
                products.Add(productmanagement.GetAllProducts()[i]);
                filteredproducts.Add(productmanagement.GetAllProducts()[i]);
                lbProductSearchResult.Items.Add(products[i].Name + ", Price " + products[i].PriceInEuros + ";");
            }
        }
        List<Product> filteredproducts = new List<Product>();
        public void RefreshReshelfRequests()
        {
            placeholderRequest.GetRequestList().Clear();
            lbRestockRequests.Items.Clear();
            for (int i = 0; i < reshelfManagement.GetAllPendingRequests().Count; i++)
            {
                placeholderRequest.AddRequest(reshelfManagement.GetAllPendingRequests()[i]);
                filteredRequests.Add(reshelfManagement.GetAllPendingRequests()[i]);
                lbRestockRequests.Items.Add(placeholderRequest.GetRequestList()[i].Product.Name);
            }
        }
        List<ReShelfRequest> filteredRequests = new List<ReShelfRequest>();
        private void tbSearchProduct_TextChanged(object sender, EventArgs e)
        {
            lbProductSearchResult.Items.Clear();
            filteredproducts.Clear();
            filteredproducts = products.Where(e => e.Name.ToUpper().Contains(tbSearchProduct.Text.ToUpper())).ToList();

            if (filteredproducts.Count > 0)
            {
                for (int i = 0; i < filteredproducts.Count; i++)
                {
                    lbProductSearchResult.Items.Add(filteredproducts[i].Name + ", Price " + filteredproducts[i].PriceInEuros + ";");
                }
            }
            else
            {
                lbProductSearchResult.Items.Clear();
                lbProductSearchResult.Items.Add("No results...");

            }

        }

        private void lbProductSearchResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lbProductSearchResult.SelectedIndex;
            if (lbProductSearchResult.SelectedItem != "No results...")
            {


                if (index != -1 & index <= filteredproducts.Count)
                {
                    Product product = filteredproducts[index];
                    MessageBox.Show(product.Description.ToString() + " Amount in stock: " + product.AmountInstock.ToString() + "& Amount sold: " + product.AmountSold.ToString());

                    tbProductName.Text = product.Name;
                    tbDescription.Text = product.Description;
                    tbPrice.Text = product.PriceInEuros.ToString();
                    tbAmountInStock.Text = product.AmountInstock.ToString();
                    tbAmountSold.Text = product.AmountSold.ToString();
                    tbWeight.Text = product.WeightInKG.ToString();
                    tbHeight.Text = product.HeightInCM.ToString();
                    tbLength.Text = product.LengthInCM.ToString();
                    tbWidth.Text = product.WidthInCM.ToString();
                }
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            Product newProduct = new Product(tbProductName.Text, tbDescription.Text, Convert.ToDouble(tbPrice.Text), Convert.ToInt32(tbAmountInStock.Text), Convert.ToInt32(tbAmountSold.Text), Convert.ToInt32(tbWeight.Text), Convert.ToInt32(tbHeight.Text), Convert.ToInt32(tbLength.Text), Convert.ToInt32(tbWidth.Text));
            productmanagement.AddProduct(newProduct);
            products.Add(newProduct);

            RefreshProducts();
        }

        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {
            int index = lbProductSearchResult.SelectedIndex;
            Product product = products[index];
            products.RemoveAt(index);
            productmanagement.DeleteProductByName(product.Name);

            RefreshProducts();
        }

        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            Product p = products[lbProductSearchResult.SelectedIndex];
            Product selectedProduct = new Product(tbProductName.Text, tbDescription.Text, Convert.ToDouble(tbPrice.Text), Convert.ToInt32(tbAmountInStock.Text), Convert.ToInt32(tbAmountSold.Text), Convert.ToInt32(tbWeight.Text), Convert.ToInt32(tbHeight.Text), Convert.ToInt32(tbLength.Text), Convert.ToInt32(tbWidth.Text));
            productmanagement.EditProduct(selectedProduct, p.Name);

            products[lbProductSearchResult.SelectedIndex].Name = selectedProduct.Name;
            products[lbProductSearchResult.SelectedIndex].PriceInEuros = selectedProduct.PriceInEuros;
            products[lbProductSearchResult.SelectedIndex].Description = selectedProduct.Description;
            products[lbProductSearchResult.SelectedIndex].AmountInstock = selectedProduct.AmountInstock;
            products[lbProductSearchResult.SelectedIndex].AmountSold = selectedProduct.AmountSold;

            RefreshProducts();
        }

        private void btnApproveRequest_Click(object sender, EventArgs e)
        {
            Product selectedProduct = productmanagement.GetProductByName(lbRestockRequests.SelectedItem.ToString());
            reshelfManagement.AddAcceptedRequest(reshelfManagement.GetPendingRequestByProduct(selectedProduct));
            placeholderRequest.AcceptRequest(placeholderRequest.GetRequestByProduct(selectedProduct));
            reshelfManagement.DeletePendingRequestByProduct(selectedProduct);
            
            RefreshReshelfRequests();
        }

        private void btnRejectRequest_Click(object sender, EventArgs e)
        {
            Product selectedProduct = productmanagement.GetProductByName(lbRestockRequests.SelectedItem.ToString());
            reshelfManagement.AddRejectedRequest(reshelfManagement.GetPendingRequestByProduct(selectedProduct), tbReason.Text);
            placeholderRequest.RejectRequest(placeholderRequest.GetRequestByProduct(selectedProduct));
            reshelfManagement.DeletePendingRequestByProduct(selectedProduct);

            RefreshReshelfRequests();
            tbReason.Clear();
        }

        private void btnViewHandledRequests_Click(object sender, EventArgs e)
        {
            HandledRequestsForm handledRequestsForm = new HandledRequestsForm();
            handledRequestsForm.Show();
        }

        private void btnMoreDetailedView_Click(object sender, EventArgs e)
        {
            DetailedProductView form = new DetailedProductView();
            form.Show();
        }
    }
}
