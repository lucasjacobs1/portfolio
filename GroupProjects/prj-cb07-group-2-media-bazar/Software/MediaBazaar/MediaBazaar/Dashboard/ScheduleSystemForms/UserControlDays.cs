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
    public partial class UserControlDays : UserControl
    {
        public static string static_day;
        int Type;
        public static int Type2;
        ScheduleManager manager = new ScheduleManager();

        Employee employee;
        public UserControlDays(Employee e, int type)
        {
            InitializeComponent();
            Type = type;
            employee = e;
            Type2 = type;
        }

        private void UserControlDays_Load(object sender, EventArgs e)
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

                lbEvent.Text = manager.Shifts(Form1.static_year.ToString(), Form1.static_mounth.ToString(), label1.Text).Count().ToString();
            }
            else if (Type == 1)
            {
                lbEvent.Text = manager.Shifts(Form1.static_year.ToString(), Form1.static_mounth.ToString(), label1.Text).Count().ToString();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            display();
            timer1.Stop();
        }


        private void UserControlDays_MouseDown(object sender, MouseEventArgs e)
        {
            Form1 form = new Form1(employee, Type, "Weekly");
            if (e.Button == MouseButtons.Left)
            {
                static_day = label1.Text;
                form.UpdateList();
            }
            if (e.Button == MouseButtons.Right)
            {
                if (Type == 0)
                {
                    static_day = label1.Text;
                    EventForm eventForm = new EventForm(timer1);
                    eventForm.Show();
                }
                else { }
            }
        }
    }
}
