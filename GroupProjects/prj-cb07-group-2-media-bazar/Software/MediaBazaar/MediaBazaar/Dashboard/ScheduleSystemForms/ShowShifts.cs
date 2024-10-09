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

namespace MediaBazaar.Dashboard.ScheduleSystemForms
{
    public partial class ShowShifts : Form
    {
        public ShowShifts(List<string> availableShifts,int type)
        {
            InitializeComponent();
            if(type == 0)
            {
                lbPlanner.DataSource = availableShifts;
                label9.Text = availableShifts.Count.ToString();
            }
            else if(type == 1)
            {
                panel1.Visible = false;
                lbPlanner.DataSource = availableShifts;
                label9.Text = availableShifts.Count.ToString();
            }
            
        }

        private void ShowShifts_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
  
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            string selectedString = lbPlanner.SelectedItem.ToString();
            int sleectedID = Convert.ToInt32(selectedString.Split(new char[] { '~', '~' })[1]);
            ScheduleManager scheduleManager = new ScheduleManager();
            if(scheduleManager.DeleteShift(sleectedID))
            {
                MessageBox.Show("Done");
            }
            else { MessageBox.Show("Error"); }
            
        }
    }
}
