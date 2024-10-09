using LogicLayer.CustomExceptions;
using LogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class TournamentAdmin
    {
        private ITournamentService _tournamentAdmin;
        private IMatchService _matchAdmin;
        public TournamentAdmin(ITournamentService tournamentAdmin, IMatchService matchAdmin)
        {
            _tournamentAdmin = tournamentAdmin;
            _matchAdmin = matchAdmin;
        }

        //CRUD operations
        public bool CheckTournamentValidations(Tournament tournament)
        {
            if (tournament.StartDate.Date < DateTime.Now.Date || tournament.EndDate.Date < DateTime.Now.Date || tournament.StartDate.Date > tournament.EndDate.Date)
            {
                throw new InvalidTournamentInputException("The date combination is wrong.");
            }
            else if (tournament.MaximumPlayers < tournament.MinimumPlayers || tournament.MaximumPlayers <= 0 || tournament.MinimumPlayers <= 1)
            {
                throw new InvalidTournamentInputException("You need atleast 2 players, maximum players needs to be bigger/equal then the minimum players.");
            }
            else if (tournament.Description.Length < 10 || tournament.Description.Length > 200)
            {
                throw new InvalidTournamentInputException("The description  needs to be atleast 10 characters, maximum 200 characters.");
            }
            else if (tournament.Location.Length <= 3 || tournament.Location.Length > 50)
            {
                throw new InvalidTournamentInputException("The location needs to be in between 4 and 50 characters.");
            }
            else
            {
                return true;
            }
        }
        public bool AddTournament(Tournament tournament)
        {
            if (CheckTournamentValidations(tournament))
            {
                _tournamentAdmin.AddTournament(tournament);
                return true;
            }
            return false;
        }

        public bool UpdateTournament(Tournament tournament)
        {
            if (CheckTournamentValidations(tournament))
            {
                _tournamentAdmin.UpdateTournament(tournament);
                return true;

            }
            return false;
        }

        public void DeleteTournament(int id)
        {
            _tournamentAdmin.DeleteTournament(id);
        }

        public List<Tournament> SearchTournamentsByLocation(string location)
        {
            List<Tournament> tournaments = new List<Tournament>();
            foreach (Tournament tournament in _tournamentAdmin.GetAllTournaments())
            {
                if (tournament.Location.Contains(location))
                {
                    tournaments.Add(tournament);
                }
            }
            return tournaments;
        }

        public Tournament GetTournamentById(int id)
        {
            return _tournamentAdmin.GetTournamentById(id);
        }


        //Registration logic
        public bool RegisterForTournament(int userId, int TournamentId)
        {
            Tournament tournement = GetTournamentWithParticipants(TournamentId);
            if ((tournement.StartDate - DateTime.Now).TotalDays >= 7)
            {
                if (tournement.Users.Count < tournement.MaximumPlayers)
                {
                    _tournamentAdmin.RegisterForTournament(TournamentId, userId); return true;
                }
                else
                {
                    throw new InvalidRegistrationTournamentInput("The tournament is already full.");
                }
            }
            else
            {
                throw new InvalidRegistrationTournamentInput("You can not sign up. minimum is 7 days before the startdate.");
            }
        }

        public bool CheckRegisteredForTournament(int TournamentId, int userId)
        {
            List<User> usersInTournament = _tournamentAdmin.GetAllUsersOfTournament(TournamentId);
            foreach (var user in usersInTournament)
            {
                if (user.Id == userId)
                {
                    return true;
                }
            }
            return false;
        }

        public List<Tournament> GetAllTournaments()
        {
            return _tournamentAdmin.GetAllTournaments();
        }

        public List<Tournament> GetTournamentsThatAreOpen()
        {
            return _tournamentAdmin.GetTournamentsThatAreOpen();
        }

        public List<Tournament> GetTournamentsThatAreClosed()
        {
            return _tournamentAdmin.GetTournamentsThatAreClosed();
        }

        public List<TournamentSystem> GetAllTournamentSystems()
        {
            return _tournamentAdmin.GetAllTournamentSytstems();
        }

        public List<User> GetAllUsersOfTournament(int id)
        {
            return _tournamentAdmin.GetAllUsersOfTournament(id);
        }

        public Tournament GetTournamentWithParticipants(int id)
        {
            List<User> users = _tournamentAdmin.GetAllUsersOfTournament(id);
            Tournament t = _tournamentAdmin.GetTournamentById(id);
            return new Tournament(t.Id, t.Description, t.StartDate, t.EndDate, t.Location, t.MinimumPlayers, t.MaximumPlayers, t.SportId, t.TournamentTypeId, users);
        }

        public Tournament GetTournamentWithParticipantsAndMatches(int id)
        {
            Tournament t = _tournamentAdmin.GetTournamentById(id);
            List<User> users = _tournamentAdmin.GetAllUsersOfTournament(id);
            List<TournamentMatch> RegisteredtournamentMatches = _matchAdmin.GetRegisteredMatchesOfTournament(t.Id);
            List<TournamentMatch> unRegisteredMatches = _matchAdmin.GetUnRegisteredMatchesOfTournament(t.Id);
            RegisteredtournamentMatches.AddRange(unRegisteredMatches);
            return new Tournament(t.Id, t.Description, t.StartDate, t.EndDate, t.Location, t.MinimumPlayers, t.MaximumPlayers, t.SportId, t.TournamentTypeId, users, RegisteredtournamentMatches);
        }

        public List<Tournament> GetAllTournamentsWithUsers()
        {
            List<Tournament> tournaments = _tournamentAdmin.GetAllTournaments();
            List<Tournament> GetTournamentsWithUsers = new List<Tournament>();
            foreach (Tournament t in tournaments)
            {
                List<User> Getusers = _tournamentAdmin.GetAllUsersOfTournament(t.Id);
                GetTournamentsWithUsers.Add(new Tournament(t.Id, t.Description, t.StartDate, t.EndDate, t.Location, t.MinimumPlayers, t.MaximumPlayers, t.SportId, t.TournamentTypeId, Getusers));
            }
            return GetTournamentsWithUsers;
        }

        public List<Leaderboard> MakeLeaderboard(int tournamentId)
        {
            Tournament tournament = GetTournamentWithParticipantsAndMatches(tournamentId);

            //This is to hold track of the wins saved by Id
            Dictionary<int, int> winCounter = new Dictionary<int, int>();

            //adding every user to the dictionary
            foreach (var user in tournament.Users)
            {
                winCounter.Add(user.Id, 0);
            }

            //gets tournament with all the registerd matches
            var tourenmentWithRegisteredMatches = tournament.TournamentMatches.Where(x => x.Result != null).ToList();
            
            //setting up who won how many times.
            for (int i = 0; i < tourenmentWithRegisteredMatches.Count; i++)
            {
                if (tournament.TournamentMatches[i].Result.PlayerHomeScore > tournament.TournamentMatches[i].Result.PlayerAwayScore)
                {
                    winCounter[tournament.TournamentMatches[i].PlayerHomeId]++;
                }
                else
                {
                    winCounter[tournament.TournamentMatches[i].PlayerAwayId]++;
                }
            }

            //converting the dictionary to a list
            var list = winCounter.ToList();

            //sorting the list with most wins up top
            list.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));

            //making the leaderboard list with objects of the leaderboard with the user and wincounter
            List<Leaderboard> leaderboard = new List<Leaderboard>();
            foreach (var user in list)
            {
                //returns a single specified conditions based on comparision
                var participant = tournament.Users.Single(x => x.Id == user.Key);
                leaderboard.Add(new Leaderboard(participant, user.Value));
            }
            return leaderboard;
        }
    }
}
