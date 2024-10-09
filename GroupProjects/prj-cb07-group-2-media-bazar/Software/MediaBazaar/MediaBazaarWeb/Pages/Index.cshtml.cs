using AspNetCoreHero.ToastNotification.Abstractions;
using Group_Project_Website;
using Group_Project_Website.Logic;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace MediaBazaarWeb.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public LogInHandler logins { get; set; }
        private readonly INotyfService Notyf;
        public Employee employee { get; set; }

        public IndexModel(INotyfService toastNotificationService)
        {
            this.Notyf = toastNotificationService;
        }

        public void OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                EmployeeManagement employeeManagement = new EmployeeManagement();
                this.employee = employeeManagement.GetEmployeeByEmail(User.Identity.Name);
                ViewData["name"] = $"{employee.FirstName} {employee.LastName}";
            }
            

        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {

                UserHelper userHelper = new UserHelper();
                if (userHelper.IsValidEmail(logins.email))
                {
                    if (userHelper.ValidateLogin(logins.email, logins.password))
                    {
                        EmployeeManagement employeeManagement = new EmployeeManagement();
                        Employee loggedEmployee = employeeManagement.GetEmployeeByEmail(logins.email);

                        List<Claim> claims = new List<Claim>();
                        claims.Add(new Claim(ClaimTypes.Email, logins.email));
                        claims.Add(new Claim(ClaimTypes.Name, logins.email));
                        claims.Add(new Claim(ClaimTypes.Role, loggedEmployee.ID.ToString()));
                        claims.Add(new Claim("id", "1"));

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));
                        this.Notyf.Success($"Succesfully logged in");
                        return RedirectToPage("Schedule");
                    }
                    else
                    {
                        Notyf.Error("Password Incorrect");
                        return new RedirectToPageResult("index");
                    }
                }
                else
                {
                    Notyf.Error("Your email is incorrect");
                    return new RedirectToPageResult("index");
                }
            }
            else
            {
                Notyf.Error("something went wrong");
                return new RedirectToPageResult("index");
            }
        }
    }
}