using MediaBazaar.Data_Layer;
using MediaBazaar.Logic_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaBazaar.Dashboard.ProductsSystemForms
{
    public partial class CashierForm : Form
    {
        ProductManagement productmanagement = new ProductManagement();
        List<Product> products = new List<Product>();
        Product tomProduct;
        string BarCode = "";
        public CashierForm()
        {
            InitializeComponent();
            products = productmanagement.GetAllProducts();
        }


        private void CashierForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (BarCode.Length == 13)
            {
                if (e.KeyData == Keys.Return)
                {
                    barCodetext.Text = BarCode;
                }
                BarCode = "";
            }
            else
            {
                int keyVal = (int)e.KeyValue;
                int value = -1;
                if ((keyVal >= (int)Keys.D0 && keyVal <= (int)Keys.D9))
                {
                    value = (int)e.KeyValue - (int)Keys.D0;
                    BarCode += value;

                }
                else if (keyVal >= (int)Keys.NumPad0 && keyVal <= (int)Keys.NumPad9)
                {
                    value = (int)e.KeyValue - (int)Keys.NumPad0;
                }

            }

        }
        void ClearALL()
        {
            barCodetext.Text = "";
            manuallyBarCheckbox.Checked = false;
            inStock.Text = "0";
            numericUpDown1.Value = 0;
            numericUpDown1.Maximum = 99999;
            foundProduct.Text = "0";
        }
        private void manuallyBarCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (manuallyBarCheckbox.Checked)
            {
                barCodetext.Enabled = true;
            }
            else { barCodetext.Enabled = false; }
        }

        List<Product> filteredProducts = new List<Product>();

        private void barCodetext_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(barCodetext.Text, @"^\d+$"))
            {
                filteredProducts = products.Where(e => e.Barcode.Equals(barCodetext.Text)).ToList();
                if (filteredProducts.Count > 0)
                {
                    foundProduct.Text = filteredProducts[0].Name;
                    inStock.Text = filteredProducts[0].AmountInstock.ToString();                    
                    tomProduct = filteredProducts[0];
                    numericUpDown1.Maximum = 1000000;
                    if (tomProduct.AmountInstock == 0)
                    {
                        button1.Enabled = false;
                        numericUpDown1.Enabled = false;
                    }
                    else
                    {
                        button1.Enabled = true;
                        numericUpDown1.Enabled = true;
                    }
                }
                else
                {
                    foundProduct.Text = "Nothing";
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
             if(numericUpDown1.Value >= tomProduct.AmountInstock)
            {
                numericUpDown1.Maximum = filteredProducts[0].AmountInstock;
                MessageBox.Show("You cannot sell more than ammount in stock!");
                numericUpDown1.Value = tomProduct.AmountInstock;
            }
            else
            {
               
                if (productmanagement.SellItem(tomProduct, Convert.ToInt32(numericUpDown1.Value)))
                {
                    MessageBox.Show("Sold!!!");
                    ClearALL();
                }    
                else
                {
                    MessageBox.Show("Error!!!");
                }
            }
        }
    }
}
