using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group_Project_Website.Logic
{
    public class ScheduleInfo
    {
        scheduleHandler handler = new scheduleHandler();
        public string date { get; set; }
        public string type { get; set; }
        public string weekday { get; set; }
        public int week { get; set; }
        public string year { get; set; }

        public ScheduleInfo(string Date, string Type, string Year)
        {
            this.date = Date;
            this.type = Type;
            this.year = Year;
            this.week = handler.addWeek(this.date);
            switch (handler.addWeekDay(this.date))
            {
                case "Monday":
                    this.weekday = "0";
                    break;
                case "Tuesday":
                    this.weekday = "1";
                    break;
                case "Wednesday":
                    this.weekday = "2";
                    break;
                case "Thursday":
                    this.weekday = "3";
                    break;
                case "Friday":
                    this.weekday = "4";
                    break;
                case "Saturday":
                    this.weekday = "5";
                    break;
                case "Sunday":
                    this.weekday = "6";
                    break;
            }
        }
    }
}
