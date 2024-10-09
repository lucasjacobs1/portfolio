using LogicLayer.Interfaces;
using LogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class Tournament
    {
        private int id;
        private string description;
        private DateTime startDate;
        private DateTime endDate;
        private string location;
        private int minimumPlayers;
        private int maximumPlayers;
        private int sportId;
        private int tournamentTypeId;
        private List<User> users;
        private List<TournamentMatch> tournamentMatches;
        #region Properties
        public int Id { get { return id; }}
        public string Description { get { return description; } set { description = value; } }
        public DateTime StartDate { get { return startDate; } set { startDate = value; } }
        public DateTime EndDate { get { return endDate; } set { endDate = value; } }
        public string Location { get { return location; } set { location = value; } }
        public int MinimumPlayers { get { return minimumPlayers; } set { minimumPlayers = value; } }
        public int MaximumPlayers { get { return maximumPlayers; } set { maximumPlayers = value; } }
        public int SportId { get { return sportId; } set { this.sportId = value; } }
        public int TournamentTypeId { get { return tournamentTypeId; } set { tournamentTypeId = value; } }
        public List<User> Users { get { return users; } }
        public List<TournamentMatch> TournamentMatches { get { return tournamentMatches; } }
        #endregion

        public Tournament(int id, string description, DateTime startDate, DateTime endDate, string location, int minimumPlayers, int maximumPlayer, int sportId, int tournamentTypeId)
        {
            this.id = id;
            this.description = description;
            this.startDate = startDate;
            this.endDate = endDate;
            this.location = location;
            this.minimumPlayers = minimumPlayers;
            this.maximumPlayers = maximumPlayer;
            this.sportId = sportId;
            this.tournamentTypeId = tournamentTypeId;
        }
        public Tournament(string description, DateTime startDate, DateTime endDate, string location, int minimumPlayers, int maximumPlayer, int sportId, int tournamentTypeId)
        {
            this.description = description;
            this.startDate = startDate;
            this.endDate = endDate;
            this.location = location;
            this.minimumPlayers = minimumPlayers;
            this.maximumPlayers = maximumPlayer;
            this.sportId = sportId;
            this.tournamentTypeId = tournamentTypeId;
        }

        public Tournament(int id, string description, DateTime startDate, DateTime endDate, string location, int minimumPlayers, int maximumPlayer, int sportId, int tournamentTypeId, List<User> users)
        {
            this.id = id;
            this.description = description;
            this.startDate = startDate;
            this.endDate = endDate;
            this.location = location;
            this.minimumPlayers = minimumPlayers;
            this.maximumPlayers = maximumPlayer;
            this.sportId = sportId;
            this.tournamentTypeId = tournamentTypeId;
            this.users = users;
        }

        public Tournament(int id, string description, DateTime startDate, DateTime endDate, string location, int minimumPlayers, int maximumPlayer, int sportId, int tournamentTypeId, List<User> users, List<TournamentMatch> tournamentMatches)
        {
            this.id = id;
            this.description = description;
            this.startDate = startDate;
            this.endDate = endDate;
            this.location = location;
            this.minimumPlayers = minimumPlayers;
            this.maximumPlayers = maximumPlayer;
            this.sportId = sportId;
            this.tournamentTypeId = tournamentTypeId;
            this.users = users;
            this.tournamentMatches = tournamentMatches;
        }

        public IGenerateMatches ReturnTournamentType()
        {
            return FactoryTournamentSystem.ReturnTournamentType(this.tournamentTypeId);
        }
    }
}
