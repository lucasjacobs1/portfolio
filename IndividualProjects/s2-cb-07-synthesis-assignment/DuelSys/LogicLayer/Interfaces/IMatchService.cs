using LogicLayer.Models;

namespace LogicLayer
{
    public interface IMatchService
    {
        void AddMatchToTournament(TournamentMatch tournamentMatch);
        List<TournamentMatch> GetAllMatchesOfATournament(int tournamentId);
        void AddMatchResult(MatchResult matchResult);
        List<TournamentMatch> GetUnRegisteredMatchesOfTournament(int tournamentId);
        List<TournamentMatch> GetRegisteredMatchesOfTournament(int tournamentId);
    }
}