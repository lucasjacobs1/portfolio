using LogicLayer.Interfaces;
using LogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class GenerateMatchesDoubleRoundRobin: IGenerateMatches
    {
        public List<TournamentMatch> GenerateMatches(Tournament tournament)
        {
            List<TournamentMatch> matches = new List<TournamentMatch>();
            for (int i = 0; i < tournament.Users.Count; i++)
            {
                for (int j = i + 1; j < tournament.Users.Count; j++)
                {
                    matches.Add(new TournamentMatch(tournament.Id, tournament.Users[i].Id, tournament.Users[j].Id));
                    matches.Add(new TournamentMatch(tournament.Id, tournament.Users[j].Id, tournament.Users[i].Id));
                }
            }
            return matches;
        }
    }
}
