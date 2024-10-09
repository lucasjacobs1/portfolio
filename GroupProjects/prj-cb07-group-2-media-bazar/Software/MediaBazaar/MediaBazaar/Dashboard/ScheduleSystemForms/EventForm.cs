using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MediaBazaar.Data_Layer;
using MySql.Data.MySqlClient;

namespace MediaBazaar.Dashboard.ScheduleSystemForms
{
    public partial class EventForm : Form
    {
        ScheduleManager ScheduleManager = new ScheduleManager();
        string shiftType;
        Timer timer;
        public EventForm(string shiftType, Timer timer)
        {
            this.timer = timer;
            this.shiftType = shiftType;
            InitializeComponent();
        }
        public EventForm()
        {
            InitializeComponent();
        }
        public EventForm(Timer timer)
        {
            this.timer = timer;
            InitializeComponent();
        }
        private void EventForm_Load(object sender, EventArgs e)
        {
            foreach (var item in ScheduleManager.GetEmployees())
            {
                cbEmp.Items.Add(item);
            }
            foreach (var item in ScheduleManager.GetDeps())
            {
                cbDepartment.Items.Add(item);
            }
            if (UserControlDays.static_day != null)
            {
                tbDate.Text = UserControlDays.static_day + "/" + Form1.static_mounth + "/" + Form1.static_year;
                cbShift.Text = shiftType;
            }
            else
            {
                tbDate.Text = UserControlDays_Big.static_day + "/" + Form1.static_mounth + "/" + Form1.static_year;
                cbShift.Text = shiftType;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ScheduleManager.AddSchedule(cbEmp.Text, tbDate.Text, cbShift.Text);
            cbDepartment.Text = cbEmp.Text = tbDate.Text = cbShift.Text = String.Empty;
            timer.Start();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void EventForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
