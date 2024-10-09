using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Models
{
    public class TournamentMatch
    {
        private int id;
        private int tournamentId;
        private int playerHomeId;
        private int playerAwayId;
        private MatchResult result;

        #region Properties
        public int Id { get { return id; } }
        public int TournamentId { get { return tournamentId; } set { tournamentId = value; } }
        public int PlayerAwayId { get { return playerAwayId; } set { playerAwayId = value; } }
        public int PlayerHomeId { get { return playerHomeId; } set { PlayerHomeId = value; } }
        public MatchResult Result { get { return result; }}
        #endregion
        public TournamentMatch(int tournamentId, int playerHomeId, int playerAwayId)
        {
            this.tournamentId = tournamentId;
            this.playerHomeId = playerHomeId;
            this.playerAwayId = playerAwayId;
        }

        public TournamentMatch(int id, int tournamentId, int playerHomeId, int playerAwayId)
        {
            this.id = id;
            this.tournamentId = tournamentId;
            this.playerHomeId = playerHomeId;
            this.playerAwayId = playerAwayId;
        }

        public TournamentMatch(int id, int tournamentId, int playerHomeId, int playerAwayId, MatchResult result)
        {
            this.id=id;
            this.tournamentId=tournamentId;
            this.playerHomeId=playerHomeId;
            this.PlayerAwayId=playerAwayId;
            this.result=result;
        }

        public TournamentMatch(int tournamentId, MatchResult matchResult)
        {
            this.tournamentId = tournamentId;
            this.result = matchResult;
        }
    }
}
