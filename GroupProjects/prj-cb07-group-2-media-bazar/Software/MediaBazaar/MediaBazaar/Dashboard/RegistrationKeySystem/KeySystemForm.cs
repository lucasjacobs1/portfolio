using MediaBazaar.Data_Layer;
using MediaBazaar.Logic_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MediaBazaar.Dashboard.RegistrationKeySystem
{
    public partial class KeySystemForm : Form
    {
        public KeySystemForm()
        {
            InitializeComponent();
            LoadData();
        }

        private void generateBtn_Click(object sender, EventArgs e)
        {
            
            Logic_Layer.UserHelper userHelper = new Logic_Layer.UserHelper();
            keyBox.Text = userHelper.GetUniqueKey(32);
            KeySystemData keySystemData = new KeySystemData();
            KeySystem k = new KeySystem(keyBox.Text);
            keySystemData.AddKey(k);
            Clipboard.SetText(keyBox.Text);
            LoadData();
        }
        private void LoadData()
        {
            KeySystemData keySystem = new KeySystemData();
            dataGridView1.DataSource = keySystem.GetAllKeys();
        }
    }
}
