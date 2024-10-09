using LogicLayer;
using LogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    internal class TestData
    {
        public List<Tournament> GetSampleTournaments()
        {
            List<Tournament> tournaments = new List<Tournament>()
            {
                new Tournament(1, "Test test test", DateTime.Now, DateTime.Now.AddDays(2), "Eindhoven", 10, 20, 0, 0),
                new Tournament(2, "prac prac prac", DateTime.Now, DateTime.Now.AddDays(2), "Eindhoven", 5, 10, 0, 0),
                new Tournament(3, "Test test test", DateTime.Now, DateTime.Now.AddDays(2), "Eindhoven", 3, 10, 0, 0),

            };
            return tournaments;
        }

        public Tournament GetTournament()
        {
            Tournament tournament = new Tournament(1, "Test test test", DateTime.Now, DateTime.Now.AddDays(2), "Eindhoven", 10, 20, 0, 0);
            return tournament;
        }

        public List<User> GetSampleUsers()
        {
            List<User> users = new List<User>()
            {
                new User(0,"Jan", "Vogel", "jan@gmail.com", "test", 0),
                new User(1,"Piet", "Kol", "piet@gmail.com", "test", 0),
                new User(2,"Tom", "Kor", "tom@gmail.com", "test", 0)
            };
            return users;
        }

        public List<TournamentMatch> GetTournamentMatches()
        {
            List<TournamentMatch> tournamentMatches = new List<TournamentMatch>()
            {
                new TournamentMatch(1, 0, 1),
                new TournamentMatch(1, 2, 0),
                new TournamentMatch(1, 1, 2)
            };
            return tournamentMatches;
        }

        public List<MatchResult> GetMatchResults()
        {
            List<MatchResult> results = new List<MatchResult>()
            {
                new MatchResult(1, 21, 2),
                new MatchResult(2, 29, 30),
                new MatchResult(3, 23, 25)
            };
            return results;
        }

        public Tournament GetTournamentWithUsers()
        {
            Tournament t = new Tournament(3, "Test test test", DateTime.Now, DateTime.Now.AddDays(2), "Eindhoven", 3, 10, 0, 0, GetSampleUsers());
            return t;
        }

        public Tournament GetTournamentForRegisterPersonWorks()
        {
            return new Tournament(3, "Test test test", DateTime.Now.AddDays(8), DateTime.Now.AddDays(9), "Eindhoven", 3, 10, 0, 0);

        }

        public Tournament GetTournamentForRegisterPersonNotWorksDate()
        {
            return new Tournament(3, "Test test test", DateTime.Now.AddDays(1), DateTime.Now.AddDays(2), "Eindhoven", 2, 2, 0, 0);
        }

        public Tournament GetTournamentForRegisterPersonNotWorksMaximumPlayers()
        {
            return new Tournament(3, "Test test test", DateTime.Now.AddDays(8), DateTime.Now.AddDays(10), "Eindhoven", 2, 2, 0, 0);
        }

        public List<User> GetUsersForLeaderboard()
        {
            List<User> users = new List<User>()
            {
                new User(0,"Jan", "Vogel", "jan@gmail.com", "test", 0),
                new User(1,"Piet", "Kol", "piet@gmail.com", "test", 0),
                new User(2,"Tom", "Kor", "tom@gmail.com", "test", 0)
            };
            return users;
        }

        public List<TournamentMatch> GetTournamentMatchesForLeaderboard()
        {
            List<TournamentMatch> tournamentMatches = new List<TournamentMatch>()
            {
                new TournamentMatch(0, 0, 0, 1, new MatchResult(0, 21, 1)),
                new TournamentMatch(1,0, 0, 2, new MatchResult(1, 21, 2)),
            };
            return tournamentMatches;
        }

        public List<TournamentMatch> GetTournamentMatchesUnregistered()
        {
            List<TournamentMatch> tournamentMatches = new List<TournamentMatch>()
            {
                new TournamentMatch(2 ,0, 1, 2),
            };
            return tournamentMatches;
        }

        public Tournament GetTournamentForLeaderboard()
        {
            Tournament t = new Tournament(0, "Test test test", DateTime.Now, DateTime.Now.AddDays(2), "Eindhoven", 3, 10, 0, 0);
            return t;
        }

        public List<Leaderboard> ExpectedLeaderboardResult()
        {
            Tournament tournament = GetTournamentForLeaderboard();
            List<User> users = GetUsersForLeaderboard();
            List<Leaderboard> result = new List<Leaderboard>()
            {
                new Leaderboard(users[0], 2),
                new Leaderboard(users[1], 0),
                new Leaderboard(users[2], 0),
            };
            return result;
        }

        public User GetUserToAddWrongFirstName()
        {
            return new User("J", "Doe", "joe.doe@gmail.com", "test", 0);
        }


    }
}
