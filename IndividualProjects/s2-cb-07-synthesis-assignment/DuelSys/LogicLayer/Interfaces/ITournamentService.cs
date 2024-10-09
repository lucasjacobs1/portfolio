using LogicLayer.Models;

namespace LogicLayer
{
    public interface ITournamentService
    {
        void AddTournament(Tournament tournament);
        List<TournamentSystem> GetAllTournamentSytstems();
        void UpdateTournament(Tournament tournament);
        void DeleteTournament(int id);
        List<Tournament> GetAllTournaments();
        Tournament GetTournamentById(int id);
        void RegisterForTournament(int tournamentId, int userId);
        List<Tournament> GetTournamentsThatAreOpen();
        List<Tournament> GetTournamentsThatAreClosed();
        List<User> GetAllUsersOfTournament(int id);

    }
}