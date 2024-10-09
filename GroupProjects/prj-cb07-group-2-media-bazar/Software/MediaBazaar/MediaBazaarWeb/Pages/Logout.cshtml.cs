using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MediaBazaarWeb.Pages
{
    public class LogoutModel : PageModel
    {

        private readonly INotyfService Notyf;

        public LogoutModel(INotyfService notyfService)
        {
            Notyf = notyfService;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);
            this.Notyf.Success("succesfully logged out");
            return RedirectToPage("index");
        }
    }
}
