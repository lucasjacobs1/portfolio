using AspNetCoreHero.ToastNotification.Abstractions;
using LogicLayer;
using LogicLayer.CustomExceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DuelSys_Web.Pages
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public User user { get; set; }

        private readonly INotyfService notyfService;
        private UserAdmin _UserAdmin;

        public RegisterModel(INotyfService notyf, UserAdmin userAdmin)
        {
            this._UserAdmin = userAdmin;
            this.notyfService = notyf;
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
                    _UserAdmin.AddUser(new User(user.FirstName, user.LastName, user.Email, user.Password, 1));
                    this.notyfService.Success($"Succesfully Registered: {user.FirstName}");
                    return RedirectToPage("LoginPage");
                }
                else
                {
                    throw new InvalidUserInputException("You forgot to fill in certain boxes");
                }
            }
            catch (InvalidUserInputException ex)
            {
                this.notyfService.Error(ex.Message);
                return Page();
            }
            catch (DatabaseFailedException ex)
            {
                this.notyfService.Error(ex.Message);
                return Page();
            }
            catch (Exception)
            {
                this.notyfService.Error("This should not happen");
                return Page();
            }
        }
    }
}
