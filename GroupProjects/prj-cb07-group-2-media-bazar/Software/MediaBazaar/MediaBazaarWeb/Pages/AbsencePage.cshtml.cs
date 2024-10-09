using AspNetCoreHero.ToastNotification.Abstractions;
using Group_Project_Website;
using MediaBazaarWeb.DataLayer;
using MediaBazaarWeb.LogicLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MediaBazaarWeb.Pages
{
    [Authorize]
    public class AbsencePageModel : PageModel
    {
        [BindProperty]
        public Absence absence{ get; set; }
        [BindProperty]
        public Employee employee { get; set; }
        private readonly INotyfService Notyf;

        [BindProperty]
        public Vacation vacation { get; set; }

        public AbsencePageModel(INotyfService notyfService)
        {
            this.Notyf = notyfService;
        }
        public void OnGet()
        {
            EmployeeManagement employeeManagement = new EmployeeManagement();
            this.employee = employeeManagement.GetEmployeeByEmail(User.Identity.Name);
            ViewData["Name"] = $"{employee.FirstName} {employee.LastName}";
            ViewData["Id"] = employeeManagement.GetEmployeeByEmail(User.Identity.Name).ID;
            
        }

        public IActionResult OnPostAbsence()
        {
            AbsenceManagement absenceManagement = new AbsenceManagement();
            EmployeeManagement employeeManagement = new EmployeeManagement();
            VacationLogic vacationLogic = new VacationLogic();
            int id = employeeManagement.GetEmployeeByEmail(User.Identity.Name).ID;
            if(absenceManagement.CheckAbsenceExist(id, absence))
            {
                this.Notyf.Information($"You already said you can not come to work on this date, {absence.Date.ToString("yyyy/MM/dd")} .");
                return RedirectToAction("AbsencePage");
            }
            else
            {
                if (vacationLogic.CheckValAddAbsence(absence))
                {
                    if (absenceManagement.AddAbsence(id, absence))
                    {
                        this.Notyf.Success("succesfully send");
                        return RedirectToAction("AbsencePage");
                    }
                    else
                    {
                        this.Notyf.Error("nothing added");
                        return RedirectToAction("AbsencePage");

                    }
                }
                else
                {
                    this.Notyf.Error($"This date: {absence.Date.ToString("yyyy/MM/dd")} already went by");
                    return RedirectToAction("AbsencePage");
                }

            }




        }

        public IActionResult OnPostVacation()
        {
            AbsenceManagement absenceManagement = new AbsenceManagement();
            EmployeeManagement employeeManagement = new EmployeeManagement();
            VacationLogic vacationLogic = new VacationLogic();
            if (vacationLogic.CheckValAddVacation(vacation))
            {
                int id = employeeManagement.GetEmployeeByEmail(User.Identity.Name).ID;
                if (absenceManagement.AddVacation(id, vacation))
                {
                    this.Notyf.Success($"Succesfully send the request for {vacation.StartDate.ToString("yyyy-MM-dd")} until {vacation.EndDate.ToString("yyyy-MM-dd")}");

                }
                else
                {
                    this.Notyf.Error("Failed to add this request");
                }
            }
            else
            {
                this.Notyf.Error("Your input is wrong");
            }
            return RedirectToAction("AbsencePage");

        }
    }
}
