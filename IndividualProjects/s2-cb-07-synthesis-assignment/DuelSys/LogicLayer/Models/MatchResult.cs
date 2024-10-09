using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Models
{
    public class MatchResult
    {
        private int matchId;
        private int playerHomeScore;
        private int playerAwayScore;

        #region Properties
        public int MatchId { get { return matchId; } set { this.matchId = value; } }
        public int PlayerHomeScore { get { return playerHomeScore; } set { playerHomeScore = value; } }
        public int PlayerAwayScore { get { return playerAwayScore; } set { PlayerAwayScore = value; } }
        #endregion

        public MatchResult(){}
        public MatchResult(int matchId, int playerHomeScore, int playerAwayScore)
        {
            this.matchId = matchId;
            this.playerHomeScore = playerHomeScore;
            this.playerAwayScore = playerAwayScore;
        }
    }
}
