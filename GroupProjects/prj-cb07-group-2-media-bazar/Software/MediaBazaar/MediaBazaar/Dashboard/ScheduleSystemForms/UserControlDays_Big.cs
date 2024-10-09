using MediaBazaar.Data_Layer;
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

namespace MediaBazaar.Dashboard.ScheduleSystemForms
{
    public partial class UserControlDays_Big : UserControl
    {
        public static string static_day;
        int Type;
        public static int Type2;
        ScheduleManager manager = new ScheduleManager();
        int counter = 0;
        int counter1 = 0;
        int counter2 = 0;
        Employee employee;
        public UserControlDays_Big(Employee e, int type)
        {
            InitializeComponent();
            Type = type;
            employee = e;
            Type2 = type;
            
        }

        public void UserControlDays_Big_Load(object sender, EventArgs e)
        {
            display();
        }

        public void days(int numday)
        {
            label1.Text = numday + "";
        }

        public void display()
        {
            if (Convert.ToInt32(label1.Text) == Convert.ToInt32(DateTime.Today.Day) && DateTime.Now.Month == Form1.currentMonth)
            {
                label1.ForeColor = Color.Red;
            }
            if (Type == 0)
            {
                PnMorning.Controls.Clear();
                pnAfterNoon.Controls.Clear();
                pnEvening.Controls.Clear();
                
                foreach (var item in manager.Shifts(Form1.static_year.ToString(), Form1.static_mounth.ToString(), label1.Text))
                {
                    if (counter < 5 || counter1 < 6 || counter2 < 6)
                    {
                        Regex regex = new Regex("[^-]*$");
                        string shiftType = regex.Match(item).ToString();
                        Regex regex2 = new Regex("(?<=~)(.*?)(?=~)");
                        string id = regex2.Match(item).ToString();
                        switch (shiftType)
                        {
                            case "Morning":
                                Label lbEvent1 = new();
                                PnMorning.Controls.Add(lbEvent1, 0, counter);
                                lbEvent1.Text = manager.ScheduleByID(id, Form1.static_year.ToString(), Form1.static_mounth.ToString(), label1.Text, shiftType);
                                counter++;
                                if (counter > 4)
                                {
                                    lbEvent1.Text = "Click for more...";
                                    lbEvent1.Enabled = false;
                                    break;
                                }
                                break;
                            case "Afternoon":
                                Label lbbEvent = new();
                                pnAfterNoon.Controls.Add(lbbEvent, 0, counter1);
                                lbbEvent.Text = manager.ScheduleByID(id, Form1.static_year.ToString(), Form1.static_mounth.ToString(), label1.Text, shiftType);
                                counter1++;
                                if (counter1 > 5)
                                {
                                    lbbEvent.Text = "Click for more...";
                                    lbbEvent.Enabled = false;
                                    break;
                                }
                                break;
                            case "Evening":
                                Label lbEvent = new();
                                pnEvening.Controls.Add(lbEvent, 0, counter2);
                                lbEvent.Text = manager.ScheduleByID(id, Form1.static_year.ToString(), Form1.static_mounth.ToString(), label1.Text, shiftType);
                                counter2++;
                                if (counter2 > 5)
                                {
                                    lbEvent.Text = "Click for more...";
                                    lbEvent.Enabled = false;
                                    break;
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }
                counter = 0;
                counter1 = 0;
                counter2 = 0;
            }
            else if (Type == 1)
            {

                switch (manager.EventByTime(Form1.static_year.ToString(), Form1.static_mounth.ToString(), label1.Text))
                {
                    case "Morning":
                        Label lbEvent = new Label();
                        PnMorning.Controls.Add(lbEvent);
                        lbEvent.Text = manager.EventByID(employee.FirstName, Form1.static_year.ToString(), Form1.static_mounth.ToString(), label1.Text);
                        break;
                    case "Afternoon":
                       Label lbEventt = new Label();
                        pnAfterNoon.Controls.Add(lbEventt);
                        lbEventt.Text = manager.EventByID(employee.FirstName, Form1.static_year.ToString(), Form1.static_mounth.ToString(), label1.Text);
                        break;
                    case "Evening":
                       Label lbbEvent = new Label();
                        pnEvening.Controls.Add(lbbEvent);
                        lbbEvent.Text = manager.EventByID(employee.FirstName, Form1.static_year.ToString(), Form1.static_mounth.ToString(), label1.Text);
                        break;
                    default:
                        break;
                }
            }
        }

        private void UserControlDays_Big_MouseDown(object sender, MouseEventArgs e)
        {
           
        }

        private void UserControlDays_Big_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }

        private void pnAfterNoon_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timerSchedule_Tick(object sender, EventArgs e)
        {
            this.UserControlDays_Big_Load(sender,e);
            this.timerSchedule.Stop();
        }

        private void pnEvening_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PnMorning_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void pnAfterNoon_MouseDown(object sender, MouseEventArgs e)
        {
           
        }

        private void pnEvening_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void PnMorning_Paint(object sender, PaintEventArgs e)
        {

        }

        private void horizontalLine2_Click(object sender, EventArgs e)
        {

        }

        private void PnMorning_MouseDown_1(object sender, MouseEventArgs e)
        {
            Form1 form = new Form1(employee, Type, "Weekly");
            if (e.Button == MouseButtons.Left)
            {
                static_day = label1.Text;
                form.UpdateWeekList();
            }
            if (e.Button == MouseButtons.Right)
            {
                if (Type == 0)
                {
                    static_day = label1.Text;
                    EventForm eventForm = new EventForm("Morning", timerSchedule);
                    eventForm.Show();
                }
                else { }
            }
        }

        private void pnAfterNoon_MouseDown_1(object sender, MouseEventArgs e)
        {
            Form1 form = new Form1(employee, Type, "Weekly");
            if (e.Button == MouseButtons.Left)
            {
                static_day = label1.Text;
                form.UpdateWeekList();
            }
            if (e.Button == MouseButtons.Right)
            {
                if (Type == 0)
                {
                    static_day = label1.Text;
                    EventForm eventForm = new EventForm("Afternoon", timerSchedule);
                    eventForm.Show();
                }
                else { }
            }
        }

        private void pnEvening_MouseDown_1(object sender, MouseEventArgs e)
        {
            Form1 form = new Form1(employee, Type, "Weekly");
            if (e.Button == MouseButtons.Left)
            {
                static_day = label1.Text;
                form.UpdateWeekList();
            }
            if (e.Button == MouseButtons.Right)
            {
                if (Type == 0)
                {
                    static_day = label1.Text;
                    EventForm eventForm = new EventForm("Evening", timerSchedule);
                    eventForm.Show();
                }
                else { }
            }
        }
    }
}
