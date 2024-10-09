using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;
using MediaBazaar.Data_Layer;

namespace Group_Project_Website.Logic
{
    public class scheduleHandler
    {
        ScheduleManager Manager = new ScheduleManager();
        List<ScheduleInfo> allShifts = new List<ScheduleInfo>();
        public static int selectedyear { get; set; }
        public static int selectedmonth { get; set; }
        public static int selectedweek { get; set; }
        public static int static_mounth, static_year, static_week;
        public static int currentMonth = DateTime.Now.Month;
        public static int adder = 7;

        public scheduleHandler()
        {
           
        }

        public string addWeekDay(string date)
        {
            string example = date;
            int firstSlash = example.IndexOf("/");
            int year = Convert.ToInt32(example.Substring(example.Length - 4, 4));
            int day = Convert.ToInt32(example.Substring(0, firstSlash));
            int month = Convert.ToInt32(example.Substring(firstSlash + 1, example.LastIndexOf("/") - firstSlash - 1));
            DateTime dateValue = new DateTime(year, month, day);
            return dateValue.DayOfWeek.ToString();
        }
        public int addWeek(string date)
        {
            string example = date;
            int firstSlash = example.IndexOf("/");
            int year = Convert.ToInt32(example.Substring(example.Length - 4, 4));
            int day = Convert.ToInt32(example.Substring(0, firstSlash));
            int month = Convert.ToInt32(example.Substring(firstSlash + 1, example.LastIndexOf("/") - firstSlash - 1));
            DateTime dateValue = new DateTime(year, month, day);
            CultureInfo ciCurr = CultureInfo.CurrentCulture;
            int weekNum = ciCurr.Calendar.GetWeekOfYear(dateValue, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            return weekNum;
        }

        public void AddAllShifts(string name)
        {
           allShifts = Manager.GetAllShiftsByName(name);
        }

        public List<ScheduleInfo> getAllShifts(string name)
        {
            AddAllShifts(name);
            return this.allShifts;
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

        public void nextWeek()
        { 

            if (selectedweek < 52)
            {
                selectedweek = selectedweek + 1;   
            }
            else
            {
                selectedweek = 1;
                selectedyear++;
            }
        
        }
        public void PreviousWeek()
        {
            if (selectedweek > 1)
            {
                selectedweek = selectedweek - 1;
            }
            else
            {
                selectedweek = 52;
                selectedyear--;
            }
        }

        /*public void PreviousWeek()
        {
            DateTime now = DateTime.Now;
            currentMonth = now.Month;
            int NextMonady = GetMonday(DateTime.Today.AddDays(week), adder -= 7);
            year = now.Year;
            static_mounth = currentMonth;
            static_year = year;
            DateTime startOfMounth = new DateTime(year, currentMonth, 1);
            int days = DateTime.DaysInMonth(year, currentMonth);
            int pastMounthDays = DateTime.DaysInMonth(year, currentMonth - 1);
            int nextMouthDays = DateTime.DaysInMonth(year, currentMonth + 1);
            int daysOfTheWeek = Convert.ToInt32(startOfMounth.DayOfWeek.ToString("d")) - 1;
            int nextMonthDiff = nextMouthDays - days;
            int endOfWeek = NextMonady + 6;
            int daysDiff = endOfWeek - days;
        }

        public void NextWeek()
        {
            DateTime now = DateTime.Now;
            currentMonth = now.Month;

            year = now.Year;
            int NextMonady = GetMonday(DateTime.Today.AddDays(week), adder += 7);
            static_mounth = currentMonth;
            static_year = year;
            DateTime startOfMounth = new DateTime(year, currentMonth, 1);
            int days = DateTime.DaysInMonth(year, currentMonth);
            int pastMounthDays = DateTime.DaysInMonth(year, currentMonth - 1);
            int nextMouthDays = DateTime.DaysInMonth(year, currentMonth + 1);
            int daysOfTheWeek = Convert.ToInt32(startOfMounth.DayOfWeek.ToString("d")) - 1;
            int nextMonthDiff = nextMouthDays - days;
            int endOfWeek = NextMonady + 6;
            int daysDiff = endOfWeek - days;
            if (cbSchedule.SelectedItem.ToString() == "Weekly")
            {
                for (int i = NextMonady; i <= endOfWeek; i++)
                {
                    UserControlDays_Big controlDays = new UserControlDays_Big(employee, Type);
                    //  controlDays.Size = new Size(100, 500);
                    controlDays.days(i);
                    if (i == Convert.ToInt32(DateTime.Today.Day) && DateTime.Now.Month == currentMonth)
                    {
                        controlDays.BackColor = Color.LightYellow;
                    }
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
        }*/
    }
}
