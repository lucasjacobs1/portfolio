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

    public partial class DetailedProductView : Form
    {

        private readonly BindingSource _source = new();
        private ProductManagement productManagement = new ProductManagement();

        public DetailedProductView()
        {
            InitializeComponent();
            DisplayProducts();
        }

        private void DisplayProducts()
        {
            dataGridView1.Rows.Clear();
            _source.DataSource = typeof(Product);
            foreach (var product in productManagement.GetAllProducts())
            {
                _source.Add(product);
            }
            dataGridView1.DataSource = _source;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
