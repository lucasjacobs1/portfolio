using AspNetCoreHero.ToastNotification.Abstractions;
using LogicLayer;
using LogicLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DuelSys_Web.Pages
{
    public class TournamentInformationModel : PageModel
    {
        [BindProperty]
        public Tournament tournament { get; set; }
        public List<Sport> sports { get; set; }
        public List<TournamentSystem> tournamentSystems { get; set; }
        public List<TournamentMatch> tournamentUnRegisteredMatches { get; set; } = new();
        public List<TournamentMatch> tournamentRegisteredMatches { get; set; } = new();
        public List<Leaderboard> Leaderboard { get; set; }

        private TournamentAdmin _TournamentAdmin;
        private readonly INotyfService _notyfService;
        private SportAdmin _SportAdmin;

        public TournamentInformationModel(TournamentAdmin tournamentAdmin,SportAdmin sportAdmin, INotyfService notyfService)
        {
            _TournamentAdmin = tournamentAdmin;
            _notyfService = notyfService;
            _SportAdmin = sportAdmin;
        }

        public void OnGet(string id)
        {
            try
            {
                int tournamentId = Convert.ToInt32(id);
                this.tournament = _TournamentAdmin.GetTournamentWithParticipantsAndMatches(tournamentId);
                this.sports = _SportAdmin.GetAllSports();
                this.tournamentSystems = _TournamentAdmin.GetAllTournamentSystems();
                ViewData[tournament.Id.ToString()] = tournament.Users.Count;
                this.Leaderboard = _TournamentAdmin.MakeLeaderboard(tournamentId);
                ViewData["Na"] = "N/A";
                foreach(var match in this.tournament.TournamentMatches)
                {
                    if(match.Result == null)
                    {
                        this.tournamentUnRegisteredMatches.Add(match);

                        var userhome = tournament.Users.Single(x => x.Id == match.PlayerHomeId);
                        ViewData[$"{match.PlayerHomeId}player"] = $"{userhome.FirstName} {userhome.LastName}";

                        var userAway = tournament.Users.Single(x => x.Id == match.PlayerAwayId);
                        ViewData[$"{match.PlayerAwayId}player"] = $"{userAway.FirstName} {userAway.LastName}";
                    }
                }

                foreach(var match in this.tournament.TournamentMatches)
                {
                    if(match.Result != null)
                    {
                        this.tournamentRegisteredMatches.Add(match);

                        var userhome = tournament.Users.Single(x => x.Id == match.PlayerHomeId);
                        ViewData[$"{match.PlayerHomeId}player"] = $"{userhome.FirstName} {userhome.LastName}";

                        var userAway = tournament.Users.Single(x => x.Id == match.PlayerAwayId);
                        ViewData[$"{match.PlayerAwayId}player"] = $"{userAway.FirstName} {userAway.LastName}";
                       
                        ViewData[$"{match.Result.PlayerHomeScore}score"] = match.Result.PlayerHomeScore.ToString();
                        ViewData[$"{match.Result.PlayerAwayScore}score"] = match.Result.PlayerAwayScore.ToString();

                    }
                }
                
                //the place of the leaderboard
                int n = 1;
                foreach(var user in Leaderboard)
                {
                    ViewData[user.User.Id.ToString()] =  n++.ToString();
                    ViewData[user.User.FirstName] = user.User.FirstName;
                    ViewData[user.User.LastName] = user.User.LastName;
                    ViewData[user.Wincounter.ToString()] = user.Wincounter.ToString();
                }
            }
            catch (Exception ex)
            {
                _notyfService.Error(ex.Message);
            }
        }
    }
}
