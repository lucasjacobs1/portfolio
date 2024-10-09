using AspNetCoreHero.ToastNotification.Abstractions;
using LogicLayer;
using LogicLayer.CustomExceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DuelSys_Web.Pages
{
    public class ViewTournamentsModel : PageModel
    {
        [BindProperty]
        public List<Tournament> tournaments { get; set; }
        public List<Sport> sports { get; set; }
        public List<TournamentSystem> tournamentSystems { get; set; }
        public User user { get; set; }

        private TournamentAdmin _TournamentAdmin;
        private UserAdmin _UserAdmin;
        private readonly INotyfService _notyfService;
        private SportAdmin _SportAdmin;

        public ViewTournamentsModel(TournamentAdmin tournamentAdmin,UserAdmin user, SportAdmin sportAdmin, INotyfService notyfService)
        {
            _TournamentAdmin = tournamentAdmin;
            _UserAdmin = user; 
            _notyfService = notyfService;
            _SportAdmin = sportAdmin;
        }
        public IActionResult OnGet()
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    this.user = _UserAdmin.GetUserByEmail(User.Identity.Name);
                }
                this.tournaments = _TournamentAdmin.GetAllTournamentsWithUsers();
                this.sports = _SportAdmin.GetAllSports();
                this.tournamentSystems = _TournamentAdmin.GetAllTournamentSystems();
                foreach (var tournament in tournaments)
                {
                    ViewData[$"{tournament.Id}ID"] = tournament.Users.Count;

                    if (User.Identity.IsAuthenticated)
                    {
                        if (!_TournamentAdmin.CheckRegisteredForTournament(tournament.Id, user.Id))
                        {
                            ViewData[tournament.Id.ToString()] = "true";
                        }
                    }
                }
                return Page();
            }
            catch (DatabaseFailedException ex)
            {
                this._notyfService.Error(ex.Message);
                return RedirectToPage("Error");
            }
            catch(InvalidRegistrationTournamentInput ex)
            {
                this._notyfService.Error(ex.Message);
                return RedirectToPage("Error");
            }
            catch (Exception ex)
            {
                this._notyfService.Error(ex.Message);
                return Page();
            }
        }

        public IActionResult OnPostJoin(string id)
        {
            try
            {
                int tournamentid = Convert.ToInt32(id);
                User u = _UserAdmin.GetUserByEmail(User.Identity.Name);
                if (_TournamentAdmin.RegisterForTournament(u.Id, tournamentid))
                {
                    this._notyfService.Success("Succesfully signed-up!!!");
                    return RedirectToPage("ViewTournaments");
                }
                else
                {
                    return RedirectToPage("ViewTournaments");
                }
            }
            catch(InvalidRegistrationTournamentInput ex)
            {
                this._notyfService.Warning(ex.Message);
                return RedirectToPage("ViewTournaments");
            }
            catch (Exception ex)
            {
                this._notyfService.Error(ex.Message);
                return RedirectToPage("ViewTournaments");

            }
        }

        public IActionResult OnPostView(string id)
        {
            return RedirectToPage("TournamentInformation", new { id });
        }
    }
}
