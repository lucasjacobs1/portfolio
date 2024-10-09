using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DuelSys_Web.Pages
{
    [Authorize]
    public class LogoutModel : PageModel
    {
        private readonly INotyfService _toastNotification;

        public LogoutModel(INotyfService notyfService)
        {
            _toastNotification = notyfService;
        }
        public async Task<IActionResult> OnPostAsync()
        {
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);
            _toastNotification.Success("Succesfully logged out");
            return RedirectToPage("Index");
        }
    }
}
