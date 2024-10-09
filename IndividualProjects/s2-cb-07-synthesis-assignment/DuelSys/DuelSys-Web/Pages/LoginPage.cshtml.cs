using AspNetCoreHero.ToastNotification.Abstractions;
using LogicLayer;
using LogicLayer.CustomExceptions;
using LogicLayer.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace DuelSys_Web.Pages
{
    public class LoginPageModel : PageModel
    {
        [BindProperty]
        public Login login { get; set; }

        private readonly INotyfService _notyfService;
        private LoginAdmin _LoginAdmin;
        private UserAdmin _UserAdmin;

        public LoginPageModel(LoginAdmin loginAdmin, INotyfService notyfService, UserAdmin userAdmin)
        {
            _LoginAdmin = loginAdmin;
            _notyfService = notyfService;
            _UserAdmin = userAdmin;
        }
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(_LoginAdmin.ValidateLogin(login))
                    {
                        User user = _UserAdmin.GetUserByEmail(login.Email);
                        List<Claim> claims = new List<Claim>();
                        claims.Add(new Claim(ClaimTypes.Role, user.Role.ToString()));
                        claims.Add(new Claim(ClaimTypes.Name, login.Email));

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));

                        _notyfService.Success("Succesfully logged in");
                        return RedirectToPage("Index");
                    }
                    else { return Page(); }
                }
                else
                {
                    throw new InvalidLoginInputException("You forgot to fill something in");
                }
            }
            catch(InvalidLoginInputException ex)
            {
                _notyfService.Error(ex.Message);
                return Page();
            }
            catch(DatabaseFailedException ex)
            {
                _notyfService.Error(ex.Message);
                return Page();
            }
            catch (Exception)
            {
                return Page();
            }
        }
    }
}
