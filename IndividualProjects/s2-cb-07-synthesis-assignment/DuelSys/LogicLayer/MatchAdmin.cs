using LogicLayer.CustomExceptions;
using LogicLayer.Interfaces;
using LogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class MatchAdmin
    {
        private IMatchService _MatchAdmin;
        private ISportService _SportAdmin;
        private TournamentAdmin TournamentAdmin;
        public MatchAdmin(IMatchService matchAdmin, TournamentAdmin tournament, ISportService sportService)
        {
            _MatchAdmin = matchAdmin;
            _SportAdmin = sportService;
            this.TournamentAdmin = tournament;
        }

        public bool AddMatchResult(TournamentMatch tournamentMatch)
        {
            ISportRules sportRules;
            Tournament tournament = TournamentAdmin.GetTournamentById(tournamentMatch.TournamentId);
            Sport sport = _SportAdmin.GetSportById(tournament.SportId);
            sportRules = sport.ValidateSportRules();
            if (sportRules.ValidateRules(tournamentMatch.Result))
            {
                _MatchAdmin.AddMatchResult(tournamentMatch.Result);
                return true;
            }
            else { return false; }
        }

        public void GenerateMatches(int tournamentId)
        {
            IGenerateMatches generateMatches;
            Tournament tournament = this.TournamentAdmin.GetTournamentWithParticipants(tournamentId);
            List<TournamentMatch> tournamentMatches;
            if (tournament.Users.Count >= tournament.MinimumPlayers)
            {
                generateMatches = tournament.ReturnTournamentType();

                tournamentMatches = generateMatches.GenerateMatches(tournament);

                for (int i = 0; i < tournamentMatches.Count; i++)
                {
                    _MatchAdmin.AddMatchToTournament(tournamentMatches[i]);
                }
            }
            else
            {
                throw new InvalidTournamentInputException("Not enough players have been registered.");
            }
        }

        public List<TournamentMatch> GetUnRegisteredMatchesOfTournament(int tournamentId)
        {
            return _MatchAdmin.GetUnRegisteredMatchesOfTournament(tournamentId);
        }

        public List<TournamentMatch> GetAllMatchesOfATournament(int tournamentId)
        {
            return _MatchAdmin.GetAllMatchesOfATournament(tournamentId);
        }
    }
}