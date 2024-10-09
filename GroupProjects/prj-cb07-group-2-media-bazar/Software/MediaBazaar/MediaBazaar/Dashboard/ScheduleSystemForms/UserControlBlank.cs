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

namespace MediaBazaar.Dashboard.ScheduleSystemForms
{
    public partial class UserControlBlank : UserControl
    {
        public static string static_day;
        int Type;
        public static int Type2;
        ScheduleManager manager = new ScheduleManager();
        Employee employee;
        public UserControlBlank(Employee e, int type)
        {
            InitializeComponent();
            Type = type;
            employee = e;
            Type2 = type;
        }

        private void UserControlBlank_Load(object sender, EventArgs e)
        {
            display();
        }
        public void days(int numday)
        {
            label1.Text = numday + "";
        }
        private void display()
        {
            if (Type == 0)
            {
                lbEvent.Text = manager.Event(Form1.static_year.ToString(), Form1.static_mounth.ToString(), label1.Text);

            }
            else if (Type == 1)
            {
                lbEvent.Text = manager.EventByID(employee.FirstName, Form1.static_year.ToString(), Form1.static_mounth.ToString(), label1.Text);

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            display();
        }
    }
}
