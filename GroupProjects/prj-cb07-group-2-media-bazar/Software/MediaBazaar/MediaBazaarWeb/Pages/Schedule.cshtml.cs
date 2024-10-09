using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using MediaBazaar.Data_Layer;
using System.Security.Claims;
using Group_Project_Website.Logic;
using System.Globalization;

namespace Group_Project_Website.Pages
{
    [Authorize]
    public class ScheduleModel : PageModel
    {
        [BindProperty]
        public scheduleHandler Handler { get; set; }
        public static string name { get; set; }
        public UserHelper Userhelper = new UserHelper();
        public EmployeeManagement EmployeeManagement = new EmployeeManagement();    
        public void OnGet()
        {
            Employee employee;
            this.Handler = new scheduleHandler();
            employee = EmployeeManagement.GetEmployeeByEmail(User.Identity.Name);
            name = employee.FirstName;
            Handler.AddAllShifts(employee.FirstName);
            CultureInfo ciCurr = CultureInfo.CurrentCulture;
            int weekNum = ciCurr.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            scheduleHandler.selectedweek = Convert.ToInt32(weekNum);
            scheduleHandler.selectedmonth = Convert.ToInt32(DateTime.Now.Month);
            scheduleHandler.selectedyear = Convert.ToInt32(DateTime.Now.Year);
        }

        public IActionResult OnPostNext()
        {
            Handler.nextWeek();
            return Page();
        }
        public IActionResult OnPostPrevious()
        {
           
            this.Handler.PreviousWeek();
            return Page();
        }

    }
}
