using MediaBazaar.Data_Layer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace MediaBazaar.Dashboard.ScheduleSystemForms
{
    public partial class Form1 : Form
    {
        int year, week;
        public static int static_mounth, static_year, static_week;
        public static int currentMonth = DateTime.Now.Month;
        public static int adder = 7;
        int Type;
        Employee employee;
        ScheduleManager ScheduleManager = new ScheduleManager();
        public Form1(Employee e, int type, string calendar)
        {
            InitializeComponent();
            Type = type;
            cbSchedule.Text = calendar;
            employee = e;
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        public void Form1_Load(object sender, EventArgs e)
        {
        }
        public void UpdateList()
        {
            List<string> shiftOnDay = new List<string>();
            foreach (var item in ScheduleManager.Shifts(Form1.static_year.ToString(), Form1.static_mounth.ToString(), UserControlDays.static_day))
            {
                shiftOnDay.Add(item.ToString());
            }
            ShowShifts showShifts = new ShowShifts(shiftOnDay, Type);
            showShifts.ShowDialog();

        }
        public void UpdateWeekList()
        {
            List<string> shiftOnDay = new List<string>();
            foreach (var item in ScheduleManager.Shifts(Form1.static_year.ToString(), Form1.static_mounth.ToString(), UserControlDays_Big.static_day))
            {
                shiftOnDay.Add(item.ToString());
            }
            ShowShifts showShifts = new ShowShifts(shiftOnDay, Type);
            showShifts.ShowDialog();

        }
        static int GetWeekNumberOfMonth(DateTime date)
        {
            date = date.Date;
            DateTime firstMonthDay = new DateTime(date.Year, date.Month, 1);
            DateTime firstMonthMonday = firstMonthDay.AddDays((DayOfWeek.Monday + 7 - firstMonthDay.DayOfWeek) % 7);
            if (firstMonthMonday > date)
            {
                firstMonthDay = firstMonthDay.AddMonths(-1);
                firstMonthMonday = firstMonthDay.AddDays((DayOfWeek.Monday + 7 - firstMonthDay.DayOfWeek) % 7);
            }
            return (date - firstMonthMonday).Days / 7 + 1;
        }
        static int GetMonday(DateTime date, int weekDays)
        {
            date = date.Date;
            DateTime firstMonthDay = new DateTime(date.Year, date.Month, 1);

            if (weekDays == 0) { weekDays = -7; }
            DateTime firstMonday = date.AddDays(-(int)date.DayOfWeek + (int)DayOfWeek.Monday);
            if (firstMonday > date)
            {
                firstMonthDay = firstMonthDay.AddMonths(-1);
                firstMonday = firstMonthDay.AddDays((DayOfWeek.Monday + weekDays - firstMonthDay.DayOfWeek) % weekDays);
            }
            if (currentMonth != firstMonday.Month)
            {
                currentMonth = firstMonday.Month;
            }
            return firstMonday.Day;
        }
        private void display()
        {
            daysTablePanel.SuspendLayout();
            DateTime now = DateTime.Now;
            currentMonth = now.Month;
            year = now.Year;

            string MonthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(currentMonth);
            if (cbSchedule.SelectedItem.ToString() == "Monthly")
            {
                lbMounth.Text = MonthName + " " + year;
            }
            if (cbSchedule.SelectedItem.ToString() == "Weekly")
            {
                displayWeek();
                lbMounth.Text = $"Week {GetWeekNumberOfMonth(DateTime.Today)}- {MonthName}";
            }

            static_mounth = currentMonth;
            static_year = year;
            DateTime startOfMounth = new DateTime(year, currentMonth, 1);
            int days = DateTime.DaysInMonth(year, currentMonth);
            int pastMounthDays = DateTime.DaysInMonth(year, currentMonth - 1);
            int daysOfTheWeek = Convert.ToInt32(startOfMounth.DayOfWeek.ToString("d")) - 1;
            int daysDiff = pastMounthDays - daysOfTheWeek + 1;

            if (cbSchedule.SelectedItem.ToString() == "Monthly")
            {
                for (int i = 0; i < daysOfTheWeek; i++)
                {
                    UserControlBlank ucblc = new UserControlBlank(employee, Type);
                    ucblc.days(daysDiff);
                    daysDiff++;
                    dayPannel.Controls.Add(ucblc);
                }
                for (int i = 1; i <= days; i++)
                {
                    UserControlDays controlDays = new UserControlDays(employee, Type);
                    controlDays.days(i);

                    dayPannel.Controls.Add(controlDays);
                }
            }
        }
        public void NextWeek()
        {
            DateTime now = DateTime.Now;
            currentMonth = now.Month;
            year = now.Year;
            int NextMonady = GetMonday(DateTime.Today.AddDays(week), adder += 7);
            lbMounth.Text += $" - {DateTimeFormatInfo.CurrentInfo.GetMonthName(currentMonth)}";
            static_mounth = currentMonth;
            static_year = year;
            int days = DateTime.DaysInMonth(year, currentMonth);
            int endOfWeek = NextMonady + 6;
            int daysDiff = endOfWeek - days;
            if (cbSchedule.SelectedItem.ToString() == "Weekly")
            {
                for (int i = NextMonady; i <= endOfWeek; i++)
                {
                    UserControlDays_Big controlDays = new UserControlDays_Big(employee, Type);
                    //  controlDays.Size = new Size(100, 500);
                    controlDays.days(i);
                    
                    if (endOfWeek > days) { endOfWeek = days; }
                    dayPannel.Controls.Add(controlDays);
                }
                for (int i = 1; i <= daysDiff; i++)
                {
                    UserControlBlank ucblc = new UserControlBlank(employee, Type);
                    ucblc.Size = new Size(100, 500);
                    ucblc.days(i);
                    dayPannel.Controls.Add(ucblc);
                }
            }
        }
        //public int WeekCounter()
        //{
        //    int weekCounter = 0;
        //    for (int i = 0; i < length; i++)
        //    {

        //    }
        //}
        public void PreviousWeek()
        {
            DateTime now = DateTime.Now;
            currentMonth = now.Month;
            int NextMonady = GetMonday(DateTime.Today.AddDays(week), adder -= 7);
            lbMounth.Text += $" - {DateTimeFormatInfo.CurrentInfo.GetMonthName(currentMonth)}";
            year = now.Year;
            static_mounth = currentMonth;
            static_year = year;
            int days = DateTime.DaysInMonth(year, currentMonth);
            int endOfWeek = NextMonady + 6;
            int daysDiff = endOfWeek - days;
            if (cbSchedule.SelectedItem.ToString() == "Weekly")
            {
                for (int i = NextMonady; i <= endOfWeek; i++)
                {
                    UserControlDays_Big controlDays = new UserControlDays_Big(employee, Type);
                    //    controlDays.Size = new Size(100, 500);
                    controlDays.days(i);
                    
                    if (endOfWeek > days) { endOfWeek = days; }
                    dayPannel.Controls.Add(controlDays);
                }
                for (int i = 1; i <= daysDiff; i++)
                {
                    UserControlBlank ucblc = new UserControlBlank(employee, Type);
                    ucblc.Size = new Size(100, 500);
                    ucblc.days(i);
                    dayPannel.Controls.Add(ucblc);
                }
            }
        }
        public void displayWeek()
        {
            DateTime now = DateTime.Now;
            currentMonth = now.Month;
            int NextMonady = GetMonday(DateTime.Today.AddDays(week), adder);
            year = now.Year;
            static_mounth = currentMonth;
            static_year = year;
            int days = DateTime.DaysInMonth(year, currentMonth);
            int endOfWeek = NextMonady + 6;
            int daysDiff = endOfWeek - days;
            if (cbSchedule.SelectedItem.ToString() == "Weekly")
            {
                if (endOfWeek > days)
                {
                    endOfWeek = days;
                }
                for (int i = NextMonady; i <= endOfWeek; i++)
                {
                    UserControlDays_Big controlDays = new UserControlDays_Big(employee, Type);
                    // controlDays.Size = new Size(100, 500);
                    controlDays.days(i);
                    
                    dayPannel.Controls.Add(controlDays);

                }
                for (int i = 1; i <= daysDiff; i++)
                {
                    UserControlBlank ucblc = new UserControlBlank(employee, Type);
                    ucblc.Size = new Size(100, 500);
                    ucblc.days(i);
                    dayPannel.Controls.Add(ucblc);
                }
            }
        }
        private void dayPannel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbWeek_Click(object sender, EventArgs e)
        {

        }



        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cbSchedule_SelectedIndexChanged(object sender, EventArgs e)
        {
            dayPannel.Controls.Clear();
            display();
            cbSchedule.Focus();
            if (cbSchedule.SelectedItem.ToString() != "Weekly")
            {
                label1.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
            }
            else
            {
                label1.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
            }
        }

        private void label1_Paint(object sender, PaintEventArgs e)
        {
            Font font = new Font("Arial", 13);
            Brush brush = new SolidBrush(Color.White);


            e.Graphics.TranslateTransform(0, 120);
            e.Graphics.RotateTransform(270);
            e.Graphics.DrawString("Morning", font, brush, 0, 0);

        }

        private void label9_Paint(object sender, PaintEventArgs e)
        {
            Font font = new Font("Arial", 13);
            Brush brush = new SolidBrush(Color.White);

            e.Graphics.TranslateTransform(0, 120);
            e.Graphics.RotateTransform(270);
            e.Graphics.DrawString("Afternoon", font, brush, 0, 0);

        }

        private void label10_Paint(object sender, PaintEventArgs e)
        {
            Font font = new Font("Arial", 13);
            Brush brush = new SolidBrush(Color.White);

            e.Graphics.TranslateTransform(0, 120);
            e.Graphics.RotateTransform(270);
            e.Graphics.DrawString("Evening", font, brush, 0, 0);

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void cbSchedule_DropDownClosed(object sender, EventArgs e)
        {


        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            dayPannel.Controls.Clear();
            static_year = year;
            if (cbSchedule.SelectedItem.ToString() == "Monthly")
            {
                currentMonth++;
                static_mounth = currentMonth;
                string MonthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(currentMonth);
                lbMounth.Text = MonthName + " " + year;
            }
            if (cbSchedule.SelectedItem.ToString() == "Weekly")
            {
                static_week = week;
                lbMounth.Text = $"Week {GetWeekNumberOfMonth(DateTime.Today.AddDays(week += 7))}";
                NextWeek();
            }
            DateTime startOfMounth = new DateTime(year, currentMonth, 1);
            int pastMounthDays = DateTime.DaysInMonth(year, currentMonth - 1);
            int days = DateTime.DaysInMonth(year, currentMonth);
            int daysOfTheWeek = Convert.ToInt32(startOfMounth.DayOfWeek.ToString("d")) - 1;
            int daysDiff = pastMounthDays - daysOfTheWeek + 1;
            if (cbSchedule.SelectedItem.ToString() == "Monthly")
            {
                for (int i = 0; i < daysOfTheWeek; i++)
                {
                    UserControlBlank ucblc = new UserControlBlank(employee, Type);
                    ucblc.days(daysDiff);
                    daysDiff++;
                    dayPannel.Controls.Add(ucblc);
                }
                for (int i = 1; i <= days; i++)
                {
                    UserControlDays controlDays = new UserControlDays(employee, Type);
                    controlDays.days(i);
                   
                    dayPannel.Controls.Add(controlDays);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dayPannel.Controls.Clear();
            static_year = year;
            if (cbSchedule.SelectedItem.ToString() == "Monthly")
            {
                currentMonth--;
                static_mounth = currentMonth;
                string MonthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(currentMonth);
                lbMounth.Text = MonthName + " " + year;
            }
            if (cbSchedule.SelectedItem.ToString() == "Weekly")
            {
                week -= 7;
                static_week = week;
                lbMounth.Text = $"Week {GetWeekNumberOfMonth(DateTime.Today.AddDays(week))}";
                PreviousWeek();
            }
            DateTime startOfMounth = new DateTime(year, currentMonth, 1);
            int pastMounthDays = DateTime.DaysInMonth(year, currentMonth - 1);
            int days = DateTime.DaysInMonth(year, currentMonth);
            int daysOfTheWeek = Convert.ToInt32(startOfMounth.DayOfWeek.ToString("d")) - 1;
            int daysDiff = pastMounthDays - daysOfTheWeek + 1;
            if (cbSchedule.SelectedItem.ToString() == "Monthly")
            {
                for (int i = 0; i < daysOfTheWeek; i++)
                {
                    UserControlBlank ucblc = new UserControlBlank(employee, Type);
                    ucblc.days(daysDiff);
                    daysDiff++;
                    dayPannel.Controls.Add(ucblc);
                }
                for (int i = 1; i <= days; i++)
                {
                    UserControlDays controlDays = new UserControlDays(employee, Type);
                    controlDays.days(i);
                    
                    dayPannel.Controls.Add(controlDays);
                }
            }
        }
    }
}